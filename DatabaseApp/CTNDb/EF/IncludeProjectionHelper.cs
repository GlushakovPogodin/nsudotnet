using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CTNDb
{
    /// <summary>
    /// Вспомогательный класс, чтобы не проставлять Include-ы вручную
    /// </summary>
    public static class IncludeProjectionHelper
    {
        private const string AllProjectionsKey = "__ALL";

        private static readonly MethodInfo IncludeMethodInfo = typeof (QueryableExtensions)
            .GetMethod("Include", new[]
            {
                typeof ( IQueryable <>), typeof (string)
            });

        private static readonly Dictionary<Type, Dictionary<string, Delegate>> _cachedProjections =
            new Dictionary<Type, Dictionary<string, Delegate>>();

        /// <summary>
        /// Инициализирует помогалку с проекциями. Этот метод необходимо вызвать один раз за все время жизни приложений
        /// Строит кэш вызовов цепочек .Include-ов, чтобы не тратить на это время в рантайме
        /// </summary>
        /// <param name="a">Сборка, в которой лежат сущности с атрибутами IncludeProjection</param>
        public static void Init(Assembly a)
        {
            IEnumerable<Type> types = a.GetTypes().Where(c => c.GetCustomAttribute<IncludeProjectionAttribute>() != null);
            foreach (Type type in types)
            {
                Type queryable = typeof (IQueryable<>).MakeGenericType(type);

                PropertyInfo[] members =
                    type
                        .GetProperties()
                        .Where(c => c.GetCustomAttributes<IncludeProjectionAttribute>().Any())
                        .ToArray();

                var projections = new Dictionary<string, List<PropertyInfo>>();
                var allProjection = new List<PropertyInfo>();
                projections[AllProjectionsKey] = allProjection;

                foreach (PropertyInfo memberInfo in members)
                {
                    IEnumerable<IncludeProjectionAttribute> attrs =
                        memberInfo.GetCustomAttributes<IncludeProjectionAttribute>();
                    foreach (IncludeProjectionAttribute includeProjectionAttribute in attrs)
                    {
                        string key = includeProjectionAttribute.ProjectionName;
                        List<PropertyInfo> mil = null;
                        if (!string.IsNullOrWhiteSpace(key))
                        {
                            if (projections.ContainsKey(key)) mil = projections[key];
                            else
                            {
                                mil = new List<PropertyInfo>();
                                projections[key] = mil;
                            }
                        }
                        if (mil != null) mil.Add(memberInfo);
                        allProjection.Add(memberInfo);
                    }
                }
                Dictionary<string, Delegate> projectionsRepo = null;
                if (_cachedProjections.ContainsKey(type)) projectionsRepo = _cachedProjections[type];
                else
                {
                    projectionsRepo = new Dictionary<string, Delegate>();
                    _cachedProjections[type] = projectionsRepo;
                }
                foreach (string k in projections.Keys)
                {
                    List<PropertyInfo> projectionMembers = projections[k];
                    ParameterExpression pexp = Expression.Parameter(queryable);
                    Expression source = pexp;
                    foreach (PropertyInfo projectionMember in projectionMembers)
                    {
                        ParameterExpression o = Expression.Parameter(type);
                        Expression prop = Expression.Constant(projectionMember.Name);
                        source = Expression.Call(null, IncludeMethodInfo, source, prop);
                    }
                    LambdaExpression l = Expression.Lambda(source, pexp);
                    Delegate compiled = l.Compile();
                    projectionsRepo.Add(k, compiled);
                }
            }
        }

        /// <summary>
        /// Добавляет указание вытягивать вместе с основной сущностью все агрегаты
        /// Все - это те, над которыми стоит IncludeProjectionAttribute
        /// </summary>
        /// <typeparam name="TEntity">Сущность БД</typeparam>
        /// <param name="entity">Множество сущностей</param>
        /// <returns>Queryable с примененными .Include</returns>
        public static IQueryable<TEntity> IncludeAll<TEntity>(this IQueryable<TEntity> entity)
        {
            return IncludeProjection(entity, AllProjectionsKey);
        }

        /// <summary>
        /// Добавляет указание вытягивать вместе с основной сущностью все агрегаты
        /// Все - это те, над которыми стоит IncludeProjectionAttribute
        /// </summary>
        /// <typeparam name="TEntity">Сущность БД</typeparam>
        /// <param name="entity">Множество сущностей</param>
        /// <param name="projectionName">Название проекции</param>
        /// <returns>Queryable с примененными .Include</returns>
        public static IQueryable<TEntity> IncludeProjection<TEntity>(this IQueryable<TEntity> entity,
                                                                     string projectionName)
        {
            if (!_cachedProjections.ContainsKey(typeof (TEntity)))
            {
                return entity;
            }
            Dictionary<string, Delegate> cached = _cachedProjections[typeof (TEntity)];
            Delegate del = cached[projectionName];
            object q = del.DynamicInvoke(entity);
            return (IQueryable<TEntity>) q;
        }
    }
}
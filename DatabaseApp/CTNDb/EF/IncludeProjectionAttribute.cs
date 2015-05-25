using System;

namespace CTNDb
{
    /// <summary>
    /// Атрибут, проставляемый над свойствами, которые надо вытягивать вместе с сущностью
    /// Используйте IncludeProjectionHelper.IncludeAll, чтобы задействовать все поля, над которыми проставлен этот атрибут
    /// Передавайте в конструктор строку, а потом используйте IncludeProjectionHelper.IncludeProjection c этой строкой, чтобы 
    /// вытянуть с сущностью только те поля, которые помечены данным атрибутом с этой строкой
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class IncludeProjectionAttribute : Attribute
    {
        public IncludeProjectionAttribute()
        {
        }

        /// <summary>
        /// Создает атрибут включения
        /// </summary>
        /// <param name="projectionName">Название проекции</param>
        public IncludeProjectionAttribute(string projectionName)
        {
            ProjectionName = projectionName;
        }

        /// <summary>
        /// Название проекции
        /// </summary>
        public string ProjectionName { get; private set; }
    }
}
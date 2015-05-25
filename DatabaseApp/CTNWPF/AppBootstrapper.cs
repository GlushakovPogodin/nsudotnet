﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Caliburn.Micro;
using Caliburn.Micro.Autofac;
using CTNDAL;

using CTNDb;
using CTNDb.Properties;
using CTNWPF.ViewModels;


namespace CTNWPF
{
    class AppBootstrapper : AutofacBootstrapper<MainViewModel>
    {
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            IncludeProjectionHelper.Init(typeof(CTNContext).Assembly);

            builder.Register(a => new CTNContext(
                Resources.ConnectionString)).As<CTNContext>().SingleInstance();
            builder.RegisterType<AddressService>().As<IService<Address>>().SingleInstance();
            builder.RegisterType<ATSTypeService>().As<IService<ATSType>>().SingleInstance();
            builder.RegisterType<ATSService>().As<IService<ATS>>().SingleInstance();           
            builder.RegisterType<BalanceChangeTypeService>().As<IService<BalanceChangeType>>().SingleInstance();
            builder.RegisterType<BalanceService>().As<IService<Balance>>().SingleInstance();
            builder.RegisterType<CTNService>().As<IService<CTN>>().SingleInstance();
            builder.RegisterType<IntercityConversationService>().As<IService<IntercityConversation>>().SingleInstance();
            builder.RegisterType<IntercityStatusService>().As<IService<IntercityStatus>>().SingleInstance();
            builder.RegisterType<PhoneService>().As<IService<Phone>>().SingleInstance();
            builder.RegisterType<PhoneTypeService>().As<IService<PhoneType>>().SingleInstance();
            builder.RegisterType<QueueService>().As<IService<Queue>>().SingleInstance();
            builder.RegisterType<QueueTypeService>().As<IService<QueueType>>().SingleInstance();
            builder.RegisterType<SubscriberService>().As<IService<Subscriber>>().SingleInstance();
            builder.RegisterType<SubscriberTypeService>().As<IService<SubscriberType>>().SingleInstance();


        }
    }
}

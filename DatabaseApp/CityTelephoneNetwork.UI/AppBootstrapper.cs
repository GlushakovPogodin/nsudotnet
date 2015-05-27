using System.Configuration;
using Autofac;
using Caliburn.Micro.Autofac;
using CityTelephoneNetwork.Logic;

using CityTelephoneNetwork.Data;
using CityTelephoneNetwork.UI.ViewModels;


namespace CityTelephoneNetwork.UI
{
    class AppBootstrapper : AutofacBootstrapper<MainViewModel>
    {
        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            IncludeProjectionHelper.Init(typeof(CTNContext).Assembly);

            builder.Register(a => new CTNContext(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)).As<CTNContext>().SingleInstance();
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

using Cirrious.CrossCore.IoC;

namespace WTM.Mobile.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .Containing("Context")
                .AsInterfaces()
                .RegisterAsSingleton();

            RegisterAppStart<ViewModels.MenuViewModel>();
        }
    }
}
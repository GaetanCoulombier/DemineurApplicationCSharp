using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace DemineurApplicationCSharp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            ((NavigationPage)MainPage).BarBackgroundColor = Color.Beige;
            ((NavigationPage)MainPage).BarTextColor = Color.DarkSlateGray;
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
            if (Current.Properties.ContainsKey("MainPageID"))
            {
                var id = Current.Properties["MainPageID"];
                Debug.WriteLine("OnStart - " + id);
            }
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
            if (Current.Properties.ContainsKey("MainPageID"))
            {
                var id = Current.Properties["MainPageID"];
                Debug.WriteLine("OnResume - " + id);
            }
        }
    }
}
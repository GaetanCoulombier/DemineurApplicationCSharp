using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemineurApplicationCSharp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemineurApplicationCSharp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Charger_Partie_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoadPage());
        }
        
        private async void Nouvelle_Partie_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPage());
        }
    }
}

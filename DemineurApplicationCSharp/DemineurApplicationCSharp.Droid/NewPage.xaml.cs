using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemineurApplicationCSharp.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPage : ContentPage
    {
        public NewPage()
        {
            InitializeComponent();
        }
        
        private async void New_Hard_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DemineurPage(10,10));
        }

        private async void New_Medium_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DemineurPage(8,7));
        }

        private async void New_Easy_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DemineurPage(6,5));
        }
    }
}
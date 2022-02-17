using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using DemineurApplicationCSharp.Droid.model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Button = Xamarin.Forms.Button;

namespace DemineurApplicationCSharp.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemineurPage : ContentPage
    {
        private Game game;

        public DemineurPage()
        {
            InitializeComponent();
        }

        public DemineurPage(int size, int nbBomb)
        {
            InitializeComponent();
            game = new Game(size, nbBomb);
            game.fill();
            refreshGrid();
        }

        public void refreshGrid()
        {
            clearGrid();
            setGrid();
        }


        private void clearGrid()
        {
            var gridChildren = Grid.Children;
            gridChildren.Clear();
        }

        private void setGrid()
        {
            for (int y = 0; y < game.SIZE; y++)
            {
                for (int x = 0; x < game.SIZE; x++)
                {
                    var case_ = game.getCase(x, y);
                    case_.getNumber();

                    var button = new Button();
                    button.Text = case_.ToString();

                    Grid.Children.Add(button);

                    button.Clicked += ButtonOnClick;
                    Grid.SetRow(button, x);
                    Grid.SetColumn(button, y);
                }
            }
        }

        private async void ButtonOnClick(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            var x = getXButton(button);
            var y = getYButton(button);

            Debug.WriteLine("X - " + x);
            Debug.WriteLine("Y - " + y);

            if (!game.revealCase(x, y))
            {
                await DisplayAlert ("Alert", "Vous avez perdu une bombe a explosée", "OK");
                await Navigation.PopAsync();
                await Navigation.PopAsync();
            }

            game.checkVictory(); // verifier aussi ça pas oublier
            refreshGrid();
        }

        private int getXButton(Button button)
        {
            return Grid.GetRow(button);
        }

        private int getYButton(Button button)
        {
            return Grid.GetColumn(button);
        }
    }
}
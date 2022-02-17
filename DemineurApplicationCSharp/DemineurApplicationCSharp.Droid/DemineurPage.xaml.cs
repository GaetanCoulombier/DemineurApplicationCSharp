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
using Action = DemineurApplicationCSharp.Droid.model.Action;
using Button = Xamarin.Forms.Button;

namespace DemineurApplicationCSharp.Droid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DemineurPage : ContentPage
    {
        private Game game;
        private Action action;
        private bool end = false;

        public DemineurPage(int size, int nbBomb)
        {
            InitializeComponent();
            action = Action.BREAKER;
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
                    var button = new Button
                    {
                        Text = case_.ToString(),
                        TextColor = Color.DimGray,
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold,
                    };

                    switch (case_.getStatus())
                    {
                        case Status.OPEN: // empty case
                            button.BackgroundColor = Color.Ivory;
                            break;
                        case Status.FLAG: // Flagged case
                        case Status.BLANK: // others
                            button.TextColor = Color.White;
                            button.BackgroundColor = Color.Brown;
                            break;
                    }

                    Grid.Children.Add(button);

                    button.Clicked += CaseOnClick;
                    Grid.SetRow(button, x);
                    Grid.SetColumn(button, y);
                }
            }
        }

        private async void CaseOnClick(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            var x = getXButton(button);
            var y = getYButton(button);

            Debug.WriteLine("X - " + x);
            Debug.WriteLine("Y - " + y);

            if (!end)
            {
                switch (action)
                {
                    case Action.BREAKER:
                        if (!game.revealCase(x, y))
                        {
                            game.revealAll();
                            await DisplayAlert("Défaite", "Vous avez perdu une bombe a explosée !", "OK");
                            end = true;
                        }
                        else
                        {
                            if (game.checkVictory())
                            {
                                await DisplayAlert("Victoire", "Vous avez gagné !", "OK");
                                end = true;
                            }
                        }

                        break;
                    case Action.FLAGGER:
                        game.putFlag(x, y);
                        break;
                }

                refreshGrid();
            }
        }

        private int getXButton(Button button)
        {
            return Grid.GetRow(button);
        }

        private int getYButton(Button button)
        {
            return Grid.GetColumn(button);
        }

        private void RevealCase_OnClicked(object sender, EventArgs e)
        {
            action = Action.FLAGGER;
            Btn_Flag.BackgroundColor = Color.RoyalBlue;
            Btn_Break.BackgroundColor = Color.OliveDrab;
        }

        private void Flag_OnClicked(object sender, EventArgs e)
        {
            action = Action.BREAKER;
            Btn_Break.BackgroundColor = Color.RoyalBlue;
            Btn_Flag.BackgroundColor = Color.OliveDrab;
        }
    }
}
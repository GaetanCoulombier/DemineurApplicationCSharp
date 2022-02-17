using System;

namespace DemineurApplicationCSharp.Droid.model
{
    public class Filler
    {
        private Game game;

        public Filler(Game game)
        {
            this.game = game;
        }

        public void fillBlank()
        {
            int i;
            int j;
            for (i = 0; i < game.SIZE; i++)
            {
                for (j = 0; j < game.SIZE; j++)
                {
                    game.setCase(i, j, new Case(0));
                }
            }
        }

        public void fillRandom()
        {
            int counter = game.NB_BOMB;
            var rand = new Random();

            while (counter > 0)
            {
                var randomX = rand.Next(0, game.SIZE);
                var randomY = rand.Next(0, game.SIZE);
                if (game.isValidePutBombe(randomX, randomY))
                {
                    game.setCase(randomX, randomY, new Case(-1));
                    counter--;
                }
            }
        }

        public void fillNumbers()
        {
            int i;
            int j;
            for (i = 0; i < game.SIZE; i++)
            {
                for (j = 0; j < game.SIZE; j++)
                {
                    var case_ = game.getCase(i, j);
                    if (case_.getNumber() == 0)
                    {
                        var numberBombeAround = getNumberBombeAround(i, j);
                        if (numberBombeAround != 0)
                        {
                            game.setCase(i, j, new Case(numberBombeAround));
                        }
                    }
                }
            }
        }

        private int getNumberBombeAround(int x, int y)
        {
            var number = 0;
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var case_ = game.getCase(x + i, y + j);
                    if (case_.getNumber() != -2 && case_.getNumber() == -1)
                        number++;
                }
            }

            return number;
        }
    }
}
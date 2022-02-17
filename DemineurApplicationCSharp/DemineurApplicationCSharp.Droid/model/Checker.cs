namespace DemineurApplicationCSharp.Droid.model
{
    public class Checker
    {
        private Game game;

        public Checker(Game game)
        {
            this.game = game;
        }

        public bool isValidePutBombe(int x, int y)
        {
            Case case_ = game.getCase(x, y);
            return case_.getNumber() == 0;
        }

        public bool checkVictory()
        {
            for (var y = 0; y < game.SIZE; y++)
            {
                for (var x = 0; x < game.SIZE; x++)
                {
                    var case_ = game.getCase(x, y);
                    if (case_.getStatus() == Status.BLANK && case_.getNumber() > 0)
                        return false;
                }
            }

            return true;
        }
    }
}
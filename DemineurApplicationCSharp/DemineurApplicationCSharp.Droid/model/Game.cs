
namespace DemineurApplicationCSharp.Droid.model
{
    public class Game
    {
        public int SIZE;
        public int NB_BOMB;
        private Checker checker;
        private Filler filler;
        private Case[,] plateau;
        private Case empty = new Case(-2);

        public Game()
        {
            checker = new Checker(this);
            filler = new Filler(this);
            SIZE = 10;
            NB_BOMB = 10;
            plateau = new Case[SIZE, SIZE];
        }

        public Game(int size)
        {
            checker = new Checker(this);
            filler = new Filler(this);
            SIZE = size;
            NB_BOMB = size;
            plateau = new Case[SIZE, SIZE];
        }

        public Game(int size, int nbBomb)
        {
            checker = new Checker(this);
            filler = new Filler(this);
            SIZE = size;
            NB_BOMB = nbBomb;
            plateau = new Case[SIZE, SIZE];
        }
        
        public bool isValidePutBombe(int x, int y)
        {
            return checker.isValidePutBombe(x, y);
        }

        public bool checkVictory()
        {
            return checker.checkVictory();
        }

        public bool revealCase(int x, int y)
        {
            var case_ = getCase(x, y);
            if (case_.reveal())
            {
                if (case_.getNumber() == 0)
                {
                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            case_ = getCase(x + i, y + j);
                            if (case_.getNumber() >= 0 && case_.getStatus() == Status.BLANK)
                                revealCase(x + i, y + j);
                        }
                    }
                }

                return true;
            }

            return false;
        }

        public void putFlag(int x, int y)
        {
            var case_ = getCase(x, y);
            case_.flag();
        }


        public void setCase(int x, int y, Case value)
        {
            plateau[x, y] = value;
        }
        
        public void revealAll()
        {
            for (var y = 0; y < SIZE; y++)
            {
                for (var x = 0; x < SIZE; x++)
                {
                    plateau[x, y].setStatus(Status.OPEN);
                }

            }
        }

        public Case getCase(int x, int y)
        {
            if (x >= 0 && x < SIZE && y >= 0 && y < SIZE)
                return plateau[x, y];
            return empty;
        }


        public void fill()
        {
            filler.fillBlank();
            filler.fillRandom();
            filler.fillNumbers();
        }

        public override string ToString()
        {
            var result = "";
            for (var y = 0; y < SIZE; y++)
            {
                for (var x = 0; x < SIZE; x++)
                {
                    result += plateau[x, y] + "  ";
                }

                result += "\n";
            }

            return result;
        }
    }
}
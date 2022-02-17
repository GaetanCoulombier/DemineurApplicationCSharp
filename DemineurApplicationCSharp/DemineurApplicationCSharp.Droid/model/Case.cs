namespace DemineurApplicationCSharp.Droid.model
{
    public class Case
    {
        private Status status = Status.BLANK;
        private int number;

        public Case(int number)
        {
            this.number = number;
        }

        public Case(int number, Status status)
        {
            this.number = number;
            this.status = status;
        }

        public int getNumber()
        {
            return number;
        }

        public Status getStatus()
        {
            return status;
        }
        
        public void setStatus(Status status)
        {
            this.status = status;
        }

        // false if the bomb has exploded
        public bool reveal()
        {
            if (status != Status.FLAG)
            {
                status = Status.OPEN;
                if (getNumber() == -1)
                    return false;
            }

            return true;
        }

        public void flag()
        {
            switch (status)
            {
                case Status.BLANK:
                    status = Status.FLAG;
                    break;
                case Status.FLAG:
                    status = Status.BLANK;
                    break;
            }
        }

        public override string ToString()
        {
            switch (status)
            {
                case Status.OPEN:
                    switch (number)
                    {
                        case -1:
                            return "*"; // bomb
                        case 0:
                            return " "; // empty case
                        default:
                            return number.ToString(); // other number
                    }
                case Status.FLAG:
                    return "P";
                case Status.BLANK:
                default:
                    return " ";
            }
        }
    }
}
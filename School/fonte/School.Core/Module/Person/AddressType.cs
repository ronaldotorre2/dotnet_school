namespace School.Core.Module.Person
{
    public class AddressType
    {
        public enum Type
        {
            commercial  = 0,
            delivery    = 1,
            residential = 2,
            others      = 3
        }

        public string GetLabel(int id)
        {
            string pross = null;

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                switch (id)
                {
                    case 0:
                        pross = "Commercial";
                        break;
                    case 1:
                        pross = "Delivery";
                        break;
                    case 2:
                        pross = "Residential";
                        break;
                    case 3:
                        pross = "Others";
                        break;
                }

                return pross;
            }
            else
            {
                return null;
            }
        }

        public string GetInitial(int id)
        {
            string pross = null;

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                switch (id)
                {
                    case 0:
                        pross = "C";
                        break;
                    case 1:
                        pross = "D";
                        break;
                    case 2:
                        pross = "R";
                        break;
                    case 3:
                        pross = "O";
                        break;
                    
                }

                return pross;
            }
            else
            {
                return null;
            }
        }
    }
}
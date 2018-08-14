namespace School.Core.Module.Person
{
    public class ContactType
    {
        public enum Type
        {
            celphone = 0,
            phone = 1,
            mail = 2,
            message = 3,
            others = 4
        }

        public string GetLabel(int id)
        {
            string pross = null;

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                switch (id)
                {
                    case 0:
                        pross = "Celphone";
                        break;
                    case 1:
                        pross = "Phone";
                        break;
                    case 2:
                        pross = "Mail";
                        break;
                    case 3:
                        pross = "Message";
                        break;
                    case 4:
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
                        pross = "P";
                        break;
                    case 2:
                        pross = "M";
                        break;
                    case 3:
                        pross = "S";
                        break;
                    case 4:
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
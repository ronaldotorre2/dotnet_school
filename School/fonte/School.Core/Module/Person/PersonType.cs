namespace School.Core.Module.Person
{
    public class PersonType
    {
        public enum Type
        {
            physical  = 0,
            juridical = 1
        }

        public enum Gender
        {
            female = 0,
            male   = 1
        }

        public enum StateCivil
        {
            married  = 0,
		    single   = 1,
		    flirt    = 2,
		    separate = 3,
		    divorced = 4,
		    Widower  = 5
        }

        public string GetLabel(string define, int id)
        {
            string pross = null;

            if ((define != "") &&(id.ToString() != ""))
            {
                if (define == "Type")
                {
                    if (id == 0)
                    {
                        pross = "Physical";
                    }
                    else if (id == 1)
                    {
                        pross = "Juridical";
                    }
                    else
                    {
                        pross = null;
                    }
                }
                else if (define == "Gender")
                {
                    if (id == 0)
                    {
                        pross = "Female";
                    }
                    else if (id == 1)
                    {
                        pross = "Male";
                    }
                    else
                    {
                        pross = null;
                    }
                }
                else if (define == "StateCivil")
                {
                    switch (id)
                    {
                        case 0:
                            pross = "Married";
                            break;
                        case 1:
                            pross = "Single";
                            break;
                        case 2:
                            pross = "Flirt";
                            break;
                        case 3:
                            pross = "Separate";
                            break;
                        case 4:
                            pross = "Divorced";
                            break;
                        case 5:
                            pross = "Widower";
                            break;

                    }
                }

                return pross;
            }
            else
            {
                return null;
            }
        }

        public string GetInitial(string define, int id)
        {
            string pross = null;

            if ((define != "") && (id.ToString() != ""))
            {
                if(define == "Type")
                {
                    if (id == 0)
                    {
                        pross = "F";
                    }
                    else if (id == 1)
                    {
                        pross = "J";
                    }
                    else
                    {
                        pross = null;
                    }
                }
                else if (define == "Gender")
                {
                    if (id == 0)
                    {
                        pross = "F";
                    }
                    else if (id == 1)
                    {
                        pross = "M";
                    }
                    else
                    {
                        pross = null;
                    }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pillit.lib.Constants
{
    public class Enums
    {
        public enum UserType { 
            Carer = 1,
            CareGiver = 2,
            Administrator = 3
        }

        public enum ResponseStatus
        {
            Success,
            Failure
        }
    }
}

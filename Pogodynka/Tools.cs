using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pogodynka
{
    class Tools
    {
        public bool areListsEqual(List<Object> List1, List<Object> List2)
        {
            if (isSubset(List1, List2) && isSubset(List2, List1))
            {
                return true;
            }
            return false;
        }

        public bool isSubset(List<Object> ListToBeUpperset, List<Object> ListToBeSubset)
        {
            foreach (Object SublistElement in ListToBeSubset)
            {
                if ((ListToBeUpperset.Find(x => x == SublistElement)) == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

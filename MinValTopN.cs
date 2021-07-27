using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nolan_McAfee_Unit04_IT481
{

    class MinValTopN
    {
        public MinValTopN()
        {
            
        }

        public int GetMinValTopN(int[] arrayOfInts, int n)
        {
            try
            {
                int currmin = arrayOfInts[n-1];
                if (n > 1)
                {
                    for (int i = n - 2; i >= 0; i--)
                    {
                        currmin = arrayOfInts[i] < currmin ? arrayOfInts[i] : currmin;
                    }
                }
                return currmin;
            }
            catch (IndexOutOfRangeException e)
            {
                return -1;
            }
            
        }
    }
}
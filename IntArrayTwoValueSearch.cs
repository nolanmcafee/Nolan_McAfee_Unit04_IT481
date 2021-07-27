using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nolan_McAfee_Unit04_IT481
{
    class IntArrayTwoValueSearch
    {
        public void SearchValues(int[] arrayOfInts, int a, int b)
        {
            int i = 0;
            bool found1 = false, found2 = false;
            while ((i < arrayOfInts.Length) && ((found1 == false) || (found2 == false)))
            {
                found1 = (arrayOfInts[i] == a) ? true : found1;
                found2 = (arrayOfInts[i] == b) ? true : found2;

                i++;
            }

            int res = Convert.ToInt32(found1) + 2 * Convert.ToInt32(found2);

            switch (res)
            {
                case 0:
                    Console.WriteLine("None of the search values were found.");
                    break;
                case 1:
                    Console.WriteLine("The value of a was found in int array.");
                    break;
                case 2:
                    Console.WriteLine("The value of b was found in int array.");
                    break;
                case 3:
                    Console.WriteLine("The values of both a and b were found in int array.");
                    break;
            }
        }
    }
}

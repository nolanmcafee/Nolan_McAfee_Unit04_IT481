using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Nolan_McAfee_Unit04_IT481
{
    class Program
    {
        public static void Main()
        {
            Console.SetWindowSize(100, 60);

            for (int i = 0; i < 60; i++) { Console.WriteLine(""); }
            RunUnitTesting1();
            Console.WriteLine("\n\nPress Any Key to Continue");
            Console.ReadLine();
            for (int i = 0; i < 60; i++) { Console.WriteLine(""); }

            RunUnitTesting2();
            Console.WriteLine("\n\nPress Any Key to Continue");
            Console.ReadLine();
            for (int i = 0; i < 60; i++) { Console.WriteLine(""); }

            RunUnitTesting3();
            Console.WriteLine("\n\nPress Any Key to Exit");
            Console.ReadLine();
        }


        private static void RunUnitTesting1()
        {
            //-------------------------------------------------------------------
            //-----------------------Test 1--------------------------------------
            //-------------------------------------------------------------------

            MinValTopN minValObj = new MinValTopN();                                //Instantiate Class Under Testing

            int n = 10;                                                             //Number of iterations
            int[] intArray = new int[] { 25, 17, 9, 2, 87, 12, 54, 41, 18, 99 };    //Test Array
            int eo1 = 2;                                                            //Expected output: Unit should output "2" as the minimum value

            int r1 = minValObj.GetMinValTopN(intArray, n);                          //Invoke Unit Under Testing

            string p1 = r1 == eo1 ? "Passed" : "Failed";                            //Form pass/fail message


            //-------------------------------------------------------------------
            //-----------------------Test 2--------------------------------------
            //-------------------------------------------------------------------

            n = 12;                                                                 //Number of iterations: Out of Bounds
            int[] intArray2 = new int[] { 25, 17, 9, 2, 87, 12, 54, 41, 18, 1 };    //Test Array
            int eo2 = -1;                                                           //Expected output: Unit should output "-1" if array out of bounds

            int r2 = minValObj.GetMinValTopN(intArray2, n);                         //Invoke Unit Under Testing

            string p2 = r2 == eo2 ? "Passed" : "Failed";                            //Form pass/fail message


            //Output section
            Console.WriteLine("");
            Console.WriteLine(" **** Module Testing: MinValTopN ****");
            Console.WriteLine(" *                                  *");
            Console.WriteLine(" * Test 1: Test Full Array          *");
            Console.WriteLine(" * -----------------------          *");
            Console.WriteLine(" *   Output Expected: {0}             *", eo1);
            Console.WriteLine(" *   Output   Actual: {0}             *", r1);
            Console.WriteLine(" *   ---------------------          *");
            Console.WriteLine(" *   Result: Test {0}            *", p1);
            Console.WriteLine(" *                                  *");
            Console.WriteLine(" ************************************");
            Console.WriteLine(" *                                  *");
            Console.WriteLine(" * Test 2: Test Index Out of Bounds *");
            Console.WriteLine(" * -----------------------          *");
            Console.WriteLine(" *   Output Expected: {0}            *", eo2);
            Console.WriteLine(" *   Output   Actual: {0}            *", r2);
            Console.WriteLine(" *   ---------------------          *");
            Console.WriteLine(" *   Result: Test {0}            *", p1);
            Console.WriteLine(" *                                  *");
            Console.WriteLine(" ************************************");
            



            
        }

        private static void RunUnitTesting2()
        {
            //-------------------------------------------------------------------
            //-----------------------Test 1--------------------------------------
            //-------------------------------------------------------------------


            //Redirect Console Output to StreamWriter

            StringBuilder builder1 = RedirectConsoleOutputToStreamWriter();

            
            //Instantiate and Run Class Under Testing

            int[] intArray3 = new int[] { 25, 17, 9, 2, 87, 12, 54, 41, 18, 99 };    //Test Array
            PrintIntArray pa1 = new PrintIntArray();                                  //Instantiation
            pa1.PrintArray(intArray3);                                                //Invoking the method




            //Reset the Console Output to StandardOutput

            ResetConsoleOutputToStandardOutput();


            //Retrieve the results from the StreamWriter object

            string[] results1 = SplitString(builder1);


            //Compare the original integer array to the results array
            
            bool[] comparison1 = new bool[results1.Length];
            bool pass1 = true;

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("|       Module Testing: PrintIntArray      |");
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|           Test 1: Typical Array          |");
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|  Line |  Orig   |  Result  |  Pass/Fail  |");
            Console.WriteLine("|------------------------------------------|");
            
            for (int i = 0; i < intArray3.Length; i++)
            {
                //int j = string[i]
                (comparison1[i], pass1) = intArray3[i] == Convert.ToInt32(results1[i]) ? (true, pass1) : (false, false);
                Console.WriteLine("|  {0:D2}:    {1:D6}     {2:D6}        {3}    |", i + 1, intArray3[i], Convert.ToInt32(results1[i]), comparison1[i]);
            }

            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|       Test 1 Overall Result: {0}        |", pass1 == true ? "Pass" : "Fail");
            Console.WriteLine("|------------------------------------------|");

            //-------------------------------------------------------------------
            //-----------------------Test 2--------------------------------------
            //-------------------------------------------------------------------

            //Redirect Console Output to StreamWriter

            StringBuilder builder2 = RedirectConsoleOutputToStreamWriter();

            //Instantiate and Run Class Under Testing

            //Create new random string array for second test - target -999999 to 999999
            int[] intArray4 = CreateRandomIntArray(10, -999999, 999999);              //Test Array Created

            PrintIntArray pa2 = new PrintIntArray();                                  //Instantiation of Class
            pa2.PrintArray(intArray4);


            //Reset the Console Output to StandardOutput

            ResetConsoleOutputToStandardOutput();


            //Retrieve the results from the StreamWriter object

            string[] results2 = SplitString(builder2);


            //Compare the original integer array to the results array

            bool[] comparison2 = new bool[results2.Length];
            bool pass2 = true;


            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|       Test 2: Array With Negatives       |");
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|  Line |  Orig   |  Result  |  Pass/Fail  |");
            Console.WriteLine("|------------------------------------------|");

            for (int i = 0; i < intArray4.Length; i++)
            {
                //int j = string[i]
                (comparison2[i], pass2) = intArray4[i] == Convert.ToInt32(results2[i]) ? (true, pass2) : (false, false);
                Console.WriteLine("|  {0:D2}:   {1}{2:D6}    {3}{4:D6}        {5}    |", i + 1, 
                    (intArray4[i] < 0) ? "" : " ", intArray4[i], 
                    (Convert.ToInt32(results2[i]) < 0) ? "" : " ", Convert.ToInt32(results2[i]), comparison2[i]);
            }


            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("|       Test 2 Overall Result: {0}        |", pass1 == true ? "Pass" : "Fail");
            Console.WriteLine("|------------------------------------------|");
        }

        public static void RunUnitTesting3() 
        {
            //Instantiate Test Unit
            IntArrayTwoValueSearch searchObject1 = new IntArrayTwoValueSearch();
            
            //-------------------------------------------------------------------
            //-----------------------Test 1--------------------------------------
            //-------------------------------------------------------------------
            //Test for accuracy - this test will run 4 times to check each outcome

            //Create Test Array
            int[] testArray1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Define Search Values
            int[,] searchArr1 = { { -1, 10 }, { 0, 10 }, { -1, 5 }, { 0, 5 } };

            //Redirect Console Output to StreamWriter for Test 1a
            StringBuilder builder1 = RedirectConsoleOutputToStreamWriter();

            
            //Perform Searches 1a through 1d
            searchObject1.SearchValues(testArray1, searchArr1[0,0], searchArr1[0,1]);
            searchObject1.SearchValues(testArray1, searchArr1[1,0], searchArr1[1,1]);
            searchObject1.SearchValues(testArray1, searchArr1[2,0], searchArr1[2,1]);
            searchObject1.SearchValues(testArray1, searchArr1[3,0], searchArr1[3,1]);
            

            //Split the Result Strings
            string[] resultStrings = SplitString(builder1);

            //Reset the Console Output to StandardOutput
            ResetConsoleOutputToStandardOutput();

            //Build Expected Output
            string[] expected =
            {
                "None of the search values were found.",
                "The value of a was found in int array.",
                "The value of b was found in int array.",
                "The values of both a and b were found in int array."
            };

            //Evaluate accuracy
            bool[] compare = new bool[4]; 
            bool pass = true;

            for (int k = 0; k < 4; k++)
            {
                (compare[k], pass) = (resultStrings[k] == expected[k]) ? (true, pass) : (false, false);
            }

            //Output 
            Console.WriteLine(" ---------------------------------------------------------------------------");
            Console.WriteLine(" |               Module Testing: IntArrayTwoValueSearch                    |");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |               Test 1: Output Accuracy, Typical Input                    |");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |                  The arrayOfIntegers values were:                       |");
            foreach (int j in testArray1) 
            { 
                Console.Write("{0}{1}{2}{3}", 
                    ((j == 0) ? " |                    { " : "" ),
                    j, 
                    (((j >= 0) && (j < testArray1.Length - 1)) ? ", " : "" ), 
                    ((j == testArray1.Length-1) ? " }                     |\n" : "")
                    ); 
            }
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            char[] unit = { 'a', 'b', 'c', 'd' };
            int i = 0;
            foreach (char c in unit)
            {
                Console.WriteLine(" | Test 1{0}, search values: a={1,3}, b={2,3}                                    |", c, searchArr1[i,0], searchArr1[i,1] );
                Console.WriteLine(" |    Output Expected: {0,51} |", expected[i]);
                Console.WriteLine(" |      Output Actual: {0,51} |", resultStrings[i]);
                Console.WriteLine(" |                                                                         |");
                Console.WriteLine(" |                                         Test 1{0}, result of test: {1}   |", c, (compare[i] == true ? "Pass" : "Fail"));
                Console.WriteLine(" |-------------------------------------------------------------------------|");
                i++;
            }
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |                      Test 1 Overall Result: {0}                      |", (pass == true) ? "Passed" : "Failed");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |-------------------------------------------------------------------------|");






            //-------------------------------------------------------------------
            //-----------------------Test 2--------------------------------------
            //-------------------------------------------------------------------
            //Test for diminishing performance with increasing size of search list

            //Instantiate Test Unit
            IntArrayTwoValueSearch searchObject2 = new IntArrayTwoValueSearch();

            //Redirect Console Output to StreamWriter for Test 2
            StringBuilder builder2 = RedirectConsoleOutputToStreamWriter();

            //Records to generate
            int records1 = 10000000, records2 = 100000000;

            //Create Test Arrays
            int[] testArray2a = CreateRandomIntArray(records1, -2147483648, 2147483647);
            int[] testArray2b = CreateRandomIntArray(records2, -2147483648, 2147483647);

            //Define Search Values
            int[] searchArr2 = CreateRandomIntArray(2, -2147483648, 2147483647);    // a=searchArr2[0], b=searchArr2[1]

            //Instantiate Stopwatch
            Stopwatch stopwatch = new Stopwatch();
            
            //Start Stopwatch for First Test
            stopwatch.Start();

            //Perform First Search
            searchObject2.SearchValues(testArray2a, searchArr2[0], searchArr2[1]);

            //Measure Elapsed Time
            stopwatch.Stop();
            long t1 = stopwatch.ElapsedTicks;

            //Start Stopwatch for Second Test
            stopwatch.Reset();
            stopwatch.Start();

            //Perform Second Search
            searchObject2.SearchValues(testArray2b, searchArr2[0], searchArr2[1]);

            //Measure Elapsed Time
            stopwatch.Stop();
            long t2 = stopwatch.ElapsedTicks;

            //Reset the Console Output to StandardOutput
            ResetConsoleOutputToStandardOutput();

            //Analysis
            double recordsPerTick1 = (double)records1 / (double)t1;
            double recordsPerTick2 = (double)records2 / (double)t2;
            double relativeSpeed = recordsPerTick1 / recordsPerTick2;

            //Output
            Console.WriteLine(" |                                                                         |");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |                  Test 2: Performance With Large Arrays                  |");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |  Searching {0:D9} array items took {1:D7} ticks,                    |",records1,t1);
            Console.WriteLine(" |       at a rate of {0,5:F} items per tick                                 |", recordsPerTick1);
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |                    -- whereas --                                        |");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |  Searching {0:D9} array items took {1:D7} ticks,                    |", records2, t2);
            Console.WriteLine(" |       at a rate of {0,5:F} items per tick                                 |", recordsPerTick2);
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" |                                              Performance penalty: {0:P1}  |", relativeSpeed - 1);
            Console.WriteLine(" |-------------------------------------------------------------------------|");
            Console.WriteLine(" ---------------------------------------------------------------------------");
        }

        private static StringBuilder RedirectConsoleOutputToStreamWriter()
        {
            StringBuilder builder = new StringBuilder();
            TextWriter writer = new StringWriter(builder);
            Console.SetOut(writer);

            return builder;
        }

        private static void ResetConsoleOutputToStandardOutput()
        {
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
            standardOutput.AutoFlush = true;
            Console.SetOut(standardOutput);
        }

        private static int[] CreateRandomIntArray(int count, int min, int max)
        {
            int[] intArray = new int[count];
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                intArray[i] = Convert.ToInt32(rand.Next(min, max));
            }

            return intArray;
        }

        private static string[] SplitString(StringBuilder builder)
        {
            return builder.ToString().Split(Environment.NewLine);
        }

    }
}

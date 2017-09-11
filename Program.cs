

using System;
using System.IO;

namespace ProfitCalculator
{
    /// ==============================================================================

    public class RangeFinder
    {
        /// <summary>
        /// Performs calculations to find the start and end of the "best" data sequence
        /// which has the greatest sum of data values over that sequence.
        /// </summary>
        /// <param name="data">the data to be examined</param>
        /// <param name="bestStart">the start point found by the search</param>
        /// <param name="bestEnd">the end point found by the search</param>
        /// <param name="bestTotal">the sum of data values over that range</param>
        /// <param name="loops">the number of executions of the inner loop</param>
        public static void MaxSum1(double[] data, out int bestStart, out int bestEnd, out double bestTotal, out int loops)
        {
            bestTotal = 0;
            bestStart = 0;
            bestEnd = 0;
            loops = 0;
            /// TODO - put your process code here      
            for (int x = 0; x < data.Length; x++) //For every possible start position // every array index in turn
            {
                for (int y = x; y < data.Length; y++) //For every possible end position // rest of array from current start
                {
                    double subtotal = 0; //Set subtotal to 0
                    for (int z = x; z < y; z++) //For every value in subseq // between current start and end
                    {
                        subtotal += data[z + 1]; // Add profit value to subtotal
                        loops++;
                    }
                    if (bestTotal < subtotal) // Update subseq info when subtotal exceeds current best total
                    {
                        bestTotal = subtotal;
                        bestStart = x + 1;
                        bestEnd = y;
                    }
                }
            }
        }
        public static void MaxSum2(double[] data, out int bestStart, out int bestEnd, out double bestTotal, out int loops)
        {
            bestTotal = 0;
            bestStart = 0;
            bestEnd = 0;
            loops = 0;
            /// TODO - put your process code here
            for (int x = 0; x < data.Length; x++) //For every possible start position...
            {
                double subTotal = 0; //Set subtotal to 0
                for (int y = x; y < data.Length; y++) //For every possible end position...
                {
                    subTotal += data[y]; //Add end position’s profit value to subtotal
                    if (subTotal > bestTotal) //Update subseq if subtotal exceeds current best total
                    {
                        bestTotal = subTotal;
                        bestStart = x;
                        bestEnd = y;

                    }
                    loops++;
                }
            }
        }
        public static void MaxSum3(double[] data, out int bestStart, out int bestEnd, out double bestTotal, out int loops)
        {
            bestTotal = 0;
            bestStart = 0;
            bestEnd = 0;
            loops = 0;
            /// TODO - put your process code here
            int start = 0; double subTotal = 0; //Set start position to 0, total to 0
            for (int x = 0; x < data.Length; x++) //For every profit value... // index from 0 to end of array as end position
            {
                subTotal += data[x]; // Add value to total
                if (subTotal > bestTotal) //Keep sequence info (start, end, total) if total exceeds current best
                {
                    bestStart = start;
                    bestEnd = x;
                    bestTotal = subTotal;
                }
                if (subTotal < 0) // If total is less than 0
                {
                    start = x + 1; //set start position to next index
                    subTotal = 0; //set total to 0
                }
                loops++;
            }
        }
    }

    /// ==============================================================================
    /// <summary>
    /// Tests the Profits Calculator
    /// </summary>
    class Test
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            double[] data;
            int bestStart, bestEnd;
            double bestTotal;
            int loops;

            /// name of the file and the number of readings
            string filename = "week52.txt";
            int items = 52;

            data = new double[items];   /// create the data array

            try
            {
                TextReader textIn = new StreamReader(filename);
                for (int i = 0; i < items; i++)   /// input and store the data values
                {
                    string line = textIn.ReadLine();
                    data[i] = double.Parse(line);
                }
                textIn.Close();
            }
            catch
            {
                Console.WriteLine("File Read Failed");
                return;
            }

            /// ---------------------------------------------------------------------
            /// call the process method to find the best profit period
            /// ---------------------------------------------------------------------

            RangeFinder.MaxSum1(data, out bestStart, out bestEnd, out bestTotal, out loops);
            Console.WriteLine("Start : {0} End : {1} Total {2} Loops {3}", bestStart, bestEnd, bestTotal, loops);
            Console.ReadLine();
        }
    }
}



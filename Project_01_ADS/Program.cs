using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Linear Search

            //Stopwatch stopWatch = new Stopwatch();

            //stopWatch.Start();

            //LinearSearch.ImprovedLinearSearch(ArrayGenerator.GenerateRandomArray(10000000), 0);

            //stopWatch.Stop();

            //TimeSpan ts = stopWatch.Elapsed;

            //// Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);

            //Console.WriteLine("RunTime LS: " + ts);

            #endregion

            #region Binary Search

            //int[] binary_test = ArrayGenerator.GenerateRandomArray(10000000);

            //Array.Sort(binary_test);

            //Stopwatch stopWatch2 = new Stopwatch();

            //stopWatch2.Start();

            //BinarySearch.Binary_Search(binary_test, 77);

            //stopWatch2.Stop();

            //TimeSpan ts2 = stopWatch2.Elapsed;

            //// Format and display the TimeSpan value.
            //string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);

            //Console.WriteLine("RunTime BS: " + ts2);

            #endregion

            int size = 10000000;

            Console.WriteLine("Size; SimpleLinearSearch; ImprovedLinearSearch; ImprovedWithSentinel,BinarySearch");
            for (int i = 1; i < 11; i++)
            {
                RunAnalys(size * i);
            }
        }



        static void RunAnalys(int size)
        {

            int SearchValue = 555;

            int[] array = new int[size];

            array[size-1] = SearchValue;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            bool IndexSimpleLinearSearch = LinearSearch.SimpleLinearSearch(array, SearchValue);

            stopwatch.Stop();

            long TimeSimpleLinearSearch = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();

            stopwatch.Start();

            bool IndexImprovedLinearSearch = LinearSearch.ImprovedLinearSearch(array, SearchValue);

            stopwatch.Stop();

            long TimeImprovedLinearSearch = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();

            stopwatch.Start();

            bool IndexImprovedLinearSearchWithSentinel = LinearSearch.ImprovedLinearSearchWithSentinel(array, SearchValue);

            stopwatch.Stop();

            long TimeImprovedLinearSearchWithSentinel = stopwatch.ElapsedMilliseconds;

            stopwatch.Reset();

            

            stopwatch.Start();

            bool IndexBinarySearch = BinarySearch.Binary_Search(array, SearchValue);

            stopwatch.Stop();

            long TimeBinarySearch = stopwatch.ElapsedMilliseconds;

           

            if (IndexSimpleLinearSearch == false)
            {
                Console.WriteLine("Value was not found");
            }
            else
            {
                Console.WriteLine(size + ";" + TimeSimpleLinearSearch + ";" + TimeImprovedLinearSearch + ";" + TimeImprovedLinearSearchWithSentinel + ";" + TimeBinarySearch);
            }

        }
    }



    class ArrayGenerator
    {
        public static int[] GenerateRandomArray(int size)
        {
            Random R = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = R.Next(-100, 100);

            return array;
        }

        public static int[] GenerateSortedAscendingArray(int size)
        {
            Random R = new Random();

            int[] array = new int[size];

            for (int i = 0; i < size; i++)

                array[i] = R.Next(0, 101);

            Array.Sort(array);

            return array;
        }
        static void LogData(string fileName, string[] columnLabels, int[,] data)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < columnLabels.Length; i++)

                    writer.Write(columnLabels[i] + "\t");

                writer.WriteLine();

                for (int i = 0; i < data.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < data.GetUpperBound(1); j++)
                    {
                        writer.Write(data[j, i] + "\t");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
    static class LinearSearch
    {
        public static bool SimpleLinearSearch(int[] array, int searchedValue)
        {
            int res = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchedValue)

                    res = i;
            }
            return (res == -1) ? false : true;
        }
        public static bool ImprovedLinearSearch(int[] array, int searchedValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == searchedValue)

                    return true;
            }
            return false;
        }
        public static bool ImprovedLinearSearchWithSentinel(int[] array, int searchedValue)
        {
            int last = array[array.Length - 1];

            array[array.Length - 1] = searchedValue;

            int i = 0;

            while (array[i] != searchedValue)

                i++;

            if (i < array.Length - 1 || last == searchedValue)

                return true;

            return false;
        }
    }
    static class BinarySearch
    {
        public static bool Binary_Search(int[] array, int searchValue)
        {
            Array.Sort(array);
          
            int p = 0, r = array.Length - 1;

            int i = 1;
            while (p <= r)
            {
                int q = (int)Math.Floor((double)(p + r) / 2);
                if (array[q] == searchValue)
                {
                    return true;
                }
                else if (array[q] != searchValue && array[q] > searchValue)
                {
                    r = q - 1;
                }
                else if (array[q] < searchValue)
                {
                    p = q + 1;
                }
                i++;
            }
            return false;
        }
    }
    
}

    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Project_03_ADS_
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 100000;//for simple sort size has to be 1000; 
            Console.WriteLine("size "+"Miliseconds");
            for (int i = 1; i < 11; i++)
            {
                RunAnalysis(size * i);
            }



        }
         static void RunAnalysis(int size)
         {
            int[] randomArray = ArrayGenerator.GenerateRandomArray(size);
            Stopwatch stopWatch = new Stopwatch();

            #region BubbleSort_random
            //stopWatch.Start();
            //bool IndexofBubbleSort = SimpleSorting.bubble_sortWithRandomArray(randomArray);
            //stopWatch.Stop();
            //long TimeBubblesort = stopWatch.ElapsedMilliseconds;
            #endregion

            #region BubbleSort_V_shaped 

            //stopWatch.Reset();

            //stopWatch.Start();
            //bool IndexofBubbleSortVShaped = SimpleSorting.bubble_sort_V_shape(randomArray,size);
            //stopWatch.Stop();
            //long TimeBubblesortVShaped= stopWatch.ElapsedMilliseconds;
            #endregion

            #region BubbleSort_A_shaped

            //stopWatch.Reset();

            //stopWatch.Start();
            //bool IndexofBubbleSortAShaped = SimpleSorting.bubble_sort_V_shape(randomArray, size);
            //stopWatch.Stop();
            //long TimeBubblesortAShaped = stopWatch.ElapsedMilliseconds;

            //Console.WriteLine(TimeBubblesortAShaped);

            #endregion

            #region BubbleSort_ascending

            //stopWatch.Reset();

            //stopWatch.Start();
            //bool IndexofBubbleSortAscending= SimpleSorting.bubble_sort_ascending(randomArray, size);
            //stopWatch.Stop();
            //long TimeBubblesortAscending = stopWatch.ElapsedMilliseconds;
            ////Console.WriteLine(TimeBubblesortAscending);

            #endregion

            #region BubbleSort_descending

            //stopWatch.Reset();

            //stopWatch.Start();
            //bool IndexofBubbleSortDescending = SimpleSorting.bubble_sort_descending(randomArray, size);
            //stopWatch.Stop();
            //long TimeBubblesortDescending = stopWatch.ElapsedMilliseconds;
            //Console.WriteLine(TimeBubblesortDescending);

            #endregion

            #region RandomQuickSort
            stopWatch.Reset();

            stopWatch.Start();
            //bool indexofQuickSort = AdvancedSorting.QuickSortWithRandom(randomArray,size);
            //stopWatch.Stop();
            //long TimeQuickSort = stopWatch.ElapsedMilliseconds;
            //Console.WriteLine(TimeQuickSort);

            #endregion

            #region QuickSort_V_shape
            //stopWatch.Reset();

            //stopWatch.Start();
            //bool indexofQuickSortVShape = AdvancedSorting.QuickSortVshape(randomArray, size);
            //stopWatch.Stop();
            //long TimeQuickSortVShape = stopWatch.ElapsedMilliseconds;
            //Console.WriteLine(TimeQuickSortVShape);


            #endregion

            #region QuickSort_A_shape
            //stopWatch.Reset();

            //stopWatch.Start();
            //bool indexofQuickSortAShape = AdvancedSorting.QuickSortVshape(randomArray, size);
            //stopWatch.Stop();
            //long TimeQuickSortAShape = stopWatch.ElapsedMilliseconds;
            //Console.WriteLine(TimeQuickSortVShape);


            #endregion

            #region QuickSort_ascending
            // stopWatch.Reset();

            //stopWatch.Start();
            //bool indexofQuickSortAscending = AdvancedSorting.QuickSortVshape(randomArray, size);
            //stopWatch.Stop();
            //long TimeQuickSortAscending = stopWatch.ElapsedMilliseconds;
            //Console.WriteLine(TimeQuickSortAscending);

            #endregion

            #region QuickSort_Descending
            //stopWatch.Reset();

            //stopWatch.Start();
            //bool indexofQuickSortDescending = AdvancedSorting.QuickSortVshape(randomArray, size);
            //stopWatch.Stop();
            //long TimeQuickSortDescending= stopWatch.ElapsedMilliseconds;
            //Console.WriteLine(TimeQuickSortDescending);

            #endregion

            CountingSorting.CountingSort(randomArray);

         }

    }


    public enum ArraySort { Ascending, Descending, VShape, AShape, None };

    class CountingSorting
    {
        public static bool CountingSort(int[] array)
        {
            int[] sortedArray = new int[array.Length];

            // find smallest and largest value
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i] - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }

            return true;
        }
    }
    class SimpleSorting
    {
        public static bool bubble_sortWithRandomArray(int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort] > array[sort + 1])
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                // Console.Write("[ " + array[i] + " ]");
            }
            return true;
        }
        public static bool bubble_sort_V_shape(int[] array,int size)
        {
            int temp = 0;
            int MinRange = 0;
            int MaxRange = 100;
            array = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.VShape);

            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort] > array[sort + 1])
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }
            return true;
        }
        public static bool bubble_sort_A_shape(int[] array,int size)
        {
            int temp = 0;
            int MinRange = 0;
            int MaxRange = 100;
            array = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.AShape);

            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort] > array[sort + 1])
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }

            return true;
        }
        public static bool bubble_sort_ascending(int[] array,  int size)
        {
            int temp = 0;
            int MinRange = 0;
            int MaxRange = 100;
            array = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.Ascending);

            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort] > array[sort + 1])
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }

            return true;
        }
        public static bool bubble_sort_descending(int[] array, int size)
        {
            int temp = 0;
            int MinRange = 0;
            int MaxRange = 100;
            array = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.Descending);

            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort] > array[sort + 1])
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }

            return true;
        }

    }
    class AdvancedSorting
    {
        public static bool QuickSortWithRandom(int[] numbers,int size)
        {
            numbers = ArrayGenerator.GenerateRandomArray(size);
            return true;
        }
        public static bool QuickSortVshape(int[] numbers,int size)
        {
         
            int MinRange = 0;
            int MaxRange = 100;
            numbers = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.VShape);
            QuicksortImplementing(numbers, 0, numbers.Length - 1);

            return true;
        }
        public static bool QuickSortAshape(int[] numbers,int size)
        {
            
            int MinRange = 0;
            int MaxRange = 100;
            numbers = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.AShape);
            QuicksortImplementing(numbers, 0, numbers.Length - 1);
            return true;
        }
        public static bool QuickSortAscending(int[]numbers,int size)
        {
            int MinRange = 0;
            int MaxRange = 100;
            numbers = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.Ascending);
            QuicksortImplementing(numbers, 0, numbers.Length - 1);
            return true;
        }
        public static bool QuickSortDescending(int[]numbers,int size)
        {
            int MinRange = 0;
            int MaxRange = 100;
            numbers = ArrayGenerator.Generate(size, MinRange, MaxRange, ArraySort.Descending);
            QuicksortImplementing(numbers, 0, numbers.Length - 1);
            return true;
        }

        public static void QuicksortImplementing(int[]numbers, int left,int right)
        {
            int i = left;
            int j = right;

            var pivot = numbers[(left + right) / 2];

            while (i <= j)
            {
                while (numbers[i] < pivot)
                {
                    i++;
                }

                while (numbers[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    var tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuicksortImplementing(numbers, left, j);
            }
            if (i < right)
            {
                QuicksortImplementing(numbers, i, right);
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
                array[i] = R.Next(0, 100);

            return array;
        }
        public static int[] GenerateAscendingSortedArray(int size)
        {
            Random R = new Random();

            int[] array = new int[size];

            for (int i = 0; i < size; i++)

                array[i] = R.Next(0, 101);

            Array.Sort(array);

            return array;
        }
        public static int[] GenerateSortedRandomArray(int size, int n)
        {
            if (size < 1)
                throw new Exception("Incorrect array size");

            Random R = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = n;
            }
            return array;
        }
        public static int[] Generate(int size, int MinRange, int MaxRange, ArraySort sortType)
        {
            int[] array = new int [size];
            Array.Sort(array);
            switch (sortType)
            {
                case ArraySort.Descending:
                    Array.Reverse(array);
                    break;
                case ArraySort.AShape:
                case ArraySort.VShape:
                    if (sortType == ArraySort.AShape)
                        Array.Reverse(array);

                    int[] shapeArray = new int[array.Length];
                    int j = (int)Math.Floor((double)(array.Length - 1) / 2);

                    for (int i = 0; i < array.Length; i++)
                    {
                        shapeArray[j] = array[i];
                        j = (i % 2 == 0) ? j + (i + 1) : j - (i + 1);
                    }
                    array = shapeArray;
                    break;
            }
            return array;
        }
        public static void LogData(string fileName, string[] columnLabels, int[,] data)
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
}

using System;

namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1 Sorting

            int[] intArray = { 8, 4, 2, 9, 2, 4, 8, 5, 1, 7, 6 };

            Console.WriteLine("\nBefore Sorting:");
            PrintArray(intArray);

            SortArray(intArray);

            Console.WriteLine("\nAfter Sorting:");
            PrintArray(intArray);

            Console.WriteLine("\n");

            #endregion

            #region Problem 2 Processing data in chunks
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[][] chunks = ReadChunksOfArray(data);

            for (int i = 0; i < chunks.Length; i++)
            {
                Console.Write("Chunk #" + (i + 1) + ": ");

                for (int j = 0; j < chunks[i].Length; j++)
                    Console.Write(chunks[i][j] + " ");

                Console.WriteLine();
            }
            #endregion
        }

        static T[] SortArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if ((dynamic)array[j] > (dynamic)array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }

            return array;
        }

        static T[][] ReadChunksOfArray<T>(T[] array, int chunkSize = 3)
        {
            int arrSize = array.Length;

            T[][] chunks = new T[(arrSize / chunkSize) + (arrSize % chunkSize)][];

            int currentChunk = 0;

            for (int i = 0; i < arrSize; i += chunkSize)
            {
                int endIdx = i + chunkSize > arrSize ? arrSize : i + chunkSize;
                T[] batchChunks = new T[endIdx - i];

                int chunkCnt = 0;
                for (int j = i; j < endIdx; j++)
                    batchChunks[chunkCnt++] = (dynamic)array[j] * (dynamic)array[j];

                chunks[currentChunk++] = batchChunks;
            }

            return chunks;
        }


        static void PrintArray<T>(T[] array)
        {
            foreach (T item in array)
                Console.Write(item + " ");
        }
    }
}

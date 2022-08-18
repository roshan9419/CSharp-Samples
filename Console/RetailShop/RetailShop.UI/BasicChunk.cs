using System;

namespace RetailShop.UI
{
    internal class BasicChunk<T>
    {
        internal static void ReadChunksOfArray(T[] items, int chunkSize = 3)
        {
            T[] chunk = new T[chunkSize];
            int chunkCounter = 0;

            while (chunkCounter < items.Length)
            {
                if (chunkCounter % chunkSize == 0)
                {
                    chunk = AdvanceChunk<T>.MoveChunk(chunk);
                    chunk = AdvanceChunk<T>.SortChunk(chunk);
                    DisplayChunk(chunk);

                    CleanChunk(chunk);
                }

                chunk[chunkCounter % chunkSize] = items[chunkCounter];
            }
        }

        internal static T[] ReadChunks(T[] items, int chunkSize = 3)
        {
            return items;
        }

        internal static void DisplayChunk(T[] chunk)
        {
            foreach (T chunkItem in chunk)
            {
                dynamic item = chunkItem;
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
            }
        }

        private static void CleanChunk(T[] chunk) => chunk = new T[chunk.Length];
    }
}
using RetailShop.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace RetailShop.Logic
{
    public class FileReader
    {
        private string _filePath;

        public FileReader(string filePath)
        {
            _filePath = filePath;
        }

        public ItemStock[] ReadStocks(int count)
        {
            ItemStock[] itemStocks = new ItemStock[count];

            using (StreamReader reader = new StreamReader(_filePath))
            {
                reader.ReadLine(); // ignore header
                
                for (int i = 0; i < count; i++)
                {
                    string lineItem = reader.ReadLine();
                    itemStocks[i] = ConvertToItemStock(lineItem);
                }
            }

            return itemStocks;
        }

        public List<ItemStock> ReadStocks()
        {
            var itemStocks = new List<ItemStock>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                reader.ReadLine(); // ignore header

                string lineItem;
                while ((lineItem = reader.ReadLine()) != null)
                {
                    itemStocks.Add(ConvertToItemStock(lineItem));
                }
            }

            return itemStocks;
        }

        private ItemStock ConvertToItemStock(string lineItem)
        {
            string[] items = lineItem.Split(',');
            return new ItemStock(items[0], int.Parse(items[1]));
        }


        public List<ItemStock> ReadItems()
        {
            List<ItemStock> items = new List<ItemStock>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                reader.ReadLine(); // ignore header

                string lineItem;
                while ((lineItem = reader.ReadLine()) != null)
                {
                    items.Add(ConvertToItemStock(lineItem));
                }
            }

            return items;
        }

        public List<T> ReadItems<T>()
        {
            List<T> items = new List<T>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                reader.ReadLine(); // ignore header

                string lineItem;
                while ((lineItem = reader.ReadLine()) != null)
                {
                    //items.Add(ConvertItem(lineItem));
                }
            }

            return items;
        }

        private T ConvertItem<T>(string lineItem, Func<T> exc)
        {
            string[] items = lineItem.Split(",");
            return exc();
        }


        // Writing to files
    }
}

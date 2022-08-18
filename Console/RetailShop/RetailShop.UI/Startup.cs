using RetailShop.Data;
using RetailShop.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetailShop.UI
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            //AddItemPrices();
            //UpdateItemStocks();

            #region Reading stocks from local storage
            string filePath = @"C:\CSharp\Console\RetailShop\RetailShop.UI\Files\Stocks.csv";
            FileReader fileReader = new FileReader(filePath);

            ItemStock[] fixedStocks = fileReader.ReadStocks(3);
            List<ItemStock> allStocks = fileReader.ReadStocks();
            #endregion

            string stocksFile = @"C:\CSharp\Console\RetailShop\RetailShop.UI\Files\Stocks.csv";
            string pricesFile = @"C:\CSharp\Console\RetailShop\RetailShop.UI\Files\Prices.csv";

            FileReader reader = new FileReader(stocksFile);
            List<ItemStock> stocks = reader.ReadItems();
            
            foreach (ItemStock item in stocks)
                Console.WriteLine($"Id: {item.Id}, Qty: {item.Quantity}");


            reader = new FileReader(pricesFile);
            List<ItemPrice> prices = reader.ReadItems<ItemPrice>();
            
            foreach (ItemPrice item in prices)
                Console.WriteLine($"Id: {item.Id}, Qty: {item.Price}, Discount: {item.Discount}");


            // using LINQ

            ItemStock stock = stocks.Find(item => item.Quantity == 10);
            ItemPrice price = prices.Find(item => item.Id == stock.Id);

            List<ItemStock> minStocks = stocks.FindAll(item => item.Quantity < 10);

            prices.Sort((a, b) => a.Price > b.Price ? 1 : -1);
            List<ItemPrice> topPrices = prices.GetRange(0, 3);

            foreach(ItemPrice item in topPrices)
                Console.WriteLine($"Price: {item.Price}");

        }

        static void ProcessShopItems()
        {
            ShopItem[] shopItems = CreateShopItems();
            IShopItem[] iShopItems = CreateShopItems();

            ShopItem[] chunk = BasicChunk<ShopItem>.ReadChunks(shopItems);
            ShopItem[] movedChunk = AdvanceChunk<ShopItem>.MoveChunk(chunk);
            ShopItem[] sortedChunk = AdvanceChunk<ShopItem>.SortChunk(movedChunk);

            BasicChunk<ShopItem>.DisplayChunk(chunk); // before sorting
            BasicChunk<ShopItem>.DisplayChunk(sortedChunk); // after sorting
        }

        static ShopItem[] CreateShopItems()
        {
            return new ShopItem[] {
                                     new ShopItem("Mazza", DateTime.Parse("05-06-22")),
                                     new ShopItem("Lays Chips", DateTime.Parse("23-07-22")),
                                     new ShopItem("Dairy Milk", DateTime.Parse("15-09-22")),
                                     new ShopItem("Rice", DateTime.Parse("23-07-22")),
                                     new ShopItem("Coca Cola", DateTime.Parse("23-07-22")),
                                     new ShopItem("Snacker", DateTime.Parse("23-07-22")),
                                     new ShopItem("Brown Bread", DateTime.Parse("23-07-22")),
                                     new ShopItem("Mustard Oil", DateTime.Parse("23-07-22")),
                                     new ShopItem("Basmati Rice", DateTime.Parse("23-07-22"))
                                  };

        }

        static void AddItemPrices()
        {
            ItemStock[] itemStocks = {
                                        new ItemStock("1", 10),
                                        new ItemStock("2", 8),
                                        new ItemStock("3", 12)
                                     };
        }

        static void UpdateItemStocks()
        {
            ItemPrice[] itemPrices = {
                                        new ItemPrice("1", 40f, 5f),
                                        new ItemPrice("2", 10f, null),
                                        new ItemPrice("3", 60f, 2.6f)
                                     };
        }
    }
}

using Mizza.DataModels;

namespace MizzaAPI.Repository
{
    internal class MizzaToppingRepository
    {
        internal CommandViewModel CommandVM;
        public MizzaToppingRepository()
        {
            CommandVM = new CommandViewModel("MIzzaNextMySqlDB");
        }

        public MizzaToppingSKUPrice MizzaToppingSKUPrices { get; set; }
        public MizzaToppingSKUStock MizzaToppingSKUStocks { get; set; }
        public MizzaToppingsStyleSKU MizzaToppingsStyleSKUs { get; set; }
        public MizzaToppingStyle MizzaToppingStyles { get; set; }
    }
}
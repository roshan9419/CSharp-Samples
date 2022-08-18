using Mizza.DataModels;

namespace MizzaAPI.Repository
{
    internal class MizzaItemRepository
    {
        internal CommandViewModel CommandVM;
        public MizzaItemRepository()
        {
            CommandVM = new CommandViewModel("MIzzaNextMySqlDB");
        }

        public MizzaSize MizzaSizes { get; set; }
        public MizzaStyle MizzaStyles { get; set; }
        public MizzaSkuBasePrice MizzaSkuBasePrices { get; set; }
        public MizzaSKU MizzaSkus { get; set; }
    }
}
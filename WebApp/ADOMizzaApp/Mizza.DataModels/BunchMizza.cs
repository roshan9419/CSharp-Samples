using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mizza.DataModels
{
    public class BunchMizza
    {
        public MizzaSize MizzaSizes { get; set; }
        public MizzaStyle MizzaStyles { get; set; }
        public MizzaSkuBasePrice MizzaSkuBasePrices { get; set; }
        public MizzaSKU MizzaSkus { get; set; }
        public MizzaSKUStock MizzaSkuStocks { get; set; }
        public MizzaToppingSKUPrice MizzaToppingSKUPrices { get; set; }
        public MizzaToppingSKUStock MizzaToppingSKUStocks { get; set; }
        public MizzaToppingsStyleSKU MizzaToppingsStyleSKUs { get; set; }
        public MizzaToppingStyle MizzaToppingStyles { get; set; }
    }
}
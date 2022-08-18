using System;
using System.Collections.Generic;

#nullable disable

namespace MizzaPricesCore.DataModel.Models
{
    public partial class ItemPrice
    {
        public int ItemId { get; set; }
        public int Price { get; set; }
        public string PriceId { get; set; }
    }
}

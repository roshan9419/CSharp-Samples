//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MIzzaNC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MizzaToppingsStyleSKU
    {
        public string ToppingStyleID { get; set; }
        public string ToppingSKUID { get; set; }
    
        public virtual MizzaToppingSKUPrice MizzaToppingSKUPrice { get; set; }
        public virtual MizzaToppingSKUStock MizzaToppingSKUStock { get; set; }
        public virtual MizzaToppingStyle MizzaToppingStyle { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScraperApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ParsingTable
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> StockRecord { get; set; }
        public string Symbol { get; set; }
        public string Company { get; set; }
        public string LastSale { get; set; }
        public string Change { get; set; }
        public string PChg { get; set; }
        public string VolumeAvg { get; set; }
    }
}

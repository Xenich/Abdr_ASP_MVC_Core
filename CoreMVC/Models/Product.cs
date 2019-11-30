using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVC.Models
{
    public class Product
    {
        public bool self { get; set; }
        public bool byCity { get; set; }
        public bool regions { get; set; }
        public int availability { get; set; }
        public int price { get; set; }
        public Dictionary<int, double> discount { get; set; }
        //public Discount discount { get; set; }

    }
}
public class Discount
{
    public Dictionary<int, double> discount { get; set; }
}
/*

    this.availability = availability;
        this.price = price;
        this.discount = discount;
        this.self = self;
        this.byCity = byCity;
        this.regions = regions;


 * */

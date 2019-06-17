using System;
using System.Collections.Generic;

namespace SoftSpace_web.Models
{
    public class Product
    {
      public  int id_product;
      public string name;
      public string description;
      public int id_dev;
      public int id_category;
      public string category_name;
      public  List<string> pictures= new List<string>();
      public  List<string> labels  = new List<string>();

      public  List<List<string>> product_events  = new List<List<string>>();
      public  List<List<string>> dlc  = new List<List<string>>();
      public string developer;
      public double price;
      public string def_picture;
      public bool liked;

      public  List<List<string>> product_reviews = new List<List<string>>();

      public Product()
      {
        this.id_product = -1;
        this.name = "NotAName";
        this.description = "NaD";
        this.id_dev =-1;
        this.id_category = -1;
        this.pictures.Clear();
        this.labels.Clear();
        
        this.product_events.Clear();
        this.dlc.Clear();
        this.developer = "NaDev";
        this.price = 0;
        this.def_picture ="NaP";
        this.product_reviews.Clear();
        this.liked = false;


      }
    }
}
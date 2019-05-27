using System;
using System.Collections.Generic;

namespace SoftSpace_web.Models
{
    public class ShopPage
    {
      public  int type_user ;
      
      public int id_dev;
      public string name_of_company;
      public List<List<string>> top_product = new List<List<string>>();
      public List<List<string>> new_product = new List<List<string>>();
      public List<List<string>> recommended_product = new List<List<string>>();
      public int currect_number;
      public int count_pages;
    }
}
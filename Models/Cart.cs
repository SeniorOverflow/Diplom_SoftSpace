using System;
using System.Collections.Generic;
using SoftSpace_web.Script;

namespace SoftSpace_web.Models
{
    public class Cart
    {
      public  int id_user ;
      public  List<List<string>> items = new List<List<string>>();
      public double this_price ;
      private double total_price ;
      private int discount;


        public Cart(int _discount = 5)
        {
            this.discount = _discount;
        }
        public void Set_Price()
        {
            List<List<string>> tmp_data_price = new List<List<string>>();
            DbConfig.UseSqlCommand("select product.price*shopping_cart.count"+
            " from shopping_cart inner join  product on " +
                  " shopping_cart.id_product = product.id"+
                  "  where shopping_cart.id_user = " + this.id_user , tmp_data_price);
             
            double _price = 0;
            if(tmp_data_price.Count > 0)
            {
                foreach(List<string>product_price in tmp_data_price)
                {
                    _price += Convert.ToDouble(product_price[0]);
                    

                }
            }

           
            this.total_price = _price;
           

        }

        public double Get_TotalPrice () =>  this.total_price;
        

    }



    
}
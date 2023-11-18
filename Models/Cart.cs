using System;
using System.Collections.Generic;
using SoftSpace_web.Scripts;

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
            DbConfig db = new DbConfig();
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("select product.id, product.price*shopping_cart.count"+
            " from shopping_cart inner join  product on " +
                  " shopping_cart.id_product = product.id"+
                  "  where shopping_cart.id_user = " + this.id_user , tmp_data);
             
            double _price = 0;
            if(tmp_data.Count > 0)
            {
                foreach(List<string>product in tmp_data)
                {
                    List<List<string>> tmp_discount = new List<List<string>>();
                    db.UseSqlCommand("SELECT discount_price from discount WHERE date_end  > now() AND id_product = " +product[0],tmp_discount );
                    
                    if(tmp_discount.Count > 0)
                    {
                        _price += Convert.ToDouble(tmp_discount[0][0]);
                    }
                    else
                        _price += Convert.ToDouble(product[1]) ;
                    

                }
            }

           
            this.total_price = _price;
           

        }

        public double Get_TotalPrice () =>  this.total_price;
        

    }



    
}
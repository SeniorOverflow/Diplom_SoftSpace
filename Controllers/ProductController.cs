using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftSpace_web.Models;
using Npgsql;
using SoftSpace_web.Script;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SoftSpace_web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ShowProduct(int id_product)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            Product this_product = new Product();
            List<List<string>> product_data = new List<List<string>>();

           
                DbConfig.UseSqlCommand("select * from product where id = " + id_product, product_data);
                this_product.id_product = Convert.ToInt32(product_data[0][0]);
                this_product.name = product_data[0][1];
                this_product.description = product_data[0][2];
                this_product.id_dev = Convert.ToInt32(product_data[0][3]);
                this_product.id_category = Convert.ToInt32(product_data[0][4]);
                this_product.price = Convert.ToDouble(product_data[0][5]);
                this_product.def_picture =  product_data[0][7];

                product_data.Clear();

                DbConfig.UseSqlCommand("select  url_picture  from picture_product  where id_product = " + this_product.id_product, product_data);

                foreach(var str in product_data)
                {
                    foreach( string pic in str)
                    {
                        this_product.pictures.Add(pic);
                    }
                }

                product_data.Clear();

                DbConfig.UseSqlCommand("select label_name from label_product  where id_product = " + this_product.id_product,product_data);
                foreach(var str in product_data)
                {
                    foreach( string label in str)
                    {
                        this_product.labels.Add(label);
                    }
                }
                
                product_data.Clear();
                DbConfig.UseSqlCommand("select name_of_company from developers where id =" + this_product.id_dev,product_data);
                this_product.developer = product_data[0][0];

                product_data.Clear();
                DbConfig.UseSqlCommand("SELECT  dlc_for_product.id_sub_product, name ,price,def_picture " +
                " FROM product  INNER JOIN dlc_for_product on product.id = dlc_for_product.id_sub_product " +
                " WHERE dlc_for_product.id_product = "+ this_product.id_product,product_data);

                    foreach(List<string> dlc in product_data)
                    {
                        this_product.dlc.Add(dlc);
                    }
                product_data.Clear();
                DbConfig.UseSqlCommand("SELECT id,event_name, description , date_event from event_product  where id_product =  " + this_product.id_product,product_data );

                    foreach(List<string> _event in product_data)
                    {
                        this_product.product_events.Add(_event);
                    }

                product_data.Clear();

                DbConfig.UseSqlCommand("SELECT first_name,second_name, comment_to_product, assessment "+
                        "FROM users INNER JOIN review ON users.id = review.id_user " + 
                        " WHERE review.id_product = " + this_product.id_product , product_data);
                    
                    foreach(List<string> _review in product_data)
                    {
                        this_product.product_reviews.Add(_review);
                    }

            if(!string.IsNullOrEmpty(login))
            {
                List<List<string>> tmp_data = new List<List<string>>();
                
                DbConfig.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);

                product_data.Clear();
                DbConfig.UseSqlCommand("Select id from liked_product WHERE id_product = " + this_product.id_product
                    + " AND  id_user = " + id_user,product_data );
                if(product_data.Count > 0)
                {
                    this_product.liked = true;
                }
                else
                {
                    this_product.liked= false;
                }
            }
            List<string> translate_words =  Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            ViewBag.Product = this_product;
           return View();
        }
        public IActionResult Search(string name)
        {
           
           return View(name);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(int _id_product, int count =1)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                DbConfig.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);

                tmp_data.Clear();
                DbConfig.UseSqlCommand("INSERT INTO shopping_cart("+
	                                    "id_product, id_user, count)"+
	                                    "VALUES ('"+_id_product+"', '"+id_user+"', '"+count+"')");
            }
           
           return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDLC(int _id_product, int _id_dlc, int count =1)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                DbConfig.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);

                tmp_data.Clear();
                DbConfig.UseSqlCommand("INSERT INTO shopping_cart("+
	                                    "id_product, id_user, count)"+
	                                    "VALUES ('"+_id_dlc+"', '"+id_user+"', '"+count+"')");
            }

           return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLike(int _id_product)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 0} ));
            }
            else
            {

                tmp_data.Clear();
                DbConfig.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);

                tmp_data.Clear();
                DbConfig.UseSqlCommand("INSERT INTO liked_product("+
	                                    "id_product, id_user)"+
	                                    "VALUES ('"+_id_product+"', '"+id_user+"')");

            }
           
           return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveLike(int _id_product)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                DbConfig.UseSqlCommand("select id from users where login = " 
                                            +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);

                tmp_data.Clear();
                DbConfig.UseSqlCommand("DELETE FROM liked_product"+
                                            " WHERE id_product = " + _id_product +
                                                " AND  id_user = " + id_user);
            }
           
           return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int _id_product, string _comment , int _assessment = 5)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 0} ));
            }
            else
            {

                tmp_data.Clear();
                DbConfig.UseSqlCommand("select id from users where login = "+sr.GetScr() +login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);
            
                tmp_data.Clear();
                DbConfig.UseSqlCommand("INSERT INTO review( "+
	                                    " id_product, id_user, assessment, comment_to_product) "+
	                                    " VALUES ("+_id_product+", "+id_user+", "+_assessment+", "+sr.GetScr()+_comment+sr.GetScr()+")");

            }
           
           return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveProduct(int _id_product_in_cart)
        {
            Screening sr = new Screening();
           
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 0} ));
            }
            else
            {
                
                tmp_data.Clear();
                DbConfig.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);

                tmp_data.Clear();
                DbConfig.UseSqlCommand("DELETE FROM shopping_cart  where id_user = " + id_user + " AND id =" + _id_product_in_cart);
            }
                return RedirectToAction("Cart", new RouteValueDictionary( 
                         new { controller = "User", action = "Cart"} ));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

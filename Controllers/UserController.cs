using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SoftSpace_web.Models;
using SoftSpace_web.Script;

namespace SoftSpace_web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        
        
        public IActionResult Cart()
        {
            Screening sr  = new Screening();
            string login = HttpContext.Session.GetString("login");
            Cart cart = new Cart();
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
                cart.id_user = id_user;
                tmp_data.Clear();
                DbConfig.UseSqlCommand("select shopping_cart.id, product.name,"+
	                                         " product.def_picture,"+
	                                         " shopping_cart.count,"+
	                                         " product.price*shopping_cart.count as price"+
	                                         " from shopping_cart inner join product on shopping_cart.id_product = product.id"+
	                                         " where shopping_cart.id_user = " + id_user,tmp_data);

                foreach(List<string> item in tmp_data)
                {
                    cart.items.Add(item);
                }
                cart.Set_Price();
                cart.this_price =  cart.Get_TotalPrice();
                Console.WriteLine(cart.this_price);
            }
            ViewBag.Cart = cart;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();
        }

        public IActionResult SetOrder()
        {
            return View();
        }

        public IActionResult YourOrders()
        {
            return View();
        }
        public IActionResult Order()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(int _id_user)
        {

             Cart cart = new Cart();
             cart.id_user = _id_user;
             cart.Set_Price();
             double total_price = cart.Get_TotalPrice();

             long _total_price = Convert.ToInt64(total_price);
            
            Console.WriteLine("All fine ^_^ " + _total_price);


            DbConfig.UseSqlCommand("INSERT INTO deal (id_user, date_deal, total_price) "+
	                                       " VALUES ("+cart.id_user+", now(), "+_total_price+")");

 
            

             List<List<string>> tmp_data = new List<List<string>>();


             DbConfig.UseSqlCommand(" select  id   from deal " +
                                    "where id_user = " + cart.id_user + 
                                    " order by id  desc  LIMIT 1 ",tmp_data);
            int id_deal = Convert.ToInt32(tmp_data[0][0]);
            tmp_data.Clear();
            Console.WriteLine(id_deal);

             DbConfig.UseSqlCommand("select shopping_cart.id_product,shopping_cart.count,product.price"+
	                                         " from shopping_cart  inner join product on shopping_cart.id_product = product.id " +
	                                         " where shopping_cart.id_user = " + _id_user,tmp_data);

                foreach(List<string> item in tmp_data)
                {
                    int id_product = Convert.ToInt32(item[0]);
                    int count = Convert.ToInt32(item[1]);
                    double price = Convert.ToDouble(item[2]);
                    DbConfig.UseSqlCommand("INSERT INTO deal_product(id_deal, id_product, count, price)"+
	                                      "       VALUES ( "+id_deal+", "+id_product+","+count+", "+price+")");

                    List<List<string>> tmp_this_deal_product = new List<List<string>>();
                    DbConfig.UseSqlCommand(" select  deal_product.id   from deal_product " +
                                    " where id_deal = " + id_deal+ 
                                    " order by id  desc  LIMIT 1 ",tmp_this_deal_product);

                    int deal_product = Convert.ToInt32(tmp_this_deal_product[0][0]);
                    DbConfig.UseSqlCommand("INSERT INTO baggage(id_user, id_deal_product)"+
	                                        "VALUES ("+cart.id_user+", "+deal_product+")");

                }
            
            DbConfig.UseSqlCommand("DELETE FROM shopping_cart where id_user = " + cart.id_user);

            return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
        }
       

        
        public IActionResult Profile(string login ="", string password ="") 
        {
             if(string.IsNullOrEmpty(login))
             {
                login = HttpContext.Session.GetString("login");
                password =  HttpContext.Session.GetString("password"); 
             }
            
            if(string.IsNullOrEmpty(login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 4} ));
            }
            else
            {

                if(string.IsNullOrEmpty(password))
                {
                    return RedirectToAction("Autorisation", new RouteValueDictionary( 
                            new { controller = "Home", action = "Autorisation", ex= 5} ));
                }
                login =  login.ToLower();
                HttpContext.Session.SetString("login",""+login);
                HttpContext.Session.SetString("password",""+ password);
                Console.WriteLine(HttpContext.Session.GetString("login"));
                Console.WriteLine(HttpContext.Session.GetString("password"));
            }
           

            User _user = new User();
            _user.is_dev = false;
            List<List<string>> tmp_login = new List<List<string>>();
            Screening sr = new Screening();
            DbConfig.UseSqlCommand("SELECT id "+
                                        "FROM users WHERE login = lower("+sr.GetScr()+login+sr.GetScr()+") ",tmp_login);
            if(tmp_login.Count()>0)
            {
                List<List<string>> tmp = new List<List<string>>();
                DbConfig.UseSqlCommand("SELECT id,login,lvl,score,first_name,second_name,bonus_score "+
                                        "FROM users WHERE login = lower("+sr.GetScr()+login+sr.GetScr()+") AND "+
                                         "password = crypt("+sr.GetScr()+password+sr.GetScr()+", password); ",tmp);
                if(tmp.Count()>0)
                {
                        _user.id_user= Convert.ToInt32(tmp[0][0]);
                        _user.login= Convert.ToString(tmp[0][1]);
                        _user.lvl= Convert.ToInt32(tmp[0][2]);
                        _user.score= Convert.ToDouble(tmp[0][3]);
                        _user.first_name = tmp[0][4];
                        _user.second_name= tmp[0][5];
                        _user.bonus_score = Convert.ToDouble(tmp[0][6]);
                        List<List<string>> tmp_u =  new List<List<string>>();
                        DbConfig.UseSqlCommand("SELECT name_of_company " +  
	                                                "FROM developers "+
                                                        "inner join user_dev on"+
                                                        " developers.id = user_dev.id_dev "+
	                                            "WHERE user_dev.id_user = "+ _user.id_user,tmp_u);
                        if(tmp_u.Count>0)
                        {
                            _user.is_dev = true;
                            _user.company = tmp_u[0][0];
                        }
                        ViewBag.User_data = _user;
                        
                         List<string> translate_words =  Language_Settings.GetWords(1);
                         ViewBag.Translate_words = translate_words;
                    return View();
                }
                else
                {
                    return RedirectToAction("Autorisation", new RouteValueDictionary( 
                                new { controller = "Home", action = "Autorisation", ex= 2} ));
                }
            }
            else
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                                new { controller = "Home", action = "Autorisation", ex= 1} ));
            }
        }


        public IActionResult Library()
        {

            List<List<string>> tmp_data = new List<List<string>>();

            Screening sr  = new Screening();
            string login = HttpContext.Session.GetString("login");
            
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
                DbConfig.UseSqlCommand("select deal_product.id, product.name, product.description, developers.name_of_company, deal.date_deal " +
                                       "  from deal inner join deal_product on deal.id = deal_product.id_deal " +
		                                            " inner join product on deal_product.id_product = product.id " +
		                                            " inner join developers on product.id_dev = developers.id " +
                                                    " inner join library on  deal_product.id = library.id_deal_product "+
	                                   " WHERE deal.id_user = " + id_user, tmp_data);

            }// i am here 
            ViewBag.Lib = tmp_data;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToLib(int _id_deal_product)
        {
            Screening sr  = new Screening();
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
                DbConfig.UseSqlCommand("select deal_product.id, product.name, product.description, developers.name_of_company, deal.date_deal " +
                                       "  from deal inner join deal_product on deal.id = deal_product.id_deal " +
		                                            " inner join product on deal_product.id_product = product.id " +
		                                            " inner join developers on product.id_dev = developers.id " +
                                                    " inner join library on  deal_product.id = library.id_deal_product "+
	                                   " WHERE deal_product.id = "+_id_deal_product+" AND  deal.id_user = " + id_user, tmp_data);


                if(tmp_data.Count < 1)
                {
                DbConfig.UseSqlCommand("INSERT INTO  library( id_user, id_deal_product )"+
                        "  VALUES ( "+id_user+", "+_id_deal_product+")");
                }
                else 
                {

                }
                
            }


            return RedirectToAction("Library", new RouteValueDictionary( 
                        new { controller = "User", action = "Library"} ));
        }

        
        public IActionResult Baggage()
        {
            Screening sr = new Screening();
             string login = HttpContext.Session.GetString("login");
            Cart cart = new Cart();
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Autorisation", new RouteValueDictionary( 
                        new { controller = "Home", action = "Autorisation", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                DbConfig.UseSqlCommand("select id  from users where login = "+ sr.GetScr()+ login + sr.GetScr(),tmp_data);

                int id_user = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();
                DbConfig.UseSqlCommand("select deal_product.id, product.name, product.description, developers.name_of_company, deal.date_deal " +
                                       "  from deal inner join deal_product on deal.id = deal_product.id_deal " +
		                                            " inner join product on deal_product.id_product = product.id " +
		                                            " inner join developers on product.id_dev = developers.id " +
	                                   " WHERE deal.id_user = " + id_user, tmp_data);

                ViewBag.Baggage = tmp_data;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                
                return View();
            }
        }

        public IActionResult Subscriptions()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubToDev(int id_dev , int id_type_sub)
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
                DbConfig.UseSqlCommand("select id  from users where login = "+ sr.GetScr()+ login + sr.GetScr(),tmp_data);

                int id_user = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();

                DbConfig.UseSqlCommand("INSERT INTO subscription_on_dev(id_type, id_dev,id_user, date_begin, date_end) "+
	            " VALUES ( "+id_type_sub+", "+id_dev+","+id_user+", now(), now())"); //XXXX

                return RedirectToAction("Index", new RouteValueDictionary( 
                                new { controller = "Home", action = "Index"} ));
            }
        }
        public IActionResult ShowUsers(int numb_page = 0)
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
                DbConfig.UseSqlCommand("select id  from users where login = "+ sr.GetScr()+ login + sr.GetScr(),tmp_data);

                int id_user = Convert.ToInt32(tmp_data[0][0]);
            
                Edit users = new Edit();
                string _sql_com = "Select id,login,mail,lvl FROM users WHERE users.id != "+id_user+" OFFSET  "+(numb_page)*12 +" limit 12" ;
                users = ShowPage.TakePages("users",_sql_com,numb_page,12);
                
                ViewBag.Users = users;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
            
        }

        
        public IActionResult SubToDev_View(int id_dev)
        {
            List<List<string>> tmp_data = new List<List<string>>();
            DbConfig.UseSqlCommand("select * from type_of_subscription", tmp_data);

            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words  = translate_words;

            ViewBag.Subscriptions = tmp_data;
            ViewBag.Id_dev = id_dev;
            return View();
        }
        
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInfo_page()
        {
            Screening sr = new Screening();
             List<List<string>> tmp_user = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT first_name,second_name FROM users "+ 
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_user);
            User user = new User();
            
            user.first_name = tmp_user[0][0];
            user.second_name =tmp_user[0][1];
            ViewBag.User_data = user;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInfo(string first_name, string second_name)
        {
            Screening sr = new Screening();
            DbConfig.UseSqlCommand("UPDATE users set first_name =  "+sr.GetScr()+first_name
            +sr.GetScr()+" ,second_name = "+sr.GetScr()+second_name+sr.GetScr()+ 
                " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() );
           
            return RedirectToAction("Index", new RouteValueDictionary( 
                                new { controller = "Home", action = "Index"} ));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFriend()
        {
            return View();
        }
        public IActionResult SearchPeople()
        {
            return View();
        }
        public IActionResult SearchProduct()
        {
            return View();
        }  
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

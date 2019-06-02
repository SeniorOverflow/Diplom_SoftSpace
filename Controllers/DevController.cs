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
using System.IO;



namespace SoftSpace_web.Controllers
{
    public class DevController : Controller
    {
        
        public IActionResult Index()
        {
            Screening sr = new Screening();
            List<List<string>> tmp_data = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT id from users WHERE login= "+
            sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr(),tmp_data);
            int id_user = Convert.ToInt32( tmp_data[0][0]);

            List<List<string>> tmp_dev = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT developers.id,developers.name_of_company,developers.score FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.id = "+sr.GetScr()+ id_user +sr.GetScr() ,tmp_dev);

            ViewBag.DesDev = tmp_dev;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();
        }

        
        public IActionResult ShowDev(int id_dev)
        {
            Screening sr = new Screening();
            List<List<string>> tmp_dev = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT id,name_of_company,url_on_logo,description  "+ 
                    " from  developers "+
                    " WHERE id =  "+ id_dev ,tmp_dev);

            ViewBag.DesDev = tmp_dev;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();
        }
        
        public IActionResult AddDev()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDev(string name)
        {
            double price_for_open_dev = 1500;
            List<List<string>> tmp_data = new List<List<string>>();
            Screening sr = new Screening();

            DbConfig.UseSqlCommand("SELECT id from users WHERE login= "+
            sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr(),tmp_data);
            int id_user = Convert.ToInt32( tmp_data[0][0]);

            List<List<string>> tmp_user_score = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT score from users WHERE users.id = " + id_user,tmp_user_score);

            double u_score = Convert.ToDouble(tmp_user_score[0][0]);

            if(u_score -  price_for_open_dev > 0)
            {
            
                DbConfig.UseSqlCommand("UPDATE users set score= score - " + price_for_open_dev + " WHERE users.id =" + id_user);

                DbConfig.UseSqlCommand("INSERT INTO deal (id_user, date_deal, total_price) "+
                                            " VALUES ("+id_user+", now(), "+price_for_open_dev+")");
                

                DbConfig.UseSqlCommand("INSERT INTO developers (name_of_company)"+
                                    "VALUES("+sr.GetScr()+name+sr.GetScr()+")");
                tmp_data.Clear();
                DbConfig.UseSqlCommand("SELECT developers.id from developers WHERE name_of_company = "+sr.GetScr()+name +sr.GetScr(),tmp_data);

                int id_dev = Convert.ToInt32( tmp_data[0][0]);
                Console.WriteLine("Тут ид компании "+id_dev + " - user id = " + id_user);
                tmp_data.Clear();

                DbConfig.UseSqlCommand("INSERT INTO user_dev (id_user,id_dev) "+
                                    " VALUES("+id_user+","+id_dev+")");

                    
                return RedirectToAction("Index", new RouteValueDictionary( 
                                    new { controller = "Dev", action = "Idex"} ));
            }
            else
            {
                 return RedirectToAction("Profile", new RouteValueDictionary( 
                                new { controller = "User", action = "Profile"} ));

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelDev(int id_dev)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            DbConfig.UseSqlCommand("select user_dev.id  from user_dev "+
							   " inner join users on user_dev.id_user = users.id "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND user_dev.id_dev = "+id_dev+" ;",tmp_check_on_righted);
            if(tmp_check_on_righted.Count>0)
            {
                
                DbConfig.UseSqlCommand("delete from developers cascade where id = " + id_dev);
              
            }
            return RedirectToAction("Index", new RouteValueDictionary( 
                                new { controller = "Home", action = "Idex"} ));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct_View()
        {
            List<List<string>> tmp_data = new List<List<string>>();
            DbConfig.UseSqlCommand("Select id,name from category",tmp_data);
            Console.WriteLine("++++++++ +++ ++ " +tmp_data[0][1] + " -- " + tmp_data.Count);

            ViewBag.List_category =  tmp_data;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(string name , string price ,   int type_product = 0, int id_category = 1)
        {
            Screening sr = new Screening();
            List<List<string>> tmp_dev = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT id_dev FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_dev);
            
            if(tmp_dev.Count>0)
            {
                string _price = "" + price;
                _price = _price.Replace(',','.');
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++" +_price + "  " , price);
                int id_dev = Convert.ToInt32(tmp_dev[0][0]);
                bool is_dlc = false ;
                if (type_product == 1)
                {
                    is_dlc = true;
                }
                DbConfig.UseSqlCommand("INSERT INTO product("+
	            "name,id_dev, id_category, price,is_dlc)"+
	            "VALUES ("+sr.GetScr()+name+sr.GetScr()+","+id_dev+","+id_category+","+_price+" , "+is_dlc + ")");
            }

            return RedirectToAction("YourProducts", new RouteValueDictionary( 
                                new { controller = "Dev", action = "YourProducts"} ));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelProduct(int id_product, int numb_page)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            DbConfig.UseSqlCommand("select product.id  from users inner join user_dev on users.id = user_dev.id_user "+
							   " inner join product on user_dev.id_dev = product.id_dev "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND product.id = "+id_product,tmp_check_on_righted); 
            if(tmp_check_on_righted.Count>0)
            {

                DbConfig.UseSqlCommand("delete from product cascade where id = " + id_product);
    
            }
            return RedirectToAction("YourProducts", new RouteValueDictionary( 
                                new { controller = "Dev", action = "YourProducts" , numb_page= numb_page} ));
        }

       
        
        public IActionResult YourProducts(int numb_page = 0)
        {
            Screening sr = new Screening();
            List<List<string>> tmp_dev = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT id_dev FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_dev);
            int id_dev = Convert.ToInt32(tmp_dev[0][0]);

            Edit you_product = new Edit();
            string _sql_com = "SELECT * FROM product WHERE id_dev="+id_dev + " OFFSET  "+(numb_page)*ICOP.your_p +" limit "+ICOP.your_p;
            you_product = ShowPage.TakePages("product WHERE id_dev="+id_dev, _sql_com, numb_page,ICOP.your_p);

            ViewBag.You_product = you_product;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDlC_view(int id_product)
        {
            Screening sr = new Screening();
            List<List<string>> tmp_dev = new List<List<string>>();
            AddDLC addDLC = new AddDLC();
            DbConfig.UseSqlCommand("SELECT id_dev FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_dev);
            int id_dev = Convert.ToInt32(tmp_dev[0][0]);

            List<List<string>> your_dlcs = new List<List<string>>();
            DbConfig.UseSqlCommand("SELECT * FROM product WHERE is_dlc = true AND  id_dev="+id_dev,your_dlcs);
            addDLC.id_product = id_product;
            addDLC.dlcs = your_dlcs;
            ViewBag.AddDLC = addDLC;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEvent_view (int id_product)
        {
            
            return View(id_product);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEvent (int _id_product , string name , string description)
        {
            Screening sr = new Screening();
            
           
            DbConfig.UseSqlCommand("INSERT INTO event_product ( id_product, event_name, date_event , description )" + 
            " VALUES(" +_id_product + 
                    " , " + sr.GetScr() + name          + sr.GetScr() + 
                    " ,  now()" + 
                    " , " + sr.GetScr() + description   + sr.GetScr() +" )" );

            return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDlC(int _id_product, int _id_dlc)
        {
        
            DbConfig.UseSqlCommand("INSERT INTO  dlc_for_product (id_product, id_sub_product)"+
            " VALUES ("+_id_product+","+_id_dlc+")");
           
             return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInfo_page(int id_dev)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            DbConfig.UseSqlCommand("select user_dev.id  from user_dev "+
							   " inner join users on user_dev.id_user = users.id "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND user_dev.id_dev = "+id_dev,tmp_check_on_righted);
            if(tmp_check_on_righted.Count>0)
            {
                List<List<string>> tmp_team_info = new List<List<string>>(); 
                DbConfig.UseSqlCommand("select * from developers WHERE id="+id_dev,tmp_team_info); // XXX NEED COOL VIEW 
                Developer dev = new Developer();
                dev.id_dev =id_dev;
               
                dev.name = tmp_team_info[0][1]; 
                dev.url_on_logo = tmp_team_info[0][2]; 
                dev.description = tmp_team_info[0][3]; 
                dev.address = tmp_team_info[0][4]; 
                dev.mail = tmp_team_info[0][5]; 
                dev.phone = tmp_team_info[0][6];  
                ViewBag.Dev = dev; 
                return View();
            }
            else
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                                    new { controller = "Home", action = "Idex"} ));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateInfo(    int id_dev,
                                            string name ,     
                                            string url_on_logo,
                                            string description,
                                            string address,
                                            string mail,
                                            string phone)
        {
           
           

            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            DbConfig.UseSqlCommand("select user_dev.id  from user_dev "+
							   " inner join users on user_dev.id_user = users.id "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND user_dev.id_dev = "+id_dev,tmp_check_on_righted); //XXXXXXXXXXXXXX
            if(tmp_check_on_righted.Count>0)
            {
              
                 DbConfig.UseSqlCommand("UPDATE developers set "+
                 "name_of_company  =  "+sr.GetScr()+    name            +sr.GetScr()+","+
                 "url_on_logo      =  "+sr.GetScr()+    url_on_logo     +sr.GetScr()+","+
                 "description      =  "+sr.GetScr()+    description     +sr.GetScr()+","+
                 "address          =  "+sr.GetScr()+    address         +sr.GetScr()+","+
                 "mail             =  "+sr.GetScr()+    mail            +sr.GetScr()+","+
                 "phone            =  "+sr.GetScr()+    phone           +sr.GetScr()+
                " WHERE developers.id= "+id_dev );

            }
            return RedirectToAction("Index", new RouteValueDictionary( 
                                    new { controller = "Home", action = "Idex"} ));
        }

        public IActionResult SetSub_View()
        {

            


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SetSub()
        {

            
            // string str =  "INSERT INTO subscription_on_dev(id_type, id_dev, date_begin, date_end)VALUES (?, ?, ?, ?)";

            return View();
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(int id_product)
        {
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            DbConfig.UseSqlCommand("select product.id  from users inner join user_dev on users.id = user_dev.id_user "+
							   " inner join product on user_dev.id_dev = product.id_dev "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND product.id = "+id_product,tmp_check_on_righted); 
            if(tmp_check_on_righted.Count>0)
            {
                tmp_check_on_righted = null;

                List<List<string>> tmp          =    new List<List<string>>(); 
                List<List<string>> tmp_lalbels  =    new List<List<string>>(); 
                List<List<string>> tmp_pictures =    new List<List<string>>();
                List<List<string>> tmp_events   =    new List<List<string>>();
                List<List<string>> tmp_dlc      =    new List<List<string>>();

                DbConfig.UseSqlCommand("SELECT label_name FROM label_product WHERE id_product = " + 
                                        id_product ,tmp_lalbels);
                DbConfig.UseSqlCommand("SELECT url_picture FROM picture_product WHERE id_product = " +
                                        id_product ,tmp_pictures);
                DbConfig.UseSqlCommand("SELECT id,event_name FROM event_product WHERE  id_product = " +
                                        id_product  ,tmp_events);
                DbConfig.UseSqlCommand("SELECT name ,price,def_picture"+
                " FROM product  INNER JOIN dlc_for_product on product.id = dlc_for_product.id_sub_product "+
                    " WHERE dlc_for_product.id_product = "+ id_product,tmp_dlc);
               

                DbConfig.UseSqlCommand("SELECT * FROM product WHERE product.id = " + id_product + ";",tmp);
                Product you_product = new Product();

                you_product.id_product = id_product;
                you_product.name = tmp[0][1];
                you_product.description = tmp[0][2];
                you_product.price =  Convert.ToDouble(tmp[0][5]);
               
                you_product.def_picture = tmp[0][7];
                


                

                foreach(var  a in tmp_lalbels)
                {
                    foreach(string label in a)
                    {
                        you_product.labels.Add(label);
                    }
                } 

                foreach(var  a in tmp_pictures)
                {
                    foreach(string url in a)
                    {
                        you_product.pictures.Add(url);
                    }
                } 

                you_product.product_events = tmp_events;
                you_product.dlc = tmp_dlc;

               
                ViewBag.Product = you_product;
                return View();
            }
            else
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                                new { controller = "Home", action = "Index"} ));
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult EditProduct_Save(int id_product ,string name,string description,string labels, IFormFile upload_file)
        {
            
            
            //Here need organaze upload file , mb not here i don' now 
            
            
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            DbConfig.UseSqlCommand("select product.id  from users inner join user_dev on users.id = user_dev.id_user "+
							   " inner join product on user_dev.id_dev = product.id_dev "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND product.id = "+id_product,tmp_check_on_righted); 
            if(tmp_check_on_righted.Count>0)
            {

                
                tmp_check_on_righted = null;
                 DbConfig.UseSqlCommand("UPDATE product SET "+
                 "name   =  "+sr.GetScr()+name+sr.GetScr()+","+
                 "description      =  "+sr.GetScr()+description+sr.GetScr()+" "+
                " WHERE product.id= "+id_product );

            
            
            string [] array_labels = labels.Split(",");
                DbConfig.UseSqlCommand("Delete from label_product where id_product = "+id_product);
                foreach(string a in array_labels)
                {
                     DbConfig.UseSqlCommand("INSERT INTO label_product(id_product,label_name) "+
                     "VALUES ("+id_product+","+sr.GetScr()+a+sr.GetScr()+")");
                }
            }
            return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            
           
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetLicenseKeys()
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

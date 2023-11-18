using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using SoftSpace_web.Scripts;

namespace SoftSpace_web.Controllers
{
    public class UserController : Controller
    {
        private readonly SoftspaceContext _softspaceContext;
        public UserController(SoftspaceContext softspaceContext)
        {
            _softspaceContext = softspaceContext;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Cart()
        {
            Screening sr  = new Screening();
            DbConfig db = new DbConfig();
            Check_discount.Check(_softspaceContext);
            string login = HttpContext.Session.GetString("login");
            Models.Cart cart = new Models.Cart();
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {

                tmp_data.Clear();
                db.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);
                cart.id_user = id_user;
                tmp_data.Clear();
                db.UseSqlCommand("select shopping_cart.id, product.name,"+
	                                         " product.def_picture,"+
	                                         " shopping_cart.count,"+
	                                         " (product.price*shopping_cart.count) as price ,"+
                                             " discount.discount_price"+
	                                         " from shopping_cart inner join product on shopping_cart.id_product = product.id"+
                                             " left join discount on   product.id = discount.id_product"+
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(int _id_user)
        {
            DbConfig db = new DbConfig();
            Screening sr = new Screening();
            Models.Cart cart = new Models.Cart();
             cart.id_user = _id_user;
             cart.Set_Price();
             double total_price = cart.Get_TotalPrice();
             if(total_price == 0.0)
             {
                  return RedirectToAction("Cart", new RouteValueDictionary( 
                            new { controller = "User", action = "Cart"} ));
                
             }

             string str_price = ""+ total_price;
             str_price = str_price.Replace(',','.');
            

            List<List<string>> tmp_user_score = new List<List<string>>();
            db.UseSqlCommand("SELECT score from users WHERE users.id = " + cart.id_user,tmp_user_score);

            double u_score = Convert.ToDouble(tmp_user_score[0][0]);

            if(u_score -  total_price > 0)
            {
                db.UseSqlCommand("UPDATE users set score = score - " + str_price + " WHERE users.id = " + cart.id_user);

                db.UseSqlCommand("INSERT INTO deal (id_user, date_deal, total_price) "+
                                            " VALUES ("+cart.id_user+", now(), "+str_price+")");

                List<List<string>> tmp_data = new List<List<string>>();

                db.UseSqlCommand(" select  id   from deal " + 
                                        " where id_user = " + cart.id_user + 
                                        " order by id  desc  LIMIT 1 ",tmp_data);

                int id_deal = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();
                Console.WriteLine(id_deal);

                db.UseSqlCommand("select shopping_cart.id_product,shopping_cart.count,product.price "+
                                                " from shopping_cart  inner join product on shopping_cart.id_product = product.id " +
                                                " where shopping_cart.id_user = " + _id_user,tmp_data);

                    foreach(List<string> item in tmp_data)
                    {
                        int id_product = Convert.ToInt32(item[0]);
                        int count = Convert.ToInt32(item[1]);
                        string price = item[2].Replace(',','.');
                         db.UseSqlCommand("INSERT INTO deal_product(id_deal, id_product, count, price)"+
                                                "       VALUES ( "+id_deal+", "+id_product+"," + count
                                                 +", "+price+")");

                        for(int i =0;i<count;i++)  //i am here 
                        {
                            Guid guid_product = Guid.NewGuid();
                            
                           
                        

                        List<List<string>> tmp_dev = new List<List<string>>();
                        db.UseSqlCommand("SELECT developers.id from developers"+
                                                    " INNER JOIN product on developers.id = product.id_dev"+
                                                " WHERE product.id = " + id_product,tmp_dev);
                        int id_dev = Convert.ToInt32(tmp_dev[0][0]);
                        db.UseSqlCommand("UPDATE developers SET score = score + " + price);
                        
                                        

                        List<List<string>> tmp_this_deal_product = new List<List<string>>();
                        db.UseSqlCommand(" select  deal_product.id   from deal_product " +
                                        " where id_deal = " + id_deal+ 
                                        " order by id  desc  LIMIT 1 ",tmp_this_deal_product);

                        int deal_product = Convert.ToInt32(tmp_this_deal_product[0][0]);
                        db.UseSqlCommand("INSERT INTO baggage(id_user, id_deal_product) "+
                                                " VALUES ("+cart.id_user+", "+deal_product+")");
                        }

                    }
                
                db.UseSqlCommand("DELETE FROM shopping_cart where id_user = " + cart.id_user);

                return RedirectToAction("Index", new RouteValueDictionary( 
                            new { controller = "Home", action = "Index"} ));

            }
            else 
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));

            }
        }
       

        
        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult LogIn(string login ="", string password ="") 
        {
            DbConfig db = new DbConfig();
            Screening sr = new Screening();
           
            
            if(string.IsNullOrEmpty(login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 4} ));
            }
            else
            {
                List<List<string>> tmp_data = new List<List<string>>();
                tmp_data.Clear();
                db.UseSqlCommand("select id from users where login =  lower(" +sr.GetScr()+login+sr.GetScr()+") "+ 
                                    "AND  password = crypt(" + sr.GetScr() + password + sr.GetScr() + ", password)" ,tmp_data);
                if(tmp_data.Count ==0)
                {
                    return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 1} ));

                }
                else
                {

                    if(string.IsNullOrEmpty(password))
                    {
                        return RedirectToAction("Authorization", new RouteValueDictionary( 
                                new { controller = "Home", action = "Authorization", ex= 5} ));
                    }

                    

                    login =  login.ToLower();
                    HttpContext.Session.SetString("login",""+login);
                    HttpContext.Session.SetString("password",""+ password);
                }
                
            }
           
            
            return RedirectToAction("Profile", new RouteValueDictionary( 
                new { controller = "User", action = "Profile"   } ));
            
        }

        public IActionResult Profile() 
        {
            List<List<string>> tmp_data = new List<List<string>>();

            Screening sr  = new Screening();
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                db.UseSqlCommand("select id from users where login =  lower(" +sr.GetScr()+login+sr.GetScr()+")" ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);
           

                Models.User _user = new Models.User();
                _user.is_dev = false;
                List<List<string>> tmp_login = new List<List<string>>();
              
                
                
                List<List<string>> tmp = new List<List<string>>();
                db.UseSqlCommand("SELECT id,login,lvl,score,first_name,second_name,bonus_score,picture_profile "+
                                        " FROM users WHERE users.id = "+id_user ,tmp);
                if(tmp.Count()>0)
                {
                        _user.id_user= Convert.ToInt32(tmp[0][0]);
                        _user.login= Convert.ToString(tmp[0][1]);
                        _user.lvl= Convert.ToInt32(tmp[0][2]);
                        _user.score= Convert.ToDouble(tmp[0][3]);
                        _user.first_name = tmp[0][4];
                        _user.second_name= tmp[0][5];
                        _user.bonus_score = Convert.ToDouble(tmp[0][6]);
                        _user.picture_profile = tmp[0][7];
                        List<List<string>> tmp_u =  new List<List<string>>();
                        db.UseSqlCommand("SELECT name_of_company " +  
                                                    " FROM developers "+
                                                        " inner join user_dev on"+
                                                        " developers.id = user_dev.id_dev "+
                                                " WHERE user_dev.id_user = "+ _user.id_user,tmp_u);
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
            }

            return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
        }
        


        public IActionResult Library()//pagination need 
        {

            List<List<string>> tmp_data = new List<List<string>>();

            Screening sr  = new Screening();
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                db.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();
                db.UseSqlCommand("select deal_product.id, product.name, product.description,"+
                "  developers.name_of_company, deal.date_deal , product.def_picture " +
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
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                db.UseSqlCommand("select id from users where login = " +sr.GetScr()+login+sr.GetScr() ,tmp_data);
                int id_user = Convert.ToInt32(tmp_data[0][0]);
                List<List<string>> tmp_check = new List<List<string>>();
                db.UseSqlCommand("SELECT id_product from deal_product WHERE  deal_product.id =" + _id_deal_product,tmp_check);
                int id_product= Convert.ToInt32(tmp_check[0][0]);

                tmp_check.Clear();
                db.UseSqlCommand("SELECT id_deal_product " +
	                " from library inner join deal_product on  library.id_deal_product = deal_product.id "+
                    " WHERE  deal_product.id_product =" + id_product + " AND library.id_user =" + id_user,tmp_check);
                if(tmp_check.Count >0)
                {
                     return RedirectToAction("Baggage", new RouteValueDictionary( 
                        new { controller = "User", action = "Baggage", ex= 1} ));

                }
                else
                {
                    tmp_data.Clear();
                    db.UseSqlCommand("select deal_product.id, product.name, product.description, developers.name_of_company, deal.date_deal, deal_product.guid " +
                                        "  from deal inner join deal_product on deal.id = deal_product.id_deal " +
                                                        " inner join product on deal_product.id_product = product.id " +
                                                        " inner join developers on product.id_dev = developers.id " +
                                                        " inner join library on  deal_product.id = library.id_deal_product "+
                                        " WHERE deal_product.id = "+_id_deal_product+" AND  deal.id_user = " + id_user, tmp_data);


                    if(tmp_data.Count < 1)
                    {
                    db.UseSqlCommand("INSERT INTO  library( id_user, id_deal_product )"+
                            "  VALUES ( "+id_user+", "+_id_deal_product+")");  
                    db.UseSqlCommand("DELETE FROM baggage WHERE id_deal_product = " + _id_deal_product);
                    }
                    else 
                    {

                    }
                }
                
            }


            return RedirectToAction("Library", new RouteValueDictionary( 
                        new { controller = "User", action = "Library"} ));
        }


        public IActionResult YourSubscriptions(int numb_page = 0)
        {
           
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {
               
                tmp_data.Clear();
                db.UseSqlCommand("select id  from users where login = "+ sr.GetScr()+ login + sr.GetScr(),tmp_data);

                int id_user = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();

                Models.Edit subs = new Models.Edit();
                string _sql_com =  "SELECT  type_of_subscription.name, developers.name_of_company,"+
                                            " date_begin, date_end ,subscription_on_dev.id_dev"+
                    " FROM subscription_on_dev inner join type_of_subscription "+
                        " on subscription_on_dev.id_type = type_of_subscription.id "+
                        " inner join developers on subscription_on_dev.id_dev = developers.id " +
                    " WHERE subscription_on_dev.id_user = " + id_user +" OFFSET  "+(numb_page)*12 +" limit 12";
                
                subs = ShowPage.TakePages("subscription_on_dev WHERE id_user =" + id_user, _sql_com, numb_page, 12);

            
                ViewBag.Subs = subs;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                
                return View();
            }
        }
        
        public IActionResult Baggage(int ex = 0)//need pagination
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            Models.Cart cart = new Models.Cart();
            List<List<string >> tmp_data = new List<List<string>>();
            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                db.UseSqlCommand("select id  from users where login = "+ sr.GetScr()+ login + sr.GetScr(),tmp_data);

                int id_user = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();
                db.UseSqlCommand("select deal_product.id, product.name, product.description, "+
                                        " developers.name_of_company, deal.date_deal, product.def_picture,deal_product.guid " +
                                       "   from baggage inner join deal_product on baggage.id_deal_product = deal_product.id " +
                                                    " inner join deal on deal_product.id_deal = deal.id " + 
		                                            " inner join product on deal_product.id_product = product.id " +
		                                            " inner join developers on product.id_dev = developers.id " +
	                                   " WHERE deal.id_user = " + id_user, tmp_data);

                ViewBag.Baggage = tmp_data;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                ViewBag.Ex = ex;
                return View();
            }
        }

       

        
        public IActionResult SubToDev(int id_dev , int id_type_sub)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();

            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                db.UseSqlCommand("select id  from users where login = "+ sr.GetScr()+ login + sr.GetScr(),tmp_data);

                int id_user = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();

                List<List<string>> tmp_user_score = new List<List<string>>();
                db.UseSqlCommand("SELECT score from users WHERE users.id = " + id_user,tmp_user_score);
                double u_score = Convert.ToDouble(tmp_user_score[0][0]);

                tmp_data.Clear();

                

                db.UseSqlCommand("SELECT price from type_of_subscription WHERE type_of_subscription.id =" + id_type_sub, tmp_data);

                 double price_sub = Convert.ToDouble(tmp_data[0][0]);

                if(u_score - price_sub  > 0)
             {

                tmp_data.Clear();
                string _price_sub = "" + price_sub;
                _price_sub = _price_sub.Replace(',','.');


                db.UseSqlCommand("UPDATE users set score= score - " + _price_sub + " WHERE users.id =" + id_user);
                db.UseSqlCommand("UPDATE developers SET score = score + " + _price_sub);
                db.UseSqlCommand("INSERT INTO deal (id_user, date_deal, total_price) "+
                                            " VALUES ("+id_user+", now(), "+_price_sub+")");
                

                db.UseSqlCommand("SELECT date_end FROM subscription_on_dev " +
	                                    "WHERE   id = "+
                                        " (SELECT MAX(id) FROM subscription_on_dev "+
                                                " WHERE id_user = "+id_user+" AND id_dev = "+id_dev+" )",tmp_data);
                string last_date_end = "";
                if(tmp_data.Count > 0)
                {
                    last_date_end = tmp_data[0][0];
                   
                }
                tmp_data.Clear();
                db.UseSqlCommand("SELECT count_days from type_of_subscription WHERE id=" +id_type_sub,tmp_data );

                int count_days = Convert.ToInt32(tmp_data[0][0]);

                Sub_Date_Seting set_date = new Sub_Date_Seting(last_date_end,count_days);

                string date_begin = set_date.GetDate_Begin();
                string date_end = set_date.GetDate_End();

                db.UseSqlCommand("INSERT INTO subscription_on_dev(id_type, id_dev,id_user, date_begin, date_end) "+
	            " VALUES ( "+id_type_sub+", "+id_dev+","+id_user+", '"+date_begin+"', '"+date_end+"')");

                return RedirectToAction("YourSubscriptions", new RouteValueDictionary( 
                                new { controller = "User", action = "YourSubscriptions"} ));
             }
             else
             {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                         new { controller = "Home", action = "Index"} ));
             }
            }
        }

        public IActionResult SubToDev_View(int id_dev)
        {
            DbConfig db = new DbConfig();
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("select * from type_of_subscription", tmp_data);

            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words  = translate_words;

            ViewBag.Subscriptions = tmp_data;
            ViewBag.Id_dev = id_dev;
            return View();
        }
        
        
        public IActionResult UpdateInfo_page()
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
             List<List<string>> tmp_user = new List<List<string>>();
            db.UseSqlCommand("SELECT first_name,second_name,picture_profile FROM users "+ 
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_user);
            Models.User user = new Models.User();
            
            user.first_name = tmp_user[0][0];
            user.second_name =tmp_user[0][1];
            user.picture_profile = tmp_user[0][2];
            ViewBag.User_data = user;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInfo(string first_name, string second_name,  IFormFile u_file = null)
        {
            string filePath = "";
            string file_name="";
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            
            string _login = HttpContext.Session.GetString("login") ;

            if(_login == "")
            {
                  return RedirectToAction("Authorization", new RouteValueDictionary( 
                                new { controller = "Home ", action = "Profile"} ));

            }
            else
            {
                if(u_file != null)
                {
                    string [] type = u_file.FileName.Split('.');

                    type[1] = type[1].ToUpper();
                    if(( type[1] == "PNG")||( type[1] == "JPEG")||( type[1] == "JPG"))
                    {
                        string [] type_pic = u_file.FileName.Split('.');
                        Guid id_pic = Guid.NewGuid();
                        filePath = "wwwroot\\Pictures\\"+id_pic + "." + type_pic[1];
                        file_name = ""  +id_pic + "." + type_pic[1];

                        Console.WriteLine("2 -- -- -- "+ filePath  + " -- " + id_pic );
                        Bitmap myBitmap;
                        using (Stream  fs = new FileStream(filePath, FileMode.OpenOrCreate))
                            {
                                await u_file.CopyToAsync(fs);
                                Console.WriteLine(fs.Position  + "  ---  - - - -- " +  u_file.Length );
                                while(fs.Position != u_file.Length) {} // ожидание  загрузки изображения

                                myBitmap = new Bitmap(fs);
                                Console.WriteLine(myBitmap.Width + " -+_+-" + myBitmap.Height);
                            }

                        Image img = myBitmap;
                        int im_w = myBitmap.Width;
                        int im_h = myBitmap.Height;

                        if(im_w > im_h)
                        {
                            im_w = im_h;
                            im_h = (im_h *9)/10; 
                        }
                        else
                            im_h = (im_w *9)/10;

                        img = img.Crop(new Rectangle(0, 0,  im_w,  im_h));
                        img.Save(filePath);
                    }
                    else
                    {
                        return RedirectToAction("UpdateInfo_page", new RouteValueDictionary( 
                                new { controller = "User", action = "UpdateInfo_page"} )); 
                    }
                    db.UseSqlCommand("UPDATE users set first_name =  "+sr.GetScr()+first_name
                            +sr.GetScr()+" ,second_name = "+sr.GetScr()+second_name+sr.GetScr()+"," + 
                            "picture_profile = "+ sr.GetScr()+file_name+sr.GetScr() +
                            " WHERE users.login = "+sr.GetScr()+_login+sr.GetScr() );
                }
                else 
                {
                  
                db.UseSqlCommand("UPDATE users set first_name =  "+sr.GetScr()+first_name
                 +sr.GetScr()+" ,second_name = "+sr.GetScr()+second_name+sr.GetScr()+" " + 
                " WHERE users.login = "+sr.GetScr()+_login+sr.GetScr() );
                }
            }
           
            return RedirectToAction("Profile", new RouteValueDictionary( 
                                new { controller = "User", action = "Profile"} ));
        }

        public IActionResult SearchProduct( string name_product, int  numb_page = 0)
        {
            Check_discount.Check(_softspaceContext);
            
            HttpContext.Session.SetString("search_porduct_name","" + name_product);
            
            
            Models.ShopPage page = new Models.ShopPage();
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
         

            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("SELECT count(id) from product WHERE product.name ~* " 
                                    + sr.GetScr()  + name_product + sr.GetScr()  , tmp_data);
            if(tmp_data.Count > 0)
            {
                page.count_pages = Convert.ToInt32(tmp_data[0][0]) / ICOP.main;
                int items = Convert.ToInt32(tmp_data[0][0]);
                if((items % ICOP.main != 0)&&(items > ICOP.main))
                {
                   page.count_pages++;
                }
            }
            db.UseSqlCommand("SELECT product.id,product.name,price ,def_picture,discount_price "+
                    "FROM product left join discount  on product.id = discount.id_product  "+
                    " where  product.name ~* "+ sr.GetScr()  + name_product + sr.GetScr() +
                    "  order by  product.id  desc  OFFSET  " +
                    (numb_page)*ICOP.main +" limit "+ICOP.main,page.new_product);
            
            page.currect_number = numb_page;
            ViewBag.Page = page;
            ViewBag.NameProduct = name_product;
            List<string> words_translate = Language_Settings.GetWords(1);
            ViewBag.Words_translate = words_translate;
            return View();

            
        }
        public IActionResult ShowCategories( int numb_page = 0)
        {
            DbConfig db = new DbConfig();
            Check_discount.Check(_softspaceContext);
            
            Models.Edit categories = new Models.Edit();


            string _sql_com =  "SELECT  category.id , " + 
                               " category.name ," + 
                               " category.description,"+
                               " category.def_picture ," +
                               " count(product.id) " + 
                               "from category  left join product on category.id = product.id_category"+
                               " GROUP BY   category.id  ORDER BY   category.id  asc OFFSET  " + (numb_page)*ICOP.main +" limit "+ICOP.main ;
                
            
            categories = ShowPage.TakePages("category ",_sql_com,numb_page,ICOP.main);
            
            ViewBag.Categories = categories;
            List<string> words_translate = Language_Settings.GetWords(1);
            ViewBag.Translate_words = words_translate;
            return View();
        }

        public IActionResult OpenCategory(int id_cat, int numb_page)
        {
            DbConfig db = new DbConfig();

            List<List<string>> tmp_data = new List<List<string>>();

            db.UseSqlCommand("SELECT name FROM category WHERE id = "+ id_cat, tmp_data);

            ViewBag.NameCategory = tmp_data[0][0];
            Models.Edit product = new Models.Edit();

                string _sql_com =

                "SELECT product.id,product.name,price ,def_picture,discount_price "+
                        "FROM product left join discount  on product.id = discount.id_product  "+
                        " where  product.id_category = "+ id_cat +
                        "  order by  product.id  desc  OFFSET  " +
                        (numb_page)*ICOP.main +" limit "+ICOP.main ;


              

            product = ShowPage.TakePages("product WHERE product.id_category =  "+ id_cat,_sql_com,numb_page,ICOP.main);
           
            ViewBag.Page = product;
            ViewBag.Id_cat = id_cat;
            List<string> words_translate = Language_Settings.GetWords(1);
            ViewBag.Words_translate = words_translate;
            return View();
        }

        public IActionResult YourLiked(int numb_page = 0)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            Models.ShopPage page = new Models.ShopPage();
            string login = HttpContext.Session.GetString("login");
            List<List<string >> tmp_data = new List<List<string>>();

            if(string.IsNullOrEmpty( login))
            {
                return RedirectToAction("Authorization", new RouteValueDictionary( 
                        new { controller = "Home", action = "Authorization", ex= 0} ));
            }
            else
            {
                tmp_data.Clear();
                db.UseSqlCommand("select id  from users where login = "+ sr.GetScr()+ login + sr.GetScr(),tmp_data);

                int id_user = Convert.ToInt32(tmp_data[0][0]);
                tmp_data.Clear();

                Check_discount.Check(_softspaceContext);
            
                tmp_data.Clear();
                db.UseSqlCommand("SELECT count(product.id)  "+
                                 "from product inner join liked_product on product.id = liked_product.id_product " +
                                 "  WHERE liked_product.id_user =   " + id_user  , tmp_data);
                if(tmp_data.Count > 0)
                {
                    page.count_pages = Convert.ToInt32(tmp_data[0][0]) / ICOP.main;
                    int items = Convert.ToInt32(tmp_data[0][0]);
                    if((items % ICOP.main != 0)&&(items > ICOP.main))
                    {
                    page.count_pages++;
                    }
                }
                db.UseSqlCommand("SELECT product.id,product.name,price ,def_picture,discount_price "+
                        "FROM product left join discount  on product.id = discount.id_product  "+
                        " inner join liked_product on product.id = liked_product.id_product " + 
                        " where  liked_product.id_user = "+ id_user +
                        "  order by  product.id  desc  OFFSET  " +
                        (numb_page)*ICOP.main +" limit "+ICOP.main,page.new_product);
                
                page.currect_number = numb_page;
                ViewBag.Page = page;
               
                List<string> words_translate = Language_Settings.GetWords(1);
                ViewBag.Words_translate = words_translate;
                
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

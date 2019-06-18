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
using System.Drawing;
using System.Threading;

namespace SoftSpace_web.Controllers
{
    public class DevController : Controller
    {
        
        public IActionResult Index()
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("SELECT id from users WHERE login= "+
            sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr(),tmp_data);
            int id_user = Convert.ToInt32( tmp_data[0][0]);

            List<List<string>> tmp_dev = new List<List<string>>();
            db.UseSqlCommand("SELECT developers.id,developers.name_of_company,developers.score,developers.url_on_logo FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.id = "+sr.GetScr()+ id_user +sr.GetScr() ,tmp_dev);
            int id_dev = Convert.ToInt32(tmp_dev[0][0]);
            ViewBag.DesDev = tmp_dev;
            List<List<string>> tmp_count = new List<List<string>>();
            db.UseSqlCommand("SELECT count(product.id) FROM product WHERE id_dev =" + id_dev,tmp_count);
            int count_p = Convert.ToInt32(tmp_count[0][0]);
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            ViewBag.Count_p = count_p;
            return View();
        }

        
        public IActionResult ShowDev(int id_dev)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            List<List<string>> tmp_dev = new List<List<string>>();
            db.UseSqlCommand("SELECT id,name_of_company,url_on_logo,description  "+ 
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
            DbConfig db = new DbConfig();
            double price_for_open_dev = 1500;
            List<List<string>> tmp_data = new List<List<string>>();
            Screening sr = new Screening();

            db.UseSqlCommand("SELECT id from users WHERE login= "+
            sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr(),tmp_data);
            int id_user = Convert.ToInt32( tmp_data[0][0]);

            List<List<string>> tmp_user_score = new List<List<string>>();
            db.UseSqlCommand("SELECT score from users WHERE users.id = " + id_user,tmp_user_score);

            double u_score = Convert.ToDouble(tmp_user_score[0][0]);

            if(u_score -  price_for_open_dev > 0)
            {
            
                db.UseSqlCommand("UPDATE users set score= score - " + price_for_open_dev + " WHERE users.id =" + id_user);

                db.UseSqlCommand("INSERT INTO deal (id_user, date_deal, total_price) "+
                                            " VALUES ("+id_user+", now(), "+price_for_open_dev+")");
                

                db.UseSqlCommand("INSERT INTO developers (name_of_company)"+
                                    "VALUES("+sr.GetScr()+name+sr.GetScr()+")");
                tmp_data.Clear();
                db.UseSqlCommand("SELECT developers.id from developers WHERE name_of_company = "+sr.GetScr()+name +sr.GetScr(),tmp_data);

                int id_dev = Convert.ToInt32( tmp_data[0][0]);
                Console.WriteLine("Тут ид компании "+id_dev + " - user id = " + id_user);
                tmp_data.Clear();

                db.UseSqlCommand("INSERT INTO user_dev (id_user,id_dev) "+
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
            DbConfig db = new DbConfig();
            Screening sr = new Screening();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            db.UseSqlCommand("select user_dev.id  from user_dev "+
							   " inner join users on user_dev.id_user = users.id "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND user_dev.id_dev = "+id_dev+" ;",tmp_check_on_righted);
            if(tmp_check_on_righted.Count>0)
            {
                
                db.UseSqlCommand("delete from developers cascade where id = " + id_dev);
              
            }
            return RedirectToAction("Index", new RouteValueDictionary( 
                                new { controller = "Home", action = "Idex"} ));
        }
        

     


        public IActionResult AddProduct_View(int ex = 0)
        {
            DbConfig db = new DbConfig();
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("Select id,name from category",tmp_data);
            Console.WriteLine("++++++++ +++ ++ " +tmp_data[0][1] + " -- " + tmp_data.Count);

            ViewBag.List_category =  tmp_data;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            ViewBag.Ex = ex ;
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> AddProduct(  
                                        
                                        string name  , 
                                        string description ,
                                        int id_category  ,
                                        int type_product , 
                                        
                                        string price,
                                        string labels  = null,
                                        IFormFile u_file = null
                                        )
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string filePath = "";
            string file_name="";
           
            List<List<string>> tmp_check_product = new List<List<string>>();
            db.UseSqlCommand("SELECT id from product WHERE name = "+ sr.GetScr() + name + sr.GetScr(),tmp_check_product);
            if(tmp_check_product.Count > 0)
            {
                 return RedirectToAction("AddProduct_View", new RouteValueDictionary( 
                                new { controller = "Dev", action = "AddProduct_View", ex = 1} ));

            }
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

                                while(fs.Position != u_file.Length)
                                {

                                }
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

                        Console.WriteLine(im_w+" - -test-"+im_h);
                           
                        
                        img = img.Crop(new Rectangle(0, 0,  im_w,  im_h));
                        img.Save(filePath);
                    }
                    else
                    {
                        return RedirectToAction("YourProducts", new RouteValueDictionary( 
                                new { controller = "Dev", action = "YourProducts"} ));  // MB need redirect Add_View
                    }
                }
                else 
                {
                    file_name = "NaPicture.png";
                }

            
            
            List<List<string>> tmp_dev = new List<List<string>>();
            db.UseSqlCommand("SELECT id_dev FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_dev);
            
            if(tmp_dev.Count>0)
            {
                
                string _price = "" + price;
                _price = _price.Replace(',','.');
               
                int id_dev = Convert.ToInt32(tmp_dev[0][0]);
                bool is_dlc = false ;
                if (type_product == 1)
                {
                    is_dlc = true;
                }
                db.UseSqlCommand("INSERT INTO product("+
	            "name,description,id_dev, id_category, price,is_dlc, def_picture)"+
	            "VALUES ("  +sr.GetScr()+name+sr.GetScr()+","+
                            sr.GetScr()+description+sr.GetScr()+","+
                            id_dev+","+
                            id_category+","+
                            _price+" , "+
                            is_dlc +", "+ 
                            sr.GetScr()+file_name+sr.GetScr()+")");


                List<List<string>> tmp_data = new List<List<string>>();
                db.UseSqlCommand("SELECT product.id from product WHERE name = " +sr.GetScr()+name+sr.GetScr(),tmp_data);
                int id_product = Convert.ToInt32(tmp_data[0][0]);
                if(labels != null)
                {
                    string [] array_labels = labels.Split(",");
                    db.UseSqlCommand("Delete from label_product where id_product = "+id_product );
                    foreach(string a in array_labels)
                    {
                        db.UseSqlCommand("INSERT INTO label_product(id_product,label_name) "+
                        "VALUES ("+id_product+","+sr.GetScr()+a+sr.GetScr()+")");
                    }
                }

                
                
            }

            return RedirectToAction("YourProducts", new RouteValueDictionary( 
                                new { controller = "Dev", action = "YourProducts"} ));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelProduct(int id_product, int numb_page)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            db.UseSqlCommand("select product.id  from users inner join user_dev on users.id = user_dev.id_user "+
							   " inner join product on user_dev.id_dev = product.id_dev "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND product.id = "+id_product,tmp_check_on_righted); 
            if(tmp_check_on_righted.Count>0)
            {

                db.UseSqlCommand("delete from product cascade where id = " + id_product);
    
            }
            return RedirectToAction("YourProducts", new RouteValueDictionary( 
                                new { controller = "Dev", action = "YourProducts" , numb_page= numb_page} ));
        }

       
        
        public IActionResult YourProducts(int numb_page = 0)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            Check_discount.Check();
            List<List<string>> tmp_dev = new List<List<string>>();
            db.UseSqlCommand("SELECT id_dev FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_dev);
            int id_dev = Convert.ToInt32(tmp_dev[0][0]);
            

            Edit you_product = new Edit();
            string _sql_com = "SELECT product.id, product.name ,"+
            " product.price ,product.def_picture, product.is_dlc, discount.discount_price "+
            "  FROM product left join discount on product.id = discount.id_product " +
            "  WHERE product.id_dev="+id_dev + " order by  product.id  desc  OFFSET  "+(numb_page)*ICOP.your_p +" limit "+ICOP.your_p;

            you_product = ShowPage.TakePages("product  WHERE id_dev="+id_dev, _sql_com, numb_page,ICOP.your_p);

            ViewBag.You_product = you_product;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();

        }

        
        public IActionResult AddDlC_view(int id_product)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            List<List<string>> tmp_dev = new List<List<string>>();
            AddDLC addDLC = new AddDLC();
            db.UseSqlCommand("SELECT id_dev FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_dev);
            int id_dev = Convert.ToInt32(tmp_dev[0][0]);

            List<List<string>> your_dlcs = new List<List<string>>();
            db.UseSqlCommand("SELECT * FROM product WHERE is_dlc = true AND  id_dev="+id_dev,your_dlcs);
            addDLC.id_product = id_product;
            addDLC.dlcs = your_dlcs;
            ViewBag.AddDLC = addDLC;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words = translate_words;
            return View();
        }

        
        public IActionResult AddEvent_view (int id_product)
        {
            
            return View(id_product);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEvent (int _id_product , string name , string description)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
           
            db.UseSqlCommand("INSERT INTO event_product ( id_product, event_name, date_event , description )" + 
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
            DbConfig db = new DbConfig();
            db.UseSqlCommand("INSERT INTO  dlc_for_product (id_product, id_sub_product)"+
            " VALUES ("+_id_product+","+_id_dlc+")");
           
             return RedirectToAction("ShowProduct", new RouteValueDictionary( 
                        new { controller = "Product", action = "ShowProduct", id_product= _id_product} ));
        }
        

        
        public IActionResult UpdateInfo_page(int id_dev)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            db.UseSqlCommand("select user_dev.id  from user_dev "+
							   " inner join users on user_dev.id_user = users.id "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND user_dev.id_dev = "+id_dev,tmp_check_on_righted);
            if(tmp_check_on_righted.Count>0)
            {
                List<List<string>> tmp_team_info = new List<List<string>>(); 
                db.UseSqlCommand("select * from developers WHERE id="+id_dev,tmp_team_info); // XXX NEED COOL VIEW 
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
        public async Task< IActionResult> UpdateInfo(  
                                            string name ,     
                                            string description,
                                            string address,
                                            string mail,
                                            string phone,
                                            IFormFile u_file = null)
        {
           
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string filePath = "";
            string file_name="";
            string login = HttpContext.Session.GetString("login");
           

            List<List<string>> tmp_dev = new List<List<string>>();
            db.UseSqlCommand("SELECT id_dev FROM users "+ 
                    " inner join user_dev on users.id = user_dev.id_user "+ 
                    " inner join developers on user_dev.id_dev =  developers.id "+
                    " WHERE users.login = "+sr.GetScr()+HttpContext.Session.GetString("login")+sr.GetScr() ,tmp_dev);

            
            if(tmp_dev.Count>0)
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
                }
                else 
                {
                    file_name = "NaPicture.png";
                }

                 int id_dev = Convert.ToInt32(tmp_dev[0][0]);
              
                 db.UseSqlCommand("UPDATE developers set "+
                 "name_of_company  =  "+sr.GetScr()+    name            +sr.GetScr()+","+
                 "url_on_logo      =  "+sr.GetScr()+    file_name       +sr.GetScr()+","+
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

        

        
        public IActionResult EditProduct(int id_product)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();

            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("Select id,name from category",tmp_data);
            ViewBag.List_category =  tmp_data;

            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            db.UseSqlCommand("select product.id  from users inner join user_dev on users.id = user_dev.id_user "+
							   " inner join product on user_dev.id_dev = product.id_dev "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND product.id = "+id_product,tmp_check_on_righted); 
            if(tmp_check_on_righted.Count>0)
            {
                tmp_check_on_righted.Clear();

                List<List<string>> tmp          =    new List<List<string>>(); 
                List<List<string>> tmp_lalbels  =    new List<List<string>>(); 
               
                List<List<string>> tmp_events   =    new List<List<string>>();
               

                db.UseSqlCommand("SELECT label_name FROM label_product WHERE id_product = " + 
                                        id_product ,tmp_lalbels);
                
                db.UseSqlCommand("SELECT id,event_name FROM event_product WHERE  id_product = " +
                                        id_product  ,tmp_events);
                
               

                db.UseSqlCommand("SELECT name,description,price, def_picture, is_dlc ,id_category"+
                " FROM product  WHERE product.id = " + id_product ,tmp);
                Product you_product = new Product();

                you_product.id_product = id_product;
                you_product.name = tmp[0][0];
                you_product.description = tmp[0][1];
                you_product.price =  Convert.ToDouble(tmp[0][2]);
                
                you_product.def_picture = tmp[0][3];
               
                
                ViewBag.Id_Cat = tmp[0][5];

                foreach(var  a in tmp_lalbels)
                {
                    foreach(string label in a)
                    {
                        you_product.labels.Add(label);
                    }
                } 

                you_product.product_events = tmp_events;
                
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
        public  IActionResult AddDiscount( int id_product ,int discount, int count_days , int numb_page = 0 ,int type_op = 1)
        {
            Screening sr = new  Screening();
            DbConfig db = new DbConfig();
            List<List<string>> tmp_price = new List<List<string>>();
            db.UseSqlCommand("SELECT price FROM product WHERE id =" + id_product, tmp_price);
            double price = Convert.ToDouble(tmp_price[0][0]);
            price = price * (100 - discount)/100;

            string _price = "" + price;
            _price = _price.Replace(",",".");
            db.UseSqlCommand(" DELETE FROM discount WHERE id_product =" + id_product);
            db.UseSqlCommand(" INSERT INTO discount( " +
                " id_product, discount_price, date_begin, date_end) " +
                " VALUES ( "+ id_product + ", "+_price+", now() , now() + interval '"+count_days+" day'  )");

            
            
            if(type_op == 2)
            {
                 return RedirectToAction("ProductModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "ProductModeration",numb_page =numb_page } ));
            }
            else
            {
                 return RedirectToAction("YourProducts", new RouteValueDictionary( 
                                new { controller = "Dev", action = "YourProducts",numb_page =numb_page } ));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct_Save(
                                        int id_product,
                                        string name  , 
                                        string description ,
                                        int id_category  ,
                                        int type_product , 
                                        
                                        string price,
                                        string labels  = null,
                                        IFormFile u_file = null) 
                                               
        {
            DbConfig db = new DbConfig();
            Screening sr = new Screening();
            string filePath = "";
            string file_name="";

            string login = HttpContext.Session.GetString("login");
            List<List<string>> tmp_check_on_righted = new List<List<string>>(); 

            db.UseSqlCommand("select product.id  from users inner join user_dev on users.id = user_dev.id_user " +
							   " inner join product on user_dev.id_dev = product.id_dev "+
				   " where users.login= "+sr.GetScr()+login+sr.GetScr()+" AND product.id = "+id_product,tmp_check_on_righted); 
            if(tmp_check_on_righted.Count>0)
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
                    bool is_dlc = false ;
                    if (type_product == 1)
                    {
                        is_dlc = true;
                    }

                     db.UseSqlCommand("UPDATE product SET "+
                    "name   =  "+sr.GetScr()+name+sr.GetScr()+","+
                    "description      =  "+sr.GetScr()+description+sr.GetScr()+" ,"+
                    "id_category      = " + id_category + ", "+
                    "is_dlc           = " + is_dlc + ", " + 
                    "def_picture   =  "+sr.GetScr()+file_name+sr.GetScr()+" "+
                    " WHERE product.id= "+id_product );

                }
                else 
                {
                     bool is_dlc = false ;
                    if (type_product == 1)
                    {
                        is_dlc = true;
                    }

                    tmp_check_on_righted = null;
                    db.UseSqlCommand("UPDATE product SET "+
                    "name   =  "+sr.GetScr()+name+sr.GetScr()+","+
                    "description      =  "+sr.GetScr()+description+sr.GetScr()+" ,"+
                    "id_category      = " + id_category + ", "+
                    "is_dlc           = " + is_dlc + " " + 
                   
                    " WHERE product.id= "+id_product );
                }

            
                if(labels != null)
                    {
                        string [] array_labels = labels.Split(",");
                        db.UseSqlCommand("Delete from label_product where id_product = "+id_product );
                        foreach(string a in array_labels)
                        {
                            db.UseSqlCommand("INSERT INTO label_product(id_product,label_name) "+
                            "VALUES ("+id_product+","+sr.GetScr()+a+sr.GetScr()+")");
                        }
                    }
            }

            return RedirectToAction("YourProducts", new RouteValueDictionary( 
                  new { controller = "Dev", action = "YourProducts"} ));
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

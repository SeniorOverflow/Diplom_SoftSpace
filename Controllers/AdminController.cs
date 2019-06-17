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
using SoftSpace_web.Models;
using SoftSpace_web.Script;

namespace SoftSpace_web.Controllers
{
    public class AdminController : Controller
    {

        private bool IsNotJustUser()
        {
            if(String.IsNullOrEmpty(HttpContext.Session.GetString("roles")) == false)
            {
                    string [] str_roles = HttpContext.Session.GetString("roles").Split(","); //Load Roles

                    if(str_roles.Length > 1) 
                        return true;
            }
            
            return false;
        }
        
        
        public IActionResult Index()
        {
            DbConfig db = new DbConfig();
            
            if(IsNotJustUser())
            {
                string [] str_roles = HttpContext.Session.GetString("roles").Split(",");
                List<List<string>> tmp_roleId = new List<List<string>>();
                int max_abilities_role_id  = 0;
                int max_abilities = 0;
                
                foreach(string _role_id  in str_roles)
                {
                    tmp_roleId.Clear();
                    db.UseSqlCommand("SELECT id_abilities FROM role_abilities WHERE id_role =  " + _role_id,tmp_roleId);
                    if(tmp_roleId.Count > max_abilities)
                    {
                        max_abilities = tmp_roleId.Count ;
                        max_abilities_role_id = Convert.ToInt32(_role_id);  
                    }
                }


                List<string> words = Language_Settings.GetWords(1);
                List<List<string>> menu = new List<List<string>>();

                List<List<string>> tmp_data_id_abilities = new List<List<string>>();
                db.UseSqlCommand("SELECT id_abilities FROM role_abilities WHERE id_role = " + max_abilities_role_id, tmp_data_id_abilities);


                foreach(List<string> abilities in tmp_data_id_abilities)
                {

                    switch(Convert.ToInt32( abilities[0]))
                    {
                        case 1 : {  
                            menu.Add(new List<string> {words[9],       "Описание",  "CategoryModeration"});
                            break;
                        };
                        case 2 : { 
                            menu.Add(new List<string> {words[10],       "Описание", "DevModeration"});
                            break;
                        };
                        case 3 : { 
                            menu.Add(new List<string> {words[11],       "Описание", "ProductModeration"});
                            break;
                        };
                        case 4 : { 
                            menu.Add(new List<string> {words[12],       "Описание", "RoleModeration"});
                            break;
                        };
                        case 5 : { 
                            menu.Add(new List<string> {words[13],       "Описание", "SubModeration"});
                            break;
                        };

                        case 6 : { 
                            menu.Add(new List<string> {words[14],       "Описание", "TransactionModeration"});
                            break;
                        };

                        case 7 : { 
                            menu.Add(new List<string> {words[15],       "Описание", "UserModeration"});
                            break;
                        };
                        case 8 : { 
                            menu.Add(new List<string> {words[16],       "Описание", "CommentModeration"});
                            break;
                        };
                        case 9 : { 
                            menu.Add(new List<string> {words[33],       "Описание", "SubEdition"});
                            break;
                        };
                        default: break;
                    }
               
                }
                ViewBag.Menu = menu;
                ViewBag.ButtonWord = words[8];
                return View();
            }
            else
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));

            }
        }

        public IActionResult DevModeration(int numb_page = 0)
        {
           
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
               
                Edit dev = new Edit();
                string _sql_com = "Select id,name_of_company,description,mail,phone,score from developers OFFSET  "+(numb_page)*ICOP.a_dev +" limit " + ICOP.a_dev;
                dev = ShowPage.TakePages("developers",_sql_com,numb_page,ICOP.a_dev);

                ViewBag.Devs = dev;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelDev(int id_dev)
        {
            DbConfig db = new DbConfig();
            db.UseSqlCommand("Delete FROM developers WHERE id =" + id_dev);
             return RedirectToAction("DevModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "DevModeration"} ));
        }
        
        public IActionResult UserModeration(int numb_page = 0)
        {
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Edit users = new Edit();
                string _sql_com = "Select id,login,score FROM users OFFSET  "+(numb_page)*ICOP.a_users +" limit "+ICOP.a_users ;  
                users = ShowPage.TakePages("users",_sql_com,numb_page,ICOP.a_users);
                
                List<List<string>> tmp_roles_name = new List<List<string>>();
               
                DbConfig db = new DbConfig();
                List<List<string>> users_list = new List<List<string>>();
                

                foreach(List<string> a in users.list)
                {
                   string _roles = "";
                   tmp_roles_name.Clear();
                   db.UseSqlCommand("Select  roles.name FROM  user_role " + 
                                        "inner join roles on "+
                                        "user_role.id_role = roles.id  WHERE id_user = "+a[0],tmp_roles_name);
                    foreach(List<string> role_name in tmp_roles_name)
                    {
                        _roles += role_name[0] + "  "; 
                    }
                    
                   

                    a.Add(_roles);
                    
                   

                    users_list.Add(a);
                
                }
            users.list = users_list;

            foreach(List<string> t in users_list)
            {
                foreach(string g in t )
                {
                    Console.Write(g + "  -  " );
                }
                Console.WriteLine();
            }
               
                ViewBag.Users = users;
                ViewBag.User_roles = users_list;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
        }


        
        public IActionResult CommentModeration(int numb_page = 0)
        {
            string role = HttpContext.Session.GetString("role");
            List<List<string >> tmp_data = new List<List<string>>();
            int _role = Convert.ToInt32(role);
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Edit comments = new Edit();

                string _sql_com = "SELECT review.id, login, comment_to_product, assessment "+
                    "FROM users INNER JOIN review ON users.id = review.id_user OFFSET  "+(numb_page)*ICOP.a_reviews +" limit "+ICOP.a_reviews;
                comments = ShowPage.TakePages("review",_sql_com,numb_page,ICOP.a_reviews);

                ViewBag.Comments = comments;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();

            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelComments(int id_review,int numb_page)
        {
            DbConfig db = new DbConfig();

            db.UseSqlCommand("Delete FROM review WHERE id =" + id_review);
             return RedirectToAction("CommentModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "CommentModeration", numb_page = numb_page} ));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelUser(int id_user)
        {
            DbConfig db = new DbConfig();

            db.UseSqlCommand("Delete FROM users WHERE id =" + id_user);
             return RedirectToAction("UserModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "CommentModeration"} ));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlockUser(int id_user,int  _count , string cause)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            List<List<string>> tmp_data_now = new List<List<string>>();
            db.UseSqlCommand("Select extract(day from now()) , extract(month  from now()) , extract(year  from now())" ,tmp_data_now);
            int day = Convert.ToInt32(tmp_data_now[0][0]);
            int month = Convert.ToInt32(tmp_data_now[0][1]);
            int year = Convert.ToInt32(tmp_data_now[0][2]);


            if( _count >12)
            {
                int year_p = _count / 12;
                year+=year_p;
                _count = _count % 12;
            }

            if((_count + month )>12)
            {
                year++;
                month = (_count + month ) - 12;
            }

            Console.WriteLine(tmp_data_now[0][0]);


            db.UseSqlCommand("INSERT INTO block_user ( id_user, date_begin, date_end, cause ) "+
                                " VALUES ("+id_user+", now() ,"+sr.GetScr()+day+"-"+month+"-"+year+sr.GetScr()+","+sr.GetScr()+cause+sr.GetScr()+")");
             return RedirectToAction("UserModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "CommentModeration"} ));
        }
        
        

        
        public IActionResult ProductModeration(int numb_page = 0)
        {
            Check_discount.Check();
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                
                Edit product = new Edit();
                string _sql_com = "SELECT product.id , product.name , name_of_company, category.name "+
	                                    "FROM product inner join developers on product.id_dev = developers.id "+
		                                "inner join category on product.id_category = category.id OFFSET  "+(numb_page)*ICOP.a_products +" limit "+ICOP.a_products ;
                 
                product = ShowPage.TakePages("product",_sql_com,numb_page,ICOP.a_products);
                
                

                ViewBag.Products = product;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelProduct(int id_product)
        {
            DbConfig db = new DbConfig();
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {

                db.UseSqlCommand("Delete FROM product WHERE id =" + id_product);
                return RedirectToAction("ProductModeration", new RouteValueDictionary( 
                            new { controller = "Admin", action = "ProductModeration"} ));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveRoles(int id_user,int  numb_page)
        {
            DbConfig db = new DbConfig();
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {

                db.UseSqlCommand("DELETE FROM user_role WHERE id_user = "+ id_user+ " AND id_role != 1");
                return RedirectToAction("UserModeration", new RouteValueDictionary( 
                            new { controller = "Admin", action = "UserModeration" , numb_page = numb_page} ));
            }
        }
        

        
        public IActionResult EditCategory(int id_category)
        {
            DbConfig db = new DbConfig();
            Category category = new Category();
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("select * from category where id=" + id_category,tmp_data);
            category.id_category = Convert.ToInt32( tmp_data[0][0]);
            category.name= tmp_data[0][1];
            category.description = tmp_data[0][2];
            category.def_picture = tmp_data[0][3];
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> EditCategory_Save(
                                                            int         id_category,
                                                            string      name,
                                                            string      description,
                                                            IFormFile   u_file = null
                                                            )
        {
            DbConfig db = new DbConfig();
            Screening sr = new Screening();
            string filePath = "";
            string file_name="";

            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
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
                    db.UseSqlCommand("UPDATE category SET "+
                    "name   =  "+sr.GetScr()+name+sr.GetScr()+","+
                    "description      =  "+sr.GetScr()+description+sr.GetScr()+","+
                    "def_picture      =  "+sr.GetScr()+file_name+sr.GetScr()+" "+
                    " WHERE category.id= "+id_category );
                }
                else 
                {
                    db.UseSqlCommand("UPDATE category SET "+
                    "name   =  "+sr.GetScr()+name+sr.GetScr()+","+
                    "description      =  "+sr.GetScr()+description+sr.GetScr()+" "+
                    " WHERE category.id= "+id_category );
                }
                

                return RedirectToAction("CategoryModeration", new RouteValueDictionary( 
                    new { controller = "Admin", action = "CategoryModeration"} ));
            }
            
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelCategory(int id_category,int  numb_page)
        {
            DbConfig db = new DbConfig();
            
            Console.WriteLine(id_category);
            
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                
                db.UseSqlCommand("delete from category cascade where id = " + id_category);
                
            }
            return RedirectToAction("CategoryModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "CategoryModeration",numb_page = numb_page } ));
                                


           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory_View()
        {
             if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                return View();
            }
        }

       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(string name , string description, IFormFile u_file = null)
        {
            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            string filePath = "";
            string file_name="";
            
            
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
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
                }
                else 
                {
                    file_name = "NaPicture.png";
                }




                
                db.UseSqlCommand("INSERT INTO public.category(name, description, def_picture)"+
                " VALUES ("+sr.GetScr()+    name            +sr.GetScr()+
                        ","+sr.GetScr()+    description     +sr.GetScr()+
                        ","+sr.GetScr()+    file_name     +sr.GetScr()+")");
           
            }
            return RedirectToAction("CategoryModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "CategoryModeration"} ));


            
           
        }
        
        

        
        public IActionResult CategoryModeration(int numb_page = 0)
        {
           
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Edit category = new Edit();
                string _sql_com = "select * from category OFFSET "+(numb_page)*ICOP.a_category +" limit "+ICOP.a_category ;
                 
                category = ShowPage.TakePages("category",_sql_com,numb_page,ICOP.a_category);
                
                ViewBag.Categories = category;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
        }

        
        public IActionResult SubModeration(int numb_page = 0)
        {
             if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Edit sub = new Edit();
                string _sql_com = "select subscription_on_dev.id, users.login,type_of_subscription.name,type_of_subscription.price,developers.name_of_company,subscription_on_dev.date_end "+
                    " from subscription_on_dev inner join users on  subscription_on_dev.id_user = users.id "+
                    "                          inner join type_of_subscription on subscription_on_dev.id_type  = type_of_subscription.id "+
                    "                          inner join developers on subscription_on_dev.id_dev = developers.id   OFFSET "+(numb_page)*ICOP.a_sub +" limit "+ICOP.a_sub ;
                 
                sub = ShowPage.TakePages("subscription_on_dev",_sql_com,numb_page,ICOP.a_sub);
                
                

                ViewBag.Sub = sub;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
        }

        public IActionResult SubEdition(int numb_page = 0)
        {
             if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Edit sub = new Edit();
                string _sql_com = "select * from type_of_subscription OFFSET "+(numb_page)*ICOP.a_type_sub +" limit "+ICOP.a_type_sub ;
                 
                sub = ShowPage.TakePages("type_of_subscription",_sql_com,numb_page,ICOP.a_type_sub);
                
                ViewBag.Sub = sub;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;

                return View();
            }
        }
        
        public IActionResult AddSub_View()
        {
             if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddSub(string name, string description, string price)
        {
            DbConfig db = new DbConfig();
             if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++",price);
                 Screening sr = new Screening();
                 db.UseSqlCommand("INSERT INTO type_of_subscription( name, description, price)"+
                                        " VALUES ("+sr.GetScr() + name          + sr.GetScr()   +", "
                                                   +sr.GetScr() + description   + sr.GetScr()   +", "
                                                   +sr.GetScr() + price         + sr.GetScr()   +") ");

                 return RedirectToAction("SubEdition", new RouteValueDictionary( 
                  new { controller = "Admin", action = "SubEdition"} ));
            }
        }
        public IActionResult UpdateSub_View(int id_sub)
        {
            DbConfig db = new DbConfig();
             if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                List<List<string>> tmp_data = new List<List<string>>();
                db.UseSqlCommand("SELECT * FROM  type_of_subscription WHERE id="+id_sub,tmp_data);
                tmp_data[0][3] = tmp_data[0][3].Replace(',','.');
                ViewBag.Sub = tmp_data;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSub(int id_sub,string name, string count_days, string price)
        {
            DbConfig db = new DbConfig();
             if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                 Screening sr = new Screening();
                db.UseSqlCommand("UPDATE type_of_subscription " +
	                                        "SET  name="    +sr.GetScr() + name          + sr.GetScr()   +
                                            ", count_days="+sr.GetScr() + count_days   + sr.GetScr()   +
                                            ", price="      +sr.GetScr() + price         + sr.GetScr()   +
	                                    "WHERE id ="+ id_sub);

                 return RedirectToAction("SubEdition", new RouteValueDictionary( 
                  new { controller = "Admin", action = "SubEdition"} ));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelSub(int id_sub)
        {
            
            DbConfig db = new DbConfig();
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {

            db.UseSqlCommand("delete from type_of_subscription cascade where id = " + id_sub);
           
            }
            return RedirectToAction("SubEdition", new RouteValueDictionary( 
                                new { controller = "Admin", action = "SubEdition"} ));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelSubribe( int id_sub, int numb_page)
        {
            
            DbConfig db = new DbConfig();
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {

            db.UseSqlCommand("delete from subscription_on_dev  where subscription_on_dev.id = " + id_sub);
           
            }
            return RedirectToAction("SubModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "SubModeration" , numb_page = numb_page} ));

        }

        

        public IActionResult GiveRole_View( int id_role, int numb_page)
        {
            
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Edit users = new Edit();
                string _sql_com = "Select id,login,mail,lvl,score, bonus_score FROM users OFFSET  "+(numb_page)*ICOP.a_users +" limit "+ICOP.a_users ;
                users = ShowPage.TakePages("users",_sql_com,numb_page,ICOP.a_users);
                
                ViewBag.Users = users;
                ViewBag.Id_role = id_role; 
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GiveRole( int id_user, int id_role , int numb_page)
        {
            
            DbConfig db = new DbConfig();
            db.UseSqlCommand(" INSERT INTO user_role (id_user, id_role) " +
                                "VALUES("+id_user+","+id_role+")");

            
           
            return RedirectToAction("GiveRole_View", new RouteValueDictionary( 
                                new { controller = "Admin", action = "GiveRole_View" , numb_page = numb_page} ));

        }

      
        
        
        public IActionResult TransactionModeration(int numb_page = 0)
        {
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
               
                Edit transaction = new Edit();
                string _sql_com = "SELECT deal.id, users.login, date_deal,total_price"+
                " FROM deal inner join users on deal.id_user = users.id OFFSET "+(numb_page)*ICOP.a_trans +" limit "+ICOP.a_trans ;
                 
                transaction = ShowPage.TakePages("deal",_sql_com,numb_page,ICOP.a_trans);
                
                

                ViewBag.Data_deal = transaction;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTransaction(int id_transaction)
        {
            DbConfig db = new DbConfig();
            db.UseSqlCommand("DELETE from deal WHERE deal.id =" + id_transaction);
            return RedirectToAction("TransactionModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "TransactionModeration"} ));
        }
        

        //------------------------------------------Role
        public IActionResult RoleModeration(int numb_page = 0)
        {
           
            if(IsNotJustUser() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                
                Edit roles = new Edit();
                string _sql_com = "SELECT * from roles OFFSET "+(numb_page)*ICOP.a_roles +" limit "+ICOP.a_roles ;
                 
                roles = ShowPage.TakePages("roles",_sql_com,numb_page,ICOP.a_roles);
                
                ViewBag.Roles = roles;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRole(string name , string description , string [] check)
        {
            DbConfig db = new DbConfig();
            Screening sr = new Screening();
            
            foreach(string a in check)
            {
                Console.Write(a+" -- ");

            }
            Console.WriteLine();
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Admin", action = "Index"} ));
            }
            else
            {
                List<List<string>> tmp_data = new List<List<string>>();
               
                db.UseSqlCommand("Select * from roles WHERE name ="+sr.GetScr() + name + sr.GetScr(),tmp_data);

                if(tmp_data.Count>0)
                {
                    return RedirectToAction("AddRole_View", new RouteValueDictionary( 
                                new { controller = "Admin", action = "AddRole_View", ex = 1 } )); 
                }
                db.UseSqlCommand("INSERT INTO roles(name, description)"+
                " VALUES ("+sr.GetScr()+name+sr.GetScr()+","+sr.GetScr()+description+sr.GetScr()+")");

                tmp_data.Clear();
                db.UseSqlCommand("SELECT roles.id FROM roles WHERE roles.name =  "+ sr.GetScr() + name + sr.GetScr() , tmp_data);
                
                
                 foreach(string a in check)
                {
                    db.UseSqlCommand("INSERT INTO role_abilities(id_abilities, id_role) " + 
	                    "VALUES " + 
                        "(" + a + ", " + tmp_data[0][0]+ ")" );
                }

            }
            return RedirectToAction("RoleModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "RoleModeration" } )); 
        }

        
        public IActionResult AddRole_View(int ex =0)
        {
             if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                DbConfig db = new DbConfig();
                List<List<string>> tmp_abilities = new List<List<string>>();
                db.UseSqlCommand("SELECT * from abilities" , tmp_abilities);
                ViewBag.Ex = ex;
                ViewBag.Abilities = tmp_abilities;


                return View();
            }
        }

        
        public IActionResult EditRole(int id_role_users,int ex = 0)
        {
            DbConfig db = new DbConfig();
            Category category = new Category();
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("select * from roles where id=" + id_role_users,tmp_data);
            
            ViewBag.Role = tmp_data;
            ViewBag.Ex = ex;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRole_Save(int id_role_users,string name, string description)
        {

            Screening sr = new Screening();
            DbConfig db = new DbConfig();
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                 List<List<string>> tmp_data = new List<List<string>>();
               
                db.UseSqlCommand("Select * from roles WHERE name ="
                                        +sr.GetScr() + name + sr.GetScr()+" AND id != "+id_role_users,tmp_data);

                if(tmp_data.Count>0)
                {
                    return RedirectToAction("EditRole", new RouteValueDictionary( 
                                new { controller = "Admin", action = "EditRole", id_role_users = id_role_users,ex = 1 } )); 
                }
                    db.UseSqlCommand("UPDATE roles SET "+
                    "name   =  "+sr.GetScr()+name+sr.GetScr()+","+
                    "description      =  "+sr.GetScr()+description+sr.GetScr()+" "+
                    " WHERE roles.id= "+id_role_users );

                return RedirectToAction("RoleModeration", new RouteValueDictionary( 
                    new { controller = "Admin", action = "RoleModeration"} ));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelRole(int id_role_users)
        {
            DbConfig db = new DbConfig();
            
            if(IsNotJustUser() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
                db.UseSqlCommand("delete from roles cascade where id = " + id_role_users);
            
            return RedirectToAction("RoleModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "RoleModeration"} ));


           
        }
        //--------------------------------------------------------------ROLE





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

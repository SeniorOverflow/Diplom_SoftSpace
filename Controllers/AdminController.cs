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
    public class AdminController : Controller
    {

        private bool IsAdmin()
        {
            if(String.IsNullOrEmpty(HttpContext.Session.GetString("roles")) == false)
            {
                    string [] str_roles = HttpContext.Session.GetString("roles").Split(","); //Load Roles

                    foreach(string role in str_roles)
                    {
                        int _role = Convert.ToInt32(role);
                        if (_role == 2) return true;
                    }
            }
            
            return false;
        }
        
        
        public IActionResult Index()
        {
             if(IsAdmin() == false)
            {
                return RedirectToAction("Index", new RouteValueDictionary( 
                        new { controller = "Home", action = "Index"} ));
            }
            else
            {
                List<string> words = Language_Settings.GetWords(1);
                List<List<string>> menu = new List<List<string>>();
                menu.Add(new List<string> {words[9],       "Описание",  "CategoryModeration"});
                menu.Add(new List<string> {words[10],       "Описание", "DevModeration"});
                menu.Add(new List<string> {words[11],       "Описание", "ProductModeration"});
                menu.Add(new List<string> {words[12],       "Описание", "RoleModeration"});
                menu.Add(new List<string> {words[13],       "Описание", "SubModeration"});
                menu.Add(new List<string> {words[14],       "Описание", "TransactionModeration"});
                menu.Add(new List<string> {words[15],       "Описание", "UserModeration"});
                menu.Add(new List<string> {words[16],       "Описание", "CommentModeration"});
                menu.Add(new List<string> {words[33],       "Описание", "SubEdition"});
                ViewBag.Menu = menu;
                ViewBag.ButtonWord = words[8];
                return View();
            }
        }

        public IActionResult DevModeration(int numb_page = 0)
        {
           
            if(IsAdmin() == false)
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

            DbConfig.UseSqlCommand("Delete FROM developers WHERE id =" + id_dev);
             return RedirectToAction("DevModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "DevModeration"} ));
        }
        
        public IActionResult UserModeration(int numb_page = 0)
        {
            if(IsAdmin() == false)
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
            if(IsAdmin() == false)
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

            DbConfig.UseSqlCommand("Delete FROM review WHERE id =" + id_review);
             return RedirectToAction("CommentModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "CommentModeration", numb_page = numb_page} ));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelUser(int id_user)
        {

            DbConfig.UseSqlCommand("Delete FROM users WHERE id =" + id_user);
             return RedirectToAction("UserModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "CommentModeration"} ));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BlockUser(int id_user,int  _count , string cause)
        {
            Screening sr = new Screening();
            List<List<string>> tmp_data_now = new List<List<string>>();
            DbConfig.UseSqlCommand("Select extract(day from now()) , extract(month  from now()) , extract(year  from now())" ,tmp_data_now);
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


            DbConfig.UseSqlCommand("INSERT INTO block_user ( id_user, date_begin, date_end, cause ) "+
                                " VALUES ("+id_user+", now() ,"+sr.GetScr()+day+"-"+month+"-"+year+sr.GetScr()+","+sr.GetScr()+cause+sr.GetScr()+")");
             return RedirectToAction("UserModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "CommentModeration"} ));
        }
        
        

        
        public IActionResult ProductModeration(int numb_page = 0)
        {
            if(IsAdmin() == false)
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
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {

                DbConfig.UseSqlCommand("Delete FROM product WHERE id =" + id_product);
                return RedirectToAction("ProductModeration", new RouteValueDictionary( 
                            new { controller = "Admin", action = "ProductModeration"} ));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(int id_category)
        {
            Category category = new Category();
            List<List<string>> tmp_data = new List<List<string>>();
            DbConfig.UseSqlCommand("select * from category where id=" + id_category,tmp_data);
            category.id_category = Convert.ToInt32( tmp_data[0][0]);
            category.name= tmp_data[0][1];
            category.description = tmp_data[0][2];
            category.def_picture = tmp_data[0][3];
            ViewBag.Category = category;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory_Save(int id_category,string name, string description)
        {
            Screening sr = new Screening();
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                
                if(IsAdmin())
                {
                    DbConfig.UseSqlCommand("UPDATE category SET "+
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
            
            Console.WriteLine(id_category);
            
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                
                DbConfig.UseSqlCommand("delete from category cascade where id = " + id_category);
                
            }
            return RedirectToAction("CategoryModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "CategoryModeration",numb_page = numb_page } ));
                                


           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory_View()
        {
             if(IsAdmin() == false)
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
        public IActionResult AddCategory(string name , string description, string def_picture ="NaPicture2")
        {
            Screening sr = new Screening();
            
            
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                
                DbConfig.UseSqlCommand("INSERT INTO public.category(name, description, def_picture)"+
                " VALUES ("+sr.GetScr()+    name            +sr.GetScr()+
                        ","+sr.GetScr()+    description     +sr.GetScr()+
                        ","+sr.GetScr()+    def_picture     +sr.GetScr()+")");
           
            }
            return RedirectToAction("CategoryModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "CategoryModeration"} ));


            
           
        }
        
        

        
        public IActionResult CategoryModeration(int numb_page = 0)
        {
           
            if(IsAdmin() == false)
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
             if(IsAdmin() == false)
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
             if(IsAdmin() == false)
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
             if(IsAdmin() == false)
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
             if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++",price);
                 Screening sr = new Screening();
                 DbConfig.UseSqlCommand("INSERT INTO type_of_subscription( name, description, price)"+
                                        " VALUES ("+sr.GetScr() + name          + sr.GetScr()   +", "
                                                   +sr.GetScr() + description   + sr.GetScr()   +", "
                                                   +sr.GetScr() + price         + sr.GetScr()   +") ");

                 return RedirectToAction("SubEdition", new RouteValueDictionary( 
                  new { controller = "Admin", action = "SubEdition"} ));
            }
        }
        public IActionResult UpdateSub_View(int id_sub)
        {
             if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                List<List<string>> tmp_data = new List<List<string>>();
                DbConfig.UseSqlCommand("SELECT * FROM  type_of_subscription WHERE id="+id_sub,tmp_data);
                tmp_data[0][3] = tmp_data[0][3].Replace(',','.');
                ViewBag.Sub = tmp_data;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSub(int id_sub,string name, string description, string price)
        {
             if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                 Screening sr = new Screening();
                DbConfig.UseSqlCommand("UPDATE type_of_subscription " +
	                                        "SET  name="    +sr.GetScr() + name          + sr.GetScr()   +
                                            ", description="+sr.GetScr() + description   + sr.GetScr()   +
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
            
            
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {

            DbConfig.UseSqlCommand("delete from type_of_subscription cascade where id = " + id_sub);
           
            }
            return RedirectToAction("SubEdition", new RouteValueDictionary( 
                                new { controller = "Admin", action = "SubEdition"} ));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DelSubribe( int id_sub, int numb_page)
        {
            
            
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {

            DbConfig.UseSqlCommand("delete from subscription_on_dev  where subscription_on_dev.id = " + id_sub);
           
            }
            return RedirectToAction("SubModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "SubModeration" , numb_page = numb_page} ));

        }

      
        
        
        public IActionResult TransactionModeration(int numb_page = 0)
        {
            if(IsAdmin() == false)
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

            DbConfig.UseSqlCommand("DELETE from deal WHERE deal.id =" + id_transaction);
            return RedirectToAction("TransactionModeration", new RouteValueDictionary( 
                        new { controller = "Admin", action = "TransactionModeration"} ));
        }
        

        //------------------------------------------Role
        public IActionResult RoleModeration(int numb_page = 0)
        {
           
           
           
            if(IsAdmin() == false)
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
        public IActionResult AddRole(string name , string description)
        {
            Screening sr = new Screening();
            
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Admin", action = "Index"} ));
            }
            else
            {
                List<List<string>> tmp_data = new List<List<string>>();
               
                DbConfig.UseSqlCommand("Select * from roles WHERE name ="+sr.GetScr() + name + sr.GetScr(),tmp_data);

                if(tmp_data.Count>0)
                {
                    return RedirectToAction("AddRole_View", new RouteValueDictionary( 
                                new { controller = "Admin", action = "AddRole_View", ex = 1 } )); 
                }
                DbConfig.UseSqlCommand("INSERT INTO roles(name, description)"+
                " VALUES ("+sr.GetScr()+name+sr.GetScr()+","+sr.GetScr()+description+sr.GetScr()+")");
           
            }
            return RedirectToAction("RoleModeration", new RouteValueDictionary( 
                                new { controller = "Admin", action = "RoleModeration" } )); 
        }

        
        public IActionResult AddRole_View(int ex =0)
        {
             if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                ViewBag.Ex = ex;
                return View();
            }
        }

        
        public IActionResult EditRole(int id_role_users,int ex = 0)
        {
            Category category = new Category();
            List<List<string>> tmp_data = new List<List<string>>();
            DbConfig.UseSqlCommand("select * from roles where id=" + id_role_users,tmp_data);
            
            ViewBag.Role = tmp_data;
            ViewBag.Ex = ex;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRole_Save(int id_role_users,string name, string description)
        {
            Screening sr = new Screening();
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
            {
                 List<List<string>> tmp_data = new List<List<string>>();
               
                DbConfig.UseSqlCommand("Select * from roles WHERE name ="
                                        +sr.GetScr() + name + sr.GetScr()+" AND id != "+id_role_users,tmp_data);

                if(tmp_data.Count>0)
                {
                    return RedirectToAction("EditRole", new RouteValueDictionary( 
                                new { controller = "Admin", action = "EditRole", id_role_users = id_role_users,ex = 1 } )); 
                }
                    DbConfig.UseSqlCommand("UPDATE roles SET "+
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
            
            
            if(IsAdmin() == false)
            {
                 return RedirectToAction("Index", new RouteValueDictionary( 
                  new { controller = "Home", action = "Index"} ));
            }
            else
                DbConfig.UseSqlCommand("delete from roles cascade where id = " + id_role_users);
            
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

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
    public class UserController_cancel : Controller
    {

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRequest(int id_user_add, int numb_page = 0)
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

                DbConfig.UseSqlCommand("INSERT INTO public.social_interconnection( "+      
	                                    "id_user_first, id_user_second, id_social_status) " +
	                                    "VALUES ("+ id_user+", "+id_user_add+", 1)");
            }
             return RedirectToAction("ShowUsers", new RouteValueDictionary( 
                        new { controller = "User", action = "ShowUsers" , numb_page = numb_page} ));
        }
        public IActionResult SearchPeople( string name )
        {
            return View();
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

                string _sql_com = 
                " SELECT users.id,login,lvl " + 
                    " from users " +
                    " inner join social_interconnection on " + 
                        " users.id = social_interconnection.id_user_first " +
                    "WHERE social_interconnection.id_user_second = " + id_user +
                        " AND social_interconnection.id_social_status = 3 ";


                //string _sql_com2 = "Select id,login,mail,lvl FROM users WHERE users.id != "+id_user+" OFFSET  "+(numb_page)*12 +" limit 12" ;
                users = ShowPage.TakePages("users  WHERE users.id != " + id_user,_sql_com,numb_page,12);
                
                ViewBag.Users = users;
                List<string> translate_words = Language_Settings.GetWords(1);
                ViewBag.Translate_words  = translate_words;
                return View();
            }
            
        }
         public IActionResult Subscriptions()
        {
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
    }
}
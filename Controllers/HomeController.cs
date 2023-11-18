using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Npgsql;
using SoftSpace_web.Scripts;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using System.IO;

namespace SoftSpace_web.Controllers
{
    public class HomeController : Controller
    {   
        private readonly SoftspaceContext _softspaceContext;

        public HomeController(SoftspaceContext softspaceContext)
        {
            _softspaceContext = softspaceContext;
        }
        DbConfig db = new DbConfig();
        
         public IActionResult ShowCategory()
         { 
             var Categotyes = _softspaceContext.Categories.ToList();

             foreach (var VARIABLE in Categotyes)
             {
                 VARIABLE.Name += "*";

             }

           
            ViewBag.Categories = Categotyes;

            return View();
        }

         public IActionResult  DevShow(int id_dev )
        {
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("select * from developers WHERE id =" + id_dev,tmp_data);

           
            ViewBag.Dev = tmp_data;
            List<string> translate_words = Language_Settings.GetWords(1);
            ViewBag.Translate_words  = translate_words;

            return View();
        }

       
        public IActionResult Index( int numb_page = 0)
        {
            DbConfig db = new DbConfig();
            Models.ShopPage page = new Models.ShopPage();
            Check_discount.Check(_softspaceContext);
            

            HttpContext.Session.SetString("search_porduct_name","" );
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("SELECT count(id) from product ", tmp_data);
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
                    " where is_dlc = false  order by  product.id  desc  OFFSET  "+(numb_page)*ICOP.main +" limit "+ICOP.main,page.new_product);
            
            

            page.currect_number = numb_page;
            ViewBag.Page = page;
            List<string> words_translate = Language_Settings.GetWords(1);
            ViewBag.Words_translate = words_translate;
            return View();
        }

        [HttpGet]
        public IActionResult Authorization(int ex = 0)
        {
            int count =0;
             if(string.IsNullOrEmpty(HttpContext.Session.GetString("CountIn")))
            {
                HttpContext.Session.SetString("CountIn","0");
            }
            else
            {
                count = Convert.ToInt32( HttpContext.Session.GetString("CountIn"));
                count ++;
                HttpContext.Session.SetString("CountIn",""+count);
            }
             Models.Authorization data = new Models.Authorization();
            data.ex = ex;
            data.count = count;
            List<string> data_names_on_lg = Language_Settings.GetWords(1);
            ViewBag.Data_name = data_names_on_lg;
            ViewBag.AutoData = data;
            return View();
        }

        [HttpGet]
        public IActionResult LogOut() 
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Reg(int type = 0)
        {
            List<string> data_words = Language_Settings.GetWords(1);


            ViewBag.Data_name = data_words;
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
         public IActionResult Reg(string _mail ,string _login , string _password , string _password2)
        {
            DbConfig db = new DbConfig();

            if(_password != _password2 )
                return RedirectToAction("Reg",new {type  = 1});
            else
                {
                    if( _password.Length > 8)
                    {
                        Screening sr = new Screening();
                        List<List<string>> tmp1 = new List<List<string>>();
                        db.UseSqlCommand("Select id FROM users WHERE login =lower("+sr.GetScr()+_login+sr.GetScr()+")" ,tmp1);

                        if(tmp1.Count == 0)
                        {
                        Regex ex = new Regex("^[0-9A-Za-z]{1}[0-9A-Za-z_-]*@{1}[A-Za-z]+[.][A-Za-z]+$");
                        if(ex.IsMatch(_mail))
                        {
                            Console.WriteLine("Plus + + +");

                            tmp1.Clear();
                            db.UseSqlCommand("select id FROM users  where mail="+sr.GetScr()+_mail +sr.GetScr(),tmp1);

                            if(tmp1.Count != 0)
                            {
                                return RedirectToAction("Reg",new {type  = 3});
                            }
                        }
                        else
                        {
                            Console.WriteLine("Minus - - - ");

                            return RedirectToAction("Reg",new {type  = 4});
                        }
                        List<List<string>> tmp = new List<List<string>>();
                        
                        Console.WriteLine( sr.GetScr());
                        db.UseSqlCommand("INSERT INTO users(mail,login,password) " +
                                                        " VALUES "+
                                                        "       (" +sr.GetScr()+_mail     +sr.GetScr()+
                                                        " ,lower(" +sr.GetScr()+_login    +sr.GetScr()+ 
                                                        "),crypt(" +sr.GetScr()+_password +sr.GetScr()+", gen_salt('bf', 8)));",tmp);

                        return RedirectToAction("Authorization", new{ex  = 3});
                        }
                        else
                            return RedirectToAction("Reg",new {type  = 2});

                    }
                    else
                        return RedirectToAction("Reg",new {type  = 5});

                }
        }

        
        public IActionResult Download()
        {
            return View();
        }

        [HttpGet]
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

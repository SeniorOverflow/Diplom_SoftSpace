using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SoftSpace_web.Models;
using SoftSpace_web.Script;

namespace SoftSpace_web.Views.Components.Menu
{
    public class MenuViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Screening sr = new Screening();
            User user = new User();
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("login")))
            {
                user.types_user.Clear(); 
                user.types_user.Add(-1);
            }
            else
            {
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("roles")))
                {
                    string _login = HttpContext.Session.GetString("login");
                    List<List<string>> tmp = new List<List<string>>();
                    
                    DbConfig.UseSqlCommand("SELECT roles.id " +
                                            " from " +
                                                " users inner join user_role on users.id = user_role.id_user " +
                                                " inner join roles on user_role.id_role = roles.id " +
                                            " WHERE login = "+sr.GetScr() + _login +sr.GetScr() , tmp);

                    string role_ids ="0";
                    foreach(var str in tmp)
                        {
                            string data_roles = role_ids + ","+ str[0];
                            role_ids = data_roles;
                        }
                    Console.WriteLine(role_ids);

                    
                    if(tmp.Count>0)
                    {

                        HttpContext.Session.SetString("roles", role_ids); //Save Roles

                        List<int> _roles = new List<int>();
                        string [] str_roles = HttpContext.Session.GetString("roles").Split(","); //Load Roles
                        
                        foreach(string role in str_roles)
                        {
                            int _role = Convert.ToInt32(role);
                            _roles.Add(_role);
                        }
                        
                        user.types_user = _roles;
                        tmp.Clear();
                        
                    
                    }
                    else
                    {
                        user.types_user.Clear();
                        user.types_user.Add(-1);
                    }
                }
                else
                {
                    
                    string _login = HttpContext.Session.GetString("login");
                    List<List<string>> tmp_data = new List<List<string>>();
                   
                    DbConfig.UseSqlCommand("select id from users where login =" +sr.GetScr()+_login +sr.GetScr() ,tmp_data);
                    if(tmp_data.Count > 0)
                    {
                    int id_user = Convert.ToInt32(tmp_data[0][0]);
                    user.id_user = id_user;

                    tmp_data.Clear();
                    DbConfig.UseSqlCommand("select count(id) from  shopping_cart where id_user = " + user.id_user,tmp_data);
                        user.quantity_cart_places =Convert.ToInt32(tmp_data[0][0]);

                    
                    
                    List<int> _roles = new List<int>();
                    string [] str_roles = HttpContext.Session.GetString("roles").Split(","); //Load Roles
                        
                    foreach(string role in str_roles)
                        {
                            _roles.Add(Convert.ToInt32(role));
                        }
                
                

                    user.types_user = _roles;
                    }
                    else
                    {
                        user.types_user.Clear();
                        user.types_user.Add(-1);
                    }
                }
            }
            
                List<List<string>> tmp_dev = new List<List<string>>();
                
                DbConfig.UseSqlCommand("SELECT id_dev,name_of_company FROM users " +
                        " inner join user_dev on users.id = user_dev.id_user " +
                        " inner join developers on user_dev.id_dev =  developers.id " +
                        " WHERE users.login = "+sr.GetScr()+ HttpContext.Session.GetString("login") +sr.GetScr(), tmp_dev);

                if (tmp_dev.Count > 0)
                {
                    user.id_dev = Convert.ToInt32(tmp_dev[0][0]);
                    user.name_of_company = tmp_dev[0][1];
                }

                List<string> buttons_names = new List<string>();
                buttons_names = Language_Settings.GetWords(1);
                ViewBag.Bn_names = buttons_names;
                ViewBag.User = user;
            
            return View();
        }
    }
}
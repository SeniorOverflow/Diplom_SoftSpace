using System;
using System.Collections.Generic;
using System.Linq;
using Npgsql;
using SoftSpace_web.Models;
namespace  SoftSpace_web.Script
{
    static class   UnionList
    {
        
         public static List<List<string>> Union(List<List<string>> list_a = null , List<List<string>> list_b= null  )
        {
            List<List<string>> u_list = new List<List<string>>();

            if(list_a.Count == list_b.Count)
            {
               for(int i = 0; i< list_a.Count;i++)
               {
                   List<string> Item = new List<string>();
                   foreach( string f_l in list_a[i])
                   {
                       Item.Add(f_l);
                   }
                   foreach( string s_l in list_b[i])
                   {
                       Item.Add(s_l);
                   }
                   u_list.Add(Item);
               }
            }

            foreach(List<string> t in u_list)
            {
                foreach(string g in t )
                {
                    Console.Write(g + " , - , " );
                }
                Console.WriteLine();
            }
            
           
           return  u_list;
        }
        
    }
}
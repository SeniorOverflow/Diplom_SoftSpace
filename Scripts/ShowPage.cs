using System;
using System.Collections.Generic;
using Npgsql;
using SoftSpace_web.Models;
namespace  SoftSpace_web.Scripts
{
    static class   ShowPage
    {
        
        public static Edit TakePages(string name_table,string sql_com,int numb_page,int count_items_on_page )
        {
            DbConfig db = new DbConfig();
            Edit edit = new Edit();
            List<List<string>> tmp_data = new List<List<string>>();
            db.UseSqlCommand("SELECT count(id) from  " + name_table, tmp_data);
            Console.WriteLine(numb_page + " - " + name_table);
            if(tmp_data.Count > 0)
            {
                edit.count_pages = Convert.ToInt32(tmp_data[0][0]) / count_items_on_page;
                int items = Convert.ToInt32(tmp_data[0][0]);
                if((items % count_items_on_page != 0)&&(items > count_items_on_page))
                {
                   edit.count_pages++;
                }
            }

            db.UseSqlCommand(sql_com,edit.list);
            edit.currect_number = numb_page;
            
            return edit;
        }
        
    }
}
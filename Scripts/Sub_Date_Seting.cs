using System;
using System.Collections.Generic;
using Npgsql;
using SoftSpace_web.Models;
namespace  SoftSpace_web.Scripts
{
     class   Sub_Date_Seting
    {
        string begin_date;
        string end_date;
       
       

        public   Sub_Date_Seting(string date_end_last_sub, int count_days)
        {
             DbConfig db = new DbConfig();

            List<List<string>> tmp_data = new List<List<string>>();
            if(date_end_last_sub =="")
            {
                tmp_data.Clear();
                db.UseSqlCommand("Select now() - interval '30 day ' ",tmp_data);

                date_end_last_sub =tmp_data[0][0];
            }
            Console.WriteLine(date_end_last_sub);

            tmp_data.Clear();
            db.UseSqlCommand("SELECT now() >  '" +date_end_last_sub + "'" ,tmp_data);

            Console.WriteLine(tmp_data[0][0]);

            bool now_is_bigger = Convert.ToBoolean(tmp_data[0][0]);
            
            if(now_is_bigger)
            {
                tmp_data.Clear();
                db.UseSqlCommand("SELECT now() " , tmp_data);
                this.begin_date = tmp_data[0][0];

                tmp_data.Clear();
                db.UseSqlCommand("SELECT  now() + interval '"+count_days+" day'" , tmp_data);
                this.end_date = tmp_data[0][0];
            }
            else
            {
                tmp_data.Clear();
                db.UseSqlCommand("SELECT  '" +date_end_last_sub + "'::timestamp + interval '"+count_days+" day'" , tmp_data);
                this.begin_date =  date_end_last_sub;
                this.end_date = tmp_data[0][0];
            }

            

            Console.WriteLine( this.begin_date + " --- " + this.end_date);

        }

        public string GetDate_Begin () => this.begin_date;
        public string GetDate_End() => this.end_date;
    }
}
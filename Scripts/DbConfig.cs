using System;
using System.Collections.Generic;
using Npgsql;
namespace  SoftSpace_web.Script
{
     class   DbConfig
    {
        static NpgsqlConnection conn;
        public static void SetStringConnection(string unSaveStringConnection)
        {
                conn = new NpgsqlConnection(unSaveStringConnection);
        }
        public static void OpenConnection()
        {
            conn.Open();
        }
        public    void  UseSqlCommand(string _sqlCommand,List<List<string>> Mas = null) 
        {
            
            List<string> row = new List<string>();
            
            NpgsqlCommand command = new NpgsqlCommand(_sqlCommand, conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                int count = dr.FieldCount;
                row = new List<string>();
                for(int i =0 ; i< count ;i++)
                {
                    row.Add(dr[i].ToString());
                }
                
                Mas.Add(row);
            }
            dr.Close();
        }
        static void  CloseConnection()
        {
            conn.Close();
        }
    }
}
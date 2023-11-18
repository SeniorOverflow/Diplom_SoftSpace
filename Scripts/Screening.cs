using System;
using System.Collections.Generic;
using Npgsql;
namespace  SoftSpace_web.Scripts
{
     class   Screening
    {
       
        private string scr ;


        void SetScr()
        {
            Random rnd = new Random();
            long rnd_numb = rnd.Next(100000000,1000000000);
            this.scr = "$a" + rnd_numb + "a$";
        }

        public string GetScr() => this.scr;

        public Screening()
        {
            SetScr();
        }
        
    }
}
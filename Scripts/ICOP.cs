

using System;
using System.Collections.Generic;
using Npgsql;
namespace  SoftSpace_web.Script
{
    static class   ICOP
    {
      public static int main;
      public static int your_p;
      public static int a_category;
      public static int a_users;
      public static int a_trans;
      public static int a_dev;
      public static int a_roles;
      public static int a_sub;
      public static int a_type_sub;
      public static int a_reviews ;
      public static int a_products;


      public static void Initialization()
       {
          main = 8;
          your_p = 3;
          a_category  = 6;
          a_users     = 10;
          a_trans     = 10;
          a_dev       = 10;
          a_roles     = 10;
          a_sub       = 10;
          a_type_sub  = 10;
          a_reviews   = 10;
          a_products  = 10;

       }
    }
}
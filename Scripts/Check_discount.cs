using System.Collections.Generic;

namespace  SoftSpace_web.Script
{
    static class Check_discount
    {
        
            public static void Check()
                {
                    DbConfig db = new DbConfig();
                    List<List<string>> check_discount = new List<List<string>>();
                    db.UseSqlCommand("SELECT id from discount  WHERE discount.date_end < now()", check_discount);
                    if(check_discount.Count > 0)
                    {
                        db.UseSqlCommand("DELETE  from discount  WHERE discount.date_end < now()");
                    }
                }
        
    }
}



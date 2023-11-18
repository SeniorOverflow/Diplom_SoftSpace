using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace  SoftSpace_web.Scripts
{
    static class Check_discount
    {
        
            public static void Check(SoftspaceContext softspaceContext)
                {
                    //DbConfig db = new DbConfig();
                    
                    // List<List<string>> check_discount = new List<List<string>>();
                    // db.UseSqlCommand("SELECT id from discount  WHERE discount.date_end < now()", check_discount);
                    // if(check_discount.Count > 0)
                    // {
                    //     db.UseSqlCommand("DELETE  from discount  WHERE discount.date_end < now()");
                    // }\

                    var countEndDiscount = softspaceContext.Discounts.Where(x => x.DateEnd <= DateTime.Now).ExecuteDeleteAsync();
                    softspaceContext.SaveChangesAsync();
                }
        
    }
}



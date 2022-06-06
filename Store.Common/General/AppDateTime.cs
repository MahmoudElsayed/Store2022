using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Common
{
  public static  class AppDateTime
    {
       
        public static DateTime Now => DateTime.UtcNow.AddHours(2);
    }
}

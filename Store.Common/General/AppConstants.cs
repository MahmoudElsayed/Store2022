using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Common
{
  public  static class AppConstants
    {
        public static readonly object[] EmptyValues = { Guid.Empty, string.Empty, null };

        public struct Areas
        {

            public const string Guide = nameof(Guide);




        }
        public struct Messages
        {

            public const string SavedSuccess = "تمت عملية الحفظ بنجاح";
            public const string SavedFailed = "حدث خطا";

            public const string ThisFieldRequierd = "{0} مطلوب";
            public const string DeletedSuccess = "تم الحذف بنجاح";
            public const string DeletedFailed = "حدث خطا اثناء الحذف";
            public const string SendSuccess = "تم الارسال بنجاح";
            public const string StoreExists = "عنوان المقالة موجود من قبل";
            public const string TagExists = "اسم الوسم موجود من قبل";

            public const string TagNotDeleted = "اسم الوسم مربوط بمقالة او اكثر";

        }

    }
}

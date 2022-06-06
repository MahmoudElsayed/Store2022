using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Store.Web
{
    public class BaseController : Controller
    {
        public JsonResult JsonDataTable(int total, object data) => JsonDataTable(new DataTableResponse(total, data));

        public JsonResult JsonDataTable(DataTableResponse res) => Json(res);


     
    }
}

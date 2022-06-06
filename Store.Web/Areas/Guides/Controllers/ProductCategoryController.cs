using Microsoft.AspNetCore.Mvc;
using Store.BLL;
using Store.DTO.Guide;

namespace Store.Web.Area.Guides.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ProductCategoryBll _productCategoryBll;

        public ProductCategoryController(ProductCategoryBll productCategoryBll)
        {
            _productCategoryBll = productCategoryBll;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LoadDataTable(DataTableRequest mdl) => JsonDataTable(_productCategoryBll.LoadData(mdl));
        public IActionResult Update(ProductCategoryUpdateDTO mdl) => Ok(_productCategoryBll.Update(mdl));

    }
}

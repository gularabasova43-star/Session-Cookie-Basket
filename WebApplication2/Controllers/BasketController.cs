using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.ViewModels.BasketVMs;

namespace WebApplication2.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Add(int id)
        //{
        //    List<BasketVM> basketVMs;

        //      if(HttpContext.Request.Cookies["basket"] != null)
        //    {
        //        basketVMs=JsonConvert.DeserializeObject<List<BasketVM>>(HttpContext.Request.Cookies["basket"]);
        //    }
        //      else
        //    {
        //        basketVMs = new ();
        //    }
        //    basketVMs.Add(new BasketVM()
        //    {
        //        Id = id,
        //        Count = 1
        //    });
        //    HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketVMs));
        //    return RedirectToAction("Index", "Home");
        //}


        public async Task<IActionResult> Add(int id)
        {
            List<BasketVM> basketVMs;

            if (HttpContext.Request.Cookies["basket"] != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>
                    (HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            
            BasketVM existedProduct = basketVMs.FirstOrDefault(x => x.Id == id);

            if (existedProduct != null)
            {
              
                existedProduct.Count++;
            }
            else
            {
                
                basketVMs.Add(new BasketVM
                {
                    Id = id,
                    Count = 1
                });
            }

            HttpContext.Response.Cookies.Append(
                "basket",
                JsonConvert.SerializeObject(basketVMs)
            );

            return RedirectToAction("Index", "Home");
        }

    }
}

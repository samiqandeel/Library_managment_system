using library_management_system;
using Library_mangement_system.Models.Entitys;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.Models.IserviceesInterfasees;
using Library_mangement_system.Models.servicesClasses;
using Library_mangement_system.viewmodel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library_mangement_system.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly Icartservice _cartservice;
        private readonly Ibooksevice  _bookservice;
        private readonly IorderServise _orderservice;

        public CartController(Icartservice cartservice, Ibooksevice booksevice, AppDbContext context, IorderServise orderservice)
        {
            _cartservice = cartservice;
            _bookservice = booksevice;
            _orderservice = orderservice;
        }

        // مؤقّت للتست فقط


        [HttpGet]
        public IActionResult Addtocart (int id  , int quentity = 1)
        {
            var userid = User.Claims.FirstOrDefault(c => c.Type == (ClaimTypes.NameIdentifier))?.Value;

            _cartservice.AddToCart(userid, id, quentity);


            return RedirectToAction("index", "Books");


        }
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            List<CartItemViewModel> Cart = await _cartservice.GetCart(userid);
            return View(Cart);
        }

        public IActionResult ClearCart()
        {
            var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            _cartservice.ClearCart(id);

            return RedirectToAction("GetCart");
        }     

        public IActionResult Removefromcart(int bookid)
        {
            _cartservice.removeitembyid(bookid);
            return RedirectToAction("GetCart");
        }
        public IActionResult CountOfCart()
        {
           int count = _cartservice.Getcartcountitems();
           return Json(new { count });
        }

        
        public async Task<IActionResult> Checkout()
        {
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user_name = User.Identity.Name.ToString();
            if (userid == null)
            {
                return Unauthorized();
            }

            var cart = await _cartservice.GetCart(userid);

            if (cart == null || !cart.Any())
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction("GetCart");
            }

            await _orderservice.CreateOrder(userid, user_name ,cart);

            _cartservice.ClearCart(userid);

            TempData["Success"] = "Order placed successfully!";
            return RedirectToAction("MyOrder");
        }

        
        public async Task<IActionResult> MyOrder()
        {
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            //var myOrder = await _orderservice.GetOrderbyuserid(userid);

            var allOrders = await _orderservice.GetAllOrder();
            var myOrders = allOrders.Where(o => o.UserId == userid).OrderByDescending(o => o.OrderDate).ToList();

            return View(myOrders);
        }
    }
}

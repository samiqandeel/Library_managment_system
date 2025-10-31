using library_management_system;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.Models.IserviceesInterfasees;
using Library_mangement_system.Models.servicesClasses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library_mangement_system.Controllers
{
    public class OrderController : Controller
    {
        private readonly IorderServise _orderservice;
        private readonly Ibooksevice _bookservice;

        public OrderController(IorderServise orderservice, Ibooksevice booksevice)
        {
            _orderservice = orderservice;
            _bookservice = booksevice;
        }
        public async Task<IActionResult> MyOrders()
        {
            var allOrders = await _orderservice.GetAllOrder();
            return View(allOrders);
        }
        public async Task<IActionResult> OrderItems(int id)
        {
            var order = await _orderservice.GetOrderbyid(id);
            if (order == null) return NotFound();

            return View(order);
        }


    }
}

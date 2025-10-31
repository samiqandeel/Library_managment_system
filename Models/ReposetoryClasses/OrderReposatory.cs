using library_management_system;
using Library_mangement_system.Models.Entitys;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.viewmodel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library_mangement_system.Models.ReposetoryClasses
{
    public class OrderReposatory : IorderReposatory
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpcontextAccessor;


        public OrderReposatory(AppDbContext context, IHttpContextAccessor httpcontextAccessor)
        {
            _context = context;
            _httpcontextAccessor = httpcontextAccessor;
        }
        public async Task CreateOrder(string userid, string user_name, List<CartItemViewModel> cart)
        {
            if (cart == null || !cart.Any())
            {
                throw new Exception("Cart is Empty");
            }

            var order = new Order
            {
                UserId = userid,
                User_Name = user_name,
                OrderDate = DateTime.Now,
                TotalAmount = cart?.Sum(c => c.Quantity * c.Price) ?? 0
            };
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in cart)
            {
                var orderitem = new OrderItems
                {
                    OrderId = order.OrderId,
                    BookId = item.bookid,
                    Titel = item.Titel,
                    Quantity = item.Quantity,
                    Price = item.Price
                };
                await _context.OrderItems.AddAsync(orderitem);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return _context.Order
                   .Include(o => o.OrderItems)
                   .ThenInclude(b => b.Book).ToList();
        }
        public Task<Order> GetOrderbyid(int id)
        {
            return _context.Order
                   .Include(o => o.OrderItems)
                   .ThenInclude(b => b.Book)
                   .FirstOrDefaultAsync(o => o.OrderId == id)!;
        }

        public async Task<List<Order>> GetOrderbyuserid(string id)
        {
            return _context.Order
                 .Include(o => o.OrderItems)
                 .ThenInclude(b => b.Book).ToList();
                 
        }

      }
}

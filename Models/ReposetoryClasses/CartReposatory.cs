using library_management_system;
using Library_mangement_system.Models.Entitys;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.viewmodel;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace Library_mangement_system.Models.ReposetoryClasses
{
    public class CartReposatory : ICartReposatory
    {
        private readonly AppDbContext _context;

        //to be Access on sessoin from this calss
        private readonly IHttpContextAccessor _httpcontextAccessor;
        private const string CART_KEY = "Shopping Cart";

        public CartReposatory(AppDbContext dbcontext , IHttpContextAccessor httpcontextAccessor)
        {
            _context = dbcontext;
            _httpcontextAccessor = httpcontextAccessor;
        }
        public void AddToCart (string userid, int id, int quentity = 1)
        {
            // to be defined object from ISession
            var session = _httpcontextAccessor.HttpContext.Session;

            List<CartItems> cart = session.GetObject<List<CartItems>>(CART_KEY)
                                       ?? new List<CartItems>();

            CartItems item = cart.FirstOrDefault(i => i.BookId == id);
            if (item != null)
            {
                item.Quantity += quentity;

            }
            else
            {
                //ApplicationUser user = _context.Users.FirstOrDefault(u => u.Id == userid);
                
                CartItems newitem = new CartItems
                {
                    BookId = id,
                    Quantity = quentity
                };
                cart.Add(newitem);
            }
                session.SetObject(CART_KEY, cart);

        }
        public async Task<List<CartItemViewModel>> GetCart(string userid)
        {
            var session = _httpcontextAccessor.HttpContext.Session;

            List<CartItems> cart = session.GetObject<List<CartItems>>(CART_KEY)
                                      ?? new List<CartItems>();

            var result = new List<CartItemViewModel>();

            foreach (var item in cart)
            {
                var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == item.BookId);
                if (book != null)
                {
                    result.Add(new CartItemViewModel
                    {
                        bookid = book.Id ,
                        Titel = book.Title,
                        Price = book.Price,
                        Quantity = item.Quantity,
                        total = book.Price * item.Quantity 

                    });
                }
            }
            return result;

        }

        public void ClearCart(string userid)
        {
            var session = _httpcontextAccessor.HttpContext.Session;
            session.Remove(CART_KEY);
        }

        public void removeitembyid(int bookid)
        {
            var session = _httpcontextAccessor.HttpContext.Session;
            List<CartItems> cart = session.GetObject<List<CartItems>>(CART_KEY)!;

            CartItems this_item = cart.FirstOrDefault(i => i.BookId == bookid)!;

            if (this_item != null)
            {
                cart.Remove(this_item);
                session.SetObject(CART_KEY, cart);
            }
        }


        public int Getcartcountitems()
        {
            var session = _httpcontextAccessor.HttpContext.Session;
            List<CartItems> cart = session.GetObject<List<CartItems>>(CART_KEY) ?? new List<CartItems>(); ;

            int countOfitem = cart.Count();
            return countOfitem;

        }
    }
}

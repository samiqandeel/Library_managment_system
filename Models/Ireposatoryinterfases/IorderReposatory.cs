using Library_mangement_system.Models.Entitys;
using Library_mangement_system.viewmodel;

namespace Library_mangement_system.Models.Ireposatoryinterfases
{
    public interface IorderReposatory
    {
        public Task CreateOrder(string userid,string user_name, List<CartItemViewModel> cart);
        public Task<List<Order>> GetAllOrder();
        public Task<Order> GetOrderbyid(int id);
        public Task<List<Order>> GetOrderbyuserid(string id);
    }
}

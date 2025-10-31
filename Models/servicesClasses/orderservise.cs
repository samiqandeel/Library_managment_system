using Library_mangement_system.Models.Entitys;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.viewmodel;

namespace Library_mangement_system.Models.servicesClasses
{
    public class orderservise : IorderServise
    {
        private readonly IorderReposatory _repo;

        public orderservise(IorderReposatory repo)
        {
            _repo = repo;
        }
        public async Task CreateOrder(string userid, string user_name, List<CartItemViewModel> cart)
        {
            await _repo.CreateOrder(userid,user_name, cart);
            
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _repo.GetAllOrder();
        }

        public async Task<Order> GetOrderbyid(int id)
        {
            return await _repo.GetOrderbyid(id);
        }

        public async Task<List<Order>> GetOrderbyuserid(string id)
        {
            return await _repo.GetOrderbyuserid(id);
        }
    }
}

using Library_mangement_system.Models.Entitys;
using Library_mangement_system.Models.Ireposatoryinterfases;
using Library_mangement_system.Models.IserviceesInterfasees;
using Library_mangement_system.viewmodel;

namespace Library_mangement_system.Models.servicesClasses
{
    public class cartservice : Icartservice
    {
        private readonly ICartReposatory _repo;

        public cartservice(ICartReposatory cartrepo)
        {
            _repo = cartrepo;
        }
        public void AddToCart(string userid, int id, int quentity)
        {
            _repo.AddToCart(userid, id, quentity);
        }
        public async Task<List<CartItemViewModel>> GetCart(string userid)
        {
            return await _repo.GetCart(userid);
        }

        public void ClearCart(string userid)
        {
            _repo.ClearCart(userid);
        }

        public void removeitembyid(int bookid)
        {
            _repo.removeitembyid(bookid);
        }


        public int Getcartcountitems()
        {
            return _repo.Getcartcountitems();
        }

    }
}

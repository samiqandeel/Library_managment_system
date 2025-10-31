using Library_mangement_system.Models.Entitys;
using Library_mangement_system.viewmodel;

namespace Library_mangement_system.Models.IserviceesInterfasees
{
    public interface Icartservice
    {
            public void AddToCart(string userid, int bookid, int quentity);
            public Task<List<CartItemViewModel>> GetCart(string userid);
            public void ClearCart(string userid);
            public void removeitembyid(int bookid);
            public int Getcartcountitems();
        
    }
}

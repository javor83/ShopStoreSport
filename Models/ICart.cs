using ShopStoreSport.database;

namespace ShopStoreSport.Models
{
    public interface ICart
    {
        decimal Total();
        void Update(int pid, int qty);

        void Add(Product pid);

        void Remove(int pid);

        int Count();

        CartLineDTO ElementAt(int key);

        void Clear();

    }
}

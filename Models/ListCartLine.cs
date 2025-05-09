
using ShopStoreSport.database;
using System.Collections;

namespace ShopStoreSport.Models
{
    public class ListCartLine 
    {
        private List<CartLine> _cartLines = null;
        //*****************************************************************
        public decimal Total()
        {
            return _cartLines.Sum(x => x.Qty * x.Price);
        }

        public ListCartLine()
        {
            _cartLines = new List<CartLine>();
        }

        //*****************************************************************
        public void Update(int pid , int qty)
        {
            int pos = this._cartLines.FindIndex
              (
                  delegate (CartLine item)
                  {
                      return item.ID == pid;

                  }
              );
            if (pos != -1)
            {
                if (qty <= 0)
                {
                    this._cartLines.RemoveAt(pos);
                }
                else
                {
                    this._cartLines[pos].Qty = qty;
                }
            }
        }
        //*****************************************************************


        public void Add(Product pid)
        {
            int pos = this._cartLines.FindIndex
               (
                   delegate (CartLine item)
                   {
                       return item.ID == pid.Id;

                   }
               );
            if (pos == -1)
            {
                this._cartLines.Add
                    (
                    new CartLine()
                    {
                        ID = pid.Id,
                        Name = pid.Name,
                        Price = pid.Price,
                        Qty = 1
                    }
                    );
            }
            else
            {


                this._cartLines[pos].Qty += 1;

            }
        }
        //*****************************************************************
        public void Remove(int pid)
        {
            int pos = this._cartLines.FindIndex
               (
                   delegate (CartLine item)
                   {
                       return item.ID == pid;

                   }
               );
            if (pos > -1) {
                this._cartLines.RemoveAt(pos);
            }
        }
        //*****************************************************************
        public int Count()
        {
            return this._cartLines.Count();
        }
        //*****************************************************************
        public CartLine ElementAt(int key)
        {
            return this._cartLines.ElementAt(key);
        }


        //*****************************************************************
        public void Clear()
        {
            this._cartLines.Clear();
        }
       
        //*****************************************************************
    }
}

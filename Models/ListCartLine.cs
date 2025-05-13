
using ShopStoreSport.database;
using System.Collections;

namespace ShopStoreSport.Models
{
    public class ListCartLine
    {
        public List<CartLineDTO> _cartLines { get; set; } = new List<CartLineDTO>();
        //*****************************************************************
        public decimal Total()
        {
            return _cartLines.Sum(x => (x.Qty ?? 0) * x.Price);
        }
        //*****************************************************************
        public ListCartLine()
        {
           
        }

       


        //*****************************************************************
        public void Update(int pid , int qty)
        {
            int pos = this._cartLines.FindIndex
              (
                  delegate (CartLineDTO item)
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
                   delegate (CartLineDTO item)
                   {
                       return item.ID == pid.Id;

                   }
               );
            if (pos == -1)
            {
                this._cartLines.Add
                    (
                    new CartLineDTO()
                    {
                        ID = pid.Id,
                        Qty = 1,
                        Price = pid.Price,
                        Name = pid.Name
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
                   delegate (CartLineDTO item)
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
        public CartLineDTO this[int key]
        {
            get
            {
                return this._cartLines[key];
            }
                 
        }

        //*****************************************************************
        public void Clear()
        {
            this._cartLines.Clear();
        }
        

        //*****************************************************************
    }
}

using System.Text.Json;

namespace ShopStoreSport.Models
{
    public static class ExtMethods
    {

        //*************************************************************************
        public static void SetJson
            (
            this ISession session,
           
            ListCartLine value
            )
        {

            int x1 = value.Count();

            string x = JsonSerializer.Serialize<ListCartLine>(value);



            session.SetString("cart",x);
        }
        //*************************************************************************
        public static ListCartLine GetJson
            (
            this ISession session
            )
        {
            ListCartLine result = null;
            string? json = session.GetString("cart");
            if (string.IsNullOrEmpty(json) == false)
            {
                result = JsonSerializer.Deserialize<ListCartLine>(json);
            }
            else
            {
                result = new ListCartLine();
            }
             
            return result;
        }


        //*************************************************************************
        public static bool Empty<T>(this IEnumerable<T> list)
        {
            return list.Count() == 0;
        }
        //*************************************************************************
        public static string ToMoney<T>(this T list)
        {
            return string.Format("{0:C2}", list);
        }
        //*************************************************************************
        public static string HTMLImgProduct(this string? key)
        {
            string result = "";
            if (string.IsNullOrEmpty(key))
            {
                result = $"./preview/noimage.jpg";
            }
            else
            {
                result = $"./preview/{key}";
            }
            return result;
        }
        //*************************************************************************
    }
}

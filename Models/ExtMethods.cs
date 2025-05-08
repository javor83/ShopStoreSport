namespace ShopStoreSport.Models
{
    public static class ExtMethods
    {
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

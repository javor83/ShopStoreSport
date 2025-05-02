namespace ShopStoreSport.DTO
{
    public static class ExtMethods
    {
        public static bool Empty<T>(this IEnumerable<T> list)
        {
            return list.Count() == 0;
        }

        public static string ToMoney<T>(this T list)
        {
            return string.Format("{0:C2}", list);
        }
    }
}

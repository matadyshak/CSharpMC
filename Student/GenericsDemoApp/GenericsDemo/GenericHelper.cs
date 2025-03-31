using UIHelperLibrary;

namespace GenericsDemo
{
    public class GenericHelper<T> where T : class, IErrorCheck, IPrintable
    {
        public string ConvertToString(T item)
        {
            return item.ToString();
        }
        public void GenericPrint(T item)
        {
            item.Print();
        }
    }
}

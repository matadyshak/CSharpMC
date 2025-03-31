namespace UIHelperLibrary
{
    // This is the class definition for when the class is NOT generic but only the method is generic
    //public class GenericToString
    //{
    //    public string ConvertToString<T>(T item)
    //    {
    //        return item.ToString();
    //    }
    //}
    public interface IErrorCheck
    {
        bool HasError { get; set; }
    }
    public interface IPrintable
    {
        void Print();
    }
}

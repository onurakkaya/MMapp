namespace MMapp
{
    public interface IMappable<To> where To : class
    {
        IMappable<To> Map(To item);
    }
}
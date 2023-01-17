namespace IMDB
{
    public interface IIMDBSearch
    {
        IEnumerable<string> GetShortCodes();
        IEnumerable<string> GetTVCodes();
    }
}
using SQLite.Net.Interop;

namespace XConceptThree.Classes
{
    public interface IConfig
    {
        string DirectoryDB { get; }

        ISQLitePlatform Platform { get; }

    }
}

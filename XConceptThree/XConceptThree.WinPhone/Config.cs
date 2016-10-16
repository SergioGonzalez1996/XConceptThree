using SQLite.Net.Interop;
using XConceptThree.Classes;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(XConceptThree.WinPhone.Config))]

namespace XConceptThree.WinPhone
{
    public class Config : IConfig
    {
        private string directoryDB;
        private ISQLitePlatform platform;

        public string DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    directoryDB = ApplicationData.Current.LocalFolder.Path;
                }
                return directoryDB;
            }
        }

        public ISQLitePlatform Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                }
                return platform;
            }
        }
    }
}

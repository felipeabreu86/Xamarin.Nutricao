using Nutricao.iOS;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_ios))]
namespace Nutricao.iOS
{
    public class SQLite_ios : ISqlite
    {
        public SQLite_ios()
        { }

        public SQLiteConnection GetConnecticon()
        {
            var fileName = "Refeicoes.db3";
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documents, "..", "Library", fileName);
            return new SQLiteConnection(path);
        }
    }
}

using Nutricao.Droid;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_android))]
namespace Nutricao.Droid
{
    public class SQLite_android : ISqlite
    {
        public SQLite_android()
        { }

        public SQLiteConnection GetConnecticon()
        {
            var fileName = "Refeicoes.db3";
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documents, fileName);
            return new SQLiteConnection(path);
        }
    }
}
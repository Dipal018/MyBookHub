using System;
using System.IO;
using MyBookHub.Data.Data.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace MyBookHub.Data.Data.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android()
		{
		}

		public SQLite.SQLiteConnection GetConnection()
		{
			var sqliteFilename = "BookHubDB.db3";
			// string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
			string documentsPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;
		}
	}
}

using SQLite;
using System;

namespace Notes.Models
{
	public class DBModel
	{
		public static SQLiteConnection DBPath()
		{
			return new SQLiteConnection(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"/NotesDataBase.sqlite");
		}
	}
}

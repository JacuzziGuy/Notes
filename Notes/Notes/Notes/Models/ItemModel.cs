using SQLite;

namespace Notes.Models
{
	[Table("ItemModel")]
	public class ItemModel
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Note { get; set; }
	}
}

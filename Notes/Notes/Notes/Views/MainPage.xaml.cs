using System;
using System.Collections.ObjectModel;
using SQLite;
using Notes.Models;
using Xamarin.Forms;

namespace Notes.Views
{
	public partial class MainPage : ContentPage
	{
		#region Variables

		SQLiteConnection db = DBModel.DBPath();
		ObservableCollection<ItemModel> items = new ObservableCollection<ItemModel>();

		#endregion
		public MainPage()
		{
			InitializeComponent();
			InitDB();
			InitList();
		}
		private void InitDB()
		{
			try
			{
				items = new ObservableCollection<ItemModel>(db.Query<ItemModel>("SELECT * FROM ItemModel"));
			}
			catch
			{
				db.CreateTable<ItemModel>();
			}
		}
		private void InitList()
		{
			notesList.ItemsSource = items;
			title.Text = "";
			note.Text = "";
			title.Completed += TitleCompleted;
			note.Completed += NoteCompleted;
			notesList.ItemTapped += ItemTapped;
		}

		private void ItemTapped(object sender, EventArgs e)
		{
			ItemModel item = notesList.SelectedItem as ItemModel;
			DisplayAlert(item.Title, item.Note, "OK");
			notesList.SelectedItem = null;
		}
		private void TitleCompleted(object sender, EventArgs e)
		{
			if (note.Text == "" && title.Text != "")
				note.Focus();
		}
		private void NoteCompleted(object sender, EventArgs e)
		{
			if (note.Text != "" && title.Text != "")
				AddItem();
		}
		private void SubmitClicked(object sender, EventArgs e)
		{
			AddItem();
		}
		private void DeleteClicked(object sender, EventArgs e)
		{
			ItemModel item = (sender as Button).BindingContext as ItemModel;
			items.Remove(item);
			db.Delete(item);
		}
		private void AddItem()
		{
			if (title.Text != "" && note.Text != "")
			{
				ItemModel item = new ItemModel { Title = title.Text, Note = note.Text };
				items.Add(item);
				db.Insert(item);
				title.Text = "";
				note.Text = "";
			}
			else
			{
				DisplayAlert("UWAGA!", "Uzupełnij brakujące pola.", "OK");
			}
		}
	}
}

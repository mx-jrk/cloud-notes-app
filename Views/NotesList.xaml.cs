namespace Cloud_Notes_App.Views;

public partial class NotesList : ContentPage
{
	public NotesList()
	{
		InitializeComponent();

		BindingContext = new Models.NotesList();
	}

    //Loading Notes Collection
    protected override void OnAppearing()
    {
        ((Models.NotesList)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(NotePage)}");
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var note = (Models.Note)e.CurrentSelection[0];

            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FileName}");

            notesCollection.SelectedItem = null;
        }
    }
}
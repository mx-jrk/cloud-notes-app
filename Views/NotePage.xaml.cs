namespace Cloud_Notes_App.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage
{

    private string itemId;
    public string ItemId
    {
        get { return itemId; }
        set
        {
            itemId = value;
            LoadNote(value);
        }
    }
    public NotePage()
	{
        InitializeComponent();
        

        string randomFileName = $"{Path.GetRandomFileName()}.note.txt";

        LoadNote(Path.Combine(FileSystem.AppDataDirectory, randomFileName));


    }

    private void LoadNote(string fileName)
    {
        Models.Note note = new Models.Note();
        note.FileName = fileName;
        
        if (File.Exists(fileName))
        {
            string[] file_content = File.ReadAllText(fileName).Split('\n' + "!--The_end_of_Title--!" + '\n');
            note.Date = File.GetCreationTime(fileName);
            note.Title = file_content[0];
            note.Text = file_content[1];
        }

        BindingContext = note;
    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (this.FindByName<Editor>("TitleEditor").Text == null || this.FindByName<Editor>("TextEditor").Text == null) return;
        if (BindingContext is Models.Note note)
        {
            File.WriteAllText(note.FileName, this.FindByName<Editor>("TitleEditor").Text.ToString() + '\n' + "!--The_end_of_Title--!" + '\n' + this.FindByName<Editor>("TextEditor").Text.ToString());
        }
        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (this.FindByName<Editor>("TitleEditor").Text == null || this.FindByName<Editor>("TextEditor").Text == null) return;
        bool dont_delete = await DisplayAlert("Подтверждение", "Вы уверены, что хотите выполнить это действие?", "Нет", "Да");

        if (dont_delete) return;
        if (BindingContext is Models.Note note && File.Exists(note.FileName))
            File.Delete(note.FileName);

        this.FindByName<Editor>("TitleEditor").Text= string.Empty;
        this.FindByName<Editor>("TextEditor").Text = string.Empty;

        await Shell.Current.GoToAsync("..");
    }

}
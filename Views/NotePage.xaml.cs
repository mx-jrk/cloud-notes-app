namespace Cloud_Notes_App.Views;

public partial class NotePage : ContentPage
{
    string fileName = Path.Combine(FileSystem.AppDataDirectory, "note.txt");
    public NotePage()
	{
		InitializeComponent();
        if (File.Exists(fileName))
        {
            string[] file_content = File.ReadAllText(fileName).Split('\n');

            this.FindByName<Editor>("TitleEditor").Text = file_content[0];
            this.FindByName<Editor>("TextEditor").Text = file_content[1];
        }
            
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(fileName, this.FindByName<Editor>("TitleEditor").Text.ToString() + '\n' + this.FindByName<Editor>("TextEditor").Text.ToString());
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(fileName))
            File.Delete(fileName);

        this.FindByName<Editor>("TitleEditor").Text= string.Empty;
        this.FindByName<Editor>("TextEditor").Text = string.Empty;

    }

}
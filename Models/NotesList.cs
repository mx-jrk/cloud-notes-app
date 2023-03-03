using System.Collections.ObjectModel;

namespace Cloud_Notes_App.Models
{
    internal class NotesList
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        public NotesList() {
            LoadNotes();
        }
        public void LoadNotes() {
            Notes.Clear();

            //Load files from local memory (LINQ)
            IEnumerable<Note> Notes_from_Dir = Directory
                //Select only files containing the key fragment "...note.txt"
                .EnumerateFiles(FileSystem.AppDataDirectory, "*.note.txt")
                //Create new Note from file
                .Select(filename =>
                {
                    var note = new Note()
                    {
                        FileName = filename,
                        Date = File.GetCreationTime(filename),
                        Title = File.ReadAllText(filename).Split('\n' + "!--The_end_of_Title--!" + '\n')[0],
                        Text = File.ReadAllText(filename).Split('\n' + "!--The_end_of_Title--!" + '\n')[1],
                    };
                        note.get_reduced();
                        return note;
                    })
                //Sorted by Date
                .OrderBy(note => note.Date);

            //Add Notes to collection
            foreach (Note note in Notes_from_Dir)
                Notes.Add(note);
        }
    }
}

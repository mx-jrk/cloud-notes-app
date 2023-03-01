    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Cloud_Notes_App.Models
    {
        internal class Note
        {
            public string FileName { get; set; }
            public string Title { get; set; }
            public string Title_reduced { get; set; }   
            public string Text { get; set; }

            public string Text_reduced { get; set; }

            public DateTime Date { get; set; }
            public Note()
            {
                Title_reduced = "";
                Text_reduced = "";
            }
        public void get_reduced()
            {
                if (Title.Length > 20) Title_reduced = Title.Substring(0, 20) + "...";
                else Title_reduced = Title;

                if (Text.Length > 50) Text_reduced = Text.Substring(0,35) + "...";
                else Text_reduced= Text;
            }


        }
    }

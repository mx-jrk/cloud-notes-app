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
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

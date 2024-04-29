using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSongbook
{
    public class Song
    {
        public int SongID { get; set; }
        public string Title { get; set; } = "***";
        public string Lyrics { get; set; } = string.Empty;
        public string Chords { get; set; } = string.Empty;
    }
}

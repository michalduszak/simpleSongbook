using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleSongbook
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        SongContext songContext;
        Song songToEdit;
        public Edit(Song songToEditPassed)
        {
            songContext = new SongContext();
            songToEdit = songToEditPassed;
            InitializeComponent();
            editLyrics.Text = songToEditPassed.Lyrics;
            editChords.Text = songToEditPassed.Chords;
            editTitle.Text = songToEditPassed.Title;


        }

        private void EditSong(object sender, RoutedEventArgs e)
        {
            songToEdit.Lyrics = editLyrics.Text;
            songToEdit.Title = editTitle.Text;
            songToEdit.Chords = editChords.Text;

            try
            {
                songContext.Songs.Update(songToEdit);
                songContext.SaveChanges();
                this.Close();
            }
            catch (Exception) { }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

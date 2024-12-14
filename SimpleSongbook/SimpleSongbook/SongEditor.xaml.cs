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
    public partial class SongEditor : Window
    {
        SongContext songContext;
        Song songToEdit;

        public SongEditor(Song songToEditPassed)
        {
            songContext = new SongContext();
            songToEdit = songToEditPassed;
            InitializeComponent();
            editorLyrics.Text = songToEditPassed.Lyrics;
            editorChords.Text = songToEditPassed.Chords;
            editorTitle.Text = songToEditPassed.Title;
        }

        private void EditSong(object sender, RoutedEventArgs e)
        {
            songToEdit.Lyrics = editorLyrics.Text;
            songToEdit.Title = editorTitle.Text;
            songToEdit.Chords = editorChords.Text;

            try
            {
                songContext.Songs.Update(songToEdit);
                songContext.SaveChanges();
                this.Close();
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

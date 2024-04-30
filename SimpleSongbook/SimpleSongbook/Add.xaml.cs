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
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        SongContext songContext;
        public Add()
        {
            songContext = new SongContext();
            InitializeComponent();
        }

        private void AddSong(object sender, RoutedEventArgs e)
        {
            Song addSong = new Song() { Title = addTitle.Text, Chords=addChords.Text, Lyrics=addLyrics.Text};

            try
            {
                songContext.Add(addSong);
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

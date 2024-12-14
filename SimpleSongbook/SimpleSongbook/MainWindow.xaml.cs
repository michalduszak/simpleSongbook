using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleSongbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SongContext songContext;
        private bool DarkmodeState { get; set; } = false;
        private bool AutoscrollState { get; set; } = false;
        List<Song> songListDB;

        public MainWindow()
        {
            songContext = new();
            InitializeComponent();
            RefreshSonglist();
        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            SongCreator addWindow = new();
            addWindow.ShowDialog();
            RefreshSonglist();
            GC.Collect();

        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (songList.SelectedItem != null)
            {
                Song songToDelete = (Song)songList.SelectedItem;
                try
                {
                    songContext.Songs.Remove(songToDelete);
                    songContext.SaveChanges();
                    MessageBox.Show("Pomyślnie usunięto utwór.");
                    RefreshSonglist();
                    GC.Collect();
                }
                catch (Exception) { }
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego utworu!");
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            if (songList.SelectedItem != null)
            {
                Song songToEdit = (Song)songList.SelectedItem;
                SongEditor editWindow = new SongEditor(songToEdit);

                editWindow.ShowDialog();
                RefreshSonglist();
            }
            else
            {
                MessageBox.Show("Nie wybrano żadnego utworu!");
            }
        }

		private void RefreshSonglist()
		{
			songListDB = songContext.Songs.Select(s => s).ToList();
			songList.ItemsSource = null;
			songList.ItemsSource = songListDB;
			songList.SelectedItem = null;
			lyrics.Text = "";
			chords.Text = "";
		}

		private void ToggleDarkmode(object sender, RoutedEventArgs e)
        {
            if (!DarkmodeState)
            {
                DarkmodeState = true;
                var appResources = Application.Current.Resources;
                var darkmodeImage = darkmodeButton.Template.FindName("darkmodeImage", darkmodeButton) as Image;

                darkmodeImage.Source = new BitmapImage(new Uri("/resources/sun.png", UriKind.Relative));

                // Retrieve the global style
                var windowStyle = new Style(((Style)appResources["WindowStyle"]).TargetType);
                var listViewStyle = new Style(((Style)appResources["ListViewStyle"]).TargetType);
                var textBoxStyle = new Style(((Style)appResources["TextBoxStyle"]).TargetType);

                listViewStyle.Setters.Clear();
                windowStyle.Setters.Clear();
                textBoxStyle.Setters.Clear();

                // Update background and foreground colors
                windowStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.DimGray));
                windowStyle.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.White));

                listViewStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Black));
                listViewStyle.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.White));

                textBoxStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Black));
                textBoxStyle.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.White));

                // Apply the changes
                appResources["WindowStyle"] = windowStyle;
                appResources["ListViewStyle"] = listViewStyle;
                appResources["TextBoxStyle"] = textBoxStyle;
            }
            else
            {
                DarkmodeState = false;
                var appResources = Application.Current.Resources;
                var darkmodeImage = darkmodeButton.Template.FindName("darkmodeImage", darkmodeButton) as Image;

                darkmodeImage.Source = new BitmapImage(new Uri("/resources/moon.png", UriKind.Relative));

                // Retrieve the global style
                var windowStyle = new Style(((Style)appResources["WindowStyle"]).TargetType);
                var listViewStyle = new Style(((Style)appResources["ListViewStyle"]).TargetType);
                var textBoxStyle = new Style(((Style)appResources["TextBoxStyle"]).TargetType);

                listViewStyle.Setters.Clear();
                windowStyle.Setters.Clear();
                textBoxStyle.Setters.Clear();

                // Update background and foreground colors
                windowStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Beige));
                windowStyle.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.Black));

                listViewStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.LemonChiffon));
                listViewStyle.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.Black));

                textBoxStyle.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.LemonChiffon));
                textBoxStyle.Setters.Add(new Setter(Control.ForegroundProperty, Brushes.Black));

                // Apply the changes
                appResources["WindowStyle"] = windowStyle;
                appResources["ListViewStyle"] = listViewStyle;
                appResources["TextBoxStyle"] = textBoxStyle;
            }
 
        }
        
        private void ChangeSong(object sender, SelectionChangedEventArgs e)
        {
            if (songList.SelectedItem != null)
            {
                Song songToAdd = (Song)songList.SelectedItem;
                lyrics.Text = songToAdd.Lyrics;
                chords.Text = songToAdd.Chords;
            }
        }

        private void ScrollText(object sender, ScrollChangedEventArgs e)
        {
            var textToSync = (sender == ScrollLyrics) ? ScrollChords : ScrollLyrics;
            textToSync.ScrollToVerticalOffset(e.VerticalOffset);
        }

        private async void AutoScroll(object sender, RoutedEventArgs e)
        {
            if (!AutoscrollState)
            {
                AutoscrollState = true;
                var scrollImage = scrollButton.Template.FindName("scrollImage", scrollButton) as Image;
                scrollImage.Source = new BitmapImage(new Uri("/resources/stop.png", UriKind.Relative));
                int millisecondsPerLine = 1500;

                while (AutoscrollState)
                {
                    ScrollLyrics.LineDown();
                    await Task.Delay(millisecondsPerLine);
                }
            }
            else
            {
                AutoscrollState = false;
                var scrollImage = scrollButton.Template.FindName("scrollImage", scrollButton) as Image;
                scrollImage.Source = new BitmapImage(new Uri("/resources/start.png", UriKind.Relative));
            }
        }
    }
}

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
using TMDbLib;
using TMDbLib.Client;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;

namespace MovieSearch
{
    /// <summary>
    /// Interaction logic for Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        TMDbClient client = new TMDbClient("fae64c30bcaf7cdf5ecd7dd3f997f7ea");

        List<Film> list = new List<Film>();
        string name;
      
        public Results(string search)
        {
            InitializeComponent();
            if (search == " ")
            {
                name = " ";
            }
            else
            {
                name = search;
            }
        }
        private async Task LoadResults()
        {
            SearchContainer<SearchMovie> results = client.SearchMovieAsync(name).Result;
            foreach (SearchMovie result in results.Results)
                list.Add(new Film()
                {
                    id = result.Id,
                    title = result.Title,
                    posterpath = "https://image.tmdb.org/t/p/w92" + result.PosterPath,
                    releasedate = result.ReleaseDate,
                    

                });
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            header.Text = $"Displaying Search Results for \"" + name + "\"";
            subHead.Text = $"If you can't find the movie you're looking for, please close the window and search again.";
            await LoadResults();
            resultText.ItemsSource = list;
            
        }
        private void detailButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int num;
            Int32.TryParse(b.Tag.ToString(), out num);
            Details details = new Details(num);
            details.Show();
        }
    }
}

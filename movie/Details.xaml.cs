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
using TMDbLib.Objects.Credit;


namespace MovieSearch
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        TMDbClient client = new TMDbClient("fae64c30bcaf7cdf5ecd7dd3f997f7ea");
        int id;
        Movie movie = new Movie();
       List<Person> person = new List<Person>();
        public Details(int num)
        {
            InitializeComponent();
            id = num;
            //title.Text = id.ToString();
        }

        private async Task LoadDetails()
        {
            movie = client.GetMovieAsync(id).Result;
            //foreach (Cast cast in movie.Credits.Cast)
            //    person.Add(new Person()
            //    {
            //        name = cast.Name,
            //        character = cast.Character,

            //    });
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDetails();
            titleDetail.Text = movie.Title;
            releaseDetail.Text ="Release Date: " + movie.ReleaseDate.ToString();
            var uriSource = new Uri("https://image.tmdb.org/t/p/w500" + movie.PosterPath);
            posterDetail.Source = new BitmapImage(uriSource);
            overviewDetail.Text = "Overview: \n" + movie.Overview;
           // castList.ItemsSource = person;
        }
    }
}

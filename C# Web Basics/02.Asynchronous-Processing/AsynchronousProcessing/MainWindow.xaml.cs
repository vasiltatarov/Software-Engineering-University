using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace AsynchronousProcessing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.License.IsChecked.HasValue && this.License.IsChecked.Value == true)
            {
                await DownloadImageAsync(this.Image1, "https://images-cdn.9gag.com/photo/arO4wL6_700b.jpg");
                await DownloadImageAsync(this.Image2, "https://i.pinimg.com/originals/3c/8f/a8/3c8fa80a8d68378472c3a4dec6c47638.jpg");
                await DownloadImageAsync(this.Image3, "https://pbs.twimg.com/media/Eb1IspNXgAAvknf.jpg");
            }
        }

        private async Task DownloadImageAsync(Image image, string url)
        {
            var httpClient = new HttpClient();
            
            var request = await httpClient.GetAsync(url);
            var byteData = await request.Content.ReadAsByteArrayAsync();

            image.Source = LoadImage(byteData);
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}

using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace DietApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        Stream fileStream;
        string fileName;

        public ItemDetailPage(string file)
        {
            fileName = file;
            InitializeComponent();
        }

        /// <summary>
        /// This happens after clicking on an list item, while its loading.
        /// </summary>

        protected override void OnAppearing()
        {
            var filePath = "DietApp.Assets.";
            base.OnAppearing();
            fileStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream(filePath + fileName);
            //Load the PDF
            pdfViewerControl.LoadDocument(fileStream);
        }
    }
}
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitiallyTappableViewModel = new ViewModel(true);
            InitiallyNotTappableViewModel = new ViewModel(false);
            InitializeComponent();
        }

        public ViewModel InitiallyTappableViewModel { get; set; }
        public ViewModel InitiallyNotTappableViewModel { get; set; }
    }
}
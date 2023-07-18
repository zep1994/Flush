using Flush_Client.DataServices;
using Flush_Client.Models;
using Flush_Client.Pages;
using System.Diagnostics;

namespace Flush_Client
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestDataService _dataService;


        public MainPage(IRestDataService dataService)
        {
            InitializeComponent();

            _dataService = dataService;

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await _dataService.GetIbsCountAsync();
        }

        async void OnAddIbsClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("---> Add button clicked!");

            //name of object and the object to pass
            var navigationParameter = new Dictionary<string, object>
                {
                    { nameof(IbsCount), new IbsCount() }
                };

            //pass to manage page
            await Shell.Current.GoToAsync(nameof(ManageIbsPage), navigationParameter);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("---> Item changed clicked!");

            //name of object and the object to pass
            var navigationParameter = new Dictionary<string, object>
                    {
                        { nameof(IbsCount), e.CurrentSelection.FirstOrDefault() as IbsCount }
                    };

            //pass to manage page
            await Shell.Current.GoToAsync(nameof(ManageIbsPage), navigationParameter);
        }


    }
}
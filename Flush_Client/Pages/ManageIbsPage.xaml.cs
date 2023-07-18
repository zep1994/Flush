using Flush_Client.DataServices;
using Flush_Client.Models;
using System.Diagnostics;

namespace Flush_Client.Pages;

[QueryProperty(nameof(IbsCount), "IbsCount")]
public partial class ManageIbsPage : ContentPage
{
    private readonly IRestDataService _dataService;
    IbsCount _ibsCount;
    bool _isNew;

    public IbsCount IbsCount
    {
        get => _ibsCount;
        set
        {
            _isNew = IsNew(value);
            _ibsCount = value;
            OnPropertyChanged();
        }
    }

    public ManageIbsPage(IRestDataService dataService)
    {
        InitializeComponent();

        _dataService = dataService;
        BindingContext = this;
    }

    bool IsNew(IbsCount ibsCount)
    {
        if (ibsCount.Id == 0)
            return true;
        return false;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            Debug.WriteLine("Button Clicked");
            IbsCount.Count = IbsCount.Count + 1;
            await _dataService.AddIbsCountAsync(IbsCount);
        }
        else
        {
            Debug.WriteLine("Update Clicked");
            IbsCount.Count = IbsCount.Count + 1;
            await _dataService.UpdateIbsCountAsync(IbsCount);
            await Shell.Current.GoToAsync("..");

        }

        await Shell.Current.GoToAsync("..");

    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataService.DeleteIbsCountAsync(IbsCount.Id);
        await Shell.Current.GoToAsync("..");

    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
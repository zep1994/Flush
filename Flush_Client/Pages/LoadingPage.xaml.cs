using Flush_Client.Services;

namespace Flush_Client.Pages;

public partial class LoadingPage : ContentPage
{
    private readonly AuthService _authService;

    public LoadingPage(AuthService authService)
	{
		InitializeComponent();
		_authService = authService;
	}

	protected async override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		if(await _authService.IsAuthenticatedAsync())
		{
            //User is logged in
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
        else
		{
			//Not logged in
			await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
		}
	}
}
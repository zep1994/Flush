using System.Text;
using System.Text.Json;

namespace Flush_Client.Pages;

public partial class RegistrationPage : ContentPage
{
    private readonly string _ApiUrl;
    private readonly string _url;
    private readonly JsonSerializerOptions _jsonSerializeOptions;

    public RegistrationPage()
	{
        _ApiUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5271" : "https://localhost:7162";
        _url = $"{_ApiUrl}/api";

        _jsonSerializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        InitializeComponent();
	}

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var userName = UserNameEntry.Text;
        var email = EmailEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "All fields are required.", "OK");
            return;
        }

        // Create a JSON payload with the registration data.
        var registrationData = new { Username = userName, Email = email, Password = password };
        var jsonPayload = JsonSerializer.Serialize(registrationData);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.PostAsync($"{_url}/register", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Registration successful. You can handle the response here.
                    await DisplayAlert("Success", "Registration successful!", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                }
                else
                {
                    // Registration failed. You can handle the response here.
                    await DisplayAlert("Error", "Registration failed. Please try again later.", "OK");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the request.
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}

using Flush_Client.DataServices;
using Flush_Client.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Flush_Client.Pages;

public partial class LoginPage : ContentPage
{
    private readonly string _ApiUrl;
    private readonly string _url;
    private readonly JsonSerializerOptions _jsonSerializeOptions;

    public LoginPage()
	{
        _ApiUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5271" : "https://localhost:7162";
        _url = $"{_ApiUrl}/api";

        _jsonSerializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var UserName = UserNameEntry.Text;
        var password = PasswordEntry.Text;

        if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "UserName and password are required.", "OK");
            return;
        }

        // Create a JSON payload with the login data.
        var loginData = new { UserName = UserName, Password = password };
        var jsonPayload = JsonSerializer.Serialize(loginData);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        using (var httpClient = new HttpClient())
        {
            try
            {
                var response = await httpClient.PostAsync($"{_url}/login", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Login successful. You can handle the response here.
                    await DisplayAlert("Success", "Login successful!", "OK");
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

                }
                else
                {
                    // Login failed. You can handle the response here.
                    await DisplayAlert("Error", "Login failed. Please check your credentials.", "OK");
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

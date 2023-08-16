using Flush_Client.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Flush_Client.Pages;

public partial class IngredientPage : ContentPage
{
    private const string ApiUrl = "http://10.0.2.2:5271/api/ingredients/{0}";

    public IngredientPage()
    {
        InitializeComponent();

    }

    private async void LoadIngredients(object sender, EventArgs e)
    {
        var ingredient = IngredientEntry.Text;

        if (string.IsNullOrWhiteSpace(ingredient))
        {
            await DisplayAlert("Error", "Please enter an ingredient.", "OK");
            return;
        }

        try
        {
            var formattedApiUrl = string.Format(ApiUrl, Uri.EscapeDataString(ingredient));
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(formattedApiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var ingredientResult = JsonSerializer.Deserialize<Ingredient>(jsonResponse);

                // Update UI labels with ingredient information.
                NameLabel.Text = ingredientResult.Name;

                // Display JSON results in the layout
                var jsonLabel = new Label
                {
                    Text = jsonResponse,
                    FontSize = 14
                };
                JsonResultsLayout.Children.Add(jsonLabel);
            }
            else
            {
                await DisplayAlert("Error", "Failed to fetch ingredient information.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}
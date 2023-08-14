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
                var ingredientResult = JsonSerializer.Deserialize<IngredientResult>(jsonResponse);

                // Display ingredient information on the UI
                UpdateUIWithIngredientInfo(ingredientResult);
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


    private void UpdateUIWithIngredientInfo(IngredientResult ingredientResult)
    {

        JsonResultsLayout.Children.Clear(); // Clear previous results

        foreach (var result in ingredientResult.Ingredients)
        {
            var nameLabel = new Label
            {
                Text = result.Name,
                FontSize = 16
            };
            JsonResultsLayout.Children.Add(nameLabel);
        }
    }
}
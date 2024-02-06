using System;
using System.Net.Http;

public class WebFetcher : IDisposable
{
    private readonly HttpClient httpClient;

    public WebFetcher()
    {
        httpClient = new HttpClient();
        // Set a common User-Agent header to mimic a real browser request
        httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
    }

    public string FetchHtmlContent(string url)
    {
        try
        {
            // Introduce a delay before making the request to avoid rate limiting
            System.Threading.Thread.Sleep(2000); // Adjust the delay as needed

            // Send a GET request to the specified URL and block until it completes
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            // Check if the request was successful (status code 200)
            if (response.IsSuccessStatusCode)
            {
                // Read the content as a string and return it
                return response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                // If the request was not successful, throw an exception with the status code
                throw new HttpRequestException($"Failed to fetch content. Status Code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., network errors, etc.)
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    // Dispose of the HttpClient when done
    public void Dispose()
    {
        httpClient.Dispose();
    }

    public string GetTopWinRatePage()
    {
        // Specify the URL to fetch HTML content
        string url = "https://www.overbuff.com/heroes?platform=pc&timeWindow=month";

        // Call the FetchHtmlContent method to get the HTML content synchronously
        return FetchHtmlContent(url);
    }
}

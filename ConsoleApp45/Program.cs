Console.WriteLine("Hello, World!");

// Create an instance of HttpClient
HttpClient client = new HttpClient();

// Send an HTTP GET request to the specified URL
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

if (response.IsSuccessStatusCode)
{
    // Read the content of the response
    string content = await response.Content.ReadAsStringAsync();

    // Deserialize the JSON array into a list of Collector objects
//List<Collector> articles = JsonSerializer.Deserialize<List<Collector>>(content);

    // Define the path for the file
    string path = @"C:\Users\nihad\OneDrive\Desktop\test.txt";

    if (!File.Exists(path))
    {
        // Create the file if it doesn't exist
        using (StreamWriter createWriter = File.CreateText(path))
        {
            foreach (var article in content)
            {
                // Check if the article Id is 1, 10, or 100
                createWriter.Write(article);
            }
        }
        Console.WriteLine("File created and articles added.");
    }
    else
    {
        // Append to the existing file
        using (StreamWriter appendWriter = new StreamWriter(path, true))
        {
            foreach (var article in content)
            {
                // Check if the article Id is 1, 10, or 100
                appendWriter.Write(article);
            }
        }
        Console.WriteLine("Articles appended to the existing file successfully.");
    }
}
else
{
    // Print the status code if the request was not successful
    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
}
    
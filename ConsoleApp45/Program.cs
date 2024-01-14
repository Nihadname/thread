// See https://aka.ms/new-console-template for more information
using ConsoleApp45;
using System.Text.Json;

Console.WriteLine("Hello, World!");
HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");


if (response.IsSuccessStatusCode)
{

    string content = await response.Content.ReadAsStringAsync();
    List<Collector> articles = JsonSerializer.Deserialize<List<Collector>>(content);
    string Path = @"C:\Users\nihad\OneDrive\Desktop\test.txt"; // Use @ to create a verbatim string
    if (!File.Exists(Path))
    {
        using (StreamWriter createWriter = File.CreateText(Path))
        {
            foreach (var article in articles)
            {
                if (article.Id == 1 || article.Id == 10 || article.Id == 100)
                {
                    createWriter.Write(article);
                }
            }
        }
        Console.WriteLine("it created and added ");
    }
    else
    {
        using (StreamWriter appendWriter = new StreamWriter(Path, true))
        {
            appendWriter.Write(content);
        }

        Console.WriteLine("Text appended to existing file successfully.");
    }

}
else
{
    // Print the status code if the request was not successful
    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
}
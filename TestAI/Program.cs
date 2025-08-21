using System.Text;
using System.Text.Json;
using TestAI;


const string apiKey = "**REDACTED**"; //See sticky note
var client = new HttpClient();
client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

const string text = "The Legend of Zelda: An open-world Action-Adventure game set in a fantasy world.";
var labels = new[] { "Adventure", "Action", "RPG", "Strategy", "Simulation", "Shooter", "Platformer" };

var data = new
{
    inputs = text,
    parameters = new
    {
        candidate_labels = labels,
        multi_label = true
    }
};

var json = JsonSerializer.Serialize(data);
var response = await client.PostAsync(
    "https://api-inference.huggingface.co/models/facebook/bart-large-mnli",
    new StringContent(json, Encoding.UTF8, "application/json")
);

var resultJson = await response.Content.ReadAsStringAsync();
var result = JsonSerializer.Deserialize<HFResult>(resultJson);

var filtered = new List<string>();
for (var i = 0; i < result!.labels.Count; i++)
{
    if (result.scores[i] >= 0.4f)
        filtered.Add(result.labels[i]);
}

var genres = filtered.Select(item => Enum.Parse(typeof(Genre), item)).ToList();

Console.WriteLine("Result: " + string.Join(", ", genres));
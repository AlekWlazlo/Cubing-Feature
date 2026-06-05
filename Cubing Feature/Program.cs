using Cubing_Feature;
using System.Text.Json;

string requestJson = """
    {
    "Quantity": 28,
    "Article": {
        "Name": "Cube_1",
        "Dimensions": {"Length": 5, "Width": 5, "Height": 5}
        },
        "BoxType": {
        "Name": "Box",
        "Dimensions": {"Length": 5, "Width": 20, "Height": 20}
        }
    }
    """;

Console.WriteLine("API REQUEST JSON: \n");
MessageFeatures.YellowColor(requestJson);

string responseJson = ApiEndpoint.Calculate(requestJson);
Console.WriteLine("\n\nAPI RESPONSE JSON: \n");
Console.WriteLine($"Is valid JSON: {ApiEndpoint.IsJson(responseJson)}");
if (ApiEndpoint.IsJson(responseJson) == true)
    MessageFeatures.YellowColor(responseJson);
else
    MessageFeatures.RedColor(responseJson);

Console.Read();

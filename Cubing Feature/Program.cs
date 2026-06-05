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

ApiEndpoint.HandlingUserJsonToCalculateBoxesNeeded(requestJson);

Console.Read();

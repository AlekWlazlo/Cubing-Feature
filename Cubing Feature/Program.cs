using Cubing_Feature;

//string requestJson = "";

string requestJson = """
    {
    "Quantity": 28,
    "Article": {
        "Name": "Cube_1",
        "Dimensions": {"Length": 5  , "Width": 5, "Height": 5}
        },
        "BoxType": {
        "Name": "Box",
        "Dimensions": {"Length": 5 , "Width": 20, "Height": 20}
        }
    }
    """;

Console.WriteLine("API REQUEST JSON: \n");
MessageFeatures.YellowColor(requestJson);

string responseJson = ApiEndpoint.Calculate(requestJson);
Console.WriteLine("\n\n API RESPONSE JSON: \n");
MessageFeatures.YellowColor(responseJson);

Console.Read();

//PackingRequest (obiekt główny)
//├── Quantity(int)
//├── Article(obiekt)
//│     ├── Name(string)
//│     └── Dimensions(obiekt)
//│           ├── Length(int)
//│           ├── Width(int)
//│           └── Height(int)
//│
//└── BoxType(obiekt)
//      ├── Name(string)
//      └── Dimensions(obiekt)
//            ├── Length(int)
//            ├── Width(int)
//            └── Height(int)

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
        "Dimensions": {"Length": 20 , "Width": 20, "Height": 20}
        }
    }
    """;

Console.WriteLine("API REQUEST JSON: \n");
Console.WriteLine(requestJson);

string responseJson = ApiEndpoint.Calculate(requestJson);
Console.WriteLine("\n\n API RESPONSE JSON: \n");
Console.WriteLine(responseJson);

Console.Read();

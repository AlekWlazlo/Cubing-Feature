using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Cubing_Feature
{
    public static class ApiEndpoint
    {
        public static void HandlingUserJsonToCalculateBoxesNeeded(string requestJson)
        {
            Console.WriteLine("API REQUEST JSON: \n");
            MessageFeatures.YellowColor(requestJson);

            string responseJson = ApiEndpoint.Calculate(requestJson);
            Console.WriteLine("\n\nAPI RESPONSE JSON: \n");
            Console.WriteLine($"Is valid JSON: {ApiEndpoint.IsJson(responseJson)}");
            if (ApiEndpoint.IsJson(responseJson) == true)
                MessageFeatures.YellowColor(responseJson);
            else
                MessageFeatures.RedColor(responseJson);
        }

        public static string Calculate(string requestJson)
        {
            try
            {
                var request = JsonSerializer.Deserialize<MessageFrame.PackingRequest>(requestJson);

                var response = PackingService.Calculate(request);

                return JsonSerializer.Serialize(response, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch (JsonException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ErrorResponse response = new ErrorResponse();
                response.Error = "Invalid JSON format/ null parameter";
                response.Details = ex.Message;
                return $"{response.Error}: {response.Details}";
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ErrorResponse response = new ErrorResponse();
                response.Error = "Error";
                response.Details = ex.Message;
                return $"{response.Error}: {response.Details}";
            }
        }

        public class ErrorResponse
        {
            public string? Error { get; set; }
            public string? Details { get; set; }
        }

        public static bool IsJson(string Object)
        {
            try
            {
                JsonSerializer.Deserialize<object>(Object);
                return true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return false;
            }
        }
    }
}
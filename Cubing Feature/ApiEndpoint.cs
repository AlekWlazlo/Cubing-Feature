using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Cubing_Feature
{
    public static class ApiEndpoint
    {
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
                ErrorResponse response = new ErrorResponse();
                response.Error = "Invalid JSON format/ null parameter";
                response.Details = ex.Message;
                return $"{response.Error}: {response.Details}";
                ;
            }
            catch (Exception ex)
            {
                ErrorResponse response = new ErrorResponse();
                response.Error = "Error";
                response.Details = ex.Message;
                return $"{response.Error}: {response.Details}";
            }
        }

        public class ErrorResponse
        {
            public string Error { get; set; }
            public string Details { get; set; }
        }
    }
}
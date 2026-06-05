using System;
using System.Collections.Generic;
using System.Text;
using static Cubing_Feature.MessageFrame;

namespace Cubing_Feature
{
    public static class PackingService
    {
        public static PackingResponse Calculate(PackingRequest request)
        {
            double perBox =
            (request.BoxType.Dimensions.Length / request.Article.Dimensions.Length) *
            (request.BoxType.Dimensions.Width / request.Article.Dimensions.Width) *
            (request.BoxType.Dimensions.Height / request.Article.Dimensions.Height);

            var result = new PackingResponse();
            double remaining = request.Quantity;

            while (remaining > 0)
            {
                double inBox = Math.Min(perBox, remaining);

                result.BoxesToUse.Add(new BoxToUse
                {
                    BoxID = Guid.NewGuid(),
                    NumberOfItems = (int)inBox
                });

                remaining -= inBox;
            }
            Console.WriteLine("\nList of Boxes and their contents:");
            foreach (var box in result.BoxesToUse)
            {
                MessageFeatures.GreenColor($"Box ID: {box.BoxID}, Items: {box.NumberOfItems}");
            }
            return result;
        }
    }
}

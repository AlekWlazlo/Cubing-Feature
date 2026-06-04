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
            //foreach (var box in result.BoxesToUse)
            //{
            //    Console.WriteLine($"Box ID: {box.LicensePlateNumber}, Items: {box.NumberOfItems}");
            //}
            //Console.WriteLine(result.BoxesToUse[0]);
            return result;
        }
    }
}

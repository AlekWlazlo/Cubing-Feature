using System;
using System.Collections.Generic;
using System.Text;
using static Cubing_Feature.MessageFrame;

namespace Cubing_Feature
{
    public static class PackingService
    {
        public static MessageFrame.PackingResponse Calculate(PackingRequest request) //?
        {
            int perBox =
            (request.BoxType.Dimensions.Length / request.Article.Dimensions.Length) *
            (request.BoxType.Dimensions.Width / request.Article.Dimensions.Width) *
            (request.BoxType.Dimensions.Height / request.Article.Dimensions.Height);

            var result = new MessageFrame.PackingResponse();
            int remaining = request.Quantity;

            while (remaining > 0)
            {
                int inBox = Math.Min(perBox, remaining);

                result.BoxesToUse.Add(new BoxToUse
                {
                    LicensePlateNumber = Guid.NewGuid(),
                    NumberOfItems = inBox
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

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cubing_Feature
{
    public class MessageFrame
    {
        public class PackingRequest
        {
            public int Quantity { get; set; }
            public Article Article { get; set; }
            public BoxType BoxType { get; set; }
        }

        public class Article
        {
            public string Name { get; set; }
            public Dimensions? Dimensions { get; set; }
        }

        public class BoxType
        {
            public string Name { get; set; }
            public Dimensions Dimensions {  get; set; }
        }

        public class Dimensions
        {
            public int Length { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

        }

        //---------------------------------------------------------------------------------------

        public class PackingResponse
        {
            public List<BoxToUse> BoxesToUse { get; set; } = new();
        }

        public class BoxToUse
        {
            public Guid LicensePlateNumber { get; set; }
            public int NumberOfItems { get; set; }
        }
    }
}

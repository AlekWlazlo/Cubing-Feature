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
            public Article? Article { get; set; }
            public BoxType? BoxType { get; set; }
        }

        public class Article
        {
            public string? Name { get; set; }
            public Dimensions? Dimensions { get; set; }
        }

        public class BoxType
        {
            public string? Name { get; set; }
            public Dimensions? Dimensions {  get; set; }
        }

        public class Dimensions
        {
            private double _length;
            private double _width;
            private double _height;

            public double Length
            {
                get => _length;
                set => _length = DimensionValidityCheck(value);
            }

            public double Width
            {
                get => _width;
                set => _width = DimensionValidityCheck(value);
            }

            public double Height
            {
                get => _height;
                set => _height = DimensionValidityCheck(value);
            }
        }

        public static double DimensionValidityCheck(double Dimension)
        {

            if (Dimension < 0)
            {
                MessageFeatures.RedColor("Dimension cannot be negative! The valuse has been overwritten by a positive number");
                return -Dimension;
            }
            else if (Dimension == 0)
                throw new ArgumentException("Dimensions cannot be 0!");
            else
                return Dimension;
        }

        public class PackingResponse
        {
            public List<BoxToUse> BoxesToUse { get; set; } = new List<BoxToUse>();
        }

        public class BoxToUse
        {
            public Guid BoxID { get; set; }
            public int NumberOfItems { get; set; }
        }
    }
}

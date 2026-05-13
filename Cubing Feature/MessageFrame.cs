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
            private double _length;
            private double _width;
            private double _height;

            public double Length
            {
                get => _length;
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Box/Item dimensions are wrong");

                    _length = value;
                }
            }

            public double Width
            {
                get => _width;
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Box/Item dimensions are wrong");

                    _width = value;
                }
            }

            public double Height
            {
                get => _height;
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Box/Item dimensions are wrong");

                    _height = value;
                }
            }
        }

        //---------------------------------------------------------------------------------------

        public class PackingResponse
        {
            public List<BoxToUse> BoxesToUse { get; set; } = new();
        }

        public class BoxToUse
        {
            public Guid BoxID { get; set; }
            public int NumberOfItems { get; set; }
        }
    }
}

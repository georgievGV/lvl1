using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string ArgExcMsg = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateValue(value, nameof(Length));
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValidateValue(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateValue(value, nameof(Height));
                this.height = value;
            }
        }


        public double GetTotalSurfaceArea() =>
            (2 * this.Length * this.Width) + (2 * this.Length * this.Height)
                + (2 * this.Width * this.Height);

        public double GetLateralSurfaceArea() =>
            (2 * this.Length * this.Height) + (2 * this.Width * this.Height);

        public double GetVolume() => this.Length * this.Width * this.Height;

        private void ValidateValue(double value, string parameter)
        {
            if (value <= 0)
            {
                throw new ArgumentException(String.Format(ArgExcMsg, parameter));
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result
                  .AppendLine($"Surface Area - {this.GetTotalSurfaceArea():f2}")
                  .AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}")
                  .AppendLine($"Volume - {this.GetVolume():f2}");

            return result.ToString().TrimEnd();
        }
    }
}

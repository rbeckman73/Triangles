using System;
using System.ComponentModel;
using Triangles.Helpers;

namespace Triangles.Models
{
    public class Triangle : INotifyPropertyChanged
    {
        public Triangle()
        {
            Classification = Classification.Invalid;
            sideAText = string.Empty;
            sideBText = string.Empty;
            sideCText = string.Empty;
        }

        private string sideAText;
        private string sideBText;
        private string sideCText;
        private string classificationToString;
        private string degrees;

        public event PropertyChangedEventHandler PropertyChanged;

        public int SideA;
        public int SideB;
        public int SideC;

        public double Degree1 { get; set; }
        public double Degree2 { get; set; }
        public double Degree3 { get; set; }
        public Classification Classification { get; set; }

        public string SideAText
        {
            get { return sideAText; }
            set
            {
                sideAText = value;
                if (!int.TryParse(sideAText, out SideA)) SideA = 0;
                Functions.Calculate(this);
            }
        }

        public string SideBText
        {
            get { return sideBText; }
            set
            {
                sideBText = value;
                if (!int.TryParse(sideBText, out SideB)) SideB = 0;
                Functions.Calculate(this);
            }
        }

        public string SideCText
        {
            get { return sideCText; }
            set
            {
                sideCText = value;
                if (!int.TryParse(sideCText, out SideC)) SideC = 0;
                Functions.Calculate(this);
            }
        }

        public string ClassificationToString
        {
            get { return classificationToString; }
            set
            {
                classificationToString = value;
                this.OnPropertyChanged("ClassificationToString");
            }
        }

        public string DegreesToString
        {
            get { return degrees; }
            set
            {
                degrees = value;
                this.OnPropertyChanged("DegreesToString");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    };

    [Flags]
    public enum Classification
    {
        Invalid = 0,
        Scalene = 1,
        Isosceles = 2,
        Equilateral = 4,
        Acute = 8,
        Obtuse = 16,
        Right = 32
    }
}

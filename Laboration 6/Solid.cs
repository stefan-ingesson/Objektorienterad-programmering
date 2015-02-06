using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboration_6
{
    public abstract class Solid
    {

        // Fält
        private double _height;

        public double Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _height = value;
            }
        }

        private double _radius;

        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                _radius = value;
            }
        }

        // Egenskaper
        public abstract double BaseArea
        {
            get;
        }
        public double HeightSquared // Ska räkna ut _height * _height
        {
            get { return _height * _height; }
        }

        public double RadiusSquared //  ska räkna ut _radius * _radius
        {
            get { return _radius * _radius; }
        }

        public abstract double SurfaceArea // Ska representera en solids ytarea
        {
            get;
        }
        public abstract double Volume // Ska representera en solids volym
        {
            get;
        }


        // Metoder
        protected Solid(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }
        // Metod för att returnera
        public override string ToString()
        {
            StringBuilder informationString = new StringBuilder();
            informationString.AppendFormat(" Radie (r)    : \t{0,5:f2}", Radius);
            informationString.AppendFormat("\n Höjd (h)     : \t{0,5:f2}", Height);
            informationString.AppendFormat("\n Volym        : \t{0,-8:f2}", Volume);
            informationString.AppendFormat("\n Basarea      : \t{0,-8:f2}", BaseArea);
            informationString.AppendFormat("\n Ytarea       : \t{0,-8:f2}", SurfaceArea);
            informationString.AppendFormat("\n══════════════════════════════════════════════════════");

            return informationString.ToString();
        }
    }
}

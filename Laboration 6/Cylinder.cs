using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration_6
{
    public class Cylinder : Solid
    {   
        //Uträkning för cylinders basarea
        public override double BaseArea
        {
            get
            {
                return (Math.PI * RadiusSquared);
            }

        }
        //Uträkning för cylinders ytarea
        public override double SurfaceArea
        {
            get
            {
                return 2 * Math.PI * Radius * (Height + Radius);
            }
        }
        // Uträkning för cylinders volym
        public override double Volume
        {
            get
            {
                return (RadiusSquared * Math.PI * Height);
            }
        }

        public Cylinder(double radius, double height)
            : base(radius, height)
        {

        }
    }
}

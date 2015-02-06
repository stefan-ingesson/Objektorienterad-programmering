using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Laboration_6
{
    public class CircularCone : Solid
    {
        public override double BaseArea
        {
            get
            {
                return (Math.PI * RadiusSquared);
            }
        }   
 
        public override double SurfaceArea
        {
	        get 
	        {
                return Math.PI * Radius * (Radius + Math.Sqrt(RadiusSquared + HeightSquared)); 
	        }     	  
        }

        public override double Volume
        {
            get
            {
                return ((Math.PI * RadiusSquared * Height) / 3);
            }          
        }

        public CircularCone(double radius, double height)
            : base(radius, height)
        {

        }
            

        }
    }


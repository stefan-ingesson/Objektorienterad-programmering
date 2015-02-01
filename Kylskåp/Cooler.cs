using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    public class Cooler
    {
        private decimal _insideTemperature = 0;
        private decimal _targetTemperature = 0;
        private const decimal OutsideTemperature = 23.7M;
        public bool DoorIsOpen { get; set; }
        public bool IsOn { get; set; }

        //Inkapsling av det privata fältet _insideTemperature
        public decimal InsideTemperature
        {
            get { return _insideTemperature; }
            set
            {
                if (value < 0 || value > 45) //if sats för att säkerställa att värdet är inom de angivna ramarna
                {
                    throw new ArgumentException("Innetemperaturen är inte i intervallet 0 - 45°C"); // Fel av typen argument exception får detta felmeddelande
                }
                _insideTemperature = value;
            }
        }

        //Inkapsling av det privata fältet _targetTemperature
        public decimal TargetTemperature
        {
            get { return _targetTemperature; }
            set
            {
                if (value < 0 || value > 20) //if sats för att säkerställa att måltemperaturen håller sig inom de angivna värdena...Förstår inte varför jag måste ha value här, men kan ha _insideTemperature ovanför. Fråga Mattias...
                {
                    throw new ArgumentException("Måltemperaturen är inte i intervallet 0-20°C"); // Fel av typen argument exception får detta felmeddelande
                }
                _targetTemperature = value;
            }
        }

        public Cooler()
            : this(0M, 0M)
        {
            // Tom konstruktor
        }

        public Cooler(decimal temperature, decimal targetTemperature)
            : this(temperature, targetTemperature, false, false)
        {

        }

        public Cooler(decimal temperature, decimal targetTemperature, bool isOn, bool isOpen)
        {
            InsideTemperature = temperature;
            TargetTemperature = targetTemperature;
            IsOn = isOn;
            DoorIsOpen = isOpen;
        }

        // Metod för att justera temperaturen i kylskåpet beroende på olika villkor
        public void Tick()
        {
            decimal change = 0;
            if (IsOn == true && DoorIsOpen == false) //Utvärderar vad som ska hända om kylskåpet är på och dörren är stängd - Temperaturen sjunker
            {
                change = -0.2M;
            }
            else if (IsOn == true && DoorIsOpen == true) //Utvärderar vad som ska hända om kylskåpet är på och dörren öppen - Temperaturen stiger
            {
                change += 0.2M;
            }
            else if (IsOn == false && DoorIsOpen == false) // Utvärderar vad som ska hända om kylskåpet är avstängt och dörren stängd - Temperaturen stiger
            {
                change += 0.1M;
            }
            else if (IsOn == false && DoorIsOpen == true) //Utvärderar vad som ska hända om kylskåpet är avstängt och dörren öppen - Temperaturen stiger
            {
                change += 0.5M;
            }


            if (InsideTemperature + change < TargetTemperature) // Kollar så att temperaturen i kylskåpet INTE går under måltemperaturen
            {
                InsideTemperature = TargetTemperature;
            }

            else if (InsideTemperature + change >= OutsideTemperature) // Jämför temperaturen i kylskåpet med temperaturen på utsidan
            {
                InsideTemperature = OutsideTemperature;
            }
            else
            {
                InsideTemperature += change;
            }
        }

        public override string ToString()
        {

            string fridgeIsOn = IsOn ? "PÅ" : "AV";
            //if (IsOn == true)
            //{
            //    fridgeIsOn = "PÅ";
            //}
            //else
            //{
            //    fridgeIsOn = "AV";
            //}

            string doorOpen = DoorIsOpen ? "Öppet" : "Stängt";

            //if (DoorIsOpen == true)
            //{
            //    doorOpen = "Öppet";
            //}
            //else
            //{
            //    doorOpen = "Stängt";
            //}

            //Returnerar de olika värdena
            return String.Format("[{0}] : {1:f1}°C : <{2:f1}°C> - {3}", fridgeIsOn, InsideTemperature, TargetTemperature, doorOpen);
        }
    }
}

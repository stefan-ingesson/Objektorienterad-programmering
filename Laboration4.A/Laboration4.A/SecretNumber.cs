using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboration4.A
{
    public class SecretNumber
    {
        // Deklarering av variabler
        private int _count;
        private int _number;
        public const int MaxNumberOfGuesses = 7;


        public SecretNumber()
        {
            Initialize();
        }


        // Metod för att initiera
        public void Initialize()
        {
            _count = 0;
            Random newRandomNumber = new Random();
            _number = newRandomNumber.Next(1, 100);
        }



        // Metod för att gissa
        public bool MakeGuess(int number)
        {
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }
            else if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();            
            }

            _count++;

            if (number == _number)
            {
                Console.WriteLine("Grattis! Du klarade det på {0} försök", _count);
                return true;
            }
            if (number > _number)
            {
                Console.WriteLine("{0} är för högt! Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - (_count));
            }
            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt! Du har {1} gissningar kvar.", number, MaxNumberOfGuesses - (_count));
            }
            if (_count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
            }

            return false;
        }
    }
}

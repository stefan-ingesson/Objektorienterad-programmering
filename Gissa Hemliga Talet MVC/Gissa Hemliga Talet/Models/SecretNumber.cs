using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gissa_Hemliga_Talet.Models
{
    public class SecretNumber
    {
        //Fält  
        //Hemliga talet
        private int? _number;                                   
        public const int MaxNumberOfGuesses = 7;
        // Visar vilken gissning man är på
        private string _guessCount;                             
        // Visar resultatet av gissningen
        private string _guessOutcome;                           
        // Lista med gjorda gissningar
        private List<GuessedNumber> _guessedNumbers;            
        // Senast gissat nummer
        private GuessedNumber _lastGuessedNumber;               

        //Egenskaper
        public string GuessOutcome
        {
            get { return _guessOutcome; }
            private set { _guessOutcome = value; }
        }
        public string GuessCount
        {
            get { return ShowGuessNumber(Count); }
            private set { _guessCount = value; }
        }
        public bool CanMakeGuess
        {
            get { return MaxNumberOfGuesses == Count ? false : true; }
        }

        public int Count { get { return _guessedNumbers.Count; } } // Ger antal gjorda gissningar 

        public IList<GuessedNumber> Guessednumbers // 
        {
            get { return _guessedNumbers.AsReadOnly(); }
        }

        public GuessedNumber LastGuessedNumber // Håller reda på senaste utfallet och värdet
        {
            get { return _lastGuessedNumber; }
        }

        public int? Number //Visar hemliga talet när gissningarna är slut
        {
            get { return !CanMakeGuess ? _number : null; }
            private set { _number = value; }
        }

        // Konstruktor
        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }

        // Metoder
        public void Initialize()
        {
            _guessedNumbers.Clear();
            _lastGuessedNumber.Outcome = Outcome.Undefined;
            Random random = new Random();
            Number = random.Next(1, 100);
        }

        public string ShowGuessNumber(int count) // Presenterar antal försök 
        {
            _guessCount = string.Empty;
            if (count > 0)
            {
                switch (count)
                {
                    case 1: _guessCount = "Första";
                        break;
                    case 2: _guessCount = "Andra";
                        break;
                    case 3: _guessCount = "Tredje";
                        break;
                    case 4: _guessCount = "Fjärde";
                        break;
                    case 5: _guessCount = "Femte";
                        break;
                    case 6: _guessCount = "Sjätte";
                        break;
                    case 7: _guessCount = "Sjunde";
                        break;
                }
                if (_lastGuessedNumber.Outcome != Outcome.Right)
                {
                    _guessCount = _guessCount + " försöket";
                }
            }
            return _guessCount;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            _lastGuessedNumber = new GuessedNumber { Number = guess };

            if (CanMakeGuess)
            {
                if (_guessedNumbers.Any(x => x.Number == guess))                            // Tittar på gissade tal och kontrollerar så det inte går att gissa på samma tal två gånger
                {
                    _lastGuessedNumber.Outcome = Outcome.OldGuess;
                    GuessOutcome = string.Format("Du har redan gissat på {0}, välj ett annat tal!", guess);
                }
                else
                {
                    if (guess > _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.High;
                        GuessOutcome = string.Format("{0} är för högt, försök igen!", guess);
                    }
                    else if (guess < _number)
                    {
                        _lastGuessedNumber.Outcome = Outcome.Low;
                        GuessOutcome = string.Format("{0} är för lågt, försök igen!", guess);
                    }
                    else if (guess == _number)                                              //Visar upp vilket försök användaren klarade det på
                    {
                        _lastGuessedNumber.Outcome = Outcome.Right;
                        string correctAnswer = ShowGuessNumber(Count + 1);
                        GuessOutcome = string.Format("Bra jobbat! Du klarade det på {0} försöket!", correctAnswer);
                    }
                    _guessedNumbers.Add(_lastGuessedNumber);

                }
            }
            if (!CanMakeGuess && LastGuessedNumber.Outcome != Outcome.Right)
            {
                _lastGuessedNumber.Outcome = Outcome.NoMoreGuesses;
                GuessOutcome = string.Format("{0} Inga fler gissningar! Det hemliga talet är {1}", _guessOutcome, _number);
            }
            return _lastGuessedNumber.Outcome;
        }

       


    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessSecretNumber.Model
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;

        //Klassfält
        List<int> _previousGuesses;
        int _number; //Det hemliga numret som ska gissas fram



        //Egenskap som bestämmer om användaren får gissa igen. //EJ KLAR lägg till om användaren redan har gissat rätt tal.
        public bool CanMakeGuess
        {
            get
            {
                return Count < MaxNumberOfGuesses;
            }
        }

        //Egenskap som räknar antalet gissningar
        public int Count
        {
            get
            {
                return _previousGuesses.Count; 
            }
        }

        //Egenskap som ger det hemliga talet ifall användaren inte kan gissa.
        public int? Number
        {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
        }

        //Egenskap som ger resultatet av den senaste gissningen //EJ KLAR
        public Outcome Outcome
        {
            get;
            set;
        }

        //Egenskap som sparar alla gjorda gissningar i en lista //EJ KLAR gör readonly
        public List<int> PreviousGuesses
        {
            get
            {
                return _previousGuesses;
            }
        }



        //Konstruktor
        public SecretNumber()
        {
            _previousGuesses = new List<int>(7);

            Initialize();
        }

        //Metod som nollställer allt och skapar ett nytt hemligt nummer. //EJ KLAR
        public void Initialize()
        {
            //Listan rensas
            _previousGuesses.Clear();

            //Ett nytt slumptal tilldelas _number.
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);
        }


        //Metod som kollar användaren gissning och skickar tillbaka lämpliga meddelanden. //EJ KLAR
        public bool MakeGuess(int number)
        {

            //Om talet är utanför 1 - 100
            if (number > 100 || number < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            //Om användaren redan gissat max antal gånger
            if (Count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            //Om talet redan är gissat
            if (Array.IndexOf(_guessedNumbers, number) != -1)
            {
                Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                return false;
            }

            _guessedNumbers[Count++] = number;

            //Om talet är större eller mindre än det hemliga talet
            if (number > _number || number < _number)
            {

                Console.WriteLine("{0} är för {2}. Du har {1} gissningar kvar", number, GuessesLeft, number > _number ? "högt" : "lågt");
                if (Count == MaxNumberOfGuesses)
                {
                    Console.WriteLine("Det hemliga talet är {0}", _number);
                }
                return false;
            }

            Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", Count);
            return true;

        }

    }

    enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess}
}

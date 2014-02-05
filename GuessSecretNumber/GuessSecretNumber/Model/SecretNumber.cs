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

        //Egenskap som bestämmer om användaren får gissa igen.
        public bool CanMakeGuess
        {
            get
            {
                return Count != MaxNumberOfGuesses || Outcome != Outcome.Correct;
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

        //Egenskap som ger resultatet av den senaste gissningen
        public Outcome Outcome
        {
            get;
            set;
        }

        //Egenskap som sparar alla gjorda gissningar i en lista
        public IEnumerable<int> PreviousGuesses
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

        //Metod som nollställer allt och skapar ett nytt hemligt nummer.
        public void Initialize()
        {
            //Listan rensas och senaste gissningen sätts till indefinite
            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;

            //Ett nytt slumptal tilldelas _number.
            Random randomNumber = new Random();
            _number = randomNumber.Next(1, 101);
        }

        //Metod som kollar användarens gissning och skickar tillbaka lämpliga meddelanden.
        public Outcome MakeGuess(int guess)
        {

            //Om talet är utanför 1 - 100
            if (guess > 100 || guess < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            //Om användaren redan gissat max antal gånger
            if (Count > MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }


            //Om talet redan är gissat
            if (_previousGuesses.Contains(guess))
            {
                return Outcome = Outcome.PreviousGuess;
            }

            //gissningen läggs till i listan 
            _previousGuesses.Add(guess);

            //Om det var rätt!
            if (guess == _number)
            {
                return Outcome = Outcome.Correct;
            }

            //Om gissningen var för hög eller låg
            if (guess > _number || guess < _number)
            {
                Outcome = guess > _number  ? Outcome.High : Outcome.Low;
            }

            //Om det var den sista gissningen.
            if (Count == MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesses;
            } 

            //Outcome returneras.
            return Outcome;
        }

    }

    //Enum med olika statusar på den senaste gissningen
    public enum Outcome { Indefinite, Low, High, Correct, NoMoreGuesses, PreviousGuess}
}

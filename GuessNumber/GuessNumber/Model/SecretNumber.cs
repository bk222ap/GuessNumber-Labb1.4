using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace GuessNumber.Model
{
    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuesses;
        private const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess { get { return PreviousGuesses.Count() < MaxNumberOfGuesses; } }
        public int Count { get { return PreviousGuesses.Count(); } }
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

        public Outcome Outcome
        {
            get;
            set;
        }

        public IEnumerable<int> PreviousGuesses 
        {
            get
            {
                return new ReadOnlyCollection<int>(_previousGuesses);
            }
        }
        public SecretNumber()
        {
            _previousGuesses = new List<int>(7);
            Initialize();
        }

        public void Initialize()
        {
            Random rand = new Random();
            _number = rand.Next(1, 101);

            _previousGuesses.Clear();
            Outcome = Outcome.Indefinite;
        }

        public Outcome Makeguess(int number)
        {
            if (number <= 0 || number > 100)
            {
                throw new ArgumentOutOfRangeException("Number is invalid");
            }
            if(!CanMakeGuess){
                return Outcome.NoMoreGuesses;
            }
            else if (PreviousGuesses.Contains(number))
            {
                return Outcome.PreviousGuess;
            }
            else if(number > _number){
                _previousGuesses.Add(number);
                return Outcome.High;
            }
            else if(number < _number){
                _previousGuesses.Add(number);
                return Outcome.Low;
            }
            else if(number == _number){
                _previousGuesses.Add(number);
                return Outcome.Correct;
            }
            
            return Outcome.Indefinite;
        }

    }
}
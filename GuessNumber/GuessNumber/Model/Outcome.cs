using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuessNumber.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess

    }
}
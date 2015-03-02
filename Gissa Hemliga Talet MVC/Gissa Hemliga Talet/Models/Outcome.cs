using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Gissa_Hemliga_Talet
{
    public enum Outcome
    {
        Undefined,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess

    }
}

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Gissa_Hemliga_Talet
{
    public struct GuessedNumber
    {
        public int? Number;
        public Outcome Outcome;
    }
}

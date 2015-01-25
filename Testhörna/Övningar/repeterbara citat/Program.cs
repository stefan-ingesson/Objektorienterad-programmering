using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repeterbara_citat
{
    class Program
    {
        static void Main(string[] args)
        {
            QuotationViewer qw = new QuotationViewer();
            qw.Quotation = "\"I have a dream\"";
            qw.Count = 7;
            qw.View();

            QuotationViewer qwNew = new QuotationViewer();
            qwNew.Quotation = "\"Make love, not war\"";
            qwNew.Count = 3;
            qwNew.View();

            QuotationViewer qwNewQuote = new QuotationViewer();
            qwNewQuote.Quotation = "\"Et tu, Brute\"";
            qwNewQuote.Count = 3;
            qwNewQuote.View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repeterbara_citat
{
   public class QuotationViewer
    {
        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private string _quotation;

        public string Quotation
        {
            get { return _quotation; }
            set { _quotation = value; }
        }

        public QuotationViewer()
        {
            _quotation = null;
            _count = 0;
        }

        public QuotationViewer(string quotation, int count)
        {
            _quotation = quotation;
            _count = count;
        }

        public void View()
        {
            Console.WriteLine("------------");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_quotation);
            }
            Console.WriteLine();
        }
   }
}

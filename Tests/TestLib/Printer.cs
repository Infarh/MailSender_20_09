using System;
using System.Collections.Generic;
using System.Text;

namespace TestLib
{
    public class Printer
    {
        private string _Prefix;

        public Printer(string Prefix)
        {
            _Prefix = Prefix;
        }

        public virtual void Print(string Message)
        {
            Console.WriteLine("{0}{1}", _Prefix, Message);
        }
    }

    internal class InternalPrinter : Printer
    {
        public int Value { get; set; }

        public InternalPrinter() : base("Internal:")
        {
            
        }

        public virtual void Print(string Message)
        {
            Console.WriteLine("Private! = " + Value);
            base.Print(Message);
        }
    }
}

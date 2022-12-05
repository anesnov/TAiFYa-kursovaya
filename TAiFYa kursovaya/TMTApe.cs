using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAiFYa_kursovaya
{
    internal class TMTape
    {
        private StringBuilder tape;
        private int position;

        public StringBuilder Tape
        {
            set 
            {
                if (value.Length > 0)
                    tape = value;
                else tape = new StringBuilder('λ');
                position = 0;
            }
            get { return tape; }
        }

        public char Current
        {
            get { return tape[position]; }
            set { tape[position] = value; }
        }

        public int Length { get { return tape.Length; } }

        public TMTape(StringBuilder tape)
        {
            this.tape = tape;
        }

        public TMTape(string word)
        {
            if (word.Length > 0)
                tape = new StringBuilder(word);
            else tape = new StringBuilder("λ");
        }

        public override string ToString()
        {
            return tape.ToString();
        }

        public void Move(int m)
        {
            if (position + m < 0)
            {
                tape.Insert(0, 'λ');
            }
            else if (position + m >= tape.Length)
            {
                tape.Insert(position + 1, 'λ');
                position++;
            }
            else position += m;
        }

        public string Step(string s)
        {
            return tape.ToString().Insert(position, s);
        }
    }
}

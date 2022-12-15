using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAiFYa_kursovaya
{
    class STTuringMachine
    {
        private static List<Dictionary<char, Tuple<char,int,int>>> comands; // q(n) = dict('char' : ('nextchar', nextpos, nextstep))
        private TMTape tape;
        public TMTape Tape
        {
            get { return tape; }
            set
            {
                tape = value;
                step = 0;
                count = 1;
            }
        }
        private int step = 0;
        public int Step { get { return step; } }
        int count = 1;

        public STTuringMachine()
        {
            comands = new List<Dictionary<char, Tuple<char,int,int>>>()
            {
                new Dictionary<char, Tuple<char, int, int>>() //q0
                {
                    { '0', new Tuple<char, int, int>('0', 1, 3) },
                    { '1', new Tuple<char, int, int>('1', 1, 3) },
                    { 'λ', new Tuple<char, int, int>('T', 1, 14) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q1
                {
                    { '0', new Tuple<char, int, int>('0', 1, 1) },
                    { '1', new Tuple<char, int, int>('1', 1, 1) },
                    { 'a', new Tuple<char, int, int>('0', 1, 2) },
                    { 'b', new Tuple<char, int, int>('1', 1, 2) },
                    { '*', new Tuple<char, int, int>('*', 1, 1) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q2
                {
                    { '0', new Tuple<char, int, int>('0', 1, 3) },
                    { '1', new Tuple<char, int, int>('1', 1, 3) },
                    { 'λ', new Tuple<char, int, int>('λ', -1, 5) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q3
                {
                    { '0', new Tuple<char, int, int>('a', -1, 4) },
                    { '1', new Tuple<char, int, int>('b', -1, 4) },
                    { 'λ', new Tuple<char, int, int>('λ', -1, 16) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q4
                {
                    { '0', new Tuple<char, int, int>('0', -1, 4) },
                    { '1', new Tuple<char, int, int>('1', -1, 4) },
                    { '*', new Tuple<char, int, int>('*', -1, 4) },
                    { 'λ', new Tuple<char, int, int>('*', 1, 1) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q5
                {
                    { '0', new Tuple<char, int, int>('0', -1, 5) },
                    { '1', new Tuple<char, int, int>('1', -1, 5) },
                    { 'a', new Tuple<char, int, int>('a', -1, 5) },
                    { 'b', new Tuple<char, int, int>('b', -1, 5) },
                    { '*', new Tuple<char, int, int>('*', -1, 5) },
                    { 'λ', new Tuple<char, int, int>('λ', 1, 6) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q6
                {
                    { 'a', new Tuple<char, int, int>('a', 1, 8) },
                    { 'b', new Tuple<char, int, int>('b', 1, 8) },
                    { '*', new Tuple<char, int, int>('λ', 1, 7) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q7
                {
                    { '0', new Tuple<char, int, int>('a', -1, 5) },
                    { '1', new Tuple<char, int, int>('b', -1, 5) },
                    { 'a', new Tuple<char, int, int>('a', 1, 7) },
                    { 'b', new Tuple<char, int, int>('b', 1, 7) },
                    { '*', new Tuple<char, int, int>('*', 1, 7) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q8
                {
                    { '0', new Tuple<char, int, int>('0', -1, 9) },
                    { '1', new Tuple<char, int, int>('1', -1, 9) },
                    { 'a', new Tuple<char, int, int>('a', 1, 8) },
                    { 'b', new Tuple<char, int, int>('b', 1, 8) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q9
                {
                    { '0', new Tuple<char, int, int>('0', -1, 9) },
                    { '1', new Tuple<char, int, int>('1', -1, 9) },
                    { 'a', new Tuple<char, int, int>('0', 1, 10) },
                    { 'b', new Tuple<char, int, int>('1', 1, 12) },
                    { 'λ', new Tuple<char, int, int>('T', 1, 14) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q10
                {
                    { '0', new Tuple<char, int, int>('0', 1, 10) },
                    { '1', new Tuple<char, int, int>('1', 1, 10) },
                    { 'a', new Tuple<char, int, int>('a', -1, 11) },
                    { 'b', new Tuple<char, int, int>('b', -1, 11) },
                    { 'λ', new Tuple<char, int, int>('λ', -1, 11) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q11
                {
                    { '0', new Tuple<char, int, int>('a', -1, 8) },
                    { '1', new Tuple<char, int, int>('1', -1, 16) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q12
                {
                    { '0', new Tuple<char, int, int>('0', 1, 12) },
                    { '1', new Tuple<char, int, int>('1', 1, 12) },
                    { 'a', new Tuple<char, int, int>('a', -1, 13) },
                    { 'b', new Tuple<char, int, int>('b', -1, 13) },
                    { 'λ', new Tuple<char, int, int>('λ', -1, 13) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q13
                {
                    { '0', new Tuple<char, int, int>('0', -1, 16) },
                    { '1', new Tuple<char, int, int>('b', -1, 8) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q14
                {
                    { '0', new Tuple<char, int, int>('λ', 1, 14) },
                    { '1', new Tuple<char, int, int>('λ', 1, 14) },
                    { 'a', new Tuple<char, int, int>('λ', 1, 14) },
                    { 'b', new Tuple<char, int, int>('λ', 1, 14) },
                    { '*', new Tuple<char, int, int>('λ', 1, 14) },
                    { 'T', new Tuple<char, int, int>('T', 1, 14) },
                    { 'F', new Tuple<char, int, int>('F', 1, 14) },
                    { 'λ', new Tuple<char, int, int>('λ', -1, 15) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q15
                {
                    { 'T', new Tuple<char, int, int>('T', 0, -1) },
                    { 'F', new Tuple<char, int, int>('F', 0, -1) },
                    { 'λ', new Tuple<char, int, int>('λ', -1, 15) }
                },
                new Dictionary<char, Tuple<char, int, int>>() //q16
                {
                    { '0', new Tuple<char, int, int>('0', -1, 16) },
                    { '1', new Tuple<char, int, int>('1', -1, 16) },
                    { 'a', new Tuple<char, int, int>('a', -1, 16) },
                    { 'b', new Tuple<char, int, int>('b', -1, 16) },
                    { '*', new Tuple<char, int, int>('*', -1, 16) },
                    { 'T', new Tuple<char, int, int>('T', -1, 16) },
                    { 'F', new Tuple<char, int, int>('F', -1, 16) },
                    { 'λ', new Tuple<char, int, int>('F', 1, 14) }
                }
            };
            tape = null;
        }

        public string Next()
        {
            try
            {
                if (step == -1)
                    return "Машина завершила работу.";
                // Tuple<char, int, int> next = null;
                if (!comands[step].TryGetValue(tape.Current, out var next)) throw new Exception("Машина прекратила работу раньше положенного! Намер шага: " + step.ToString());
                
                var step_string = count.ToString() + ". " + tape.Step("[q" + (step).ToString() + ']');
                step = next.Item3;
                tape.Current = next.Item1;
                tape.Move(next.Item2);
                count++;
                if (next.Item3 == -1)
                {
                    step = -1;
                    return count.ToString() + ". " + tape.Step("[qz]");
                }
                return step_string;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ex.Message;
            }            
        }

        public static int Evaluate(int length, CancellationToken cts)
        {
            int max = 0;

            for (ulong i = 0; i < (ulong)Math.Pow(2, length); i++)
            {
                cts.ThrowIfCancellationRequested();
                string str = Convert.ToString((long)i, 2);
                StringBuilder sb = new StringBuilder(new string('0', length > 0 ? length - str.Length : 0) + str);
                max = Math.Max(max, Run(sb));
            }

            return max;
        }

        public static int Run(StringBuilder word) 
        {
            int cnt = 1;
            int stp = 0;
            TMTape tape = new TMTape(word);

            while (stp != -1)
            {
                var next = comands[stp][tape.Current];
                if (next == null) throw new Exception("Машина прекратила работу раньше положенного! Намер шага: " + stp.ToString());
                else if (next.Item3 == -1)
                {
                    stp = -1;
                    return cnt;
                }
                stp = next.Item3;
                tape.Current = next.Item1;
                tape.Move(next.Item2);
                cnt++;
            }

            return cnt;
        }
    }
}

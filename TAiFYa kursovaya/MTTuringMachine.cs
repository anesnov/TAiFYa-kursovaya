using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAiFYa_kursovaya
{
    internal class MTTuringMachine
    {
        private static List<Dictionary<string, Tuple<List<char>, List<int>, int>>> comands;
        /* q(n) = dict('keystring' : ((nextchar1, nextchar2, nextchar3), (nextpos1, nextpos2, nextpos3), nextstep))
                        keystring = tapes[0][pos1] + tapes[1][pos2] + tapes[2][pos3] */              
        private int count = 1;
        private int step = 0;
        public int Step { get { return step; } }

        private List<TMTape> tapes = null;
        public TMTape Tapes
        {
            set
            {
                tapes = new List<TMTape>() { value, new TMTape("λ"), new TMTape("λ") };
                count = 1;
                step = 0;
            }
        }

        public MTTuringMachine()
        {
            comands = new List<Dictionary<string, Tuple<List<char>, List<int>, int>>>()
            {
                new Dictionary<string, Tuple<List<char>, List<int>, int>>() //q0
                {
                    { "0λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'0', 'λ', 'λ'}, 
                        new List<int>() { 1, 0, 0 }, 1) },
                    { "1λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'1', 'λ', 'λ'}, 
                        new List<int>() { 1, 0, 0 }, 1) },
                    { "λλλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'}, 
                        new List<int>() { -1, -1, 0 }, 2) }
                },
                new Dictionary<string, Tuple<List<char>, List<int>, int>>() //q1 - tape[1] = tape[0] mod 2
                {
                    { "0λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'0', '*', 'λ'},
                        new List<int>() { 1, 1, 0 }, 0) },
                    { "1λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'1', '*', 'λ'},
                        new List<int>() { 1, 1, 0 }, 0) },
                    { "λλλ", new Tuple<List<char>, List<int>, int>( // konets
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, -1, 0 }, 5) }
                },
                new Dictionary<string, Tuple<List<char>, List<int>, int>>() //q2 - tape[2] = tape[0] - tape[1]
                {
                    { "0*λ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', '0'},
                        new List<int>() { -1, -1, 1 }, 2) },
                    { "1*λ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', '1'},
                        new List<int>() { -1, -1, 1 }, 2) },
                    { "0λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'0', 'λ', 'λ'},
                        new List<int>() { 0, 0, -1 }, 3) },
                    { "1λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'1', 'λ', 'λ'},
                        new List<int>() { 0, 0, -1 }, 3) },
                    { "λλλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'T', 'λ', 'λ'},
                        new List<int>() { 0, 0, 0 }, -1) }
                },
                new Dictionary<string, Tuple<List<char>, List<int>, int>>() //q3 - возвращение в начало на tape[2] 
                {
                    { "0λ0", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'0', 'λ', '0'},
                        new List<int>() { 0, 0, -1 }, 3) },
                    { "1λ0", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'1', 'λ', '0'},
                        new List<int>() { 0, 0, -1 }, 3) },
                    { "0λ1", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'0', 'λ', '1'},
                        new List<int>() { 0, 0, -1 }, 3) },
                    { "1λ1", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'1', 'λ', '1'},
                        new List<int>() { 0, 0, -1 }, 3) },
                    { "0λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'0', 'λ', 'λ'},
                        new List<int>() { 0, 0, 1 }, 4) },
                    { "1λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'1', 'λ', 'λ'},
                        new List<int>() { 0, 0, 1 }, 4) }
                },
                new Dictionary<string, Tuple<List<char>, List<int>, int>>() //q4 - посимвольное сравнение с удалением
                {

                    { "0λ0", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 4) },
                    { "1λ0", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 5) },
                    { "0λ1", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 5) },
                    { "1λ1", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 4) },
                    { "λλλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'T', 'λ', 'λ'},
                        new List<int>() { 0, 0, 0 }, -1) }
                },
                new Dictionary<string, Tuple<List<char>, List<int>, int>>() //q5 - очистка ленты
                {
                    { "0*λ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, -1, 0 }, 5) },
                    { "1*λ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, -1, 0 }, 5) },
                    { "0λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 0 }, 5) },
                    { "1λλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 0 }, 5) },
                    { "0λ0", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 5) },
                    { "1λ0", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 5) },
                    { "0λ1", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 5) },
                    { "1λ1", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){ 'λ', 'λ', 'λ'},
                        new List<int>() { -1, 0, 1 }, 5) },
                    { "λλλ", new Tuple<List<char>, List<int>, int>(
                        new List<char>(){'F', 'λ', 'λ'},
                        new List<int>() { 0, 0, 0 }, -1) }
                }
            };
        }

        public List<string> Next()
        {
            try
            {
                var output = new List<string>();
                if (step == -1)
                {
                    output.Add("Машина завершила работу.");
                    return output;
                }
                Tuple<List<char>, List<int>, int> next = null;
                string curr = tapes[0].Current.ToString() + tapes[1].Current + tapes[2].Current;
                if (!comands[step].TryGetValue(curr, out next))
                    throw new Exception("Машина прекратила работу раньше положенного! Намер шага: " + step.ToString());

                output.Add(count.ToString() + ": " + curr);
                
                for (int i=0; i < next.Item1.Count; i++)
                {
                    if (next.Item3 != -1)
                        output.Add(tapes[i].Step("[q" + (step).ToString() + ']'));
                    tapes[i].Current = next.Item1[i];
                    tapes[i].Move(next.Item2[i]);


                    if (next.Item3 == -1) output.Add(tapes[i].Step("[qz]"));
                }
                step = next.Item3;
                count++;
                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<string>() { ex.Message };
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
            List<TMTape> tapes = new List<TMTape>() { new TMTape(word), new TMTape("λ"), new TMTape("λ") };

            while (stp != -1)
            {
                Tuple<List<char>, List<int>, int> next = null;
                string curr = tapes[0].Current.ToString() + tapes[1].Current + tapes[2].Current;
                if (!comands[stp].TryGetValue(curr, out next))
                    throw new Exception("Машина прекратила работу раньше положенного! Намер шага: " + stp.ToString());


                for (int i = 0; i < next.Item1.Count; i++)
                {
                    tapes[i].Current = next.Item1[i];
                    tapes[i].Move(next.Item2[i]);
                }
                stp = next.Item3;
                cnt++;
            }

            return cnt;
        }
    }
}

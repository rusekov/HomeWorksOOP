/* By using delegates develop an universal static method to calculate the sum of infinite convergent series with given precision 
 * depending on a function of its term. By using proper functions for the term calculate with a 2-digit precision the sum of 
 * the infinite series:
 * 1 + 1/2 + 1/4 + 1/8 + 1/16 + …
 * 1 + 1/2! + 1/3! + 1/4! + 1/5! + …
 * 1 + 1/2 - 1/4 + 1/8 - 1/16 + … 
 * 1 + 1/2 + 1/3 + 1/4 + 1/5 + … 
*/

//// not good :)

namespace InfiniteConvergent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class InfiniteCalc
    {
        private const int AfterDecimal = 2;

        public delegate void ConvergentProcess(List<string> list);

        public delegate List<string> ToListProcess(string input);

        public delegate string ToStringProcess(List<string> processedList);

        public static void Main()
        {
            string input = @"1 + 1/2 + 1/4 + 1/8 + 1/16 + 1/32";

            ToListProcess tolist = new ToListProcess(TansformToList);
            
            List<string> members = tolist(input);
            
            ConvergentProcess processor = new ConvergentProcess(Factoriel);
            processor += Pow;
            processor += Multiplication;
            processor += Division;
            processor += Minus;
            processor(members);

            ToStringProcess toString = new ToStringProcess(Calculate);

            string result = toString(members);

            Console.WriteLine("The Result is: {0}", result);
        }

        private static List<string> TansformToList(string input)
        {
            string expression = input
                            .Replace("/", " / ")
                            .Replace("*", " * ")
                            .Replace("%", " % ")
                            .Replace("+", " + ")
                            .Replace("-", " - ")
                            .Replace("!", " ! ")
                            .Replace("^", " ^ ")
                            .Replace("+ ...", string.Empty)
                            .Replace("+...", string.Empty);

            List<string> members = new List<string>(expression.Split(new[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries));
            return members;
        }

        private static string Calculate(List<string> members)
        {
            decimal firstMember = decimal.Parse(members[0]);
            List<decimal> coeficient = new List<decimal>();

            for (int i = 2; i < members.Count; i++)
            {
                if (members[i] == "+")
                {
                    coeficient.Add(decimal.Parse(members[i + 1]) / decimal.Parse(members[i - 1]));
                }
            }

            decimal baseCoeficien = coeficient[0];
            bool constantCoefiecient = true;
            for (int i = 0; i < coeficient.Count; i++)
            {
                if (coeficient[i] != baseCoeficien)
                {
                    constantCoefiecient = false;
                    break;
                }
            }

            if (constantCoefiecient)
            {
                if (baseCoeficien >= 1)
                {
                    if (decimal.Parse(members[2]) > 0)
                    {
                        return "Infiniti";
                    }
                    else if (decimal.Parse(members[2]) < 0)
                    {
                        return "- Infiniti";
                    }
                    else
                    {
                        return members[0].ToString();
                    }
                }
                else
                {
                    return ConstantExpander(members, baseCoeficien, AfterDecimal);
                }
            }
            else
            {
                if (coeficient[1] > coeficient[0])
                {
                    if (decimal.Parse(members[2]) > 0)
                    {
                        return "Infiniti";
                    }
                    else if (decimal.Parse(members[2]) < 0)
                    {
                        return "- Infiniti";
                    }
                }

                string result = VariableExpander(members, coeficient[coeficient.Count - 1], coeficient[coeficient.Count - 2], AfterDecimal);
                return string.Format("(could be so wrong) {0}", result);
            }            
        }

        private static string VariableExpander(List<string> members, decimal coefLast, decimal coefPrevious, int afterDecimal)
        {
            decimal lastMember = decimal.Parse(members[members.Count - 1]);
            decimal result = new decimal();

            for (int i = 0; i < members.Count; i++)
            {
                if (members[i] == "+")
                {
                    result = decimal.Parse(members[i - 1]) + decimal.Parse(members[i + 1]);
                    members[i - 1] = result.ToString();
                    members.RemoveAt(i + 1);
                    members.RemoveAt(i);
                    i--;
                }
            }

            decimal before = decimal.MinValue;
            decimal after = decimal.MaxValue;
            
            while (before != after)
            {
                before = after;

                decimal coeficientBase = (1 / coefLast) / (1 / coefPrevious);
                decimal coeficient = 1 / ((1 / coefLast) * coeficientBase);
                coefPrevious = coefLast;
                coefLast = coeficient;
                
                lastMember = lastMember * coeficient;
                
                result += lastMember;
                after = Math.Round(result, afterDecimal + 1);
            }
            
            Console.WriteLine();
            return after.ToString();
        }

        private static string ConstantExpander(List<string> members, decimal baseCoeficien, int afterDecimal)
        {
            decimal lastMember = decimal.Parse(members[members.Count - 1]);
            decimal result = new decimal();
            
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i] == "+")
                {
                    result = decimal.Parse(members[i - 1]) + decimal.Parse(members[i + 1]);
                    members[i - 1] = result.ToString();
                    members.RemoveAt(i + 1);
                    members.RemoveAt(i);
                    i--;
                }
            }
            
            decimal before = decimal.MinValue;
            decimal after = decimal.MaxValue;
            
            while (before != after)
            {
                before = after;
                lastMember = lastMember * baseCoeficien;
                result += lastMember;
                after = Math.Round(result, afterDecimal + 1);
            }

            Console.WriteLine();
            return after.ToString();
        }

        private static void Minus(List<string> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i] == "-")
                {
                    decimal result = decimal.Parse(members[i - 1]) - decimal.Parse(members[i + 1]);
                    members[i - 1] = result.ToString();
                    members.RemoveAt(i + 1);
                    members.RemoveAt(i);
                    i--;
                }
            }

            Console.Write("Submition Done: ");
            members.ForEach(Console.Write);
            Console.WriteLine();
        }

        private static void Multiplication(List<string> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i] == "*")
                {
                    BigInteger result = int.Parse(members[i - 1]) * int.Parse(members[i + 1]);
                    members[i - 1] = result.ToString();
                    members.RemoveAt(i + 1);
                    members.RemoveAt(i);
                    i--;
                }            
            }

            Console.Write("Miltiplication Done: ");
            members.ForEach(Console.Write);
            Console.WriteLine();
        }

        private static void Division(List<string> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i] == "/")
                {
                    decimal result = decimal.Parse(members[i - 1]) / decimal.Parse(members[i + 1]);
                    members[i - 1] = result.ToString();
                    members.RemoveAt(i + 1);
                    members.RemoveAt(i);
                    i--;
                }
            }

            Console.Write("Division Done: ");
            members.ForEach(Console.Write);
            Console.WriteLine();
        }

        private static void Pow(List<string> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i] == "^")
                {
                    BigInteger result = 1;

                    for (int j = int.Parse(members[i + 1]); j > 0; j--)
                    {
                        result *= int.Parse(members[i - 1]);
                    }

                    members[i - 1] = result.ToString();
                    members.RemoveAt(i + 1);
                    members.RemoveAt(i);
                    i--;
                }
            }

            Console.Write("Power Done: ");
            members.ForEach(Console.Write);
            Console.WriteLine();
        }

        private static void Factoriel(List<string> members)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i] == "!")
                {
                    BigInteger result = 1;

                    for (int j = int.Parse(members[i - 1]); j > 0; j--)
                    {
                        result *= j;
                    }

                    members[i - 1] = result.ToString();
                    members.RemoveAt(i);
                    i--;
                }               
            }

            Console.Write("Factoriel Done: ");
            members.ForEach(Console.Write);
            Console.WriteLine();
        }
    }
}

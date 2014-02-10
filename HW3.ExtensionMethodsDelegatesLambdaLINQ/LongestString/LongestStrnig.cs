﻿//// 17.Write a program to return the string with maximum length from an array of strings. Use LINQ.

namespace LongestString
{
    using System;
    using System.Linq;

    public class LongestStrnig
    {
        public static void Main()
        {
            string inputText = "Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam eaque ipsa, quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt, explicabo. Nemo enim ipsam voluptatem, quia voluptas sit, aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos, qui ratione voluptatem sequi nesciunt, neque porro quisquam est, qui dolorem ipsum, quia dolor sit amet consectetur adipisci[ng] velit, sed quia non numquam [do] eius modi tempora inci[di]dunt, ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit, qui in ea voluptate velit esse, quam nihil molestiae consequatur, vel illum, qui dolorem eum fugiat, quo voluptas nulla pariatur?";

            string[] words = inputText.Split(new[] { ' ', ',', '?', '.', '!' }, StringSplitOptions.RemoveEmptyEntries);

            int maxLength = words.Max(z => z.Length);
            string longestWord = words.First(x => x.Length == maxLength);

            Console.WriteLine(longestWord);
        }
    }
}
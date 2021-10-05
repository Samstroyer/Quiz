using System;
using System.Collections.Generic;
using System.IO;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            int points = 0;
            Console.WriteLine("Välkommen till mitt quiz!");
            Console.WriteLine("Svara med 1-3 på tangentbordet, försök få så många poäng som möjligt!");

            Console.ReadLine();

            List<int> questions = new List<int>();
            for (int i = 0; i < 10; i++)
            {
            Again:
                int next = ran.Next(1, 32);
                if (questions.Contains(next))
                {
                    goto Again;
                }
                else
                {
                    questions.Add(next);
                }
            }
        }
        static void mess()
        {
            string[] contents = File.ReadAllLines(@"..\qna.csv");
            List<string[]> LineContents = new List<string[]>();
            foreach (string c in contents)
            {
                LineContents.Add(c.Split(","));
            }
            string[][] qna = LineContents.ToArray();
        }
    }
}

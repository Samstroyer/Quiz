using System;
using System.Collections.Generic;
using System.IO;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            int diff;

            Console.WriteLine("Välkommen till mitt quiz!");
            Console.WriteLine($"test {points}");
            Console.WriteLine("Svara med 1-3 på tangentbordet, försök få så många poäng som möjligt!");

            Console.ReadLine();

        difficulty:
            Console.WriteLine("Vill du köra lätta (1) versionen eller svåra (2)?");
            diff = int.Parse(Console.ReadLine());

            if (diff == 1)
            {
                points += easy();
            }
            else if (diff == 2)
            {
                points += hard();
            }
            else
            {
                goto difficulty;
            }

            Console.WriteLine("You finished the quiz with");


            Console.ReadLine();

            /* 
            Console.ReadLine();
            qna[1][0] == question
            qna[1][1] == answer

            foreach (int n in questions)
            {
                Console.WriteLine(n);
            }
            */

        }


        static int easy()
        {
            int tempScore = 0;
            List<int> questions = generateQuestions();
            string[][] qna = mess();
            Random ran = new Random();

            foreach (int q in questions)
            {
                List<int> alternativ = new List<int>();
                for (int i = 0; i < 3; i++)
                {
                start:
                    int temp = ran.Next(1, qna.Length);
                    if (alternativ.Contains(temp) || q == temp)
                    {
                        goto start;
                    }
                    else
                    {
                        alternativ.Add(temp);
                    }
                }
                alternativ.Sort();

                int correct = ran.Next(0, 2);
                alternativ[correct] = q;

                Console.WriteLine(qna[q][0]);
                Console.Write($"1) {qna[alternativ[0]][1]}. 2) {qna[alternativ[1]][1]}. 3) {qna[alternativ[2]][1]}");
                int svar = Int32.Parse(Console.ReadLine());

                if (svar - 1 == alternativ[correct])
                {
                    tempScore++;
                }
            }

            return tempScore;
        }

        static int hard()
        {
            int tempScore = 0;
            List<int> questions = generateQuestions();
            string[][] qna = mess();

            foreach (int q in questions)
            {
                Console.WriteLine(qna[q][0]);
                string svar = Console.ReadLine().ToLower();

                if (svar == qna[q][1])
                {
                    tempScore++;
                    Console.WriteLine("Correct!");
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    Console.WriteLine("Wrong, better luck next time!");
                    System.Threading.Thread.Sleep(100);
                }
            }

            return tempScore;

        }
        static string[][] mess()

        {
            string[] contents = File.ReadAllLines(@"..\qna.csv");
            List<string[]> LineContents = new List<string[]>();
            foreach (string c in contents)
            {
                LineContents.Add(c.Split(","));
            }
            return LineContents.ToArray();
        }
        static List<int> generateQuestions()
        {
            Random ran = new Random();

            //Generera vilka frågor som ska komma, får inte vara dubbletter.
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
            return questions;

        }
    }
}

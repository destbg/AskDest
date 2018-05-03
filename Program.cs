using System;
using System.IO;
using static System.Console;

namespace AskDest {
    class Program {
        static Random rnd = new Random();
        static string[] askAnswres = File.ReadAllLines("AskAnswers.txt");
        static string[] banWords = File.ReadAllLines("BanWords.dest");
        static void Main() {
            Title = "AskDest";
            WriteLine("Welcome to AskDest. Created by destbg.\n" +
                "If you want to edit the answers go to the AskAnswers.txt file.\n" +
                "Ask a question that can be answered with yes or no.\n" +
                "And don't swear!\n");
            while (true) {
                Write("Ask: ");
                string question = ReadLine().ToLower().Trim();
                if (question == "") continue;
                string[] check = question.Split(' ');
                bool isQuestion = false;
                for (int i = 0; i < check.Length; i++)
                    if (check[i] == "is"
                        || check[i] == "can"
                        || check[i] == "has"
                        || check[i] == "will"
                        || check[i] == "should"
                        || check[i] == "would"
                        || check[i] == "am"
                        || check[i] == "did"
                        || check[i] == "does"
                        || check[i] == "are"
                        || check[i] == "r") isQuestion = true;
                for (int i = 0; i < banWords.Length; i++)
                    if (question.Contains(banWords[i])) {
                        int helper = question.IndexOf(banWords[i]);
                        SetCursorPosition(helper + 5, CursorTop - 1);
                        WriteLine(new string('*', banWords[i].Length));
                        question = question.Replace(banWords[i], new string('*', banWords[i].Length));
                        i--;
                    }
                if (!isQuestion) {
                    WriteLine("Couldn't understand your question.\n");
                    continue;
                }
                WriteLine("AskDest answeres: " + askAnswres[rnd.Next(askAnswres.Length)] + "\n");
            }
        }
    }
}

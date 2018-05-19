using System;
using System.IO;
using static System.Console;

namespace AskDest {
    class Program {
        static void Main() {
            string[] askAnswres;
            string[] banWords;
            if (!File.Exists("AskAnswers.txt")) {
                WriteLine("The file AskAnswers.txt is missing!");
                return;
            }
            else if (!File.Exists("BanWords.dest")) {
                WriteLine("The file BanWords.dest is missing!");
                return;
            }
            else {
                askAnswres = File.ReadAllLines("AskAnswers.txt");
                banWords = File.ReadAllLines("BanWords.dest");
            }
            var rnd = new Random();
            Title = "AskDest";
            WriteLine("Welcome to AskDest. Created by destbg.\n" +
                "If you want to edit the answers go to the AskAnswers.txt file.\n" +
                "Ask a question that can be answered with yes or no.\n" +
                "And don't swear!\n");
            while (true) {
                Write("Ask: ");
                string question = ReadLine().ToLower();
                if (question.Trim() == "") continue;
                bool isQuestion = IsQuestion(question);
                for (int i = 0; i < banWords.Length; i++)
                    if (question.Contains(banWords[i])) {
                        int helper = question.IndexOf(banWords[i]);
                        SetCursorPosition(helper + 5, CursorTop - 1);
                        WriteLine(new string('*', banWords[i].Length));
                        question = question.Remove(helper, banWords[i].Length)
                            .Insert(helper, new string('*', banWords[i].Length));
                        i--;
                    }
                if (!isQuestion)
                    WriteLine("Couldn't understand your question.\n");
                else WriteLine("AskDest answeres: " + askAnswres[rnd.Next(askAnswres.Length)] + "\n");
            }
        }

        private static bool IsQuestion(string question) {
            string[] check = question.Trim().Split(",.?! ".ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries);
            bool isQuestion = false;
            for (int i = 0; i < check.Length; i++)
                if (check[i] == "is"
                    || check[i] == "isnt"
                    || check[i] == "isn't"
                    || check[i] == "has"
                    || check[i] == "hasnt"
                    || check[i] == "hasn't"
                    || check[i] == "can"
                    || check[i] == "cant"
                    || check[i] == "can't"
                    || check[i] == "could"
                    || check[i] == "couldnt"
                    || check[i] == "couldn't"
                    || check[i] == "should"
                    || check[i] == "shouldnt"
                    || check[i] == "shouldn't"
                    || check[i] == "will"
                    || check[i] == "wont"
                    || check[i] == "won't"
                    || check[i] == "would"
                    || check[i] == "wouldnt"
                    || check[i] == "wouldn't"
                    || check[i] == "am"
                    || check[i] == "did"
                    || check[i] == "didnt"
                    || check[i] == "didn't"
                    || check[i] == "do"
                    || check[i] == "dont"
                    || check[i] == "don't"
                    || check[i] == "does"
                    || check[i] == "doesnt"
                    || check[i] == "doesn't"
                    || check[i] == "are"
                    || check[i] == "arent"
                    || check[i] == "aren't"
                    || check[i] == "r") {
                    isQuestion = true;
                    break;
                }
            if (isQuestion)
                for (int i = 0; i < check.Length; i++)
                    if (check[i].StartsWith("what")
                        || check[i].StartsWith("why")
                        || check[i].StartsWith("where")
                        || check[i].StartsWith("when")
                        || check[i].StartsWith("who")
                        || check[i].StartsWith("how")) {
                        isQuestion = false;
                        break;
                    }
            return isQuestion;
        }
    }
}
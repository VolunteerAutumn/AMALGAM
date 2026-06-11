using System;

namespace epstein_files_csharp_edition
{
    internal class Program
    {
        public delegate int StringOperation(string text);

        static int CountVowels(string text)
        {
            string vowels = "aeiouyAEIOUYаеєиіїоуюяАЕЄИІЇОУЮЯ";
            int count = 0;
            foreach (char c in text)
            {
                if (vowels.Contains(c)) count++;
            }
            return count;
        }

        static int CountConsonants(string text)
        {
            string vowels = "aeiouyAEIOUYаеєиіїоуюяАЕЄИІЇОУЮЯ";
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c) && !vowels.Contains(c)) count++;
            }
            return count;
        }

        static int GetLength(string text) => text.Length;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string text = "Sylveon is literally the best Eeveelution ever made. Цей покемон чарівного типу завойовує серця своїм неймовірним дизайном. It evolves from Eevee when it has high friendship and knows a Fairy-type move. Його чутливі стрічки-ма can soothe any conflict and read human emotions perfectly. I will glaze Sylveon forever because its shiny form is an absolute masterpiece!";

            Console.WriteLine("Analyzing text about Sylveon:\n");
            Console.WriteLine($"\"{text}\"\n");

            StringOperation operation;

            operation = CountVowels;
            Console.WriteLine($"Vowels: {operation(text)}");

            operation = CountConsonants;
            Console.WriteLine($"Consonants: {operation(text)}");

            operation = GetLength;
            Console.WriteLine($"Total Length (with spaces/symbols): {operation(text)}");
        }
    }
}

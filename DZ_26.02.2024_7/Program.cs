/* Создайте приложение, проверяющее текст на недопустимые слова. Если недопустимое 
   слово найдено, оно должно быть заменено на набор символов *. По итогам работы 
   приложения необходимо показать статистику действий. 
	Например, если и у нас есть такой текст: 
		To be, or not to be, that is the question,
        Or to take arms against a sea of troubles,
        And by opposing end them? To die: to sleep;
		No more; and by a sleep to say we end
		Devoutly to be wish'd. To die, to sleep
		
		Недопустимое слово: die.

        Результат работы:
		To be, or not to be, that is the question,
        Whether tis nobler in the mind to suffer
		The slings and arrows of outrageous fortune,
        Or to take arms against a sea of troubles,
        And by opposing end them? To ***: to sleep;
		No more; and by a sleep to say we end
		Devoutly to be wish'd. To ***, to sleep.
		
		Статистика: 2 замены слова die.*/

using System.Text.RegularExpressions;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = @" To be, or not to be, that is the question,
                        Or to take arms against a sea of troubles,
                        And by opposing end them? To die: to sleep;
                        No more; and by a sleep to say we end
                        Devoutly to be wish'd. To die, to sleep";

            List<string> replacedWord = new List<string> { "die" };

            int count = 0;

            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = Regex.Split(lines[i], @"\W+");

                for (int j = 0; j < words.Length; j++)
                {
                    if (replacedWord.Contains(words[j].ToLower()))
                    {
                        string replacement = new string('*', words[j].Length);
                        words[j] = replacement;
                        count++;
                    }
                }

                lines[i] = string.Join(" ", words);
            }

            string result = string.Join(Environment.NewLine, lines);

            Console.WriteLine(result);
            Console.WriteLine($"\nСтатистика: {count} замены слов.");          
        }
    }
}
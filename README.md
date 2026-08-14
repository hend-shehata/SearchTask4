namespace SearchTask4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter number of elements: ");
                int n = Convert.ToInt32(Console.ReadLine());

                List<int> numbers = new List<int>();

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Enter number: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    if (numbers.Contains(number))
                    {
                        throw new Exception($"Number {number} is duplicated.");
                    }

                    numbers.Add(number);
                }

                Console.WriteLine("No duplicate numbers found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("done");
            }


        }

        static void CheckVowels(string text)
        {
            bool hasVowel = false;

            foreach (char letter in text)
            {
                if ("aeiouAEIOU".Contains(letter))
                {
                    hasVowel = true;
                    break;
                }
            }

            if (!hasVowel)
            {
                throw new Exception("The string does not contain any vowels");
            }
        }
    }
}

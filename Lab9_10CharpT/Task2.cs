namespace Task2
{
    class Program
    {
        public static void Main_Task2()
        {
            string file = "C:\\Users\\YANA\\Source\\Repos\\csharplab9-vshnvsk\\Lab9_10CharpT\\input.txt";

            if (!File.Exists(file))
            {
                Console.WriteLine("File not founded");
                return;
            }

            Queue<string> upperCase = new Queue<string>();
            Queue<string> lowerCase = new Queue<string>();

            using(StreamReader reader = new StreamReader(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach(string word in words)
                    {
                        if (char.IsUpper(word[0]))
                        {
                            upperCase.Enqueue(word);
                        } 
                        else if (char.IsLower(word[0]))
                        {
                            lowerCase.Enqueue(word);
                        }
                    }
                }
            }

            Console.WriteLine("Words that start with a uppercase letter:");
            while (upperCase.Count > 0)
            {
                Console.WriteLine(upperCase.Dequeue());
            }

            Console.WriteLine("\nWords that start with a lowercase letter:");
            while (lowerCase.Count > 0)
            {
                Console.WriteLine(lowerCase.Dequeue());
            }
        }
    }
}
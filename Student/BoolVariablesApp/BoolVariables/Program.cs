namespace BoolVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> factStrings = new List<string> 
            {
                "The sky is blue", "The grass is pink", "The sun is bright", "The birds are singing", "NFM Sells dogs and cats" 
            };
            List<bool> answerKey = new List<bool> { true, false, true, true, false };
            List<bool> responses = new List<bool> { };
            int score = 0;
            bool done = false;

            for (int i = 0; i < answerKey.Count; i++)
            {
                done = false;
                while (!done)
                {
                    Console.Write($"{factStrings.ElementAt(i)} (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool response))
                    {
                        responses.Add(response);
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter true or false.");
                    }
                }
                
                if (responses.ElementAt(i) == answerKey.ElementAt(i))
                {
                    Console.WriteLine("Correct!");
                    score+= 20;
                }
                else
                {
                    Console.WriteLine("Incorrect!");
                }
            }

            if (score == 100)
            {
                Console.WriteLine($"You passed with a score of {score}%");
            }
            else
            {
                Console.WriteLine($"You failed with a score of {score}%");
            }
        }
    }
}

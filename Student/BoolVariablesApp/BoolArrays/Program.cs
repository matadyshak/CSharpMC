namespace BoolArrays
{
    internal class Program
    {
        static void Main()
        {
            string[] factStrings = new string[] 
            {
                "The sky is blue", "The grass is pink", "The sun is bright", "The birds are singing", "NFM Sells dogs and cats"
            };
            bool[] answerKey = { true, false, true, true, false };
            bool[] responses = new bool[5];
            responses[0] = false;
            responses[1] = false;
            responses[2] = false;
            responses[3] = false;
            responses[4] = false;
            int score = 0;
            bool done = false;

            for (int i = 0; i < answerKey.Length; i++)
            {
                done = false;
                while (!done)
                {
                    Console.Write($"{factStrings[i]} (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool response))
                    {
                        responses[i] = response;
                        done = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter true or false.");
                    }
                }

                if (responses[i] == answerKey[i])
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

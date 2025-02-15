namespace BowlingGame
{
    public static class BowlingSimulator
    {
        public static int[] Games { get; private set; }
        public static int Series { get; private set; }
        public static int Pins { get; private set; }
        public static string Tally { get; private set; }
        public static int[] Roll1 { get; private set; }
        public static int[] Roll2 { get; private set; }
        public static int[] Roll3 { get; private set; }
        public static int[] FrameScores { get; private set; }
        public static int[] Scores { get; private set; }
        public static Random RandomNumberGen { get; private set; }

        // Static constructor to initialize properties
        static BowlingSimulator()
        {
            Games = new int[3];
            Games[0] = 0;
            Games[1] = 0;
            Games[2] = 0;
            Series = 0;
            Roll1 = new int[10];
            Roll2 = new int[10];
            Roll3 = new int[10];
            FrameScores = new int[10];
            Scores = new int[10];

            for (int i = 0; i < 10; i++)
            {
                FrameScores[i] = -1;
                Scores[i] = -1;
                Roll1[i] = -1;
                Roll2[i] = -1;
                Roll3[i] = -1;
            }
            RandomNumberGen = new Random();
        }

        public static void BowlingSimulatorReset()
        {
            Games[0] = 0;
            Games[1] = 0;
            Games[2] = 0;
            Series = 0;
            for (int i = 0; i < 10; i++)
            {
                Roll1[i] = -1;
                Roll2[i] = -1;
                Roll3[i] = -1;
                FrameScores[i] = -1;
                Scores[i] = -1;
            }
            RandomNumberGen = new Random();
        }

        public static void RunBowlingGame()
        {
            bool gameOver = false;
            string playAgain;

            while (!gameOver)
            {
                // Bowl a 3-game series
                Games[0] = PlayBowlingGame();
                Games[1] = PlayBowlingGame();
                Games[2] = PlayBowlingGame();

                Series = Games[0] + Games[1] + Games[2];

                // Update statistics
                BowlingPlayer.UpdatePlayerStats(Series, Games, 3);
                BowlingPlayer.PrintPlayerStats(Series, Games);

                Console.Write("\n\nPlay Another Game? (Y/N): ");
                playAgain = Console.ReadLine().ToLower();
                if (playAgain != "y")
                {
                    gameOver = true;
                }
            }
            return;
        }

        public static int PlayBowlingGame()
        {
            int index = 0;
            int frame = 1;
            string tallyOut = "";

            Tally = "";

            // The tally is 4 chars per frame
            // The last char is always a space to divide the columns (Spaces shown as "_" below)

            // For frames 1-9
            //The first and last chars are always a space
            // Strike = __X_
            // Spare  = _9/_
            // Open   = _63_

            // For frame 10
            // 3 Strikes = XXX_
            // 2 Strikes = XX9_
            // 1 Strike  = X9/_
            // Spare     = 9/8_
            // Open      = 81__

            while (frame <= 10)
            {
                if (frame < 10)
                {
                    TallyFrames1To9(frame, Tally, out tallyOut);
                }
                else
                {
                    TallyFrame10(Tally, out tallyOut);
                }
                Tally = tallyOut;
                frame++; //changes to 11 to exit loop
            } // End of while loop

            // Compute game score from pins knocked down data
            Scores = ComputeScores();

            // Zeroes in tally should show as a dash
            Tally = Tally.Replace("0", "-");

            Console.WriteLine($"\n{Tally}");

            foreach (int score in Scores)
            {
                //Scores print with a width of 3 chars right justified then followed by a space
                Console.Write($"{score,3} ");
            }
            Console.Write("\n");

            //Return the game score
            return Scores[9];
        }

        static int Roll(Random random, int pinsStanding)
        {
            int index = random.Next(0, pinsStanding+1);  //0..pinsStanding

            int[] pinsDown = new int[]
            {
                pinsStanding,
                pinsStanding-1,
                pinsStanding,
                pinsStanding-2,
                pinsStanding,
                pinsStanding-3,
                pinsStanding,
                pinsStanding-4,
                pinsStanding,
                pinsStanding-5,
                pinsStanding
            };

            // In some cases the number of pins down goes negative
            // In that case we set the additional pins knocked down to zero
            Pins = Math.Max(pinsDown[index], 0);
            return Pins;
        }

        static void TallyFrames1To9(int frame, string tallyIn, out string tallyOut)
        {
            int index = frame - 1;
            tallyOut = tallyIn;

            // Roll 1st ball at 10 pins
            // Return value = Pins = Number of pins knocked down
            Roll1[index] = Pins = Roll(RandomNumberGen, 10);
            if (Pins == 10)
            {
                //Strike
                tallyOut += "  X ";
            }
            else
            {
                //Not a strike
                tallyOut += " " + Pins;
                Roll2[index] = Pins = Roll(RandomNumberGen, 10 - Pins);
                if (Roll1[index] + Roll2[index] == 10)
                {
                    //Spare
                    tallyOut += "/ ";
                }
                else
                {
                    //Open frame
                    tallyOut += Pins + " ";
                }
            } //Not a strike
        }


        static void TallyFrame10(string tallyIn, out string tallyOut)
        {
            int frame = 10;
            int index = frame -1;
            tallyOut = tallyIn;

            Roll1[index] = Pins = Roll(RandomNumberGen, 10);
            if (Pins == 10)
            {
                //First ball in 10th frame a strike
                tallyOut += "X";
                Roll2[index] = Pins = Roll(RandomNumberGen, 10);
                if (Pins == 10)
                {
                    // Two strikes in 10th frame
                    tallyOut += "X";
                    Roll3[index] = Pins = Roll(RandomNumberGen, 10);
                    //Third roll in the 10th frame
                    if (Pins == 10)
                    {
                        // Turkey!!!
                        tallyOut += "X ";
                    }
                    else
                    {
                        tallyOut += Pins + " ";
                    }
                } // 10th frame two strikes
                else
                {
                    //Strike followed by a non-strike
                    tallyOut += Pins;
                    Roll3[index] = Pins = Roll(RandomNumberGen, 10 - Pins);
                    if (Roll2[index] + Roll3[index] == 10)
                    {
                        //Spare after a strike
                        tallyOut += "/ ";
                    }
                    else
                    {   //Open after a strike
                        tallyOut += Pins + " ";
                    }
                } // 10th frame strike followed by a non-strike
            } // 10th frame first ball strike
            else
            {
                //First ball in 10th frame not a strike
                tallyOut += Pins;
                Roll2[index] = Pins = Roll(RandomNumberGen, 10 - Pins);
                if (Roll1[index] + Roll2[index] == 10)
                {
                    //Spare in 10th frame
                    tallyOut += "/";
                    //Roll 3rd ball in 10th frame
                    Roll3[index] = Pins = Roll(RandomNumberGen, 10);
                    if (Pins == 10)
                    {
                        // Spare in 10th + a strike
                        tallyOut += "X ";
                    }
                    else
                    {
                        // Spare in 10th + a non-strike
                        tallyOut += Pins + " ";
                    }
                }
                else
                {
                    // Open 10th frame
                    tallyOut += Pins + "  ";
                }
            } //First ball in 10th frame not a strike
        } // 10th frame

        static int[] ComputeScores()
        {
            int frame;

            for (int i = 0; i < 10; i++)
            {
                FrameScores[i] = 0;
                Scores[i] = 0;
            }

            // Loop on frames 1-8
            for (frame = 1; frame <= 8; frame++)
            {
                ComputeScoreFrames1To8(frame);
            }

            ComputeScoreFrame9();
            ComputeScoreFrame10();

            //Frame 1 (index 0)
            Scores[0] = FrameScores[0];

            for (int i = 1; i<=9; i++)
            {
                // Frames 2-10 (index 1-9)
                Scores[i] = Scores[i-1] + FrameScores[i];
            }

            return Scores;
        }

        static void ComputeScoreFrames1To8(int frame)
        {
            int index = frame - 1;

            if (Roll1[index] == 10)
            {
                //Strike 
                FrameScores[index] = 10 + Roll1[index+1] + Roll2[index+1];
                if (Roll1[index+1] == 10)
                {
                    // Two strikes so get 1st roll from 3rd frame from here
                    FrameScores[index] += Roll1[index+2];
                }
            }
            else if (Roll1[index] + Roll2[index] == 10)
            {
                //Spare 
                FrameScores[index] = 10 + Roll1[index+1];
            }
            else
            {
                // Open
                FrameScores[index] = Roll1[index] + Roll2[index];
            }
            return;
        }

        static void ComputeScoreFrame9()
        {
            int frame = 9;
            int index = frame - 1;

            if (Roll1[index] == 10)
            {
                //Strike in 9th frame
                FrameScores[index] = 10 + Roll1[index+1] + Roll2[index+1];
            }
            else if (Roll1[index] + Roll2[index] == 10)
            {
                //Spare in 9th frame 
                FrameScores[index] = 10 + Roll1[index+1];
            }
            else
            {
                // Open in the 9th frame
                FrameScores[index] = Roll1[index] + Roll2[index];
            }
            return;
        }

        static void ComputeScoreFrame10()
        {
            // 10th frame logic
            int frame = 10;
            int index = frame - 1;

            if (Roll1[index] == 10)
            {
                //First Strike in 10th frame
                FrameScores[index] = 10 + Roll2[index] + Roll3[index];
            }
            else if (Roll1[index] + Roll2[index] == 10)
            {
                //Spare in 10th frame 
                FrameScores[index] = 10 + Roll3[index];
            }
            else
            {
                //Open in 10th frame
                FrameScores[index] = Roll1[index] + Roll2[index];
            }
            return;
        }
    }
}

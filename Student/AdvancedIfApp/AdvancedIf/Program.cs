using System;

namespace AdvancedIf
{
    internal class Program
    {
        static void Main()
        {
            int gameCount = 1;
            bool gameOver = false;
            string playAgain = "y";

            while (!gameOver)
            {
                PlayBowlingGame();
                gameCount++;
                Console.Write("\n\nPlay Another Game? (Y/N): ");
                playAgain = Console.ReadLine().ToLower();
                if (playAgain != "y")
                {
                    gameOver = true;
                }
            }
            return;
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

            return (Math.Max(pinsDown[index], 0));
        }

        static void PlayBowlingGame()
        {
            //int ball = 1;
            int index = 0;
            int frame = 1;
            int pins = 0;
            int pinsLeft = 0;
            string tally = "";
            int[] Roll1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Roll2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Roll3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] scores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Random random = new Random();

            while (frame <= 10)
            {
                index = frame - 1;
                if (frame >= 1 && frame <= 9)
                {
                    //ball = 1;
                    pins = Roll(random, 10);
                    Roll1[index] = pins;
                    if (pins == 10)
                    {
                        //Strike
                        tally += "  X ";
                    }
                    else
                    {
                        //Not a strike
                        tally += " " +pins;
                        //ball = 2;
                        pinsLeft = 10 - pins;
                        pins = Roll(random, pinsLeft);
                        Roll2[index] = pins;
                        if (pins == pinsLeft)
                        {
                            //Spare
                            tally += "/ ";
                        }
                        else
                        {
                            //Open frame
                            tally += pins + " ";
                        }
                    } //Not a strike
                    frame++;
                } //Frames 1-9
                else if (frame == 10)
                {
                    //ball = 1;
                    pinsLeft = 10;
                    pins = Roll(random, pinsLeft);
                    Roll1[index] = pins;
                    if (pins == 10)
                    {
                        //First ball in 10th frame a strike
                        tally += "X";
                        //ball = 2;
                        pinsLeft = 10;
                        pins = Roll(random, pinsLeft);
                        Roll2[index] = pins;
                        if ((pins == 10))
                        {
                            // Two strikes in 10th frame
                            tally += "X";
                            //ball = 3;
                            pinsLeft = 10;
                            pins = Roll(random, pinsLeft);
                            Roll3[index] = pins;
                            //Third roll in the 10th frame
                            if ((pins == 10))
                            {
                                tally += "X";
                            }
                            else
                            {
                                tally += pins;
                            }
                        } // 10th frame two strikes
                        else
                        {
                            //Strike followed by a non-strike
                            tally += pins;
                            //ball = 3;
                            pinsLeft = 10 - pins;
                            pins = Roll(random, pinsLeft);
                            Roll3[index] = pins;
                            if (pins == pinsLeft)
                            {
                                //Spare after a strike
                                tally += "/";
                            }
                            else
                            {   //Open after a strike
                                tally += pins;
                            }
                        } // 10th frame strike followed by a non-strike
                    } // 10th frame first ball strike
                    else
                    {
                        //First ball in 10th frame not a strike
                        tally += pins;
                        //ball = 2;
                        pinsLeft = 10 - pins;
                        pins = Roll(random, pinsLeft);
                        Roll2[index] = pins;
                        if (pins == pinsLeft)
                        {
                            //Spare in 10th frame
                            tally += "/";
                            //Roll 3rd ball in 10th frame
                            // ball = 3;
                            pinsLeft = 10;
                            pins = Roll(random, pinsLeft);
                            Roll3[index] = pins;
                            if (pins == 10)
                            {
                                // Spare in 10th + a strike
                                tally += "X";
                            }
                            else
                            {
                                // Spare in 10th + a non-strike
                                tally += pins;
                            }
                        }
                        else
                        {
                            // Open 10th frame
                            tally += pins + " ";
                        }
                    } //First ball in 10th frame not a strike
                    frame++; //changes to 11 to exit loop
                } // 10th frame
            } // End of while loop

            scores = ComputeScore(Roll1, Roll2, Roll3);
            tally = tally.Replace("0", "-");
            Console.WriteLine($"\n{tally}");
            foreach (int score in scores)
            {
                Console.Write($"{score,3} ");
            }
            return;
        }

        static int[] ComputeScore(int[] Roll1, int[] Roll2, int[] Roll3)
        {
            int[] frameScore = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] cumulativeScore = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int frame = 1;
            int index = 0;

            for (frame = 1; frame <= 8; frame++)
            {
                index = frame - 1;
                if (Roll1[index] == 10)
                {
                    //Strike 
                    frameScore[index] = 10 + Roll1[index+1] + Roll2[index+1];
                    if (Roll1[index+1] == 10)
                    {
                        frameScore[index] += Roll1[index+2];
                    }
                }
                else if (Roll1[index] + Roll2[index] == 10)
                {
                    //Spare 
                    frameScore[index] = 10 + Roll1[index+1];
                }
                else
                {
                    frameScore[index] = Roll1[index] + Roll2[index];
                }
            }

            for (frame = 9; frame <= 9; frame++)
            {
                index = frame - 1;
                if (Roll1[index] == 10)
                {
                    //Strike in 9th frame
                    frameScore[index] = 10 + Roll1[index+1] + Roll2[index+1];
                }
                else if (Roll1[index] + Roll2[index] == 10)
                {
                    //Spare in 9th frame 
                    frameScore[index] = 10 + Roll1[index+1];
                }
                else
                {
                    frameScore[index] = Roll1[index] + Roll2[index];
                }
            }

            for (frame = 10; frame <= 10; frame++)
            {
                index = frame - 1;
                if (Roll1[index] == 10)
                {
                    //First Strike in 10th frame
                    frameScore[index] = 10 + Roll2[index] + Roll3[index];
                }
                else if (Roll1[index] + Roll2[index] == 10)
                {
                    //Spare in 10th frame 
                    frameScore[index] = 10 + Roll3[index];
                }
                else
                {
                    frameScore[index] = Roll1[index] + Roll2[index];
                }
            }

            //Frame 1 (index 0)
            cumulativeScore[0] = frameScore[0];

            for (int i = 1; i<=9; i++)
            {
                // Frames 2-10 (index 1-9)
                cumulativeScore[i] = cumulativeScore[i-1] + frameScore[i];
            }

            return cumulativeScore;
        }
    }
}

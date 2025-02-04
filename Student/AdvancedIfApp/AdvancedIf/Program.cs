using System;

namespace AdvancedIf
{
    internal class Program
    {
        enum Enum_Pins
        {
            TEN = 10
        };

        static void Main()
        {
            int[] Game = new int[3];
            int series;
            int highestGame = 0;
            int highestSeries = 0;
            int totalPins = 0;
            int gameCount = 0; 
            int average;
            bool gameOver = false;
            string playAgain;

            while (!gameOver)
            {
                // Bowl a 3-game series
                Game[0] = PlayBowlingGame();
                Game[1] = PlayBowlingGame();
                Game[2] = PlayBowlingGame();

                // Update statistics
                gameCount += 3;
                series = Game[0] + Game[1] + Game[2];
                totalPins += series;
                average = totalPins / gameCount;
                highestSeries = Math.Max(highestSeries, series);
                highestGame = Math.Max(Math.Max(highestGame, Game[0]), Math.Max(Game[1], Game[2]));
                
                Console.WriteLine($"\n\nSeries: {series}  Total Pins: {totalPins}  Games: {gameCount}  Average: {average}  High Series: {highestSeries}  High Game: {highestGame}");
                Console.Write("\n\nPlay Another Game? (Y/N): ");
                
                playAgain = Console.ReadLine().ToLower();
                if (playAgain != "y")
                {
                    gameOver = true;
                }
            }
            return;
        }

        static int Roll(Random random, int pinsStanding, out int pins)
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
            pins = Math.Max(pinsDown[index], 0);
            return pins;
        }

        static int PlayBowlingGame()
        {
            int index;
            int frame = 1;
            int pins;
            string tally = "";
            int[] Roll1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Roll2 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] Roll3 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] scores = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

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
                // Spare     = 9/8_
                // Open      = 81__

            Random random = new Random();

            while (frame <= 10)
            {
                index = frame - 1;
                if (frame >= 1 && frame <= 9)
                {
                    // Frames 1-9
                    Roll1[index] = Roll(random, 10, out pins);
                    if (pins == 10)
                    {
                        //Strike
                        tally += "  X ";
                    }
                    else
                    {
                        //Not a strike
                        tally += " " + pins;
                        Roll2[index] = Roll(random, 10 - pins, out pins);
                        if (Roll1[index] + Roll2[index] == 10)
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
                    Roll1[index] = Roll(random, 10, out pins);
                    if (pins == 10)
                    {
                        //First ball in 10th frame a strike
                        tally += "X";
                        Roll2[index] = Roll(random, 10, out pins);
                        if (pins == 10)
                        {
                            // Two strikes in 10th frame
                            tally += "X";
                            Roll3[index] = Roll(random, 10, out pins);
                            //Third roll in the 10th frame
                            if (pins == 10)
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
                            Roll3[index] = Roll(random, 10 - pins, out pins);
                            if (Roll2[index] + Roll3[index] == 10)
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
                        Roll2[index] = Roll(random, 10 - pins, out pins);
                        if (Roll1[index] + Roll2[index] == 10)
                        {
                            //Spare in 10th frame
                            tally += "/";
                            //Roll 3rd ball in 10th frame
                            Roll3[index] = Roll(random, 10, out pins);
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

            // Roll3 just used for the 10th frame
            scores = ComputeScore(Roll1, Roll2, Roll3);
            // Zeroes in tally should show as a dash
            tally = tally.Replace("0", "-");
            Console.WriteLine($"\n{tally}");
            
            foreach (int score in scores)
            {
                //Scores print with a width of 3 chars right justified then followed by a space
                Console.Write($"{score,3} ");
            }
            Console.Write("\n");
            //Return the game score
            return scores[9];
        }

        static int[] ComputeScore(int[] Roll1, int[] Roll2, int[] Roll3)
        {
            int[] frameScore = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] cumulativeScore = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int frame;
            int index;

            // Loop on frames 1-8
            for (frame = 1; frame <= 8; frame++)
            {
                index = frame - 1;
                if (Roll1[index] == 10)
                {
                    //Strike 
                    frameScore[index] = 10 + Roll1[index+1] + Roll2[index+1];
                    if (Roll1[index+1] == 10)
                    {
                        // Two strikes so get 1st roll from 3rd frame from here
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
                    // Open
                    frameScore[index] = Roll1[index] + Roll2[index];
                }
            }

            //9th Frame logic
            frame = 9;
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
                // Open in the 9th frame
                frameScore[index] = Roll1[index] + Roll2[index];
            }

            // 10th frame logic
            frame = 10;
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
                //Open in 10th frame
                frameScore[index] = Roll1[index] + Roll2[index];
            }

            //Frame 1 (index 0)
            cumulativeScore[0] = frameScore[0];

            for (int i=1; i<=9; i++)
            {
                // Frames 2-10 (index 1-9)
                cumulativeScore[i] = cumulativeScore[i-1] + frameScore[i];
            }

            return cumulativeScore;
        }
    }
}

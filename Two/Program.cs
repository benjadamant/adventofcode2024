// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

string[] strInput = File.ReadAllLines("Input.txt");

int intAmountOfSafeReports = 0;

for (int i = 0; i < strInput.Length; i++)
{
    string[] strReport = strInput[i].Split(" ");

    int intPrevLevel = -1;

    bool bolCandidate = false;
    bool bolLlvlRising = false;
    bool bolDampenerUsed = false;

    for (int z = 0; z < strReport.Length; z++)
    {
        Console.WriteLine();

        if(z == 0)
        {
            intPrevLevel = int.Parse(strReport[z]);
            Console.Write(intPrevLevel);

            //Determine if pressure is rising or falling
            int intNextLevel = int.Parse((strReport[z + 1]));
            int intNextNextLevel = int.Parse(strReport[z + 2]);

            //If next value is the same, we cannot determine if pressure is falling or rising and we need to get the next-next number
            if (intPrevLevel == intNextLevel)
            {
                if(intPrevLevel < intNextNextLevel)
                {
                    bolLlvlRising = true;
                }
            }
            
            if(intPrevLevel < intNextLevel && intNextLevel < intNextNextLevel)
            {
                bolLlvlRising = true;
            }
            
            if(intPrevLevel > intNextLevel && intNextLevel < intNextNextLevel)
            {
                bolLlvlRising = true;
            }
        }
        else
        {
            int intCurrentLevel = int.Parse(strReport[z]);
            Console.Write(intCurrentLevel);

            //Handle when pressure stays the same
            if (intCurrentLevel == intPrevLevel)
            {
                if (bolDampenerUsed)
                {
                    bolCandidate = false;
                    break;
                }
                else
                {
                    bolDampenerUsed = true;
                    bolCandidate = true;
                    continue;
                }
            }

            //Pressure is rising
            if (bolLlvlRising)
            {
                if(Math.Abs(intCurrentLevel - intPrevLevel) < 4)
                {
                    bolCandidate = true;
                }
                else
                {
                    if (bolDampenerUsed)
                    {
                        bolCandidate = false;
                        break;
                    }
                    else
                    {
                        bolDampenerUsed = true;
                        bolCandidate = true;
                    }
                }
            }
            //Pressure is falling
            else
            {
                if(Math.Abs(intPrevLevel - intCurrentLevel) < 4)
                {
                    Console.WriteLine("This one is safe!");
                    bolCandidate = true;
                }
                else
                {
                    if (bolDampenerUsed)
                    {
                        bolCandidate = false;
                        break;
                    }
                    else
                    {
                        bolDampenerUsed = true;
                        bolCandidate = true;
                    }
                }
            }

            intPrevLevel = intCurrentLevel;
        }

        /*
        if (intPrevLevel == -1)
        {
            intPrevLevel = int.Parse(strReport[z]);

            int intNextLevel = int.Parse(strReport[z + 1]);

            if (intPrevLevel == intNextLevel)
            {
                bolDampenerUsed = true;

                intNextLevel = int.Parse(strReport[z + 2]);
            }


            if (intPrevLevel < intNextLevel)
            {
                bolLlvlRising = true;
            }

        }
        else
        {
            int intCurrentLevel = int.Parse(strReport[z]);

            Console.WriteLine("Previous level was {0} and current level is {1}.", intPrevLevel, intCurrentLevel);

            if ((intPrevLevel <= intCurrentLevel) && bolLlvlRising)
            {
                int intDifference = Math.Abs(intCurrentLevel - intPrevLevel);

                if (intDifference != 0 && intDifference < 4)
                {
                    Console.WriteLine("Difference between Previous level and Current level is: {0}", Math.Abs(intCurrentLevel - intPrevLevel));
                    bolCandidate = true;
                    intPrevLevel = intCurrentLevel;
                }
                else
                {
                    if (!bolDampenerUsed)
                    {
                        bolDampenerUsed = true;
                        intPrevLevel = intCurrentLevel;
                        continue;
                    }
                    bolCandidate = false;
                    break;
                }

            }
            else if ((intPrevLevel >= intCurrentLevel) && !bolLlvlRising)
            {
                int intDifference = Math.Abs(intPrevLevel - intCurrentLevel);

                if (intDifference != 0 && intDifference < 4)
                {
                    bolCandidate = true;
                    intPrevLevel = intCurrentLevel;
                }
                else
                {
                    if (!bolDampenerUsed)
                    {
                        bolDampenerUsed = true;
                        intPrevLevel = intCurrentLevel;
                        continue;
                    }
                    bolCandidate = false;
                    break;
                }
            }
            else
            {
                bolCandidate = false;
                break;
            }
        
        }
        */
    }

    if (bolCandidate)
    {
       intAmountOfSafeReports++;
    }
}

Console.WriteLine("The amount of safe reports are {0}.", intAmountOfSafeReports);


//Confirmed correct answer to 2a is: 390 safe reports.

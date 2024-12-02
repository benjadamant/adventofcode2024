// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

int[] intsFirstList;
int[] intsSecondList;


//Populate arrays from input.txt
string[] strInputFile = File.ReadAllLines("input.txt");

intsFirstList = new int[strInputFile.Length];
intsSecondList = new int[strInputFile.Length];

for(int i=0; i<strInputFile.Length; i++)
{
    string[] strInputValues = strInputFile[i].Split("   ");
    
    if(strInputValues.Length != 2)
    {
        Console.WriteLine("Unevened pair from input values discovered.");
        break;
    }
    else
    {

        intsFirstList[i] = int.Parse(strInputValues[0]);
        intsSecondList[i] = int.Parse(strInputValues[1]);
    }
 }

Array.Sort(intsFirstList);
Array.Sort(intsSecondList);

List<int> listDifferantior = new List<int>();

//Calculate answer to 1a
if (intsFirstList.Length == intsSecondList.Length)
{
    for (int i =0; i<intsFirstList.Length; i++)
    {
        Console.WriteLine("Subtracting {0} from {1}.", intsSecondList[i], intsFirstList[i]);

        int intDiff = 0;

        if (intsSecondList[i] > intsFirstList[i])
        {
            intDiff = intsSecondList[i] - intsFirstList[i];
        }
        else
        {
            intDiff = intsFirstList[i] - intsSecondList[i];
        }

        listDifferantior.Add(intDiff);
    }

    int totalDifference = 0;

    foreach(int intDiff in listDifferantior) { totalDifference += intDiff; };

    Console.WriteLine("The sum of all differences are {0}.", totalDifference);
    //Confirmed correct answer to 1a: Differantial Score is 2756096

}
else
{
    Console.WriteLine("One of the provided arrays doesn't match logical length.");
}

//Calculate answer to 1b

int intSimilarityScore = 0;

for (int i = 0;i < intsFirstList.Length; i++)
{

    int intMultiplier = 0;

    for(int z=0;z <intsSecondList.Length; z++)
    {
        if(intsSecondList[z] == intsFirstList[i]){
            intMultiplier++;
        }
    }

    intSimilarityScore += intsFirstList[i] * intMultiplier;
}

Console.WriteLine("The similarity score of the provided input is {0}.", intSimilarityScore);
//Confirmed correct answer to 1b: Similarity Score is 23117829
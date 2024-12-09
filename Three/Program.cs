using System.Text.RegularExpressions;


internal class Program
{
    private static void Main(string[] args)
    {
        string[] strInput = File.ReadAllLines("input.txt");

        int intTotal = 0;

        string strDoString = findDosAndDonts(strInput);
        int intPreciseTotoal = calculateDos(strDoString);

        for (int i = 0; i < strInput.Length; i++)
        {
            intTotal += calculateDos(strInput[i]);
        }

        Console.WriteLine("Total product of memory multiplications are {0}.", intTotal);
        //Confirmed answer to 3a is: Total product is 184511516

        Console.WriteLine("Total precide product of memory multiplication are {0}.", intPreciseTotoal);
    }

    public static string findDosAndDonts(string[] strInput)
    {
        string strDoString = String.Empty;

        string strDo = "do()";
        string strDont = "don't()";

        string strEntireString = string.Empty;

        for(int i = 0; i < strInput.Length; i++)
        {
            strEntireString = String.Concat(strEntireString, strInput[i].ToLower());
        }

        string[] strSplittedDontString = strEntireString.Split(strDont);

        for(int i = 0;i < strSplittedDontString.Length;i++)
        {
            Console.WriteLine("Split on {0}: {1}", strDont, strSplittedDontString[i]);

            //First line always included
            if(i == 0)
            {
                strDoString = strSplittedDontString[i];
            }
            else
            {
                string[] strSplittedDoString = strSplittedDontString[i].Split(strDo);

                for(int j = 1; j < strSplittedDoString.Length; j++)
                {
                    strDoString = String.Concat(strDoString, strSplittedDoString[j]);
                }
            }
        }

        

        return strDoString;
    }

    public static int calculateDos(string strInput)
    {
        string strRegExToSingleOutMultiplications = "mul\\((-?\\d+(\\.\\d+)?),(-?\\d+(\\.\\d+)?)\\)";

        int intTotal = 0;

        MatchCollection oMatches = Regex.Matches(strInput, strRegExToSingleOutMultiplications);

        foreach (Match m in oMatches)
        {
            //Break out values for "mul(X,Y)"

            Console.WriteLine("Matching value is {0}.", m.Value);

            string strSubstring = m.Value.Substring(m.Value.IndexOf("(") + 1);

            string strX = strSubstring.Substring(0, strSubstring.IndexOf(","));

            Console.WriteLine("Substring X is {0}.", strX);

            int intX = int.Parse(strX);

            string strY = strSubstring.Substring(strSubstring.IndexOf(',') + 1).Trim(')');

            Console.WriteLine("Substring Y is {0}.", strY);

            int intY = int.Parse(strY);

            intTotal += intX * intY;
        }

        return intTotal;
    }

}
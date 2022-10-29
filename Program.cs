using System;
using System.Linq;

class Program
{
    static bool DetermineSxml(string sxml)
    {
        // Remove double quotes from the input string
        string str = "";

        for (int m = 0; m < sxml.Length; m++)
        {
            if ((char)sxml[m] != '"')
            {
                str = str + sxml[m];
            }
        }
        sxml = str; // After removing double quotessud
        int sBracket = 0; // Count the start of an element with < char
        int eBracket = 0; // Count the end of an element with > char

        for (int l = 0; l < sxml.Length; l++) // Find total number of elements
        {
            if ((char)sxml[l] == '<')
            {
                sBracket++;
            }
            else if ((char)sxml[l] == '>')
            {
                eBracket++;
            }
        }

        if (sBracket != eBracket) // If < and > don't match meaning sXML error
        {
            return false;
        }

        int i = 0; // Index to loop through the sXML string
        int end = sxml.Length; // Find the number of characters in the sXML string
        string[] element = new string[sBracket]; // Set the size of string array holding elements
        int j = 0; // Use as the counter for total number of elements

        while (i < end) // Use the while loop to extract individual element
        {
            char ck = (char)sxml[i];
            if (ck == '<')
            {
                i++;
                char ck1 = (char)sxml[i];
                while (ck1 != '>')
                {
                    element[j] = element[j] + ck1;
                    i++;
                    ck1 = sxml[i];
                }
                j++;
            }
            else
            {
                i++;
            }
        }

        if (element.Count() % 2 != 0) // Starting and ending elemnets must be equal
        {
            return false;
        }
        else
        {
            int arrEnd = element.Count();
            // The array contains half starting and half ending elements 
            for (int k = 0; k < arrEnd / 2; k++)
            {
                int sLen = element[arrEnd - k - 1].Length - 1;
                // Check if the starting and ending elements are the same
                if (element[k] != element[arrEnd - k - 1].Substring(1, sLen))
                {
                    return false;
                }
            }
        }

        return true;
    }

    static void Main()
    {
        // One sXML text string is read from the standard input
        string sxml = Console.ReadLine();

        // Make the function call
        string result = Convert.ToString(DetermineSxml(sxml));

        // Use standard output to display the result of function call
        Console.WriteLine(result.ToLower());
    }
}
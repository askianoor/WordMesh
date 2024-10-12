using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter words separated by spaces:");
        var input = Console.ReadLine();
        var words = new List<string>(input.Split(' '));

        var combinations = GetCombinations(words);

        using (StreamWriter file = new StreamWriter("combinations.txt"))
        {
            foreach (var combination in combinations)
            {
                file.WriteLine(string.Join("", combination));
            }
        }

        Console.WriteLine("Combinations saved to combinations.txt");
    }

    static List<List<string>> GetCombinations(List<string> words)
    {
        var result = new List<List<string>>();
        int count = words.Count;

        for (int i = 1; i < (1 << count); i++)
        {
            var combination = new List<string>();
            for (int j = 0; j < count; j++)
            {
                if ((i & (1 << j)) != 0)
                {
                    combination.Add(words[j]);
                }
            }
            result.Add(combination);
        }
        return result;
    }
}

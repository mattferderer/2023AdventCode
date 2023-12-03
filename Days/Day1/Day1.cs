/// <summary>
/// Day1 is a class that parses a file of strings and returns the sum of the numbers in each string.
/// The numbers can be in the form of a word number (one, two, three, etc.) or a number (1, 2, 3, etc.)
/// </summary>


public class Day1
{
    private readonly string[] _wordNumbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    private readonly string[] _input;

    public Day1(string inputFile)
    {
        _input = System.IO.File.ReadAllLines(inputFile);
    }

    /// <summary>
    /// This method uses pointers and does not modify the array of characters in each line
    /// </summary>
    /// <returns></returns>
    public int UsePointers()
    {
        List<int> numbers = [];
        foreach (string line in _input)
        {
            var number = Parse(line, true);
            numbers.Add(number);
        }
        return numbers.Sum();
    }

    /// <summary>
    /// This method uses the Replace method to modify the array of characters in each line
    /// </summary>
    /// <returns></returns>
    public int UseReplaceInArray()
    {
        List<int> numbers = [];
        foreach (string line in _input)
        {
            var number = Parse(ParseLine(line));
            numbers.Add(number);
        }
        return numbers.Sum();

    }

    int Parse(string line, bool searchWordNumbers = false)
    {
        return int.Parse(string.Concat(FindFirstNumber(line, searchWordNumbers), FindLastNumber(line, searchWordNumbers)));
    }

    char FindFirstNumber(string line, bool searchWordNumbers = false)
    {
        var index = line.Length - 1;
        var number = '0';
        for (int i = 0; i < line.Length; i++)
        {
            if (char.IsNumber(line[i]))
            {
                index = i;
                number = line[i];
                break;
            }
        }

        if (searchWordNumbers)
        {
            for (int i = 0; i < _wordNumbers.Length; i++)
            {
                var matchIndex = line.IndexOf(_wordNumbers[i]);
                if (matchIndex != -1 && matchIndex < index)
                {
                    number = (i + 1).ToString()[0];
                    index = matchIndex;
                }
            }
        }

        return number;
    }

    char FindLastNumber(string line, bool searchWordNumbers = false)
    {
        var index = 0;
        var number = '0';
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (char.IsNumber(line[i]))
            {
                index = i;
                number = line[i];
                break;
            }
        }

        if (searchWordNumbers)
        {
            for (int i = 0; i < _wordNumbers.Length; i++)
            {
                var matchIndex = line.LastIndexOf(_wordNumbers[i]);
                if (matchIndex != -1 && matchIndex > index)
                {
                    number = (i + 1).ToString()[0];
                    index = matchIndex;
                }
            }
        }

        return number;
    }

    /// <summary>
    /// Uses a trick to replace the word numbers with a number based on the knowledge that the numbers are only 1-9.
    /// Note: It keeps the first & last letter of the word number to avoid replacing the word number when it shares a letter with another word number.
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    string ParseLine(string line)
    {
        return line
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "f4r")
            .Replace("five", "f5e")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");
    }
}



// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

using System.Globalization;

namespace TestApp;

class Program
{
    static void Main(string[] args)
    { 
        //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        CultureInfo.CurrentCulture = new CultureInfo("en-US");
        // Solution1();
        // Solution2();
        // Solution3();
        // Solution4();
        // Solution5();
        
        // var testStr = "This is a really really really long long long sentence";
        // Console.WriteLine(SummarizeText(testStr, 25));
        
        // Solution6();
        // Solution7();
        // Solution8();
        // Solution9();
        Solution10();

    }
    
    /// <summary>
    /// Write a program and continuously ask the user to enter different names, until the user presses Enter 
    /// (without supplying a name). Depending on the number of names provided, display a message based on the above pattern.
    /// </summary>
    public static void Solution1()
    {
        var isOpen = true;
        var names = new List<string>();
        while (isOpen)
        {
            Console.Write("Enter a name (to exit press 'enter'): ");
            var nameEntered = Console.ReadLine();
            if (string.IsNullOrEmpty(nameEntered))
            {
                isOpen = false;
                Console.WriteLine("Exiting...");
            }
            else
            {
                names.Add(nameEntered);
            }
        }

        var numOfPeopleLiked = names.Count;
        switch (numOfPeopleLiked)
        {
            case 1:
                Console.WriteLine("{0} likes your post.", names[0]);
                break;
            case 2:
                Console.WriteLine("{0} and {1} like your post", names[0], names[1]);
                break;
            default:
                if (numOfPeopleLiked > 2)
                    Console.WriteLine($"{names[0]}, {names[1]} and {names.Count - 2} others like your post.");
                break;
        }
    }
    
    /// <summary>
    /// Ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. 
    /// Display the reversed name on the console.
    /// </summary>
    public static void Solution2()
    {
        Console.Write("Please enter your name: ");
        var input = Console.ReadLine().ToLower();
        var nameArr= new char[input.Length];
        for (var i = input.Length; i > 0; i--)
        {
            nameArr[input.Length - i] = input[i - 1];
        }

        var reversed = new string(nameArr);
        Console.WriteLine($"Your name in reverse: {reversed}");
    }

    /// <summary>
    /// Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display 
    /// an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them 
    /// and display the result on the console.
    /// </summary>
    public static void Solution3()
    {
        var numbers = new List<int>();

        while (numbers.Count < 5)
        {
            Console.Write("Please enter a number: ");
            var num = Convert.ToInt32(Console.ReadLine());
            if (numbers.Contains(num))
            {
                Console.WriteLine("You've already entered: " + num);
                continue;
            }
            numbers.Add(num);
        }
        Console.WriteLine();
        numbers.Sort();
        foreach(var num in numbers)
            Console.Write(num + " ");
    }

    /// <summary>
    /// Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may 
    /// include duplicates. Display the unique numbers that the user has entered.
    /// </summary>
    public static void Solution4()
    {
        var numbers = new List<int>();
        while (true)
        {
            Console.Write("Please enter a number (type 'Quit' to exit): ");
            var input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            numbers.Add(Convert.ToInt32(input));
        }

        var uniqueNumbers = new List<int>();
        foreach (var num in numbers)
        {
            if(!uniqueNumbers.Contains(num))
                uniqueNumbers.Add(num);
        }
        
        uniqueNumbers.Sort();
        Console.WriteLine("Unique numbers: ");
        foreach (var num in uniqueNumbers)
        {
            Console.Write(num + " ");
        }
    }
    
    /// <summary>
    /// Write a program and ask the user to supply a list of comma separated numbers (e.g 5, 1, 9, 2, 10). If the list is 
    /// empty or includes less than 5 numbers, display "Invalid List" and ask the user to re-try; otherwise, display 
    /// the 3 smallest numbers in the list.
    /// 
    /// </summary>
    public static void Solution5()
    {
        string[] elements;
        while (true)
        {
            Console.Write("Please enter comma-separated values: ");
            var input = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(input))
            {
                elements = input.Split(',');
                if (elements.Length >= 5)
                    break;
            }

            Console.WriteLine("Invalid list. Try again.");
        }

        var numbers = new List<int>();
        foreach (var num in elements)
        {
            numbers.Add(Convert.ToInt32(num));
        }

        var smallests = new List<int>();
        while (smallests.Count < 3)
        {
            // Assume the first elements is the smallest
            var min = numbers[0];
            foreach (var num in numbers)
            {
                if (num < min)
                    min = num;
            }
            smallests.Add(min);
            numbers.Remove(min);
        }

        Console.WriteLine("The smallest 3 numbers are: ");
        foreach (var num in smallests)
            Console.Write(num + " ");
    }

    public static string SummarizeText(string text, int maxLength = 20)
    {
        if (text.Length <= maxLength)
            return text;
        
        var words = text.Split(" ");
        var totalCharacters = 0;
        var summaryWords = new List<string>();

        foreach (var word in words)
        {
            if (word.Length + totalCharacters > maxLength)
                break;
            summaryWords.Add(word);
            totalCharacters += word.Length + 1; // +1 for the space
        }
        
        return (String.Join(" ", summaryWords) +  "...");
    }
    
    /// <summary>
    /// Write a program and ask the user to enter a few numbers separated by a hyphen. Work out 
    /// if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16", 
    /// display a message: "Consecutive"; otherwise, display "Not Consecutive".
    /// </summary>
    public static void Solution6()
    {
        Console.Write("Enter a few numbers (e.g., 1-2-3-4): ");
        var input = Console.ReadLine();
        var numbers = new List<int>();
        foreach (var num in input.Split('-'))
        {
            numbers.Add(Convert.ToInt32(num));
        }
        
        numbers.Sort();

        var isConsecutive = true;
        for (var i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] != numbers[i - 1] + 1)
            {
                isConsecutive = false;
                break;
            }
        }

        var message = isConsecutive ? "Consecutive" : "Not Consecutive";
        Console.WriteLine(message);

    }

    /// <summary>
    /// Write a program and ask the user to enter a few numbers separated by a hyphen. If the user simply 
    /// presses Enter without supplying an input, exit immediately; otherwise, check to see if there are 
    /// any duplicates. If so, display "Duplicate" on the console.
    /// </summary>
    public static void Solution7()
    {
        Console.Write("Enter a few numbers (e.g., 9-8-17-9): ");
        var input = Console.ReadLine();
        if (String.IsNullOrWhiteSpace(input))
            return;
        
        var numbers = new List<int>();
        foreach (var num in input.Split('-'))
        {
            numbers.Add(Convert.ToInt32(num));
        }

        var uniques = new List<int>();
        var includesDuplicates = false;

        foreach (var num in numbers)
        {
            if (!uniques.Contains(num))
            {
                uniques.Add(num);
            }
            else
            {
                includesDuplicates = true;
                break;
            }
        }
        
        if(includesDuplicates)
            Console.WriteLine("Contains duplicates");
        Console.WriteLine("The list is unique");
    }
    
    /// <summary>
    /// Write a program and ask the user to enter a time value in the 24-hour time format (e.g. 19:00).
    /// A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok"; otherwise, 
    /// display "Invalid Time". If the user doesn't provide any values, consider it as invalid time. 
    /// </summary>
    public static void Solution8()
    {
        Console.Write("Enter a time (e.g., 19:00): ");
        var input = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid time");
            return;
        }

        var components = input.Split(':');
        if (components.Length != 2)
        {
            Console.WriteLine("Invalid time");
            return;
        }

        try
        {
            var hour = Convert.ToInt32(components[0]);
            var minute = Convert.ToInt32(components[1]);

            if (hour >= 0 && hour <= 23 && minute >= 0 && minute <= 59)
                Console.WriteLine("Valid time");
            else
                Console.WriteLine("Invalid time");
        }

        catch (Exception)
        {
            Console.WriteLine("Invalid time");
        }
    }

    /// <summary>
    /// Write a program and ask the user to enter a few words separated by a space. Use the words to 
    /// create a variable name with PascalCase convention. For example, if the user types: 
    /// "number of students", display "NumberOfStudents". Make sure the program is not dependent on 
    /// the casing of the input. So if the input is "NUMBER OF STUDENTS", it should still display 
    /// "NumberOfStudents". If the user doesn't supply any words, display "Error".
    /// </summary>
    public static void Solution9()
    {
        Console.Write("Enter a few words: ");
        var input = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input");
            return;
        }

        var variableName = "";
        foreach (var word in input.Split(' '))
        {
            var wordWithPascalCase = char.ToUpper(word[0]) + word.ToLower().Substring(1);
            variableName += wordWithPascalCase;
        }

        Console.WriteLine("Pascal name: " + variableName);
    }
    
    /// <summary>
    /// Write a program and ask the user to enter an English word. Count the number of vowels 
    /// (a, e, o, u, i) in the word. So, if the user enters "inadequate", the program should display 
    /// 6 on the console. Make sure the program calculates the number of vowels irrespective of the 
    /// casing of the word (eg "Inadequate", "inadequate" and "INADEQUATE" all include 6 vowels).
    /// </summary>
    public static void Solution10()
    {
        Console.Write("Enter a word: ");
        var input = Console.ReadLine().ToLower();

        var vowels = new List<char>(new[] { 'a', 'e', 'o', 'u', 'i' });
        var vowelsCount = 0;

        foreach (var character in input)
        {
            if (vowels.Contains(character))
                vowelsCount++;
        }

        Console.WriteLine("Vowels count: " + vowelsCount);
    }
}
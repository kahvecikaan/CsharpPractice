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
        var testStr = "This is a really really really long long long sentence";
        Console.WriteLine(SummarizeText(testStr, 25));

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
}
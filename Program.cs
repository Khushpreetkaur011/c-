namespace ques2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
           // to enter lower number
            Console.Write("Enter low number:");
            int LOWERNO = Convert.ToInt32(Console.ReadLine());
            // to enter higher number
            Console.Write("Enter high number:");
            int HIGHERNO = Convert.ToInt32(Console.ReadLine());
            // to find difference between higher and lower number
            int DIFFER = HIGHERNO - LOWERNO;
            Console.WriteLine($"The difference between {HIGHERNO} and {LOWERNO} is {DIFFER}.");

            do { Console.Write("Enter a positive low number:"); }
            while (!int.TryParse(Console.ReadLine(), out LOWERNO) || LOWERNO <= 0);
            do { Console.Write($"Enter a high number greater than {LOWERNO}:"); }
            while (!int.TryParse(Console.ReadLine(), out HIGHERNO) || HIGHERNO <= LOWERNO);
            Console.WriteLine($"Positive low number: {LOWERNO}");
            Console.WriteLine($"High number greater than {LOWERNO}: {HIGHERNO}");

            int[] A = new int[HIGHERNO - LOWERNO + 1];
            for (int j = 0; j < A.Length; j++)
            {
                A[j] = HIGHERNO - j;
            }
            string filePath = "number.txt";

            try
            {
                using (StreamWriter streamwriter = new StreamWriter(filePath))
                {
                    // Write each number in reverse order to the file
                    foreach (int number in A)
                    {
                        streamwriter.WriteLine(number);
                    }
                }
                Console.WriteLine($"{filePath} stores numbers  in reverse order of array");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            double lowno = GetUserInput("Enter a lower no ");
            double highno = GetUserInput("Enter a higher no greater than the low number: ");


            List<double> numList = GetNumList(lowno, highno);

            string FilePath = "number.txt";

            try
            {
                WriteNumToFile(numList, FilePath);
                Console.WriteLine($"{FilePath}  no. in reverse format= ");

                List<double> numFromFile = ReadNumFromFile(FilePath);
                double sum = CalculateSum(numFromFile);
                Console.WriteLine($"Sum = {sum}");

                PrimeNumbers(lowno, highno);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            static double GetUserInput(string prompt)
            {
                double userInput;
                Console.Write(prompt);
                while (!double.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Invalid input");
                    Console.Write(prompt);
                }
                return userInput;
            }

            static List<double> GetNumList(double low, double high)
            {
                List<double> t = new List<double>();
                for (double k = high; k >= low; k--)
                {
                    t.Add(k);
                }
                return t;
            }

            static void WriteNumToFile(List<double> numbers, string FilePath)
            {
                File.WriteAllLines(FilePath, Array.ConvertAll(numbers.ToArray(), n => n.ToString()));
            }

            static List<double> ReadNumFromFile(string FilePath)
            {
                List<double> l = new List<double>();
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    if (double.TryParse(line, out double num))
                    {
                        l.Add(num);
                    }
                }
                return l;
            }

            static double CalculateSum(List<double> nums)
            {
                double sum = 0;
                foreach (double num in nums)
                {
                    sum += num;
                }
                return sum;
            }

            static bool IsPrime(double num)
            {
                if (num <= 1)
                {
                    return false;
                }

                for (double w = 2; w <= Math.Sqrt(num); w++)
                {
                    if (num % w == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            static void PrimeNumbers(double low, double high)
            {
                Console.WriteLine($"Prime numbers between {low} and {high}:");
                for (double s = low; s <= high; s++)
                {
                    if (IsPrime(s))
                    {
                        Console.Write($"{s} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
    


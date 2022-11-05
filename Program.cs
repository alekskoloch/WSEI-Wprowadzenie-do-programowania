using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace WSEI_Wprowadzenie_do_programowania
{
    internal class Program
    {
        /* enter data */
        static T[] enterData<T>()
        {
            Console.Write("How many elements do you want to enter? ");
            int n = Convert.ToInt32(Console.ReadLine());
            T[] tab = new T[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter " + (i + 1) + " number: ");
                tab[i] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T))!;
            }

            return tab;
        }

        static T[] enterData<T>(int count)
        {
            count = (count > 0) ? count : 0;
            T[] tab = new T[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter " + (i + 1) + " number: ");
                tab[i] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T))!;
            }
            return tab;
        }

        static void enterData<T>(T[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write("Enter " + (i + 1) + " element: ");
                tab[i] = (T)Convert.ChangeType(Console.ReadLine(), typeof(T))!;
            }
        }

        static T[] enterDataLine<T>()
        {
            string[] subs = Console.ReadLine()!.Split(' ');
            T[] tab = new T[subs.Length];

            for (int i = 0; i < subs.Length; i++)
                tab[i] = (T)Convert.ChangeType(subs[i], typeof(T))!;

            return tab;
        }

        /* generate data */
        static T[] generateTable<T>(int x, Func<T, T> foo)
        {
            T[] table = new T[x];

            for (int i = 0; i < x; i++)
                table[i] = foo((T)Convert.ChangeType(i, typeof(T)));

            return table;
        }

        /* table algorithms */
        static T find<T>(T[] tab, Func<T, T, bool> foo)
        {
            T result = tab[0];
            for (int i = 0; i < tab.Length; i++)
                if (foo(result, tab[i]))
                    result = tab[i];
            return result;
        }

        static int count<T>(T[] tab, Func<T, bool> foo)
        {
            int counter = 0;
            for (int i = 0; i < tab.Length; i++)
                if (foo(tab[i]))
                    counter++;
            return counter;
        }

        static T[] order<T>(T[] tab, Func<T, T> foo, Func<T, bool> fbool)
        {
            for (int i = 0; i < tab.Length; i++)
                if (fbool(tab[i]))
                    tab[i] = foo(tab[i]);
            return tab;
        }

        static T[] order<T>(T[] tab, Func<T, T> foo)
        {
            for (int i = 0; i < tab.Length; i++)
                tab[i] = foo(tab[i]);
            return tab;
        }

        static T[] reverseTable<T>(T[] tab)
        {
            T temp;
            for (int i = 0; i < tab.Length / 2; i++)
            {
                temp = tab[i];
                tab[i] = tab[tab.Length - (i + 1)];
                tab[tab.Length - (i + 1)] = temp;
            }
            return tab;
        }

        /* sorting algorithms */
        static void sortTable(int[] tab)
        {
            int temp = tab[0];
            bool swap = false;
            do
            {
                swap = false;
                for (int i = 1; i < tab.Length; i++)
                    if (tab[i - 1] > tab[i])
                    {
                        temp = tab[i];
                        tab[i] = tab[i - 1];
                        tab[i - 1] = temp;
                        swap = true;
                    }
            } while (swap);
        }

        static void sortTable(int[] tab, int start, int end)
        {
            int temp = tab[0];
            bool swap = false;
            do
            {
                swap = false;
                for (int i = start + 1; i < end + 1; i++)
                    if (tab[i - 1] < tab[i])
                    {
                        temp = tab[i];
                        tab[i] = tab[i - 1];
                        tab[i - 1] = temp;
                        swap = true;
                    }
            } while (swap);
        }

        static void sortTableMin(int[] result)
        { 
            for (int i = 0; i < result.Length; i++)
            {
                int minPos = i;
                for (int j = i; j < result.Length; j++)
                    if (result[j] < result[minPos])
                        minPos = j;
                if (minPos != i)
                {
                    int temp = result[i];
                    result[i] = result[minPos];
                    result[minPos] = temp;
                }
            }
        }

        /* other algorithms */
        static int fibonacci(int x)
        {
            if (x <= 1)
                return 0;
            else if (x == 2)
                return 1;
            else
                return fibonacci(x - 1) + fibonacci(x - 2);
        }

        static int[] fibonacciSequence(int x)
        {
            
            x = x < 0 ? 0 : x;
            int[] result = new int[x];
            result[0] = 0;
            if (x >= 1)
                result[1] = 1;

            if (x >= 2)
                result[2] = 1;

            if (x >= 3)
                for (int i = 3; i < x; i++)
                    result[i] = result[i - 1] + result[i - 2];
            return result;
        }

        /* display tables */
        static void printTable<T>(T[] table, Func<T, bool> foo)
        {
            bool first = true;

            Console.Write("[");
            for (int i = 0; i < table.Length;i++)
            {
                if (foo(table[i]))
                {
                    if (!first)
                        Console.Write("|");
                    Console.Write(table[i]);
                    first = false;
                }
            }
            Console.Write("]");
        }

        static void printTable<T>(T[] table)
        {
            Console.Write("[");
            for (int i = 0; i < table.Length;)
            {
                Console.Write(table[i++]);
                if (i != table.Length)
                    Console.Write("|");
            }
            Console.Write("]");
            Console.WriteLine();
        }

        /* int algorithms */
        static bool isPow(int x, int pow)
        {
            while (x != 1)
            {
                if (x % pow == 0)
                    x /= pow;
                else
                    return false;
            }
            return true;
        }

        static double toDecimal(double x, int numeralSystem)
        {
            string number = Convert.ToString(x);
            double result = 0;

            for (int i = 0; i < number.Length; i++)
                result += (Convert.ToInt32(number[i].ToString())) * Math.Pow(numeralSystem, number.Length - (i + 1));

            return result;
        }

        /* simple programs */
        static void guessGame()
        {
            Console.Write("Range? From 0 to: ");
            Random random = new Random();
            int x = random.Next(Convert.ToInt32(Console.ReadLine()) + 1);
            int result = x + 1;

            int counter = 0;

            while (x != result)
            {
                Console.Write("Now guess the number... ");
                result = Convert.ToInt32(Console.ReadLine());

                if (result > x)
                    Console.WriteLine("Too big!");
                else if (result < x)
                    Console.WriteLine("Too small!");

                counter++;
            }

            Console.WriteLine("Nice! You guess the number for the " + counter + " time!");
        }

        static void calculator()
        {
            bool work = true;

            while (work)
            {
                int x = 0;
                int y = 0;
                string ch = "0";
                Console.WriteLine("1. Addition (+)");
                Console.WriteLine("2. Subtraction (-)");
                Console.WriteLine("3. Multiplication (*)");
                Console.WriteLine("4. Division (/)");
                Console.WriteLine("5. The rest (%)");
                Console.WriteLine("0. Exit");

                ch = Console.ReadLine()!;
                
                if (ch == "1" || ch == "2" || ch == "3" || ch == "4" || ch == "5")
                {
                    Console.WriteLine("------------------------------");

                    Console.Write("Enter 1 number: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter 2 number: ");
                    y = Convert.ToInt32(Console.ReadLine());
                }


                switch (ch)
                {
                    case "1":
                        {
                            Console.WriteLine("Addition: " + (x + y));
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Subtraction: " + (x - y));
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Multiplication: " + (x * y));
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Division: " + (x / y));
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("The rest: " + (x % y));
                            break;
                        }
                    case "0":
                        {
                            work = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("ERROR");
                            break;
                        }
                }
                Console.WriteLine("Press ENTER");
                Console.ReadLine();
                Console.Clear();
            }
        }

        // TASKS
        static void zad821()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(find(tab, (x, y) => x < y));
        }
        
        static void zad822()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(find(tab, (x, y) => x > y));
        }

        static void zad823()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(count(tab, x => x == find(tab, (x, y) => x < y)));
        }

        static void zad824()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(count(tab, x => x == find(tab, (x, y) => x > y)));
        }

        static void zad825()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(find(tab, (x, y) => x < y && y != find(tab, (x, y) => x < y)));
        }

        static void zad826()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(find(tab, (x, y) => x > y && y != find(tab, (x, y) => x > y)));
        }

        static void zad827()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(count(tab, x => x == find(tab, (x, y) => x < y && y != find(tab, (x, y) => x < y))));
        }

        static void zad828()
        {
            int[] tab = enterData<int>();
            Console.WriteLine(count(tab, x => x == find(tab, (x, y) => x > y && y != find(tab, (x, y) => x > y))));
        } 

        static void zad831()
        {
            double[] tab = enterData<double>();
            order(tab, x => x = x * x);
            printTable(tab);
        }

        static void zad832()
        {
            double[] tab = enterData<double>();
            order(tab, x => x * x * x);
            printTable(tab);
        }

        static void zad833()
        {
            double[] tab = enterData<double>();
            order(tab, x => x += 1);
            printTable(tab); 
        }

        static void zad834()
        {
            double[] tab = enterData<double>();
            order(tab, x => x *= 2);
            printTable(tab);
        }

        static void zad841()
        {
            int[] tab = enterData<int>();
            printTable(tab, x => x % 2 == 0);
        }

        static void zad842()
        {
            int[] tab = enterData<int>();
            printTable(tab, x => x % 2 != 0);
        }

        static void zad843()
        {
            int[] tab = enterData<int>();
            printTable(tab, x => x % 3 == 0);
        }

        static void zad844()
        {
            double[] tab = enterData<double>();
            printTable(tab, x => x >= 4 && x < 15);
        }

        static void zad845()
        {
            int[] tab = enterData<int>();
            for (int i = 0; i < tab.Length; i++)
            {
                int value = tab[i];
                while (value != 0)
                {
                    if (value % 2 == 0)
                        value /= 10;
                    else
                        break;
                }
                if (value == 0)
                    Console.WriteLine(tab[i]);
            }
        }

        static void zad846()
        {
            int[] tab = enterData<int>();
            for (int i = 0; i < tab.Length; i++)
            {
                int value = tab[i];
                int sum = 0;
                while (value != 0)
                {
                    sum = sum + (value % 10);
                    value /= 10;
                }
                if (sum == 1)
                    Console.WriteLine(tab[i]);
            }
        }

        static void zad847()
        {
            int[] tab = enterData<int>();
            int[] result = order(tab, x => x += 100, x => x % 2 == 0);
            printTable(result);
        }

        static void zad848()
        {
            double[] tab = enterData<double>();
            tab = order(tab, x => x = 0, x => x < 0);
            printTable(tab);
        }

        static void zad851()
        {
            double[] tab = enterData<double>();
            for (int i = 0; i < tab.Length; i += 2)
                Console.WriteLine(tab[i]);
        }

        static void zad852()
        {
            double[] tab = enterData<double>();
            for (int i = 1; i < tab.Length; i++)
            {
                if (i * i < tab.Length)
                    Console.WriteLine(tab[i * i]);
                else
                    break;
            }
        }

        static void zad861()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] tab = new int[n];

            for (int i = 0; i < n; i++)
                tab[i] = 0;

            for (int i = 2; i * i <= n; i++)
                if (tab[i] == 0)
                    for (int j = i * i; j < n; j += i)
                        tab[j] = 1;

            for (int i = 2; i < n; i++)
                if (tab[i] == 0)
                    Console.Write(i + " ");
        }

        static void zad862()
        {
            int[] tab = fibonacciSequence(35);
            printTable(tab);
        }

        static void zad863()
        {
            int[] tab = { 2, 7, 4, 9, 3, 5, -3, -123, -124326, 345, 123, 123, 123, 11111, 342, 324, 5, 5, 4, 4, 1, -1, 1, -1, 0, 5, 2, 2, 2, 444, -444, 4 };
            sortTableMin(tab);
            printTable(tab);
        }

        static void zad864()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] tabA = generateTable<int>(n, x => x);
            int[] tabB = generateTable<int>(n, x => x = x + 7);
            int[] tabC = generateTable<int>(n, x => x = 4 * (x + 1));
            int[] tabD = generateTable<int>(n, x => x = Convert.ToInt32(Math.Pow(2,x)));
            int[] tabE = generateTable<int>(n, x => x = 2 + x);

            //fibonacci test
            double[] tabF = generateTable<double>(n, x => x == 0 ? 0 : x =Math.Round((1 / Math.Sqrt(5)) * (Math.Pow(((1 + Math.Sqrt(5)) / 2), x)) - (Math.Pow(((1 - Math.Sqrt(5)) / 2), x))));

            Console.Write("a) ");
            printTable(tabA);
            Console.Write("b) ");
            printTable(tabB);
            Console.Write("c) ");
            printTable(tabC);
            Console.Write("d) ");
            printTable(tabD);
            Console.Write("e) ");
            printTable(tabE);
            Console.Write("f) ");
            printTable(tabF);
        }

        static void Main(string[] args)
        {
            int[] tab = { 1, 2, 3, 4, 5 };

            if (tab[0] == tab[tab.Length - 1])
                Console.WriteLine("TRUE");
            else
            {
                Console.WriteLine("FALSE");
            }
        }
    }
}
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WSEI_Wprowadzenie_do_programowania
{
    internal class Program
    {
        static int[] enterNumbers()
        {
            Console.Write("How many numbers do you want to enter: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] tab = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter " + " number: ");
                tab[i] = Convert.ToInt32(Console.ReadLine());
            }

            return tab;
        }

        static double[] enterDoubleNumbers()
        {
            Console.Write("How many numbers do you want to enter: ");
            int n = Convert.ToInt32(Console.ReadLine());
            double[] tab = new double[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter " + " number: ");
                tab[i] = Convert.ToDouble(Console.ReadLine());
            }

            return tab;
        }

        static int findMax(int[] tab)
        {
            int result = tab[0];
            for (int i = 1; i < tab.Length; i++)
                if (result < tab[i])
                    result = tab[i];
            return result;
        }

        static int findMax(int[] tab, int which)
        {
            which--;
            int without = findMax(tab);
            int result = findMax(tab);
            for (int x = 0; x <= which; x++)
            {
                result = findMin(tab);
                for (int i = 0; i < tab.Length; i++)
                    if (result < tab[i] && tab[i] < without)
                        result = tab[i];
                which -= 1;
                without = result;
            }
            return result;
        }

        static int findMin(int[] tab)
        {
            int result = tab[0];
            for (int i = 1; i < tab.Length; i++)
                if (result > tab[i])
                    result = tab[i];
            return result;
        }

        static int findMin(int[] tab, int which)
        {
            which--;
            int without = findMin(tab);
            int result = findMin(tab);
            for (int x = 0; x <= which; x++)
            {
                result = findMax(tab);
                for (int i = 0; i < tab.Length; i++)
                    if (result > tab[i] && tab[i] > without)
                        result = tab[i];
                which -= 1;
                without = result;
            }
            return result;
        }

        static int count(int[] tab, int x)
        {
            int result = 0;
            foreach (int i in tab)
                if (i == x)
                    result++;

            return result;
        }

        static double[] pow(double[] tab, int p)
        {
            p--;
            for (int i = 0; i < tab.Length; i++)
            {
                double value = tab[i];
                for (int x = 0; x < p; x++)
                    tab[i] *= value;
            }
            return tab;
        }

        static double[] addForEach(double[] tab, double add)
        {
            for (int i = 0; i < tab.Length; i++)
                tab[i] += add;
            return tab;
        }

        static double[] multiplyForEach(double[] tab, double multiply)
        {
            for (int i = 0; i < tab.Length; i++)
                tab[i] *= multiply;
            return tab;
        }

        static int[] sortTable(int[] tab)
        {
            int temp = tab[0];
            bool swap = true;
            while (swap)
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
            }
            return tab;
        }

        static T[] functionTable<T>(T[] tab, Func<T, T> foo, Func<T, bool> fbool)
        {
            for (int i = 0; i < tab.Length; i++)
                if (fbool(tab[i]))
                    tab[i] = foo(tab[i]);
            return tab;
        }

        static void printTable<T>(T[] table)
        {
            Console.Write("[");
            for (int i = 0; i < table.Length;)
            {
                Console.Write(table[i++]);
                if (i != table.Length)
                    Console.Write(" , ");
            }
            Console.Write("]");
        }

        //TODO repair display
        static void printTable<T>(T[] table, Func<T, bool> foo)
        {
            Console.Write("[");
            for (int i = 0; i < table.Length;i++)
            {
                if (foo(table[i]))
                {
                    if (i != 0)
                        Console.Write(" , ");
                    Console.Write(table[i]);
                }
            }
            Console.Write("]");
        }

        // TASKS
        static void zad821()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(findMax(tab));
        }

        static void zad822()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(findMin(tab));
        }

        static void zad823()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(count(tab, findMax(tab)));
        }

        static void zad824()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(count(tab, findMin(tab)));
        }

        static void zad825()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(findMax(tab, 2));
        }

        static void zad826()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(findMin(tab, 2));
        }

        static void zad827()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(count(tab, findMax(tab, 2)));
        }

        static void zad828()
        {
            int[] tab = enterNumbers();
            Console.WriteLine(count(tab, findMin(tab, 2)));
        }

        static void zad831()
        {
            double[] tab = enterDoubleNumbers();
            pow(tab, 2);
            printTable(tab);
        }

        static void zad832()
        {
            double[] tab = enterDoubleNumbers();
            pow(tab, 3);
            printTable(tab);
        }

        static void zad833()
        {
            double[] tab = enterDoubleNumbers();
            addForEach(tab, 1);
            printTable(tab); 
        }

        static void zad834()
        {
            double[] tab = enterDoubleNumbers();
            multiplyForEach(tab, 2);
            printTable(tab);
        }

        static void zad841()
        {
            int[] tab = enterNumbers();
            printTable(tab, x => x % 2 == 0);
        }

        static void zad842()
        {
            int[] tab = enterNumbers();
            printTable(tab, x => x % 2 != 0);
        }

        static void zad843()
        {
            int[] tab = enterNumbers();
            printTable(tab, x => x % 3 == 0);
        }

        static void zad844()
        {
            double[] tab = enterDoubleNumbers();
            printTable(tab, x => x >= 4 && x < 15);
        }

        static void zad845()
        {
            int[] tab = enterNumbers();
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
            int[] tab = enterNumbers();
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
            int[] tab = enterNumbers();
            int[] result = functionTable(tab, x => x += 100, x => x % 2 == 0);
            printTable(result);
        }

        static void zad848()
        {
            double[] tab = enterDoubleNumbers();
            tab = functionTable(tab, x => x = 0, x => x < 0);
            printTable(tab);
        }

        static void zad851()
        {
            double[] tab = enterDoubleNumbers();
            for (int i = 0; i < tab.Length; i += 2)
                Console.WriteLine(tab[i]);
        }

        static void zad852()
        {
            double[] tab = enterDoubleNumbers();
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

        static void Main(string[] args)
        {
            zad861();
        }
    }
}
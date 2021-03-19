using System;
using System.Collections.Generic;



namespace pythagoreanTriplet
{
    class MainClass
    {
        //a < b < c
        //a + b + c = z

        // a min / max =
        //    1  / 1/3 -1

        // b min / max =
        // b = 2 / z/2 -1

        // c min  / max =
        // 1/3z+1 /  z-3

        //#MaxofC #MinOfB #MinOfA z = 100. a = 1 | b = 2 | c = 97
        //#MaxOfB #MinOfA z = 100. a = 1 | b = 49 | c = 50
        //#MaxOfA #MinOfC z = 100. a = 32 | b = 33 | c = 35

        /*
        a starts at 1
        b starts at a+1
        c starts at z-a-b

        a | b | c
        1 + 2 + 97
        1 + 3 + 96
        ...
        1 + 49 + 50
        ...
        1 + 2 + 97
        __________
        
        2 + 3 + 95
        2 + 4 + 94
        2 + 48 + 50
        __________

        
    a:1,b:2,c:997   c starts at max, a & b start at min - >
    ...                b keeps incrementing by 1, c decrements by 1 - >
    a:1,b:499,c:500      c keeps decrementing until b = c - a - >
                           a b c reset ->
    a:2,b:3,c:995              a++, b = a+ 1, c = z - a - b ->
    ...                             c keeps decrementing until b = c - a - >
    a:2,b:498,c:500                     a b c reset - >
    ...                                     a++ , b = a+1, c = z - a - b
   
         */

        public static IEnumerable<(int a, int b, int c)> PythTrip(int z)
        {
            int a = 0, b = a + 1, c = b + 1;

            do
            {
                for (; a < b; a++)
                {
                    for (b = a + 1; b < c; b++)
                    {
                        for (c = b + 1; c < z;c++ )
                        {
                            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) && (a + b + c == z))
                            {
                                yield return (a, b, c);
                            }
                        }
                    }
                }
            } while (a <= z - 2);
        }
        public static void Main(string[] args)
        {
            Console.Write($"Type a pythagorean triplet sum\t: ");
            int sumOfDigits = int.Parse(Console.ReadLine());
            var enumer = PythTrip(sumOfDigits);
            foreach (var item in enumer)
            {
                Console.Write($"Results are (a,b,c)\t: "+item);
            }

        }

    }
}

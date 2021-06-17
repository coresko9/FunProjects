using System;
using System.Collections.Generic;

namespace SimpleLinearRegressionFinder
{

    class RegressionFinder
    {
        public RegressionFinder()
        {
            bool isNotFirstIter = true;
            decimal lowestSquareOfDiff =0;
            Tuple<decimal, Tuple<int, int>> possibleCorrect = new Tuple<decimal, Tuple<int, int>>(0, new Tuple<int, int>(0,0));
            foreach (KeyValuePair<Tuple<int,int>,decimal> item in CalculateSimpleRegression(GenerateRandomData()))
            {
                Console.WriteLine( item.Value);
                
                if (isNotFirstIter)
                {
                    lowestSquareOfDiff = item.Value;
                    possibleCorrect = new Tuple<decimal, Tuple<int, int>>(item.Value, item.Key);
                    isNotFirstIter = false;
                    
                }
                else
                {
                    if(lowestSquareOfDiff > item.Value)
                    {
                        possibleCorrect = new Tuple<decimal, Tuple<int, int>>(item.Value, item.Key);
                        lowestSquareOfDiff = item.Value;
                    }
                }
            }
            Console.WriteLine($"Found optimal regression with [100] trials: sum of squares: {possibleCorrect.Item1} starting salary: {possibleCorrect.Item2.Item2} | pay raise {possibleCorrect.Item2.Item1}" +
                $"\ny = ${possibleCorrect.Item2.Item1}x + ${possibleCorrect.Item2.Item2}\n" +
                $"Actual:\n" +
                $"y = $4000x + $30000 ");
        }
        //Generates random data
        private Dictionary<decimal, decimal> GenerateRandomData()
        {
            decimal baseSalary = 300000m;
            //x= years in company, y = salary. y is dependant

            Random randomDependant = new Random();
            Dictionary<decimal, decimal> depAndIndepVars = new Dictionary<decimal, decimal>();
            for (decimal x = 0; x <= 10; x += 0.40m)
            {
                decimal ranDeviation = (randomDependant.Next(0, 100) / 500m);
                int ranSubOrAdd = randomDependant.Next(0, 10);
                bool isAdd = false;
                switch (ranSubOrAdd)
                {
                    case 0:
                        isAdd = true;
                        break;
                    case 3:
                        isAdd = true;
                        break;
                    case 4:
                        isAdd = true;
                        break;
                    case 7:
                        isAdd = true;
                        break;
                    case 9:
                        isAdd = true;
                        break;

                    default:
                        isAdd = false;
                        break;
                }
                decimal y = (4000m * x) + 30000m;

                if (isAdd)
                {
                    y *= (1 + ranDeviation);

                }
                else
                {
                    y /= (1 - ranDeviation);

                }
                depAndIndepVars.Add(x, Math.Ceiling(y));
            }
            foreach (KeyValuePair<decimal, decimal> item in depAndIndepVars)
            {
                Console.WriteLine($"x: {item.Key} years, y = ${item.Value}");
            }
            return depAndIndepVars;
        }

        private Dictionary<Tuple<int, int>, decimal> CalculateSimpleRegression(Dictionary<decimal, decimal> data)
        {
            Console.WriteLine("/////////////////////////////");
            Console.WriteLine("Sum of Squares");
            Console.WriteLine("/////////////////////////////");
            Console.WriteLine();
            Random ranFormulaGenerator = new Random();
            Dictionary<Tuple<int, int>, decimal> regressionCollection = new Dictionary<Tuple<int, int>, decimal>();

            for (int i = 0; i < 100; i++) 
            {
                decimal differenceSquared = 0;
            decimal sumOfDifference =0 ;
                int startingSalary_Guess = ranFormulaGenerator.Next(1, 61000);
                int payRaise_Guess = ranFormulaGenerator.Next(1, 8000);

                foreach (KeyValuePair<decimal, decimal> dataPoint in data)
                {
                     differenceSquared = dataPoint.Value - ((payRaise_Guess * dataPoint.Key ) + startingSalary_Guess);
                    differenceSquared = differenceSquared * differenceSquared;
                    sumOfDifference += differenceSquared;

                }

                regressionCollection.Add(new Tuple<int, int>(payRaise_Guess, startingSalary_Guess), sumOfDifference);
            }
            return regressionCollection;
        }
    }
    class Program
    {
        //generate random data with correlation between the dependant and independant variables
        //generate random linear regression formula to test if correct formula to represent data. 
        //find sum of differences from all data, repeat [100] times and store the smallest regression line


        static void Main(string[] args)
        {

            RegressionFinder regression = new RegressionFinder();
            Console.Read();

        }
    }
}

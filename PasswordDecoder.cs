using System;
using System.Text;
using System.Threading;
using System.IO;
namespace Havefun
{
    class MainClass
    {

        public static double beb = 1;
        
        public static int Randomize(string b)
        {
            Random a = new Random();
            int yp = a.Next(0, b.Length);
            return yp;      
        }
        public static void Replace(string alphabet, string encrypt, string toBeGuessed)
        {
            var sb = new StringBuilder();
            
                for (int i = 0; i < encrypt.Length; i++)
                {
                    sb.Append(alphabet[Randomize(alphabet)]);
                }
            string possibleCorrect = sb.ToString();
            if (possibleCorrect[0] == toBeGuessed[0])
            {
                Check(alphabet, encrypt, toBeGuessed, possibleCorrect);
            }
            else
            {
                Replace(alphabet, encrypt, toBeGuessed);
            }
            
        }
        public static void Check(string b, string encrypt, string toBeGuessed,string possibleCorrect)
        {
            if (toBeGuessed == possibleCorrect)
            {
                Console.WriteLine($"{beb} : {possibleCorrect} = {toBeGuessed}");
                Console.WriteLine($"you found it after {beb} iterations");

            }    
            else
            {
                beb++;
                Console.WriteLine($"{beb} : {possibleCorrect} != {toBeGuessed}");
                Replace(b, encrypt, toBeGuessed);
            }
        }
        public static void Finish()
        {
            Console.WriteLine("Complete");
        }
        public static void Main(string[] args)
        {   //ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890
            string alphabet = "ABCDEFGHijkLMNOPQRSUVWXYZabcdefghijklmnopqrstuvwxyz";
            Console.WriteLine("what is your password?");
            string toBeGuessed = Console.ReadLine();
            string encrypt = alphabet.Substring(alphabet.Length - toBeGuessed.Length);
           
            Replace(alphabet, encrypt, toBeGuessed);
        } 
    }
}

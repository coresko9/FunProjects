

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Math;

namespace BaseConversion
{
    class MainClass
    {
        public static ulong BinToDec(ulong base2Num)
        {
            char[] toBinArr = base2Num.ToString().ToCharArray();
            ulong toDec = 0;
            int index = toBinArr.Length - 1;
            for (ulong i = 0; i <= (ulong)toBinArr.Length - 1; i++)
            {
                if (ulong.Parse(toBinArr[index].ToString()) == 1)
                {
                    toDec += (ulong)Pow(2, i);

                }
                index--;
            }
            return toDec;
        }
        public static ulong OctToDec(ulong base8Num)
        {
            ulong currBase = (ulong)base8Num.ToString().Length - 1;
            ulong toDec = 0;
            string base8Str = base8Num.ToString();
            foreach (char item in base8Str)
            {
                toDec += ulong.Parse(item.ToString()) * (ulong)Pow(8, currBase);
                currBase--;
            }
            return toDec;

        }
        public static ulong HexToDec(string hexNum)
        {

            ulong currBase = (ulong)hexNum.Length - 1;
            ulong toDec = 0;

            ulong currVal;
            string a = "";

            foreach (char item in hexNum)
            {
                bool isNum = ulong.TryParse(item.ToString(), out currVal);
                if (!isNum)
                {
                    currVal = GetHexVal(item.ToString());
                }
                toDec += currVal * (ulong)Pow(16, currBase);
                currBase--;
            }
            return toDec;
        }
        public static string DecToBin(int decVal)
        {
            int a;
            bool startIndexFound = false;
            string binVal = "";
            for (int i = 0; !startIndexFound; i++)
            {
                if (Pow(2, (i + 1)) > decVal)
                {
                    a = i;
                    startIndexFound = true;

                    for (; a >= 0; a--)
                    {
                        if (decVal >= Pow(2, a))
                        {
                            binVal += "1";
                            decVal -= (int)Pow(2, a);
                        }
                        else
                        {
                            binVal += "0";
                        }
                    }
                }
            }
            return binVal;
        }
        public static string DecToOct(int decVal)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> octal = new List<string>();

            do
            {
                int oct = decVal % 8;
                octal.Add(oct.ToString());
                decVal /= 8;

            } while (decVal != 0);

            foreach (var item in octal)
            {
                stringBuilder.Insert(0, item);
            }
            return stringBuilder.ToString();
        }
        public static string DecToHex(int decVal)
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> octal = new List<string>();
            do
            {
                int oct = decVal % 16;
                if (oct >= 10)
                {
                    octal.Add(GetDecVal(oct));
                }
                else
                {
                    octal.Add(oct.ToString());
                }

                decVal /= 16;

            } while (decVal != 0);

            foreach (var item in octal)
            {
                stringBuilder.Insert(0, item);
            }
            return stringBuilder.ToString();
        }
        public static string GetDecVal(int val)
        {
            string toHex = "";
            switch (val)
            {
                case 10:
                    toHex = "a";
                    break;
                case 11:
                    toHex = "b";
                    break;
                case 12:
                    toHex = "c";
                    break;
                case 13:
                    toHex = "d";
                    break;
                case 14:
                    toHex = "e";
                    break;
                case 15:
                    toHex = "f";
                    break;
                default:
                    break;
            }
            return toHex;
        }
        public static ulong GetHexVal(string val)
        {
            ulong toInt = 0;
            switch (val.ToLower())
            {
                case "a":
                    toInt = 10;
                    break;
                case "b":
                    toInt = 11;
                    break;
                case "c":
                    toInt = 12;
                    break;
                case "d":
                    toInt = 13;
                    break;
                case "e":
                    toInt = 14;
                    break;
                case "f":
                    toInt = 15;
                    break;
                default:
                    break;
            }
            return toInt;
        }


        //public static ulong HexToDec(string base16Num)


        //binary to octal 
        public static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.Write("\n\nEnter 'Q' to Exit, anything else to continue: ");
                    string exit = Console.ReadLine();
                    if (exit.ToLower() == "q")
                    {
                        Environment.Exit(0);
                    }
                    Console.Clear();
                    Console.Write("What base are you converting from? : [2] [8] [10] [16]: ");
                    string baseInput = Console.ReadLine();

                    Console.Write("Enter the value you're converting from: ");
                    string fromInput = Console.ReadLine();

                    if (baseInput == "2")
                    {
                        Console.Write($"{fromInput} to Octal :\t{DecToOct((int)BinToDec(ulong.Parse(fromInput)))}\n");
                        Console.Write($"{fromInput} to Decimal :\t{BinToDec(ulong.Parse(fromInput))}\n");
                        Console.Write($"{fromInput} to Hexadecimal :\t{DecToHex((int)BinToDec(ulong.Parse(fromInput)))}");

                    }
                    else if (baseInput == "8")
                    {
                        Console.Write($"{fromInput} to Binary :\t{DecToBin((int)OctToDec(ulong.Parse(fromInput)))}\n");
                        Console.Write($"{fromInput} to Decimal :\t{OctToDec(ulong.Parse(fromInput))}\n");
                        Console.Write($"{fromInput} to Hexadecimal :\t{DecToHex((int)OctToDec(ulong.Parse(fromInput)))}");
                    }
                    else if (baseInput == "10")
                    {
                        Console.Write($"{fromInput} to Binary :\t{DecToBin(int.Parse(fromInput))}\n");
                        Console.Write($"{fromInput} to Octal :\t{DecToOct(int.Parse(fromInput))}\n");
                        Console.Write($"{fromInput} to Hexadecimal :\t{DecToHex(int.Parse(fromInput))}");
                    }
                    else if (baseInput == "16")
                    {
                        Console.Write($"{fromInput} to Binary :\t{DecToBin((int)HexToDec(fromInput))}\n");
                        Console.Write($"{fromInput} to Octal :\t{DecToOct((int)HexToDec(fromInput))}\n");
                        Console.Write($"{fromInput} to Decimal :\t{HexToDec(fromInput)}");
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }




            }




        }
    }
}
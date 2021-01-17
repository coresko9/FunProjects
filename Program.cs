using System.Text;
using System;

namespace cipher
{
    class MainClass
    {
        public static string Rotate(string text, int shiftKey)
        {
            if (shiftKey >= 26)
            {
                shiftKey = shiftKey - 26;
                Rotate(text, shiftKey);
            }
            string plainText = "abcdefghijklmnopqrstuvwxyz";
            string upperPlainText = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            text = text.Trim();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length;)
            {
                if (char.IsLetter(text[i]))
                {
                    if (char.IsUpper(text[i]))
                    {
                        int newIndex = upperPlainText.IndexOf(text[i]);
                        newIndex += shiftKey;
                        if (newIndex >= 26)
                        {
                            newIndex = newIndex - 26;
                        }

                        sb.Insert(i, upperPlainText[newIndex]);
                        i++;
                    }
                    else
                    {
                        int newIndex = plainText.IndexOf(text[i]);
                        newIndex += shiftKey;

                        if (newIndex >= 26)
                        {
                            newIndex = newIndex - 26;
                        }

                        sb.Insert(i, plainText[newIndex]);
                        i++;
                    }
                }
                else
                {
                    sb.Insert(i, text[i]);
                    i++;
                }
            }
            return sb.ToString();
          
                     
        }
        public static void Main(string[] args)
        {

          

            Console.Write("what would you like to cipher:  ");
            string pT = Console.ReadLine().ToString();

            Console.WriteLine("How much would you like to shift?:  ");
            int shiftKey = int.Parse(Console.ReadLine());

            Console.WriteLine(Rotate(pT, shiftKey) );


            
        }
    }
}

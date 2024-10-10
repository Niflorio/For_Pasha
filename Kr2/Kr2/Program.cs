using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kr2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            string x = Console.ReadLine();
            Console.Write(Word(x));
            Console.ReadKey();
        }
        public static string LastWord(string x)
        {
            string s = "";
            switch (x)
            {
                case "1":
                    s += "одна копейка";
                    break;
                case "2":
                    s += "две копейки";
                    break;
                case "3":
                    s += "три копейки";
                    break;
                case "4":
                    s += "четыре копейки";
                    break;
                case "5":
                    s += "пять копеек";
                    break;
                case "6":
                    s += "шесть копеек";
                    break;
                case "7":
                    s += "семь копеек";
                    break;
                case "8":
                    s += "восемь  копеек";
                    break;
                case "9":
                    s += "девять  копеек";
                    break;
                case "0":
                    s += "копеек";
                    break;
            }
            return s;
        }
        public static string FirstWord(string x)
              {
            string s = "";
            switch (x)
            {
                case "1":
                    s += "одна копейка";
                    break;
                case "2":
                    s += "двадцать ";
                    break;
                case "3":
                    s += "тридцать ";
                    break;
                case "4":
                    s += "сорок ";
                    break;
                case "5":
                    s += "пятьдесят ";
                    break;
                case "6":
                    s += "шестьдесят ";
                    break;
                case "7":
                    s += "семьдесят ";
                    break;
                case "8":
                    s += "восемьдесят ";
                    break;
                case "9":
                    s += "девяносто ";
                    break;
            }
            return s;
        }
        public static string TensWord(string x)
        {
            string s = "";
            switch (x)
            {
                case "10":
                    s += "десять копеек";
                    break;
                case "11":
                    s += "одинадцать копеек";
                    break;
                case "12":
                    s += "двенадцать копеек";
                    break;
                case "13":
                    s += "тринадцать копеек";
                    break;
                case "14":
                    s += "четырнадцать копеек";
                    break;
                case "15":
                    s += "пятнадцать копеек";
                    break;
                case "16":
                    s += "шестнадцать копеек";
                    break;
                case "17":
                    s += "семнадцать копеек";
                    break;
                case "18":
                    s += "восемнадцать копеек";
                    break;
                case "19":
                    s += "девятнадцать копеек";
                    break;
            }
            return s;
        }
        public static string Word(string x)
        {
            string s = "";
            for (int i = 0; i < x.Length; i++)
            {
                if (x.Length == 2 && x[0] == '1')
                {
                    s += TensWord(x);
                    break;
                }
                if (x.Length == 2)
                {
                    s += FirstWord(Convert.ToString(x[0]));
                    s += LastWord(Convert.ToString(x[1]));
                    break;
                }
                else
                {
                    s += LastWord(Convert.ToString(x));
                }
            }
            return s;

        }

    }
}

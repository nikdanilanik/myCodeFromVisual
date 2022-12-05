using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Security;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Diagnostics.SymbolStore;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using static Main;

public static class Main
{
    public static int Sol(int first)
    {
        // If we list all the natural numbers below 10 that are multiples of 3 or 5,
        // we get 3, 5, 6 and 9. The sum of these multiples is 23.

        //This is used if the user himself wants to enter a value
        int ifirst = Convert.ToInt32(first);
        int i = 0;
        int res = 0;
        // Set limits
        if (ifirst > 1000) Console.WriteLine($"Number {ifirst} too big");
        if (ifirst <= 0) Console.WriteLine("0");
        if (ifirst <= 1000 || ifirst >= 1)
        {
            do
            {
                // for number "3"
                i = i + 3;
                res = res + i;
            }
            while (i < ifirst);
            i = 0;
            do
            {
                // for number "5"
                i = i + 5;
                res = res + i;
            }
            while (i < ifirst);
            i = 0;
            do
            {
                // if the number is repeated
                res = res - 15;
                i = i + 15;
            }
            while (i < ifirst);
        }
        return res;
    }

    public static string Upper(string text)
    {
        //This function raises the first letter of each word

        TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
        string res = (myTI.ToTitleCase(text));

        return res;
    }
    public static class Times
    {
        // This class is for converting seconds to days, hours, minutes and seconds
        public static int[] TimeScore(int timeSecond)
        {
            int id = 0;
            int ih = 0;
            int im = 0;
            int ts = timeSecond;
            if (ts >= 86400)
            {
                do
                {
                    ts = ts - 86400;
                    id = id + 1;
                }
                while (ts >= 86400);
            }

            if (ts >= 3600)
            {
                do
                {
                    ts = ts - 3600;
                    ih = ih + 1;
                }
                while (ts >= 3600);
            }
            if (ts >= 60)
            {
                do
                {
                    ts = ts - 60;
                    im = im + 1;
                }
                while (ts >= 60);
            }
            int[] result = { id, ih, im, ts };
            return result;
        }
    }
    public static class Roman
    {
        // This class is converting to/from Roman numerals
        public static string ToRoman(int number)
        {
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public static int FromRoman(string number)
        {
            int num = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (i + 1 < number.Length && RomanMap[number[i]] < RomanMap[number[i + 1]])
                {
                    num -= RomanMap[number[i]];
                }
                else
                {
                    num += RomanMap[number[i]];
                }
            }
            return num;
        }

        private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
    }

    public static class DecodeMorse
    {
        // Decodes Morse code
        public static string Katasix(string forDecode)
        {
            forDecode = KataTwoOneZero(forDecode);
            string result = "";
            forDecode = forDecode.Replace("   ", " _ ");
            string[] text = forDecode.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < text.Length; i++)
            {
                result += MorseToAbc[text[i]];
            }
            return result;
        }

        public static string KatasixOneZero(string forDecodeOneZero, int unit)
        {
            // Deciphers Morse code from zeros and ones
            if (unit == 2)
            {
                forDecodeOneZero = forDecodeOneZero.Replace("00000000000000", "   ");
                forDecodeOneZero = forDecodeOneZero.Replace("111111", "-");
                forDecodeOneZero = forDecodeOneZero.Replace("11", ".");
                forDecodeOneZero = forDecodeOneZero.Replace("000000", " ");
                forDecodeOneZero = forDecodeOneZero.Replace("00", "");
            }
            else
            {
                forDecodeOneZero = forDecodeOneZero.Replace("0000000", "   ");
                forDecodeOneZero = forDecodeOneZero.Replace("111", "-");
                forDecodeOneZero = forDecodeOneZero.Replace("1", ".");
                forDecodeOneZero = forDecodeOneZero.Replace("000", " ");
                forDecodeOneZero = forDecodeOneZero.Replace("0", "");
            }
            return forDecodeOneZero;
        }

        public static string KataTwoOneZero(string forDecod)
        {
            forDecod = forDecod.Replace(KataTwoCheckZero(forDecod), "   ");
            forDecod = forDecod.Replace(KataTwoCheckOne(forDecod), "-");
            forDecod = forDecod.Replace(KataTwoCheckOne(forDecod), ".");
            forDecod = forDecod.Replace(KataTwoCheckZero(forDecod), " ");
            forDecod = forDecod.Replace(KataTwoCheckZero(forDecod), "");
            return forDecod;
        }

        private static string KataTwoCheckZero(string forDecoder)
        {
            string snum1 = "";
            string snum2 = "";
            string tmp;
            char[] valueArray = forDecoder.ToCharArray();
            string chepolino = String.Join(",", valueArray);
            string[] items = chepolino.Split(',');
            foreach (string item in items)
            {
                tmp = item;
                if (tmp == "0")
                {
                    snum1 += "0";
                }
                else
                {
                    if (snum1.Length > snum2.Length)
                    {
                        snum2 = snum1;
                        snum1 = "";
                    }
                    else snum1 = "";
                }
            }
            return snum2;
        }

        private static string KataTwoCheckOne(string forDecoder)
        {
            string snum1 = "";
            string snum2 = "";
            string tmp;
            char[] valueArray = forDecoder.ToCharArray();
            string chepolino = String.Join(",", valueArray);
            string[] items = chepolino.Split(',');
            foreach (string item in items)
            {
                tmp = item;
                if (tmp == "1")
                {
                    snum1 += "1";
                }
                else 
                {
                    if (snum1.Length > snum2.Length)
                    {
                        snum2 = snum1;
                        snum1 = "";
                    }
                    else snum1 = "";
                }
            }
            return snum2;
        }

        private static Dictionary<string, string> MorseToAbc = new Dictionary<string, string>()
        {
            {".-", "A"},
            {"-...", "B"},
            {"-.-.", "C"},
            {"-..", "D"},
            {".", "E"}, 
            {"..-.", "F"}, 
            {"--.", "G"}, 
            {"....", "H"},
            {"..", "I"}, 
            {".---", "J"}, 
            {"-.-", "K"}, 
            {".-..", "L"},
            {"--", "M"}, 
            {"-.", "N"}, 
            {"---", "O"}, 
            {".--.", "P"},
            {"--.-", "Q"}, 
            {".-.", "R"}, 
            {"...", "S"}, 
            {"-", "T"},
            {"..-", "U"}, 
            {"...-", "V"}, 
            {".--", "W"}, 
            {"-..-", "X"},
            {"-.--", "Y"},
            {"--..", "Z"},
            {".----", "1"},
            {"..---", "2"},
            {"...--", "3"},
            {"....-", "4"},
            {".....", "5"},
            {"-....", "6"},
            {"--...", "7"},
            {"---..", "8"},
            {"----.", "9"},
            {"-----", "0"},
            {"_", " " },
            {"......", "." },
        };
    }

    public static class NextSmailerNum
    {
        public static string nextSmailer(string num)
        {
            int inum = Convert.ToInt32(num);
            if (inum < 10) return "-1";
            else if (CheckSameDigit(inum) == 1) return "-1";
            else
            {
                string result = "";
                int[] numbers = new int[num.Length];
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    for (int y = 0; y < num.Length; y++)
                    {
                        if (Char.IsDigit(num[i]))
                        {
                            numbers[y] = IntForChar(num[y]);
                        }
                    }
                    int a = numbers[i];
                    numbers[i] = numbers[i - 1];
                    numbers[i - 1] = a;

                    foreach (var item in numbers)
                    {
                        result += (item.ToString());
                    }
                    if (Convert.ToInt32(result) < Convert.ToInt32(num))
                    {
                        if (numbers[0] == 0)
                        {
                            result = "";
                            int tmp = numbers[numbers.Length - 1];
                            numbers[numbers.Length - 1] = numbers[0];
                            numbers[0] = tmp;
                            foreach (var items in numbers)
                            {
                                result += (items.ToString());
                            }
                            return result;
                        }
                        else return result;
                    }
                    result = "";
                    if (i <= 1) return "-1";
                }
                return "-1";
            }

            //int a, k, e, c;
            //a = Convert.ToInt32(Console.ReadLine());
            //k = a % 10;
            //c = a / 10 % 10;
            //e = a / 10 / 10 % 10;
            //int res = Math.Min(Math.Min((k * 100 + c * 10 + e), (k * 100 + e * 10 + c)),
            //    Math.Min(Math.Min((e * 100 + k * 10 + c),(c * 100 + k * 10 + e)),
            //    Math.Min((c * 100 + e * 10 + k), a)));
            //Console.WriteLine(res);
        }
        static int IntForChar(char ch)
        {
            switch (ch)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
            }
            return -1; // если это не число
        }

        public static int CheckSameDigit(int num)
        {
            int digit = num % 10;
            while (num > 0)
            {
                if (num % 10 != digit) return 0;
                num = num / 10;
            }
            return 1;
        }
    }

    public static class DontGiveMeFive
    {
        public static int GiveMe(int openNum, int closeNum)
        {
            int result = closeNum - openNum + 1;
            int tmp = closeNum;
            int digit = closeNum % 10;
            if (digit < 5) tmp = tmp - digit - 5;
            if (digit > 5)
            {
                int digitTwo = closeNum % 5;
                tmp = tmp - digitTwo;
            }
            while (tmp > openNum)
            {
                tmp = tmp - 10;
                result = result - 1;
            }

            return result;
        }
    }
    public static string getBetween(string strSource, string strStart, string strEnd)
    {
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            int Start, End;
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }

        return "";
    }
}
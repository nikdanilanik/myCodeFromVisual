using MySqlX.XDevAPI.Common;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Main;

#pragma warning disable CS8600
string snumber = Console.ReadLine();
#pragma warning restore CS8600
try
{
    int number = Convert.ToInt32(snumber);
    switch (number)
    {
        case 0:
            //link = https://www.codewars.com/kata/514b92a657cdc65150000006
            //string si = Console.ReadLine();
            //int i = Convert.ToInt32(si);
            int i = 1000;
            Console.WriteLine(Main.Sol(i));
            break;

        case 1:
            //link = https://www.codewars.com/kata/587731fda577b3d1b0001196
#pragma warning disable CS8600
            string st = Console.ReadLine();
#pragma warning restore CS8600
            try
            {

#pragma warning disable CS8604
                Console.WriteLine(Main.Upper(st));
#pragma warning restore CS8604
            }
            catch (Exception)
            {
                Console.WriteLine("Mistake. Check your input.");
            }
            break;

        case 2:
            //link = https://www.codewars.com/kata/52742f58faf5485cae000b9a
#pragma warning disable CS8600
            string timeSecond = Console.ReadLine();
#pragma warning restore CS8600
            try
            {
                int itimeSecond = Convert.ToInt32(timeSecond);
                int[] result = Main.Times.TimeScore(itimeSecond);
                Console.Write(Environment.NewLine + $"input {timeSecond} second = ");
                if (result[0] != 0) Console.Write($"{result[0]} day ");
                if (result[1] != 0) Console.Write($"{result[1]} hour ");
                if (result[2] != 0) Console.Write($"{result[2]} minute ");
                if (result[3] != 0) Console.WriteLine($"{result[3]} second");
            }
            catch (Exception)
            {
                Console.WriteLine("Mistake. Check your input.");
            }
            break;

        case 3:
            //link = https://www.codewars.com/kata/51b66044bce5799a7f000003
#pragma warning disable CS8600
            string Roman = Console.ReadLine();
#pragma warning restore CS8600
            int tryConvertToInt = 0;
            try
            {
                if (int.TryParse(Roman, out tryConvertToInt))
                {
                    if ((tryConvertToInt < 0) || (tryConvertToInt > 4000))
                    {
                        Console.WriteLine("insert value betwheen 1 and 4000");
                    }
                    else
                    {
                        Roman = Main.Roman.ToRoman(tryConvertToInt);
                        Console.WriteLine(Roman);
                    }
                }
                else
                {
#pragma warning disable CS8604
                    Console.WriteLine(Main.Roman.FromRoman(Roman));
#pragma warning restore CS8604
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mistake. Check your input.");
            }
            break;

        case 4:
            //link https://www.codewars.com/kata/54b72c16cd7f5154e9000457
            //string azcMorse = ".. -   .-. .- .. -. . -..   --- -. .   ... " +
            //    "..- -- -- . .-.   -.. .- -.-- ......   .... .   .-- .- .." +
            //    ".   ...- . .-. -.--   ... - .-. --- -. --.";
            //string oneZeroMorse = "110011001100110000001100000011111100110" +
            //    "011111100111111000000000000001100111111001111110011111100" +
            //    "0000110011001111110000001111110011001100000011";
            string xzZeroMorse = "1110000111000011100001110000000001110000000001111100001110000" +
                "11111000011111000000000000111000011111000011111000011111000000000" +
                "11100001110000111110000000001111100001110000111000000000111";
            //Console.WriteLine(Main.DecodeMorse.Katasix(Main.DecodeMorse.KatasixOneZero(oneZeroMorse, timeUnit)));
            //Console.WriteLine(Main.DecodeMorse.Katasix(Main.DecodeMorse.KataTwoOneZero(xzZeroMorse)));
            //Console.WriteLine(Main.DecodeMorse.KataTwoOneZero(xzZeroMorse));
            Console.WriteLine(Main.DecodeMorse.Katasix(xzZeroMorse));
            break;

        case 5:
            // link: https://www.codewars.com/kata/5659c6d896bc135c4c00021e
            string num = "1";
            Console.WriteLine(Main.NextSmailerNum.nextSmailer(num));
            break;

        case 6:
            // link https://www.codewars.com/kata/621f89cc94d4e3001bb99ef4
            int open = Convert.ToInt32(Console.ReadLine());
            int close = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Main.DontGiveMeFive.GiveMe(open, close));
            break;

        case 7:
            // link = https://www.codewars.com/kata/54de279df565808f8b00126a
#pragma warning disable CS8600
            string stnum = Console.ReadLine();
#pragma warning restore CS8600
            try
            {
#pragma warning disable CS8604
                if ((Convert.ToInt32(Main.ConverterToFromBinary.FromBinary(stnum)) % 3) == 0)
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }
#pragma warning restore CS8604
            }
            catch (Exception)
            {
                Console.WriteLine("Mistake. Check your input.");
            }
            break;

        case 8:
            //link = https://www.codewars.com/kata/5647c3858d4acbbe550000ad
#pragma warning disable CS8600
            string strnum = Console.ReadLine();
            string innum = Console.ReadLine();
#pragma warning restore CS8600
            try
            {
#pragma warning disable CS8604
                if ((Convert.ToInt32(Main.ConverterToFromBinary.FromBinary(strnum)) % Convert.ToInt32(innum)) == 0)
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }
#pragma warning restore CS8604
            }
            catch (Exception)
            {
                Console.WriteLine("Mistake. Check your input.");
            }
            break;

        case 9:
            //link = https://www.codewars.com/kata/51c8e37cee245da6b40000bd
            string text = "apples, pears # and bananas\ngrapes\nbananas !apples";
            string[] symbols = { "#", "!" };
            string stripped = Main.StripCommentsSolution.StripComments(text, symbols);
            Console.WriteLine(stripped);
            break;
    }
}
catch (Exception)
{
    Console.WriteLine("Mistake. Check your input.");
}
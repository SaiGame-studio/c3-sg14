using System;
using UnityEngine;

public class LargeNumber
{
    //static string formatString = "N2";
    private static double maxFractional = 00.99;

    //static string[] latin = { "M", "B", "T", "Q", "D", "S", "P", "O", "N" };
    private static string[] ones = { "M", "B", "T", "Q", "D", "V", "P", "Y", "N" };
    private static string[] latin = ones;
    private static string[] tens = { "A", "B", "C", "D", "E", "F", "G", "H", "J" };
    private static string[] hundreds = { "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AJ" };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawNumber"></param>
    /// <param name="formatString"></param>
    /// <returns></returns>
    static public string ToString(double rawNumber, string formatString = "2")
    {
        //Debug.Log("LargeNumber: " + rawNumber.ToString());
        double number;

        if (rawNumber < 10000) formatString = "0";

        if (rawNumber < 1000000.0)
        {
            if (rawNumber > 10000)
            {
                rawNumber /= 1000;

                number = rawNumber;
                if (formatString == "0") number = Mathf.Floor((float)number);
                if (formatString == "1") number = Mathf.Floor((float)number * 10) / 10;
                if (formatString == "2") number = Mathf.Floor((float)number * 100) / 100;
                if (formatString == "3") number = Mathf.Floor((float)number * 1000) / 1000;
                if (formatString.Length == 1) return number.ToString() + " K";

                return rawNumber.ToString(formatString) + " K";
            }

            return rawNumber.ToString("N0");
        }

        ScientificNotation scientificNotation = ScientificNotation.FromDouble(rawNumber);
        ushort adjustedExponent = (ushort)((scientificNotation.exponent / 3) - 1);
        string prefix = "";
        if (adjustedExponent < 10)
        {
            prefix = latin[adjustedExponent - 1];
        }
        else
        {
            ushort hundredsPlace = (ushort)(adjustedExponent / 100);
            ushort tensPlace = (ushort)((adjustedExponent / 10) % 10);
            ushort onesPlace = (ushort)(adjustedExponent % 10);
            string onesString = (onesPlace > 0) ? ones[onesPlace - 1] : "";
            string tensString = (tensPlace > 0) ? tens[tensPlace - 1] : "";
            string hundredsString = (hundredsPlace > 0) ? hundreds[hundredsPlace - 1] : "";
            prefix = string.Format("{0}{1}{2}", tensString, onesString, hundredsString);
        }
        double adjustedSignificand = scientificNotation.significand * Math.Pow(10, scientificNotation.exponent % 3);
        double integralPart = Math.Truncate(adjustedSignificand);

        number = (((adjustedSignificand - integralPart) > maxFractional) ? integralPart + maxFractional : adjustedSignificand);
        if (formatString == "0") number = Mathf.Floor((float)number);
        if (formatString == "1") number = Mathf.Floor((float)number * 10) / 10;
        if (formatString == "2") number = Mathf.Floor((float)number * 100) / 100;
        if (formatString == "3") number = Mathf.Floor((float)number * 1000) / 1000;
        if (formatString.Length == 1) return string.Format("{0} {1}", number.ToString(), prefix);

        return string.Format("{0} {1}", number.ToString(formatString), prefix);
    }
}

/// <summary>
/// 
/// </summary>
public struct ScientificNotation
{
    public ushort exponent;
    public double significand;

    static public ScientificNotation FromDouble(double rawNumber)
    {
        ushort exponent = (ushort)Math.Log10(rawNumber);
        return new ScientificNotation
        {
            exponent = exponent,
            significand = rawNumber * Math.Pow(0.1, exponent)
        };
    }
}

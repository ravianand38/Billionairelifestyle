using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
public static class MonetFormatter
{
    public static string FormatMoney(BigInteger value)
    {
        string moneyFormat = "{0}";

        if (value >= 1000000000)
        {
            moneyFormat = "{0:#,0,,, B}";
        }




       else if (value >= 1000000)
        {
            moneyFormat = "{0:#,0,, M}";
        }




       else if (value >= 1000)
        {
            moneyFormat = "{0:#,0, K}";
        }





        return string.Format(moneyFormat + "£", value);
    }
}
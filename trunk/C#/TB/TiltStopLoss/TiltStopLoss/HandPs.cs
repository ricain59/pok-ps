using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiltStopLoss
{
    class HandPs
    {
        public String getNL(String hand)
        {
            if (hand.Contains("0.02/") && hand.Contains("0.05"))
            {
                return "nl5";
            }
            if (hand.Contains("0.05/") && hand.Contains("0.10"))
            {
                return "nl10";
            }
            if (hand.Contains("0.08/") && hand.Contains("0.16"))
            {
                return "nl16";
            }
            if (hand.Contains("0.10/") && hand.Contains("0.25"))
            {
                return "nl25";
            }
            if (hand.Contains("0.25/") && hand.Contains("0.50"))
            {
                return "nl50";
            }
            if (hand.Contains("0.50/") && hand.Contains("1"))
            {
                return "nl100";
            }
            return "_";
        }



    }
}

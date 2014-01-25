using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiltStopLoss
{
    class HandPs
    {
        public Double getBb(String hand, String player)
        {
            Double limit = getNL(hand);
            String money = getMoney(hand);
            string[] stringSeparators = new string[] { "SUMMARY" };
            string[] splithand = hand.Split(stringSeparators, StringSplitOptions.None);
            stringSeparators = new string[] { "\r\n" };
            string[] allhand = hand.Split(stringSeparators, StringSplitOptions.None);
            //caso folda a mão fora das blinds
            if (splithand[1].Contains(player + " folded before Flop (didn't bet)"))
            {
                return 0.0;
            }
            //caso esta na SB e folda
            if (splithand[1].Contains(player + " (small blind) folded before Flop"))
            {
                return 0.5;
            }
            //caso esta na BB e folda
            if (splithand[1].Contains(player + " (big blind) folded before Flop"))
            {
                return 1.0;
            }
            //ler a mão completa se não acontece nenhum dos casos anteriores
            foreach (String handar in allhand)
            {
                Double invest = 0.0;
                if(handar.Contains(player+": posts small blind"))
                {
                    invest += getSB(limit)/limit;
                }
                if(handar.Contains(player+": posts big blind"))
                {
                    invest += limit;
                }
                if (handar.Contains(player) && handar.Contains("raises"))
                {
                    stringSeparators = new string[] { "to "+money };
                    String[] newsplitvalue = handar.Split(stringSeparators, StringSplitOptions.None);
                    invest += Convert.ToDouble(newsplitvalue[1]);
                }
                return invest;
            }            
            return 0.0;
        }
        
        
        
        
        public Double getNL(String hand)
        {
            if (hand.Contains("0.02/") && hand.Contains("0.05"))
            {
                return 0.05;
            }
            if (hand.Contains("0.05/") && hand.Contains("0.10"))
            {
                return 0.10;
            }
            if (hand.Contains("0.08/") && hand.Contains("0.16"))
            {
                return 0.16;
            }
            if (hand.Contains("0.10/") && hand.Contains("0.25"))
            {
                return 0.25;
            }
            if (hand.Contains("0.25/") && hand.Contains("0.50"))
            {
                return 0.50;
            }
            if (hand.Contains("0.50/") && hand.Contains("1"))
            {
                return 1.00;
            }
            return 0;
        }

        public Double getSB(Double bb)
        {
            if (bb == 0.05)
            {
                return 0.02;
            }
            if (bb == 0.10)
            {
                return 0.05;
            }
            if (bb == 0.16)
            {
                return 0.08;
            }
            if (bb == 0.25)
            {
                return 0.10;
            }
            if (bb == 0.50)
            {
                return 0.25;
            }
            if (bb == 1.00)
            {
                return 0.50;
            }
            return 0;
        }

        private String getMoney(String hand)
        {
            if (hand.Contains("$"))
            {
                return "$";
            }
            if (hand.Contains("€"))
            {
                return "€";
            } if (hand.Contains("£"))
            {
                return "£";
            }
            return "$";
        }

    }
}

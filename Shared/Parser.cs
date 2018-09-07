using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public class Parser
    {
        public Parser()
        {
        }
        public Dictionary<string, int> Parse(String sFragDNA)
        {
            Dictionary<string, int> dResult = new Dictionary<string, int>();

            //List<Char> lBase = sFragDNA.Split().ToList();
            //Count Paire
            for(int i = 0; i < sFragDNA.Count()-1; i += 2)
            {
                String paireBase = sFragDNA[i].ToString() + sFragDNA[i + 1].ToString();
                if (dResult.ContainsKey(paireBase))
                {
                    int nbpaireBase = dResult[paireBase];
                    dResult[paireBase] = nbpaireBase + 1;
                }
                else
                {
                    dResult.Add(paireBase, 1);
                }
                
            }

            return dResult;
        }
    }
}

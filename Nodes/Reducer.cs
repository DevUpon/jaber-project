﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nodes
{
    class Reducer
    {
        List<Dictionary<string, int>> lToReduce = new List<Dictionary<string, int>>();
        public Reducer()
        {
        }
        public Dictionary<string, int> Reduce()
        {
            Dictionary<string, int> finalDict = new Dictionary<string, int>();

            foreach (Dictionary<string, int> dict in lToReduce)
            {
                foreach (String Key in dict.Keys)
                {
                    if (finalDict.ContainsKey(Key))
                    {
                        //int nbpaireBase = dict[Key];
                        finalDict[Key] = finalDict[Key] + dict[Key];
                    }
                    else
                    {
                        finalDict.Add(Key, dict[Key]);
                    }
                }

            }

            return finalDict;
        }
        public void addDictToReduce(Dictionary<string, int> dict)
        {
            lToReduce.Add(dict);
        }
    }
}

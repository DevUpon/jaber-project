using System;
using System.Collections.Generic;
﻿using Nodes;

namespace Orchestrator
{
    public class Maestro
    {
        private TaskManager manager;
        private IConnexionOrchestrateur connexion;
        private String dna;
        private List<String> dnaFragments; //store dna splitted in case of loss of connexion

        public Maestro(int type)
        {
            connexion = new ConnexionOrchestrateur(1);
            this.manager = new TaskManager(connexion);
        }

        public void Connecter(int countNode)
        {
            this.manager.RunConnecter(countNode);
        }

        public void Envoyer(List<List<String>> data)
        {
            connexion.Envoyer(data);
        }

        public void WaitCompletedConnexion()
        {
            manager.Wait();
        }

        public void Recevoir()
        {
            manager.TaskRecevoir();
        }

        //Prends un fichier local qui se fait spliter
        public List<String> Split(String pathFile)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(pathFile);
            List<string> mylist = new List<string>();
            String allstring = "";

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Contenant du fichier = ");
            int testValue = 0;
            foreach (string line in lines)
            {
                /*if (testValue == 50)
                {
                    break;
                }*/
                // Use a tab to indent each line of the file.
                //Console.WriteLine("\t Line:" + line);
                //Console.WriteLine("\t Line:");
                char[] delimiters = new char[] { '\r', '\n' };
                String[] Tabvalues = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);


                foreach (var val in Tabvalues)
                {
                    char[] delimiter = new char[] { '\t' };
                    String[] elts = val.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    String element = elts[3];


                    //Alors stocker la valeur dans le tableau définitif
                    //Console.Write(element);

                    mylist.Add(element);
                    //allstring += element;


                }
                //testValue++;
            }


            // Keep the console window open in debug mode.
            /*foreach (String item in mylist) {
            Console.Write(item);
            }*/
            Console.WriteLine("Résult final " + mylist[10]);
            Console.WriteLine("Résult final " + mylist[11]);
            Console.WriteLine("Résult final " + mylist[12]);
            Console.WriteLine("Press any key to exit.");
            // System.Console.ReadKey();
            string path = @"C:\Users\Faurever\Desktop\result.txt";
            //string path2 = @"C:\Users\Faurever\Desktop\result2.txt";
            System.IO.File.WriteAllLines(path, mylist);
            //String beu = mylist.ToString();
            //System.IO.File.WriteAllText(path2, allstring);
            return mylist;
        }

        public void MapNode(List<Node> nodes)
        {
            
        }

        public List<List<String>> CreateDnaFragChunk(String pathFile, int countNodes)
        {
            List<String> dnaFragments = Split(pathFile);
            List<List<String>> dnaFragmentsChunkedList = new List<List<String>>();

            if (dnaFragments.Count != 0)
            {
                int numberOfDnaLinePerNode = dnaFragments.Count / countNodes;

                for (int index = 0; index < countNodes; index++)
                {
                    dnaFragmentsChunkedList.Add(dnaFragments.GetRange(index * numberOfDnaLinePerNode, numberOfDnaLinePerNode));
                }
            } else
            {
                throw new Exception("Unsupported operation exception");
            }

            /*       List<String> listResult = new List<string>();
                   foreach(List<String> subList in dnaFragmentsChunkedList)
                   {
                       String firstResult = "";
                       foreach(String item in subList)
                       {
                           firstResult = firstResult + item;
                       }
                       listResult.Add(firstResult);*/
            return dnaFragmentsChunkedList;
            }
        }

    }
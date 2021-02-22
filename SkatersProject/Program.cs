using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp6
{
   
    class SkatersDemo
    {
        static void Main(string[] args)
        {
            string filepath = @"C:\Sim_IPD-program\course contents\11.dot_net_programming\Project\Pairs.txt";
            StreamReader sr = new StreamReader(filepath);
            //List<string> lines = File.ReadAllLines(filepath).ToList();
            List<Skaters> SkatersArray = new List<Skaters>();

            try
            {
                string ln;
                while ((ln=sr.ReadLine())!=null)
                {
                    Skaters newSkaters = new Skaters();
                    
                    newSkaters.FirstName = ln;
                    newSkaters.LastName = sr.ReadLine();
                    newSkaters.Country = sr.ReadLine();
                    string tech_asp = sr.ReadLine();
                    string perf_asp = sr.ReadLine();
                    double Final_Score = newSkaters.CalcFinalScores(tech_asp, perf_asp);
                    newSkaters.FinalScores = Final_Score;
                    SkatersArray.Add(newSkaters);     
                }
                //print all the skaters with their details 
                Console.WriteLine("All the skaters with FirstName, LastName, Country, Final Scores are:");
                foreach (var skater in SkatersArray)
                {    
                    Console.WriteLine($"{skater.FirstName} {skater.LastName} {skater.Country} {skater.FinalScores}");
                }
                Console.WriteLine();

                //now print the skater details according to the sorted list
                Console.WriteLine("All the skaters with details sorted in decreasing order of final scores are:");
                SkatersArray.Sort(delegate (Skaters x, Skaters y) { return y.FinalScores.CompareTo(x.FinalScores); });

                foreach (var skater in SkatersArray)
                {
                    Console.WriteLine($"{skater.FirstName} {skater.LastName} {skater.Country} {skater.FinalScores}");
                }
                Console.WriteLine();
                Console.WriteLine();
                
                //Now as we know 2 or 3 skaters may have the same score for the medals, 
                //so we should give them all the respective position/medal so for that we can find out
                //the number of skaters with same position by using the variables(First, Second, Third) in following code.
                int First = 0;
                //the printing will start from the first position so i=0
                for (int i = 0; i < SkatersArray.Count(); i++)
                {
                        if (Math.Abs(SkatersArray.ElementAt(i).FinalScores-SkatersArray.ElementAt(i + 1).FinalScores)<0.00001)
                            First = First + 1;
                        else
                           break;
                }

                int Second = First+1;
                //as we know we already have the position of last skater for First prize so we will start from next value
                for (int i = Second; i <SkatersArray.Count(); i++)
                {
                        if (Math.Abs(SkatersArray.ElementAt(i).FinalScores - SkatersArray.ElementAt(i + 1).FinalScores) < 0.00001)
                               Second = Second + 1;
                        else
                           break;
                }
                int Third = Second+1;
                //as we know we already have the position of last skater for Second prize so we will start from next value
                for (int i = Second + 1; i < SkatersArray.Count(); i++)
                {
                        if (Math.Abs(SkatersArray.ElementAt(i).FinalScores - SkatersArray.ElementAt(i + 1).FinalScores) < 0.00001)
                        Third = Third + 1;
                    else
                        break;
                }
                //finally we will have the counter values in variables for first, second and third positions
                Console.WriteLine();
                Console.WriteLine("The value of variable First= "+First + " Second= " + Second + " Third= " + Third);
                Console.WriteLine();
                //we can start to print First position skater/s from 0 till the counter value i.e. First
                for(int i = 0; i <= First; i++)
                {
                    var FirstElement = SkatersArray.ElementAt(i);
                    Console.WriteLine("The Gold Medal Winner is "+ FirstElement.FirstName +" "+ FirstElement.LastName +" and his/her score is "+ FirstElement.FinalScores);

                }
                //we can start to print second position skater/s from First+1 till the counter value of Second
                for (int i = First+1; i <= Second; i++)
                {
                    var FirstElement = SkatersArray.ElementAt(i);
                    Console.WriteLine("The Silver Medal Winner is " + FirstElement.FirstName + " " + FirstElement.LastName + " and his/her score is " + FirstElement.FinalScores);

                }
                //we can start to print third position skater/s from Second+1 till the counter value of Third
                for (int i = Second + 1; i <= Third; i++)
                {
                    var FirstElement = SkatersArray.ElementAt(i);
                    Console.WriteLine("The Bronze Medal Winner is " + FirstElement.FirstName + " " + FirstElement.LastName + " and his/her score is " + FirstElement.FinalScores);
                }
                
                Console.WriteLine();      
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

    }
}

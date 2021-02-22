using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class Skaters 
    {
        private double CalcFinalScore;
        private Skaters skaters;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public double FinalScores { get; set; }
        public Skaters()
        {
        }

        public Skaters(string firstName, string lastName, string country,double finalScores)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.FinalScores = finalScores;
        }

        public Skaters(Skaters skaters)
        {
            this.skaters = skaters;
        }

        public double CalcFinalScores(string tech_asp, string perf_asp)
        {
               double totalTech=0.0, totalPerform = 0.0;
              // create the array of values by spliting the string by space' '(so we will have all the score values in an array)
              string[] Technical_aspects = tech_asp.Split(' ');
              //now as we know there are 8 scores so we can add all the 8 items and store the total in a variable
              //(also convert the string to double)
              for (int i = 0; i <= 7; i++)
              {
                 totalTech = totalTech + Double.Parse(Technical_aspects[i]);
              }
               // create the array of values by spliting the string by space' '(so we will have all the score values in an array)
               string[] Performance_aspects = perf_asp.Split(' ');
               //now as we know there are 8 scores so we can add all the 8 items and store the total in a variable
               //(also convert the string to double)
               for(int i=0; i <= 7; i++)
               {
                  totalPerform = totalPerform + Double.Parse(Performance_aspects[i]);
               }

              CalcFinalScore = (totalTech / 8) + (totalPerform / 8);
              return CalcFinalScore;
        }

    }

        }

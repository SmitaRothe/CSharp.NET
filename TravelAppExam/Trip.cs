using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAppExam
{
    class Trip
    {      
        public string Destination { get; set; }     
        public string Name { get; set; }
        public string Passport { get; set; }           
        public DateTime Departure { get; set; }      
        public DateTime Return { get; set; }

            public Trip(string destination, string name, string passport, DateTime departure, DateTime returndate )
            {
                this.Destination = destination;
                this.Name = name;
                this.Passport = passport;
                this.Departure = departure;
                this.Return= returndate;
            }
            public Trip()
            {

            }

            public  string ToString()
            {
                return string.Format("{0};{1};{2};{3};{4}", this.Destination, this.Name, this.Passport, this.Departure,this.Return);
            }

            public string ToDataString()
            {
                return string.Format("{0};{1};{2};{3};{4}", this.Destination, this.Name, this.Passport, this.Departure,this.Return);
            }

        }
    }

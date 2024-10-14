using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsWorker
{
    public class Employee
    {

        public Employee() 
        {
            Dependents = new List<Dependent>();
            Checks = new List<double>();
        }
       
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Salary { get; set; }
        public List <Dependent> Dependents { get;  private set; }    

        public List<double> Checks { get; set; }


        public bool AddDependent( Dependent dependent)
        {
            if (dependent == null)
            {
                return false;
            }

            if(dependent.Relationship == Relationship.DomesticPartner || dependent.Relationship == Relationship.Spouse)
            {
                
               if (Dependents.Any(d => d.Relationship == Relationship.Spouse || d.Relationship == Relationship.DomesticPartner))
               {
                    return false;
               }
            }

            Dependents.Add(dependent);
            return true;
        }
    }
}

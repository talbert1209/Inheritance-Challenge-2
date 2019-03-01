using System;
using System.Collections.Generic;

namespace Inheritance15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pay an hourly employee Bob who works for 40 hours
            // Bob's hourly rate is $27.50

            // Pay a salaried employee Steve who works one week.
            // Steve's yearly salary is $50,000
            var employees = new List<Employee>
            {
                new HourlyEmployee{Name = "Bob", HourlyRate = 27.50},
                new SalariedEmployee{Name = "Steve", BaseSalary = 50000}
            };
            
            PayEmployees(employees);
        }

        private static void PayEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employee.PayEmployee();
            }
        }
    }

    public abstract class Employee
    {
        public string Name { get; set; }

        public abstract void PayEmployee();

    }

    public class HourlyEmployee : Employee
    {
        public double HourlyRate { get; set; }          
        public override void PayEmployee()
        {
            var payCheck = 40 * HourlyRate;
            Console.WriteLine($"{Name} has been paid {payCheck:C}");
        }
    }

    public class SalariedEmployee : Employee
    {
        public double BaseSalary { get; set; }
        public override void PayEmployee()
        {
            var payCheck = BaseSalary / 26;
            Console.WriteLine($"{Name} has been paid {payCheck:C}");
        }
    }
}

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
                new HourlyEmployee{Name = "Bob"},
                new SalariedEmployee{Name = "Steve"}
            };
            
            PayEmployees(employees);
        }

        private static void PayEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                if (employee.GetType() == typeof(HourlyEmployee))
                {
                    employee.PayEmployee(40, 27.50);
                }

                if (employee.GetType() == typeof(SalariedEmployee))
                {
                    employee.PayEmployee(40, 50000);
                }
            }
        }
    }

    public abstract class Employee
    {
        public string Name { get; set; }

        public abstract void PayEmployee(int time, double rate);

    }

    public class HourlyEmployee : Employee
    {
        public override void PayEmployee(int hoursWorked, double payRate)
        {
            var payCheck = hoursWorked * payRate;
            Console.WriteLine($"{Name} has been paid {payCheck:C}");
        }
    }

    public class SalariedEmployee : Employee
    {
        public double BaseSalary { get; set; }
        public override void PayEmployee(int hoursWorked, double yearlyRate)
        {
            var payCheck = yearlyRate / 26;
            Console.WriteLine($"{Name} has been paid {payCheck:C}");
        }
    }
}

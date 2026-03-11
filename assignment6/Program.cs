using System;

namespace EmployeeSystem
{
    // Enum for Gender
    public enum Gender
    {
        M,
        F
    }

    // Enum for Security Level
    public enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA
    }

    // Hire Date Class
    public class HireDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public HireDate(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

    // Employee Class
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public SecurityLevel Security { get; set; }
        public double Salary { get; set; }
        public HireDate HireDate { get; set; }
        public Gender Gender { get; set; }

        // Constructor
        public Employee(int id, string name, SecurityLevel security, double salary, HireDate hireDate, Gender gender)
        {
            ID = id;
            Name = name;
            Security = security;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }

        // Override ToString
        public override string ToString()
        {
            return string.Format(
                "ID: {0}\nName: {1}\nSecurity Level: {2}\nSalary: {3:C}\nHire Date: {4}\nGender: {5}\n",
                ID,
                Name,
                Security,
                Salary,
                HireDate,
                Gender
            );
        }
    }

    class Program
    {
        static void Main()
        {
            // Create array of employees
            Employee[] EmpArr = new Employee[3];

            EmpArr[0] = new Employee(
                1,
                "Ahmed",
                SecurityLevel.DBA,
                15000,
                new HireDate(10, 5, 2020),
                Gender.M
            );

            EmpArr[1] = new Employee(
                2,
                "Sara",
                SecurityLevel.Guest,
                5000,
                new HireDate(15, 3, 2022),
                Gender.F
            );

            EmpArr[2] = new Employee(
                3,
                "Omar",
                SecurityLevel.Developer,
                12000,
                new HireDate(1, 1, 2021),
                Gender.M
            );

            // Print employees
            foreach (Employee emp in EmpArr)
            {
                Console.WriteLine(emp);
                Console.WriteLine("----------------------");
            }
        }
    }
}
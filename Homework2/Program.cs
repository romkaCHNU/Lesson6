using System;
using System.Xml.Linq;
namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Professor professor = new Professor("Professor", 260);
            professor.Money = Math.Round(professor.CalculateSalary(professor.Hours));
            
            List<Person> people = new List<Person>();
            for(int i = 0; i < 16; i++)
            {
                int randomHours = 0;
                for (int j = 0; j < 25 * 12; j++)
                {
                    randomHours += 8 + Person.random.Next(-1, 3);
                }
                if(i < 3) people.Add(new Professor($"Professor {i+1}", randomHours));
                else if(i < 13)people.Add(new Student($"Student {i-2}", randomHours));
                else people.Add(new Staff($"Staff {i-12}", randomHours));
            }
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} earned {person.Money} dollars");
            }
        }
    }
    abstract class Person
    {
        protected double multiplier;
        protected double BonusMultiplier;
        protected int salaryPerHour = 30;
        public string Name { get; set; }
        public int Hours { get; set; }
        public double Money { get; set; }
        public Person(string name, int hours, double multiplier, double BonusMultiplier)
        {
            Name = name;
            Hours = hours;
            this.multiplier = multiplier;
            this.BonusMultiplier = BonusMultiplier;
            Money = Math.Round(CalculateSalary(hours));
        }
        public static Random random = new Random();
        public abstract double CalculateSalary(int numbersHour);        
            
        


    }
    class Professor : Person
    {
        public Professor(string name, int hours) : base(name, hours, 3, 5)
        { 
        }
            
        
        public override double CalculateSalary(int numbersHour)
        {
            int bonus = 2000;
            if (numbersHour < 160)
            {
                return salaryPerHour * multiplier * numbersHour + bonus;
            }
            else
            {
                return salaryPerHour * multiplier * numbersHour + salaryPerHour * BonusMultiplier * (numbersHour - 160) +  bonus;
            }

        }
    }
    class Student : Person
    {
        public Student(string name, int hours) : base(name, hours, 0.5, 1)
        {
        }
        public override double CalculateSalary(int numbersHour)
        {
            if (numbersHour < 160)
            {
                return salaryPerHour * multiplier * numbersHour + random.Next(-700, 701);
            }
            else
            {
                return salaryPerHour * multiplier * numbersHour + salaryPerHour * BonusMultiplier * (numbersHour - 160) + random.Next(-700, 701);
            }

        }


    }
    class Staff : Person
    {
        public Staff(string name, int hours) : base(name, hours, 1.2, 2)
        {

        }
        public override double CalculateSalary(int numbersHour)
        {
            if (numbersHour <= 160)
            {
                return salaryPerHour * multiplier * numbersHour;
            }
            else
            {
                return salaryPerHour * multiplier * numbersHour + salaryPerHour * BonusMultiplier * (numbersHour - 160);
            }
        }

        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Student
    {
        private int id;
        private string name;
        private int age;
        private int grade;
        private double averageScore;
        private decimal fee;
        private bool hasScholarship;
        private char classLetter;
        private DateTime birthDate;

        public int Id
        {
            get => id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Номера трябва да бъде положителен.");
                }
                id = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Името е задължително и не може да съдържа само интервали.");
                }
                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 6 || value > 20)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Възрастта на ученика трябва да бъде между 6 и 20 включително.");
                }
                age = value;
            }
        }

        public int Grade
        {
            get => grade;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Класовете са само от 1 до 12.");
                }
                grade = value;
            }
        }

        public double AverageScore
        {
            get => averageScore;
            set
            {
                if (value < 2.00 || value > 6.00)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Възможният успех е от 2 до 6.");
                }
                averageScore = value;
            }
        }

        public decimal Fee
        {
            get => fee;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Не може да има отрицателна такса.");
                }
                fee = value;
            }
        }

        public bool HasScholarship { get; set; }

        public char ClassLetter
        {
            get => classLetter;
            set
            {
                if (!char.IsLetter(value))
                {
                    throw new ArgumentOutOfRangeException("Паралелката трябва да бъде буква.");
                }
                classLetter = value;
            }
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Не може датата на раждане да е бъдеща.");
                }
                birthDate = value;
            }
        }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Base
{
    class Person
    {


        internal class Program
        {
            private static void Main(string[] args)
            {
                // Создать один объект типа Student, преобразовать данные в текстовый вид с помощью метода ToShortString() и вывести данные.

                var student = new Student(new Person("Alex ", "Avgust ", new DateTime(2004, 06, 03)), Education.Вachelor, 320);
                Console.WriteLine(student.ToShortString());

                // Вывести значения индексатора для значений индекса Education.Specialist, Education.Bachelor и Education.SecondEducation.

                Console.WriteLine(student[Education.Specialist]);
                Console.WriteLine(student[Education.Вachelor]);
                Console.WriteLine(student[Education.SecondEducation]);
                // Присвоить значения всем определенным в типе Student свойствам, преобразовать данные в текстовый вид с помощью метода ToString() и вывести данные.

                student.Persons = new Person("Sena ", "Avgust ", new DateTime(2008, 09, 12));
                student.Educations = Education.Specialist;
                student.Groups = 320;

                Console.WriteLine(student.ToString());

                // C помощью метода AddExams( params Exam*+ ) добавить элементы в список экзаменов и вывести данные объекта Student, используя метод ToString().

                student.AddExams(new Exam("Info", 4, new DateTime(2022, 09, 25)), new Exam("Algoritm", 5, new DateTime(2022, 09, 27)));
                Console.WriteLine(student.ToString());

                //Сравнить время выполнения операций с элементами одномерного, двумерного прямоугольного и двумерного ступенчатого массивов с одинаковым числом элементов типа Exam.

                var OneArray = new Exam[10000];
                var TwoArray = new Exam[100,100];
                var jaggedArray = new Exam[100][];

                

                // OneArray       
                var sw = Stopwatch.StartNew();

                for (int i = 0; i < 10000; i++)
                {
                    OneArray[i] = null;
                }
                    
                sw.Stop();
                Console.Write("одномерный массив: ");
                Console.WriteLine(sw.Elapsed);

                // TwoArray
                sw = Stopwatch.StartNew();

                for(int i = 0; i < 100; i++)
                {
                    for(int j = 0; j < 100; j++)
                    {
                        TwoArray[i,j] = null;
                    }
                }

                sw.Stop();
                Console.Write("двумерный прямоугольный массив: ");
                Console.WriteLine(sw.Elapsed);

                // JaggedArray

                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    jaggedArray[i] = new Exam[1000];
                }

                sw = Stopwatch.StartNew();

                for(int i = 0; i < 100; i++)
                {
                    for(int j = 0; j < 100; j++)
                    {
                        jaggedArray[i][j] = null;
                    }
                }

                sw.Stop();
                Console.Write("двумерный ступенчатый массив: ");
                Console.WriteLine(sw.Elapsed);
                Console.ReadKey();
            }
        }


        private string Name;
        private string Surname;
        private System.DateTime DateOfBirth;


        public Person(string name, string surname, DateTime dateOfBirth)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        public Person()
        {
            this.Name = "Alex";
            this.Surname = "Avgust";
            this.DateOfBirth = new DateTime(2004, 04, 12);
        }


        public string Names
        {
            get { return Name; }
            set { Name = value; }
        }

        public string Surnames
        {
            get { return Surname; }
            set { Surname = value; }
        }

        public DateTime DateOfBirths
        {
            get { return DateOfBirth; }
            set { DateOfBirths = value; }
        }


        public int ChangingDateOfBirth
        {
            get { return DateOfBirth.Year; }
            set { DateOfBirth = new DateTime(value, DateOfBirth.Month, DateOfBirth.Day); }
        }

        public override string ToString()
        {
            return Name + "" + Surname + "" + DateOfBirths.Date.ToString();
        }

        public string ToShortString()
        {
            return Name + "" + Surname;
        }
    }



    enum Education
    {
        Specialist,
        Вachelor,
        SecondEducation
    }


    class Exam
    {
        public string NameSubject { get; set; }
        public int Evaluation { get; set; }

        public System.DateTime ExamOfDate { get; set; }


        public Exam(string nameSubject, int evaluation, DateTime examOfDate)
        {
            this.NameSubject = nameSubject;
            this.Evaluation = evaluation;
            this.ExamOfDate = examOfDate;
        }


        public Exam()
        {
            this.NameSubject = "ru";
            this.Evaluation = 3;
            this.ExamOfDate = new DateTime(2022, 09, 27);
        }


        public override string ToString()
        {
            return NameSubject + "" + Evaluation + "" + ExamOfDate;
        }
    }


    class Student
    {
        private Person Person;
        private Education Education;
        private int Group;
        private readonly List<Exam> exams = new List<Exam>();


        public Student(Person person, Education education, int group)
        {
            this.Person = person;
            this.Education = education;
            this.Group = group;
        }

        public Student()
        {
            this.Person = new Person();
            this.Education = Education.Specialist;
            this.Group = 320;
        }


        public Person Persons
        {
            get { return Person; }
            set { Person = value; }
        }

        public Education Educations
        {
            get { return Education; }
            set { Education = value; }
        }

        public int Groups
        {
            get { return Group; }
            set { Group = value; }
        }

        public Exam[] Exams
        {
            get { return exams.ToArray(); }

        }

        public double AvgEvaluation
        {
            get { return exams.Count > 0 ? exams.Average(p => p.Evaluation) : 0; }
        }

        public bool this[Education index]
        {
            get { return this.Education == index; }
        }

        public void AddExams(params Exam[] exams)
        {
            this.exams.AddRange(exams);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Person, Education, Group, string.Join(",", exams));
        }

        public string ToShortString()
        {
            return string.Format("{0} {1} {2} {3:0.00}", Person, Education, Group, AvgEvaluation);
        }

    }

}



using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string endGrading = "";
            string studentName = "";
            string Grades = "";
            bool endStudentName = false;

            //Loop to enter multiple students' names
            while (endStudentName != true)
            {
                Console.WriteLine("Please enter a student's FULL NAME. Enter EXIT to quit application.");
                studentName = (Console.ReadLine());
                if (studentName.ToUpper() != "EXIT")
                {
                    endStudentName = false;
                    endGrading = "CONTINUE";
                    //Try-Catch for error handling. Runs continuously if valid statement not entered.
                    try
                    {
                        gradeBook.Add(studentName, new Stack<double>());
                    }
                    catch
                    {
                        Console.WriteLine("Error. Student's name is already in the grade book. Either include a middle name or the student's ID number also.");
                        endGrading = "STOP";
                    }
                    //Loop to enter multiple grades for students
                    while (endGrading == "CONTINUE")
                    {
                        Console.WriteLine("Enter in the student's GRADES. Enter DONE if finished grading current student. Enter REVIEW to review full summary.");
                        Grades = Console.ReadLine();

                        endGrading = Grading(studentName, Grades);
                    }
                }
                else
                {
                    endStudentName = true;
                }
            }
        }

        //gradeBook Dictionary 
        public static Dictionary<string, Stack<double>> gradeBook = new Dictionary<string, Stack<double>>();

        //Grading Method
        public static string Grading(string studentName, string Grades)
        {
            if (Grades.ToUpper() != "DONE" && Grades.ToUpper() != "REVIEW")
            {
                //Try-Catch for Error handling
                try
                {
                    gradeBook[studentName].Push(Convert.ToDouble(Grades));
                }
                catch
                {
                    Console.WriteLine("Error. Please enter a valid numerical grade! If You want to review the Grade Book, enter REVIEW. If you are finished grading, enter DONE.");
                }
            }
            //For Reviewing the gradebook
            else if (Grades.ToUpper() == "REVIEW")
            {

                //Find Min grade, Max grade, AVG grade
                foreach (var indiv in gradeBook)
                {
                    Console.WriteLine("Student Name: " + indiv.Key);
                    Console.WriteLine("Avg: " + indiv.Value.Average());
                    Console.WriteLine("Min: " + indiv.Value.Min());
                    Console.WriteLine("Max: " + indiv.Value.Max());
                }
            }
            else return "STOP";
            return "CONTINUE";
        }
    }
}


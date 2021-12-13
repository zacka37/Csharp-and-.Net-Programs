using System;
using System.Collections.Generic;
using System.Linq;
namespace GradeConverter2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /* Write a program that converts number scores into the correct 
            letter grade, e.g. 88 = "B", and 76 = "C". 
            The program will also produce statistics for the grades. */

            // Var's
            bool do_agian = true;
            string firstName;
            string lastName;
            float numberOfGrades;

            // User name
            Console.WriteLine("Enter your first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            lastName = Console.ReadLine();

            // User welcome message
            Console.WriteLine($"Hello {firstName} {lastName} Welcome to the Code Converter!");

            // loop (Do you want to convert more grades (y/n))
            while(do_agian)
            {

                //  Create list (float) corisponding to number of grades
                List<float> gradesList = new List<float>();
                // Enter a number of grades they need to convert 
                
                while(true) {
                    try
                    {
                        Console.WriteLine("Enter the number of grades you need to convert!: ");
                        numberOfGrades = float.Parse(Console.ReadLine());
                    
                        for (float grades = 1; grades <= numberOfGrades; grades++) {
                            // Ask user for the grade value (float)
                            Console.WriteLine("Enter a grade: ");
                            float userGradeValue = float.Parse(Console.ReadLine());
                            // Store user grades in list
                            gradesList.Add(userGradeValue);
                            continue;
                        }
                        break;
                    }catch (Exception)
                    {
                        Console.WriteLine("Enter a number");
                    }
                }

                
                

                // add all grades up and divide by number of grades
                float addAllGrades = gradesList.AsQueryable().Sum();
                float averageGrade = (addAllGrades / numberOfGrades);
                // Convert number grades to letter grades
                string grade = "F";
                if (averageGrade < 60) {
                    
                    grade = "F";
                }
                else if (averageGrade >= 60 && averageGrade <= 69) {
                    grade = "D";
                }
                else if (averageGrade >= 70 && averageGrade <= 79) {
                    grade = "C";
                }
                else if (averageGrade >= 80 && averageGrade <= 89) {
                    grade = "B";
                }
                else if (averageGrade >= 90 && averageGrade >= 100) {
                    grade = "A";
                }
                
                
                
                /* Grade Statistics
                --------------------------
                Number of grades: 10
                Average Grade: 81, which is a B 
                */
                Console.WriteLine("\nGrade Statistics\n--------------------");
                Console.WriteLine($"Number of grades: {numberOfGrades}");
                Console.WriteLine($"Average Grade: {averageGrade} which is a {grade}");
                Console.WriteLine("\nDo you want to convert more grades? (y/n): ");
                string userLoop = Console.ReadLine();
                if (userLoop != "y" && userLoop != "Y")
                {
                    do_agian = false;
                }
            }
        }    
    }
}


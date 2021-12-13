using System;
using System.Collections.Generic;

namespace GradeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doAgain = true;
            float averageScore;
            string moreConversions;
            int numberOfGrades;
            //Ask the user to enter their first and last name
            string userName = getName();


            //Print a welcome message: "Hello [first name] [last name] Welcome to the Grade Converter!"
            Console.WriteLine($"\nHello {userName}! Welcome to the Grade Converter!");
            
            while(doAgain){
                
                List<float> scores = new List<float>();

                //Prompt the user to enter the number of grades they need to convert "Enter the number of grades you need to convert: "
                numberOfGrades = getNumberOfGrades();

                //Prompt the user to enter the grades. The grades should be stored in a list and you should use the appropriate data type for the grades. 
                scores = populateGradesList(scores,numberOfGrades);

                // Print grade report

                printGradeReport(scores);

                Console.WriteLine("\nGrade Statistics\n-------------------------\n");               
                averageScore = getAverageGrade(scores, numberOfGrades);
                printGradeStatistics(numberOfGrades, averageScore, scores);
                
                Console.WriteLine("Would you like to convert more grades (y/n)?");
                moreConversions = Console.ReadLine();
                
                

                if (moreConversions != "y" && moreConversions != "Y"){
                    doAgain = false;
                }
            }
        }
        
        
        static void printGradeReport(List<float> scoresList)
        {
            string letterGrade;
            Console.WriteLine();
            foreach(float testScore in scoresList)
            {    
                //Convert the number grades to letter grades (A = 90-100, B = 80-89, C = 70-79, D = 60 - 69, F lower than 60)
                letterGrade = getLetterGrade(testScore);
                //Print all the numerical grades and their corresponding letter grades to the console 
                Console.WriteLine($"A score of {testScore} is a {letterGrade} grade");  
            }
            return;
        }
        static List<float> populateGradesList(List<float> listOfScores, int numberOfGrades) {
            float score;
            for(int counter = 0; counter < numberOfGrades; counter ++){
                score = getScores();
                listOfScores.Add(score);
            }
            return listOfScores;
        }

        static int getNumberOfGrades() {
            //Prompt the user to enter the number of grades they need to convert "Enter the number of grades you need to convert: "
            int numberOfGrades;
            while (true)
            {
                Console.WriteLine("\nEnter the number of grades you need to convert:");
                try{
                    numberOfGrades = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter a whole number");
                }
            }
            return numberOfGrades;
        }     
        static string getName() {
            //Ask the user to enter their first and last name
            Console.WriteLine("Please enter your first name and last name");
            string userName = Console.ReadLine();
            return userName;
        }
        static float getScores()
        {
            float grade;
            while(true)
            {
                Console.WriteLine("\nEnter the score to be converted: ");
                try
                {
                    grade = float.Parse(Console.ReadLine());
                    break;  
                }
                catch(FormatException)
                {
                    Console.WriteLine("Error: Only numbers allowed");
                }
            }  
            return grade;
        }

        static string getLetterGrade(float score){
            //(A = 90-100, B = 80-89, C = 70-79, D = 60 - 69, F lower than 60).
            if (score >= 90)
            {
                return "A";
            }
            else if(score >= 80)
            {
                return "B";
            }
            else if (score >= 70)
            {
                return "C";
            }
            else if(score >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }
        }
        static float getAverageGrade(List<float> scoresList, int numberOfGrades) {
            float total = 0;
            float average;
            
            foreach (float grade in scoresList) {
                total = grade + total;    
            }
            average = total / numberOfGrades;
            return average;
        }
        
        static float getMaxumumGrade(List<float> scoresList) {
            float max = scoresList[0];
            
            foreach (float grade in scoresList) {
                if (grade >  max) {
                    max = grade;
                }
            }return max;
        }

        static float getMinimumGrade(List<float> scoresList) {
            float min = scoresList[0];
            
            foreach (float grade in scoresList) {
                if (grade < min) {
                    min = grade;
                }
            } return min;
        }

        static void printGradeStatistics(int numberOfGrades, float averageScore, List<float> scores){
            //averageScore = totalScore / numberOfGrades; 
                Console.WriteLine($"Number of grades: {numberOfGrades}");
                Console.WriteLine($"Average Grade: {averageScore} which is a {getLetterGrade(averageScore)}");
                // Max grade in list
                Console.WriteLine($"The maxumum grade is {getMaxumumGrade(scores)}");
                // Min grade in list
                Console.WriteLine($"The Minumum grade is {getMinimumGrade(scores)}");
            
        // float averageScore = getAverageGrade(scores, numberOfGrades);

        }

        
    }
}

using System;

namespace ImprovedObjectPosCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print welcome message
            Console.WriteLine("This program calculates an object's final position.");
            // Create book var for exit condition
            bool do_calculation = true;
            float initial_position;
            float initial_volocity;
            float initial_acceleration;
            float time_elasped;
            // Create loop to run program in
            while(do_calculation) {
                // Prompt user for initial position, velocity, acceleration, elasped time
                // Error check values, elasped time has to be < 0
                while(true) {
                    try {
                        Console.WriteLine("Enter the object's initial position: ");
                        initial_position = float.Parse(Console.ReadLine()); 
                        break;
                    } catch(Exception) {
                        Console.WriteLine ("Invalid Value. Only numerical values are valid");
                    }    
                }

                while(true) {
                    try {
                        Console.WriteLine("Enter the object's initial velocity: ");
                        initial_volocity = float.Parse(Console.ReadLine()); 
                        break;
                    } catch(Exception) {
                        Console.WriteLine ("Invalid Value. Only numerical values are valid");
                    }    
                }

                while(true) {
                    try {
                        Console.WriteLine("Enter the object's initial acceleration: ");
                        initial_acceleration = float.Parse(Console.ReadLine()); 
                        break;
                    } catch(Exception) {
                        Console.WriteLine ("Invalid Value. Only numerical values are valid");
                    }    
                }

                while(true) {
                    try {
                        Console.WriteLine("Enter the time that has elasped: ");
                        time_elasped = float.Parse(Console.ReadLine()); 
                        if(time_elasped < 0) {
                            Console.WriteLine("Values must be 0 or greater");
                            continue;
                        }
                        break;
                    } catch(Exception) {
                        Console.WriteLine ("Invalid Value. Only numerical values are valid");
                    }    
                }
                // Calculate final position
                double final_position = initial_position + initial_volocity * time_elasped + 0.5 * initial_acceleration * time_elasped * time_elasped;
                Console.WriteLine("\nThe final position is: " + final_position);
                // Output final position
                // Ask user if they want to continue
                Console.WriteLine("\nDo you want to preform another calculation? (y/n): ");
                // get user input for continue
                string another_calculation = Console.ReadLine();
                if (another_calculation != "y" && another_calculation != "Y") {
                    do_calculation = false;
                }
            }
                        
        }
    }
}

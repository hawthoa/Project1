/*
 The following is a program that collects information about a chemical and associated rating, 
 calculates and outputs an overall rating as per the Task Description.
 * Author: Joshua Pujol
 * Date: 26/8/2016
 * SID: 216189236
 */

/*
 * Part 3 Tasks
-Your program should display appropriate informative prompts, retrieve the data from the keyboard and check the data is valid then store each entry to be used to display output or used to calculate the overall rating
-Where an error is detected in the data entry process, display an appropriate message then re-prompt the user to enter the data again
-You need to ensure that the option ' Get chemical ratings (r) ' is not executed if the chemical details (m) have not been entered
-You need to ensure that the option 'Calculate and display (c)' is not executed if the chemical details and ratings (r) have not been entered
-Use a for loop to write the '*' character to the screen
-Ensure you place a comment at the top of the program that contains your full name and student number
-Place comments in your code as required and ensure you layout your code appropriately */
using System;
class Program
{
    static void Main()
    {
        //Puts the entire project in a boolean function for the exit function at the end of the program.

        // Declare constants
        bool returnValue = false;
        bool validData = false;
        bool userContinue = true;
        const ushort OUTOF = 10;
        const string Output = "Your Chemical Output Data";
        string menuChoice = "";
        // Rating %
        const float TOXIC_PERCENT = 0.20F;
        const float FLAMMABILE_PERCENT = 0.20F;
        const float CORROSIVE_PERCENT = 0.145F;
        const float EXPLOSIVE_PERCENT = 0.30F;
        const float HARMFUL_PERCENT = 0.145F;
        // Declare variables
        string Name = "";
        string Supplier = "";
        float Quantity = 0.0F;
        float Cost = 0.0F;
        int Year = 0;
        //Ratings
        int Toxicity = -1;
        int Flammability = -1;
        int Corrosiveness = -1;
        int Explosive = -1;
        int Harmful = -1;
        // Calcuation and temp variables       
        float Rating = 0.0F;
        int RatingRounded = 0;
        string Stars = "";
        string tempStr = "";

        //Puts entire program in a boolean function when corrosponding switch parameters is met (x) program will exit.
        while (userContinue == true)
        {
            //Display menu
            Console.WriteLine("{0,0}{1}", "", new string('*', 42));
            Console.WriteLine("Enter Chemical Details (m) ");
            Console.WriteLine("Enter Chemical Rating (b) ");
            Console.WriteLine("Calculate and Display (c) ");
            Console.WriteLine("Exit (x) ");
            Console.Write("Enter your choice >");
            menuChoice = Console.ReadLine();
            // Process the choice
            switch (menuChoice)
            {
                case "m":
                case "M":
                    // Collect data
                    Console.Clear();
                    Console.WriteLine("{0,0}{1}", "", new string('*', 42));
                    Console.WriteLine("Enter the following chemical details");
                    Console.WriteLine("{0,0}{1}", "", new string('*', 42));

                    // Puts code in a boolean dowhile function that is default to true, if it means the if statement parameters, will display error, set bool variable "validData" to false which repeats while function until correct.
                    do
                    {
                        validData = true;
                        Console.Write("Chemical Name > ");
                        Name = Console.ReadLine();
                        if (Name.Length == 0)
                        //Checks to see if the string contains data, if it's length = 0 program executes code within if statement prompting the user the reason for error.
                        {
                            Console.WriteLine("Error : the chemical name must contain characters.\nTry again!");
                            validData = false;
                        }
                    } while (validData == false);


                    do
                    {
                        validData = true;
                        Console.Write("Year released (2010-2016) > ");
                        tempStr = Console.ReadLine();
                        returnValue = int.TryParse(tempStr, out Year);
                        if (returnValue == false)
                        //Checks the returnVale, if it is not a valid integer, it executes the if statement below.
                        {
                            Console.WriteLine("Error : year must be a valid integer.\nTry again!");
                            validData = false;
                        }
                        if (validData == true && (Year < 2010 || Year > 2016))
                        //Checks the year variable to make sure it is between 2010 and 2016
                        {
                            Console.WriteLine("Error : Year must be between 2010 and 2016.\nTry again!");
                            validData = false;
                        }
                    } while (validData == false);


                    do
                    {
                        validData = true;
                        Console.Write("Supplier > ");
                        Supplier = Console.ReadLine();
                        if (Supplier.Length == 0)
                        //Checks to see if the string contains data, if it's length = 0 program executes code within if statement prompting the user the reason for error.
                        {
                            Console.WriteLine("Error : the supplier name must contain Characters.\nTry again!");
                            validData = false;
                        }
                    } while (validData == false);


                    do
                    {
                        validData = true;
                        Console.Write("Quantity (L/Kg) > ");
                        tempStr = Console.ReadLine();
                        returnValue = float.TryParse(tempStr, out Quantity);
                        if (returnValue == false)
                        //Checks the returnVale, if it is not a valid float, it executes the if statement below.
                        {
                            Console.WriteLine("Error : year must be a valid decimal number.\nTry again!");
                            validData = false;
                        }
                        if (validData == true && Quantity <= 0)
                        //Checks the quantity to make sure it is not a negative number, if it is program executes code below.
                        {
                            Console.WriteLine("Error : Quantity must be greater than zero.\nTry again!");
                            validData = false;
                        }
                    } while (validData == false);

                    do
                    {
                        validData = true;
                        Console.Write("Cost ($) > ");
                        tempStr = Console.ReadLine();
                        returnValue = float.TryParse(tempStr, out Cost);
                        if (returnValue == false)
                        //Checks the returnVale, if it is not a valid float, it executes the if statement below.
                        {
                            Console.WriteLine("Error : Cost must be a valid decimal number (Do not enter dollar sign ($)).\nTry again!");
                            validData = false;
                        }
                        if (validData == true && Cost <= 0)
                        //Checks the cost to make sure it is not a negative number, if it is program executes code below.
                        {
                            Console.WriteLine("Error : Cost must be greater than zero.\nTry again!");
                            validData = false;
                        }
                    } while (validData == false);
                    break;

                case "b":
                case "B":
                    if (Name.Length > 0)
                    {
                        //Clears console and prompts for chemical ratings. 
                        Console.Clear();
                        Console.WriteLine("{0,0}{1}", "", new string('*', 42));
                        Console.WriteLine("Enter the following chemical rating");
                        Console.WriteLine("{0,0}{1}", "", new string('*', 42));


                        do
                        {
                            validData = true;
                            Console.Write("Toxicity > ");
                            tempStr = Console.ReadLine();
                            returnValue = int.TryParse(tempStr, out Toxicity);
                            if (returnValue == false)
                            // Checks for valid data type (same function for all ratings).
                            {
                                Console.WriteLine("Error : rating must be a valid integer.\nTry again!");
                                validData = false;
                            }
                            if (validData == true && (Toxicity < 0 || Toxicity > 10))
                            // Checks to ensure integer is between 0-10 (same function for all ratings).
                            {
                                Console.WriteLine("Error : Rating must be an integer between 0-10.\nTry again!");
                                validData = false;
                            }
                        } while (validData == false);

                        do
                        {
                            validData = true;
                            Console.Write("Flammability > ");
                            tempStr = Console.ReadLine();
                            returnValue = int.TryParse(tempStr, out Flammability);
                            if (returnValue == false)
                            {
                                Console.WriteLine("Error : rating must be a valid integer.\nTry again!");
                                validData = false;
                            }
                            if (validData == true && (Flammability < 0 || Flammability > 10))
                            {
                                Console.WriteLine("Error : Rating must be an integer between 0-10.\nTry again!");
                                validData = false;
                            }
                        } while (validData == false);

                        do
                        {
                            validData = true;
                            Console.Write("Corrosiveness > ");
                            tempStr = Console.ReadLine();
                            returnValue = int.TryParse(tempStr, out Corrosiveness);
                            if (returnValue == false)
                            {
                                Console.WriteLine("Error : rating must be a valid integer.\nTry again!");
                                validData = false;
                            }
                            if (validData == true && (Corrosiveness < 0 || Corrosiveness > 10))
                            {
                                Console.WriteLine("Error : Rating must be an integer between 0-10.\nTry again!");
                                validData = false;
                            }
                        } while (validData == false);

                        do
                        {
                            validData = true;
                            Console.Write("Explosive > ");
                            tempStr = Console.ReadLine();
                            returnValue = int.TryParse(tempStr, out Explosive);
                            if (returnValue == false)
                            {
                                Console.WriteLine("Error : rating must be a valid integer.\nTry again!");
                                validData = false;
                            }
                            if (validData == true && (Explosive < 0 || Explosive > 10))
                            {
                                Console.WriteLine("Error : Rating must be an integer between 0-10.\nTry again!");
                                validData = false;
                            }
                        } while (validData == false);

                        do
                        {
                            validData = true;
                            Console.Write("Harmful > ");
                            tempStr = Console.ReadLine();
                            returnValue = int.TryParse(tempStr, out Harmful);
                            if (returnValue == false)
                            {
                                Console.WriteLine("Error : rating must be a valid integer.\nTry again!");
                                validData = false;
                            }
                            if (validData == true && (Harmful < 0 || Harmful > 10))
                            {
                                Console.WriteLine("Error : Rating must be an integer between 0-10.\nTry again!");
                                validData = false;
                            }
                        } while (validData == false);
                    }
                    else
                        Console.Clear();
                    Console.WriteLine("You must enter the chemicals details first!");
                    break;

                case "c":
                case "C":
                    if (Toxicity != -1)
                    {

                        // Calculate the Rating
                        Rating = Toxicity * TOXIC_PERCENT;
                        Rating = Rating + Flammability * FLAMMABILE_PERCENT;
                        Rating = Rating + Corrosiveness * CORROSIVE_PERCENT;
                        Rating = Rating + Explosive * EXPLOSIVE_PERCENT;
                        Rating = Rating + Harmful * HARMFUL_PERCENT;

                        // Covert the Rating to an int
                        // Round up the rating to ensure the rating is always expressed as the highest value
                        RatingRounded = (int)Math.Ceiling(Rating);

                        //Clears the console so user won't have to scroll, Makes it look much cleaner as an ouput.
                        Console.Clear();

                        //Output data.
                        Console.WriteLine("{0,0}{1}", "", new string('*', 42));
                        Console.WriteLine("\t{0}\n", Output);

                        Console.WriteLine("Chemical Name:               {0,8}", Name);
                        Console.WriteLine("Year Purchased:              {0,8}", Year);
                        Console.WriteLine("Supplier:                    {0,8}", Supplier);
                        Console.WriteLine("Quantity:                    {0,8} (L/Kg) ", Quantity);
                        Console.WriteLine("Cost:                        {0,8:C}", Cost);

                        Console.WriteLine("{0,0}{1}", "", new string('*', 42));

                        Console.WriteLine("Toxicity:                    {0,8}", Toxicity);
                        Console.WriteLine("Flammability:                {0,8}", Flammability);
                        Console.WriteLine("Corrosiveness:               {0,8}", Corrosiveness);
                        Console.WriteLine("Explosive:                   {0,8}", Explosive);
                        Console.WriteLine("Harmful:                     {0,8}", Harmful);

                        Console.WriteLine("{0,0}{1}", "", new string('*', 42));

                        //Creates amount of '*' respectable to the RatingRounded.
                        Stars = new string('*', RatingRounded);
                        Console.WriteLine("Overall rating is {0}/{1}: {2}", RatingRounded, OUTOF, Stars);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You must enter the chemicals details, and rating first!");
                    }
                    break;

                case "x":
                case "X":
                    userContinue = false;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Your choice is not in the menu. Please try again.");

                    break;

            }
        }
    }
}

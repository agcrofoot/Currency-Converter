using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS221_Starter_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starter Code
            //Menu
            Console.WriteLine("Welcome to the Menu. Please select one of the options.");
            Console.WriteLine("Convert Currencies, Restaurant POS, Exit");
            string option = Console.ReadLine();           
            switch (option)
            {
                case "Convert Currencies":
                Start:
                    Console.WriteLine("Would you like to convert to USD, or from USD?");
                    string convert = Console.ReadLine();
                    switch (convert)
                    {
                        case "to USD":
                            ConvertDollars();
                            break;
                        case "to":
                            ConvertDollars();
                            break;
                        case "to dollars":
                            ConvertDollars();
                            break;
                        case "convert to USD":
                            ConvertDollars();
                            break;
                        case "convert to dollars":
                            ConvertDollars();
                            break;
                        case "from USD":
                            ConvertForeign();
                            break;
                        case "from":
                            ConvertForeign();
                            break;
                        case "from dollars":
                            ConvertForeign();
                            break;
                        case "convert from USD":
                            ConvertForeign();
                            break;
                        case "convert from dollars":
                            ConvertForeign();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid response.");
                            goto Start;      
                    }
                    break;


                case "Restaurant POS":
                    //Variables
                    double foodTotal = 0.00;
                    double alcoholTotal = 0.00;
                    double mealTotal = 0.00;
                    double mealTax = 0.00;
                    double nonAlcoholTip = 0.00;
                    double totalAmount = 0.00;
                    double paymentAmount = 0.00;
                    double changeAmount = 0.00;
                    Console.WriteLine("Please enter the total cost of your food.");
                    foodTotal = double.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter the total cost of any alcohol.");
                    alcoholTotal = double.Parse(Console.ReadLine());
                    mealTotal = foodTotal + alcoholTotal;
                    mealTax = .09 * mealTotal + mealTotal;
                    nonAlcoholTip = .18 * foodTotal;
                    totalAmount = mealTax + nonAlcoholTip;
                    Console.WriteLine("Your bill is " + string.Format("{0:0.00}", totalAmount) + ".");
                    Console.WriteLine("Please enter your payment amount.");
                    paymentAmount = double.Parse(Console.ReadLine());
                    if (paymentAmount < totalAmount)
                    {
                        Console.WriteLine("You did not pay enough to cover your bill.");
                       
                    }
                    if (paymentAmount > totalAmount)
                    {
                        changeAmount = paymentAmount - totalAmount;
                        Console.WriteLine("Your change is " + string.Format("{0:0.00}", changeAmount) + ".");
                    }
                    break;
                case "Exit":
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    Console.ReadKey();
                    break;
            }        
            Console.ReadKey();
        }

        //Methods
        static void ConvertDollars()
        {
            Start:
            Console.WriteLine("Are you converting from Canadian Dollars, Euros, Indian Rupees, Japanese Yen, Mexican Pesos, or British Pounds?");
            string foreign = Console.ReadLine();
            switch (foreign)
            {
                case "Canadian Dollars":
                    Console.WriteLine("Please enter the amount.");
                    double canAmount = 0.0;
                    canAmount = double.Parse(Console.ReadLine());
                    double convertCanAmount = canAmount * .9813;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertCanAmount) + " USD.");
                    Console.ReadKey();
                    break;
                case "Euros":
                    Console.WriteLine("Please enter the amount.");
                    double eurAmount = 0.0;
                    eurAmount = double.Parse(Console.ReadLine());
                    double convertEurAmount = eurAmount * .757;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertEurAmount) + " USD.");
                    Console.ReadKey();
                    break;
                case "Indian Rupees":
                    Console.WriteLine("Please enter the amount.");
                    double indAmount = 0.0;
                    indAmount = double.Parse(Console.ReadLine());
                    double convertIndAmount = indAmount * 52.53;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertIndAmount) + " USD.");
                    Console.ReadKey();
                    break;
                case "Japanese Yen":
                    Console.WriteLine("Please enter the amount.");
                    double japAmount = 0.0;
                    japAmount = double.Parse(Console.ReadLine());
                    double convertJapAmount = japAmount * 80.92;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertJapAmount) + " USD.");
                    Console.ReadKey();
                    break;
                case "Mexican Pesos":
                    Console.WriteLine("Please enter the amount.");
                    double mexAmount = 0.0;
                    mexAmount = double.Parse(Console.ReadLine());
                    double convertMexAmount = mexAmount * 13.1544;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertMexAmount) + " USD.");
                    Console.ReadKey();
                    break;
                case "British Pounds":
                    Console.WriteLine("Please enter the amount.");
                    double britAmount = 0.0;
                    britAmount = double.Parse(Console.ReadLine());
                    double convertBritAmount = britAmount * .6178;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertBritAmount) + " USD.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please enter a valid response.");
                    goto Start;
            }
        }

        static void ConvertForeign()
        {
            Start:
            Console.WriteLine("Are you converting to Canadian Dollars, Euros, Indian Rupees, Japanese Yen, Mexican Pesos, or British Pounds?");
            string dollars = Console.ReadLine();
            switch (dollars)
            {
                case "Canadian Dollars":
                    Console.WriteLine("Please enter the amount.");
                    double canAmount = 0.0;
                    canAmount = double.Parse(Console.ReadLine());
                    double convertCanAmount = canAmount / .9813;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertCanAmount) + " Canadian Dollars.");
                    Console.ReadKey();
                    break;
                case "Euros":
                    Console.WriteLine("Please enter the amount.");
                    double eurAmount = 0.0;
                    eurAmount = double.Parse(Console.ReadLine());
                    double convertEurAmount = eurAmount / .757;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertEurAmount) + " Euros.");
                    Console.ReadKey();
                    break;
                case "Indian Rupees":
                    Console.WriteLine("Please enter the amount.");
                    double indAmount = 0.0;
                    indAmount = double.Parse(Console.ReadLine());
                    double convertIndAmount = indAmount / 52.53;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertIndAmount) + " Indian Rupees.");
                    Console.ReadKey();
                    break;
                case "Japanese Yen":
                    Console.WriteLine("Please enter the amount.");
                    double japAmount = 0.0;
                    japAmount = double.Parse(Console.ReadLine());
                    double convertJapAmount = japAmount / 80.92;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertJapAmount) + " Japanese Yen.");
                    Console.ReadKey();
                    break;
                case "Mexican Pesos":
                    Console.WriteLine("Please enter the amount.");
                    double mexAmount = 0.0;
                    mexAmount = double.Parse(Console.ReadLine());
                    double convertMexAmount = mexAmount / 13.1544;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertMexAmount) + " Mexican Pesos.");
                    Console.ReadKey();
                    break;
                case "British Pounds":
                    Console.WriteLine("Please enter the amount.");
                    double britAmount = 0.0;
                    britAmount = double.Parse(Console.ReadLine());
                    double convertBritAmount = britAmount / .6178;
                    Console.WriteLine("You have " + string.Format("{0:0.00}", convertBritAmount) + " British Pounds.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please enter a valid response.");
                    goto Start;
            }
        }
    
    }
}
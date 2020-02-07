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

            //Constants
            double CAN_DOLLAR = .9813;
            double EURO = .757;
            double IND_RUPEE = 52.53;
            double JAP_YEN = 80.92;
            double MEX_PESO = 13.1544;
            double BRIT_POUND = .6178;

            //Menu
            WelcomeMenu();
        Menu:
            string option = MenuOptions();
            switch (option)
            {
                //Convert Currency
                case "Convert Currencies":
                Convert:
                    string conversion = GetConvert();
                    switch (conversion)
                    {
                        //Convert to USD
                        case "to":
                        ToUSD:
                            string foreign = ConvertPrompt("from");
                            switch (foreign)
                            {
                                case "Canadian Dollars":
                                    ConvertFromAmount(CAN_DOLLAR, " USD.");
                                    goto Menu;
                                case "Euros":
                                    ConvertFromAmount(EURO, " USD.");
                                    goto Menu;
                                case "Indian Rupees":
                                    ConvertFromAmount(IND_RUPEE, " USD.");
                                    goto Menu;
                                case "Japanese Yen":
                                    ConvertFromAmount(JAP_YEN, " USD.");
                                    goto Menu;
                                case "Mexican Pesos":
                                    ConvertFromAmount(MEX_PESO, " USD.");
                                    goto Menu;
                                case "British Pounds":
                                    ConvertFromAmount(BRIT_POUND, " USD.");
                                    goto Menu;
                                default:
                                    ErrorResponse();
                                    goto ToUSD;
                            }

                        //Convert from USD
                        case "from":
                        FromUSD:
                            string dollars = ConvertPrompt("to");
                            switch (dollars)
                            {
                                case "Canadian Dollars":
                                    ConvertToAmount(CAN_DOLLAR, " Canadian Dollars.");
                                    goto Menu;
                                case "Euros":
                                    ConvertToAmount(EURO, " Euros.");
                                    goto Menu;
                                case "Indian Rupees":
                                    ConvertToAmount(IND_RUPEE, " Indian Rupees.");
                                    goto Menu;
                                case "Japanese Yen":
                                    ConvertToAmount(JAP_YEN, " Japanese Yen.");
                                    goto Menu;
                                case "Mexican Pesos":
                                    ConvertToAmount(MEX_PESO, " Mexican Pesos.");
                                    goto Menu;
                                case "British Pounds":
                                    ConvertToAmount(BRIT_POUND, "British Pounds.");
                                    goto Menu;
                                default:
                                    ErrorResponse();
                                    goto FromUSD;
                            }
                        default:
                            ErrorResponse();
                            goto Convert;
                    }
                //Restaurant POS
                case "Restaurant POS":
                    double foodTotal = GetFoodTotal();
                    double alcoholTotal = GetAlcoholTotal();
                    double mealTotal = GetMealTotal(foodTotal, alcoholTotal);
                    double mealTax = GetMealTax(mealTotal);
                    double nonAlcoholTip = GetNonAlcoholTip(foodTotal);
                    double totalAmount = GetTotalAmount(mealTax, nonAlcoholTip, mealTotal);
                    GiveTotalBill(totalAmount);
                    double paymentAmount = GetPayment();
                    GiveChange(paymentAmount, totalAmount);
                    goto Menu;

                //Exit
                case "Exit":
                    Goodbye();
                    Console.ReadKey();
                    break;

                default:
                    ErrorResponse();
                    goto Menu;

            }

        }


        //Methods

        //Menu
        static void WelcomeMenu()
        {
            Console.WriteLine("Welcome to the Menu. Please select one of the options by typing it below.");
        }

        static string MenuOptions()
        {
            Console.WriteLine("Convert Currencies, Restaurant POS, Exit");
            return Console.ReadLine();
        }

        static void ErrorResponse()
        {
            Console.WriteLine("Please enter a valid response.");
        }

        //Convert Currency
        //Convert to Dollars
        static string GetConvert()
        {
            Console.WriteLine("Would you like to convert to USD (enter 'to'), or from USD? (enter 'from')");
            return Console.ReadLine();
        }
        static string ConvertPrompt(string customText)
        {
            Console.WriteLine("Are you converting " + customText + " Canadian Dollars, Euros, Indian Rupees, Japanese Yen, Mexican Pesos, or British Pounds?");
            return Console.ReadLine();
        }
        static void ConvertFromAmount(double exchangeRate, string customText)
        {
            Console.WriteLine("Please enter the amount.");
            double startAmount = double.Parse(Console.ReadLine());
            double endAmount = startAmount * exchangeRate;
            Console.WriteLine("You have " + string.Format("{0:0.00}", endAmount) + customText);
        }

        static void ConvertToAmount(double exchangeRate, string customText)
        {
            Console.WriteLine("Please enter the amount.");
            double startAmount = double.Parse(Console.ReadLine());
            double endAmount = startAmount / exchangeRate;
            Console.WriteLine("You have " + string.Format("{0:0.00}", endAmount) + customText);
        }

        
        //Restaurant POS
        static double GetFoodTotal()
        {
            Console.WriteLine("Please enter the total cost of your food.");
            return double.Parse(Console.ReadLine());
        }

        static double GetAlcoholTotal()
        {
            Console.WriteLine("Please enter the total cost of any alcohol.");
            return double.Parse(Console.ReadLine());
        }

        static double GetMealTotal(double foodTotal, double alcoholTotal)
        {
            double mealTotal = foodTotal + alcoholTotal;
            return mealTotal;
        }

        static double GetMealTax(double mealTotal)
        {
            double mealTax = .09 * mealTotal;
            return mealTax;
        }

        static double GetNonAlcoholTip(double foodTotal)
        {
            double nonAlcoholTip = .18 * foodTotal;
            return nonAlcoholTip;
        }

        static double GetTotalAmount(double mealTax, double nonAlcoholTip, double mealTotal)
        {
            double totalAmount = mealTax + nonAlcoholTip + mealTotal;
            return totalAmount;
        }

        static void GiveTotalBill(double totalAmount)
        {
            Console.WriteLine("Your bill is " + string.Format("{0:0.00}", totalAmount) + ".");
        }

        static double GetPayment()
        {
            Console.WriteLine("Please enter your payment amount.");
            return double.Parse(Console.ReadLine());
        }

        static void GiveChange(double paymentAmount, double totalAmount)
        {
            if (paymentAmount < totalAmount)
            {
                Console.WriteLine("You did not pay enough to cover your bill.");

            }
            if (paymentAmount > totalAmount)
            {
                double changeAmount = paymentAmount - totalAmount;
                Console.WriteLine("Your change is " + string.Format("{0:0.00}", changeAmount) + ".");
            }
    
        }

        static void Goodbye()
        {
            Console.WriteLine("Goodbye!");
            System.Environment.Exit(1);
        }
    
    }
}
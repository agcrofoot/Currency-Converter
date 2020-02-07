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
                case "1":
                Convert:
                    string conversion = GetConvert();
                    switch (conversion)
                    {
                        //Convert to USD
                        case "1":
                        ToUSD:
                            string foreign = ConvertPrompt("from");
                            switch (foreign)
                            {
                                //Canadian Dollars
                                case "1":
                                    ConvertFromAmount(CAN_DOLLAR, " USD.");
                                    goto Menu;
                                //Euros
                                case "2":
                                    ConvertFromAmount(EURO, " USD.");
                                    goto Menu;
                                //Indian Rupees
                                case "3":
                                    ConvertFromAmount(IND_RUPEE, " USD.");
                                    goto Menu;
                                //Japanese Yen
                                case "4":
                                    ConvertFromAmount(JAP_YEN, " USD.");
                                    goto Menu;
                                //Mexican Pesos
                                case "5":
                                    ConvertFromAmount(MEX_PESO, " USD.");
                                    goto Menu;
                                //British Pounds
                                case "6":
                                    ConvertFromAmount(BRIT_POUND, " USD.");
                                    goto Menu;
                                default:
                                    ErrorResponse();
                                    goto ToUSD;
                            }

                        //Convert from USD
                        case "2":
                        FromUSD:
                            string dollars = ConvertPrompt("to");
                            switch (dollars)
                            {
                                //Canadian Dollars
                                case "1":
                                    ConvertToAmount(CAN_DOLLAR, " Canadian Dollars.");
                                    goto Menu;
                                //Euros
                                case "2":
                                    ConvertToAmount(EURO, " Euros.");
                                    goto Menu;
                                //Indian Rupees
                                case "3":
                                    ConvertToAmount(IND_RUPEE, " Indian Rupees.");
                                    goto Menu;
                                //Japanese Yen
                                case "4":
                                    ConvertToAmount(JAP_YEN, " Japanese Yen.");
                                    goto Menu;
                                //Mexican Pesos
                                case "5":
                                    ConvertToAmount(MEX_PESO, " Mexican Pesos.");
                                    goto Menu;
                                //British Pounds
                                case "6":
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
                case "2":
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
                case "3":
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
            Console.WriteLine("Welcome to the Menu. Please select the application you wish to use.");
        }

        static string MenuOptions()
        {
            Console.WriteLine("For Converting Currency, please type '1'. For Restaurant POS, please type '2'. To Exit the program, type '3'.");
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
            Console.WriteLine("To convert to USD from another currency, please type '1'. To convert to a foreign currency from USD, please type '2'.");
            return Console.ReadLine();
        }
        static string ConvertPrompt(string customText)
        {
            Console.WriteLine("If you would like to convert " + customText + " Canadian Dollars, type '1'. Euros, type '2'. Indian Rupees, type '3'. Japanese Yen, type '4'. Mexican Pesos, type '5'. Or British Pounds, type '6'.");
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
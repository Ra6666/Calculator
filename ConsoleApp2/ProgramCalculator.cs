using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Calculator
{
    class Program
    {

        static void Main()//
        {
            double number_one_double = 0;
            double number_two_double = 0;
            double result = 0;
            char operand = '0';
            bool repeat = true;
            string instructions = "Welcome to calculator. Please enter what you need to calculate. Sample 2+3 and press Enter";
            string number_one_string;
            string number_two_string;

            while (repeat)
            {
                Console.WriteLine(instructions);
                string input = Console.ReadLine();
                Console.SetCursorPosition(input.Length, Console.CursorTop - 1);

                char char_index;
                for (int index=0; index<=input.Length; index++)
                {
                    char_index = input[index];
                    if (char_index == '+' || char_index == '-' || char_index == '*' || char_index == '/')
                    {
                        operand = char_index;
                        number_one_string = input.Remove(index, input.Length - index);
                        number_two_string = input.Remove(0, index + 1);
                        index = input.Length;
                        try
                        {
                            number_one_double = double.Parse(number_one_string, System.Globalization.CultureInfo.InvariantCulture);
                            number_two_double = double.Parse(number_two_string, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Input string is not a sequence of digits");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("The number cannot fit in double");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Input string is not a sequence of digits");
                        }

                    }  
                    else 
                    {
                       
                    }
                }

                switch (operand)
                {
                    case '0':
                        break;
                    case '+':
                        result = number_one_double + number_two_double;
                        break;
                    case '-':
                        result = number_one_double - number_two_double;
                        break;
                    case '/':
                        result = number_one_double / number_two_double;
                        break;
                    case '*':
                        result = number_one_double * number_two_double;
                        break;
                    default:
                        throw new InvalidOperationException("Unknown item type");
                }

                Console.Write("=");
                Console.WriteLine(result);
                Console.WriteLine("Go again? Y/N");
                string go = Console.ReadLine();
                if (go == "Y" || go == "y")
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            }


        }
    }
}

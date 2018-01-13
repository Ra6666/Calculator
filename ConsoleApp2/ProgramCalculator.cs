using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Console_Calculator
{
    class Program
    {

        static void Main()
        {
            double number_one_double = 0; 
            double number_two_double = 0;
            double result = 0;
            char operand = '0';
            bool repeat = true;
            int input_control = 0;
            string instructions = "Welcome to calculator. Please enter what you need to calculate. Sample 2+3 and press Enter";
            string number_one_string;
            string number_two_string;
            string list_of_allowed = "1234567890.+-*/"; // ? how do i need to use 'new' here?


            // While repeat is true we go in sircles asking to continue
            while (repeat)
            {
                Console.WriteLine(instructions);
                string input = Console.ReadLine();
                Console.SetCursorPosition(input.Length, Console.CursorTop - 1);

                // Checking  if the inout string contains only allowed symbols
                input_control = 0;
                result = 0;
                for (int index = 0; index <= input.Length-1; index++) 
                {
                    for (int jindex=0; jindex<= list_of_allowed.Length-1; jindex++)
                    {
                        if (input[index] == list_of_allowed[jindex])
                        {
                            input_control++;
                        }
                        
                    }
                }
                if (input_control != input.Length)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input Error. Please type carefully!");
                    goto Again;
                }

                char char_index;

                // spil the string before and after operation sign and try to cast the parts to double.
                // starting from the 1st symbol because of possibility of negative value
                for (int index=1; index<=input.Length; index++)
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
                            goto Again;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("The number cannot fit in double");
                            goto Again;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Input string is not a sequence of digits");
                            goto Again;
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
                        Console.Write("=");
                        Console.WriteLine(result);
                        break;
                    case '-':
                        result = number_one_double - number_two_double;
                        Console.Write("=");
                        Console.WriteLine(result);
                        break;
                    case '/':
                        result = number_one_double / number_two_double;
                        Console.Write("=");
                        Console.WriteLine(result);
                        break;
                    case '*':
                        result = number_one_double * number_two_double;
                        Console.Write("=");
                        Console.WriteLine(result);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown item type");
                }

                
                Again:
                Console.WriteLine("Go again? Y/N");
                string go = Console.ReadLine();
                if (go == "Y" || go == "y")
                {
                    repeat = true;
                }
                else if (go == "N" || go == "n")
                {
                    repeat = false;
                }
                else
                {
                    goto Again;
                }
            }


        }
    }
}

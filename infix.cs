using System.Collections;
namespace ConsoleApp3;

public static class SampleStack
{
    public static void Main()
    {
        var stack = new Stack();
        var output = "";

        int Precedence(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }

            return -1;
        }

        string? InfixConverter(string data)
        {

            // Getting rid of spaces in the string
            var trim = data.Replace(" ", "");

            foreach (var t in trim)
            {
                if (!char.IsLetterOrDigit(t))
                {
                    switch (t)
                    {
                        // We put it to the stack, 'cause later we'll need to find it, in order to
                        // add elements to the output

                        case '(':
                        {
                            stack?.Push(t);
                            break;
                        }
                        case ')':
                        {
                            // Loop that delete last elements from the stack and put it to the output,
                            // until ")" is found

                            while (stack is {Count: > 0} && (char) stack.Peek()! != '(')
                            {
                                output += stack.Pop();
                            }

                            stack?.Pop();
                            break;
                        }
                        default:
                        {
                            // Algo for checking operators priority 
                            while (stack is {Count: > 0} && Precedence(t) <= Precedence((char) stack.Peek()!))
                            {
                                output += stack.Pop();
                            }

                            stack?.Push(t);
                            break;
                        }
                    }
                }

                // If char is a digit - put it to the output
                else
                {
                    output += t;
                }
            }

            // Adding remaining values to the output
            while (stack is {Count: > 0})
            {
                output += stack.Pop();
            }

            return output;
        }

        // Usage of the function
        var converted = InfixConverter("5 * 1 - 8 / 7 + 1");
        Console.WriteLine(converted);

        // Count the result of the expression
        var s = new Stack();
        var operation = "";
        var num1 = "";
        var num2 = "";
        string? Result(string expression)
        {
            var output = "";
            foreach (var t in expression)
            {
                if (char.IsLetterOrDigit(t))
                {
                    s.Push(t);
                }
                else
                {
                    num1 += s.Pop();
                    num2 += s.Pop();
                    // need to make calculations with an operator
                    operation  = num1 + t + num2;
                    bool success = int.TryParse(operation, out _);
                    if (success)
                    {
                        s.Push(operation);
                    }
                    else
                    {
                        Console.WriteLine($"Attempted conversion of '{operation}' failed.");
                    }
                }
            }
            output += s.Pop();
            return output;
        }
        
        var calculated = Result(converted);
        Console.WriteLine(calculated);
    }
}
 
        
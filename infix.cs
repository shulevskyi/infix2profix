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

        string? InfixToPostfix(string data)
        {
            
            var trim = data.Replace(" ", "");

            foreach (var t in trim)
            {
                if (!char.IsLetterOrDigit(t))
                {
                    switch (t)
                    {
                        case '(':
                        {
                            stack?.Push(t);
                            break;
                        }
                        case ')':
                        {
                            while (stack is {Count: > 0} && (char) stack.Peek()! != '(')
                            {
                                output += stack.Pop();
                            }

                            stack?.Pop();
                            break;
                        }
                        default:
                        {
                            while (stack is {Count: > 0} && Precedence(t) <= Precedence((char) stack.Peek()!))
                            {
                                output += stack.Pop();
                            }

                            stack?.Push(t);
                            break;
                        }
                    }
                }
                else
                {
                    output += t;
                }
            }

            while (stack is {Count: > 0})
            {
                output += stack.Pop();
            }

            return output;
        }

        Console.WriteLine(InfixToPostfix("5 * (10 - 8) / 7 + 1"));
    }
    
}

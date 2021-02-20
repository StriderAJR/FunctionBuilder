using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionBuilder.Logic
{
    public class Function
    {
        ReversePolishNotation rpn = new ReversePolishNotation();
        private object[] reversePolishNotation;

        public Function(string expression)
        {
            reversePolishNotation = rpn.Parse(expression);
        }

        public double Calculate()
        {
            if (reversePolishNotation == null || reversePolishNotation.Length == 0)
            {
                throw new Exception("¬ыражение еще не было обработано.");
            }

            Stack<double> numbers = new Stack<double>(); // можно и без стека, а бегать назад по массиву, но так мне нравитс€ больше
            // пробегаем по всем токенам в ќѕ«
            foreach (var token in reversePolishNotation)
            {
                if (token is double) 
                {
                    // если число - сохран€ем в стек дл€ дальнейшего использовани€
                    numbers.Push((double)token);
                }
                else 
                {
                    // если операци€...
                    var operation = (Operation) token;
                    var args = new double[operation.OperandCount];
                    // извлекаем из стека чисел столько раз, сколько аргументов у данной операции
                    // причем помним, что числа в стеке лежат в обратном пор€дке - их нужно развернуть
                    for(int i = operation.OperandCount; i > 0; i--)
                    {
                        args[i-1] = numbers.Pop(); 
                    }
                    var subResult = operation.Evaluate(args);
                    // кладем результат обратно в стек чисел
                    numbers.Push(subResult);
                }
            }
            // т.к. мы уверены, что наша ќѕ« корректна, то в принципе, когда дошли до конца записи,
            // последнее число в стеке - наш итоговый результат

            return numbers.Pop();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (object token in reversePolishNotation)
            {
                sb.Append(token.ToString());
                sb.Append(" ");
            }

            sb.Remove(sb.Length-1, 1);
            return sb.ToString();
        }
    }
}
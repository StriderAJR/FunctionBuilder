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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (object token in reversePolishNotation)
            {
                sb.Append(token.ToString());
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }
}
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
                throw new Exception("��������� ��� �� ���� ����������.");
            }

            Stack<double> numbers = new Stack<double>(); // ����� � ��� �����, � ������ ����� �� �������, �� ��� ��� �������� ������
            // ��������� �� ���� ������� � ���
            foreach (var token in reversePolishNotation)
            {
                if (token is double) 
                {
                    // ���� ����� - ��������� � ���� ��� ����������� �������������
                    numbers.Push((double)token);
                }
                else 
                {
                    // ���� ��������...
                    var operation = (Operation) token;
                    var args = new double[operation.OperandCount];
                    // ��������� �� ����� ����� ������� ���, ������� ���������� � ������ ��������
                    // ������ ������, ��� ����� � ����� ����� � �������� ������� - �� ����� ����������
                    for(int i = operation.OperandCount; i > 0; i--)
                    {
                        args[i-1] = numbers.Pop(); 
                    }
                    var subResult = operation.Evaluate(args);
                    // ������ ��������� ������� � ���� �����
                    numbers.Push(subResult);
                }
            }
            // �.�. �� �������, ��� ���� ��� ���������, �� � ��������, ����� ����� �� ����� ������,
            // ��������� ����� � ����� - ��� �������� ���������

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
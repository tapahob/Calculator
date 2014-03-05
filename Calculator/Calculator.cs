using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Interfaces;

namespace MyCalculator
{
    public class Calculator : IRPNCalculator
    {
        public Stack<char> RPNStack { get; private set; }
        public Stack<int> CalcStack { get; private set; }
        public bool IsCalculating { get; private set; }
        public IDictionary<char, IOperation> Operations { get; private set; }
        public string RPNResult { get; set; }

        public Calculator()
        {
            RPNStack = new Stack<char>();
            CalcStack = new Stack<int>();
            Operations = new Dictionary<char, IOperation>();
            IsCalculating = false;
            LoadOperations();
        }

        public int Calculate(string expression)
        {
            return processRPN(BuildReversedPolishNotation(expression.Replace(" ", "")));
        }

        private void LoadOperations()
        {
            var currentDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            var assemblies = currentDir.GetFiles("*.dll");
            foreach (var assemblyFile in assemblies)
            {
                var assembly = Assembly.LoadFile(assemblyFile.FullName);
                var operations = assembly.ExportedTypes.Where(x => !x.IsAbstract && x.GetInterfaces().Any(y=>y == typeof(IOperation)));
                foreach (var op in operations)
                {
                    var newOp = Activator.CreateInstance(op) as IOperation;
                    if (newOp == null)
                        continue;
                    if (Operations.ContainsKey(newOp.Symbol))
                        throw new Exception(string.Format("Operation \"{0}\" already exists", newOp.Symbol));
                   Operations.Add(newOp.Symbol, newOp);
                }
            }
        }

        private string BuildReversedPolishNotation(string expression)
        {
            foreach (var character in expression)
            {
                if (char.IsDigit(character))
                {
                    RPNResult += character;
                    continue;
                }

                Operations[character].Execute(this);
            }
            if (RPNStack.Count >= 0)
                foreach (var oper in RPNStack)
                    RPNResult += oper;
            IsCalculating = true;
            return RPNResult;
        }

        private int processRPN(string RPNExpression)
        {
            CalcStack.Clear();

            foreach (var c in RPNExpression)
            {
                if (char.IsDigit(c))
                    CalcStack.Push(int.Parse(c.ToString()));
                else
                {
                    Operations[c].Execute(this);
                }
            }
            string res = string.Empty;
            foreach (var i in CalcStack)
                res += i.ToString();
            return int.Parse(res);
        }
    }
}

using System;
using System.Collections.Generic;
namespace ClassExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            StringTransform transformer = new StringTransform();
            UpperTransform secondTransformer = new UpperTransform();
            LowerTransform thirdTransformer = new LowerTransform();
            string userInput;
            Console.WriteLine("Write a word to transform:");
            userInput = (Console.ReadLine());
            StringTransform[] allTransforms = new StringTransform()
            {
                transformer,
                secondTransformer,
                thirdTransformer
            };

            foreach (var item in collection)
            {
                var result2 = secondTransformer.Transform(userInput);
                Console.WriteLine(result2);
            }
        }
    }
    public class StringTransform
    {
        private static string DefaultValue = "test";
        protected string _input;
        public StringTransform(string input)
        {
            _input = input ?? DefaultValue;
        }
        public virtual string Transform()
        {
            string input = string.Empty;
            if (input == null)
            {
                throw new ArgumentException("Null passed");
            }
            else
            {
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    result += input[i];
                }
                return result;
            }
        }
    }

    public class UpperTransform : StringTransform
    {
        public string LastTransform { get; set; }

        public override string Transform(string input) : base (input)
        {
            return input.toUpper();
        }
    }
    public class LowerTransform : StringTransform
    {
        public string LastTransform { get; set; }

        public override string Transform(string input)
        {
            return input.toLower();
        }
    }
}
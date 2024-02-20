using System;
using System.Text;

namespace DesignPatternExercises.BuilderPattern
{
    /*
    Builder Coding Exercise
    You are asked to implement the Builder design pattern for rendering simple chunks of code.

    Sample use of the builder you are asked to create:

    var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
    Console.WriteLine(cb);
    The expected output of the above code is:

    public class Person
    {
      public string Name;
      public int Age;
    }
    Please observe the same placement of curly braces and use two-space indentation.
    */

    public class CodeBuilder : ICodeBuilder
    {
        private StringBuilder _code;
        public CodeBuilder(string className)
        {
            _code = new StringBuilder($"public class {className}");
            _code.AppendLine();
            _code.AppendLine("{");
        }

        public ICodeBuilder AddField(string fieldName, string fieldType)
        {
            _code.AppendLine($"  public {fieldType} {fieldName};");
            return this;
        }

        public override string ToString()
        {
            _code.AppendLine("}");
            return _code.ToString();
        }
    }

    public interface ICodeBuilder
    {
        ICodeBuilder AddField(string fieldName, string fieldType);
    }

    public class Program
    {
        public static void Main()
        {
            var a = new CodeBuilder("Test");
            a.AddField("Name", "string");
            a.AddField("Age", "int");

            Console.WriteLine(a.ToString());
        }
    }
}

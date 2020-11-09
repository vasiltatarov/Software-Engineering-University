using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string investigatedClass)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] methods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            var gettersInMethods = methods.Where(x => x.Name.StartsWith("get"));

            foreach (var method in gettersInMethods)
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            var settersInMethods = methods.Where(x => x.Name.StartsWith("set"));

            foreach (var method in settersInMethods)
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb
                .AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(className);
            FieldInfo[] fields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] privateMethods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] publicMethods = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            var gettersInMethods = privateMethods.Where(x => x.Name.StartsWith("get"));
            foreach (var method in gettersInMethods)
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            var settersInMethods = publicMethods.Where(x => x.Name.StartsWith("set"));
            foreach (var method in settersInMethods)
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string StealFieldInfo(string investigatedClass, params string[] namesOfFields)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] fields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");
            var sortedFields = fields.Where(x => namesOfFields.Contains(x.Name));

            foreach (var field in sortedFields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Conditions;

namespace Architecture.Tests.Common.Conditions;

internal sealed class InterfaceWrappedResultCondition(
    System.Reflection.Assembly assembly,
    Type interfaceType,
    Type resultWrappedInType) : ICondition<Class>
{
    public string Description => $"Classes implementing {interfaceType.Name} should return a type wrapped in {resultWrappedInType.Name}.";

    public IEnumerable<ConditionResult> Check(IEnumerable<Class> classes, ArchUnitNET.Domain.Architecture architecture)
    {
        foreach (var @class in classes)
        {
            var type = assembly.GetType(@class.FullName);

            if (type is null)
            {
                yield return new ConditionResult(@class, false, $"Could not find type for {@class.FullName}.");
                continue;
            }

            // Find the interface implemented by this class using reflection
            var implementedInterface = type.GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);

            if (implementedInterface != null)
            {
                // Get the generic argument of the interface
                var genericArgument = implementedInterface.GetGenericArguments().FirstOrDefault();

                // Check if the generic argument is wrapped with the specified type
                bool isWrappedCorrectly = genericArgument != null &&
                                          genericArgument.IsGenericType &&
                                          genericArgument.GetGenericTypeDefinition() == resultWrappedInType;

                yield return new ConditionResult(@class, isWrappedCorrectly,
                    isWrappedCorrectly
                        ? $"{type.FullName} correctly returns a {resultWrappedInType.Name} wrapped result."
                        : $"{type.FullName} implements {interfaceType.Name} but does not return a {resultWrappedInType.Name} wrapped result.");
            }
            else
            {
                // If the class does not implement the specified interface, it's irrelevant for this check.
                yield return new ConditionResult(@class, pass: true, failDescription: $"{type.FullName} does not implement {interfaceType.Name}.");
            }
        }
    }

    public bool CheckEmpty() => true;
}
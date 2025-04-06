using Swdac.ValidationFrameworkSample.Domain;
using Swdac.ValidationFrameworkSample.Domain.PersonSpecification;

namespace Swdac.ValidationFramework.Sample;


internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello family!\r\n");

        Console.WriteLine("Creating the family and validating... ");
        Person fc = new(1, "Fernando", "Calvo", new DateTime(1929, 05, 25), GenderEnum.Masculine);
        Person eb = new(2, "Elena", "Balvin", new DateTime(1935, 03, 15), GenderEnum.Feminine);

        Person dc = new(3, "Dario", "Calvo", new DateTime(1960, 07, 20), GenderEnum.Masculine);
        dc.setParents(eb, fc);

        IsParentOfSpecification isParentSpec = new(dc);
        Console.WriteLine($"Is {dc} a parent of {fc}? {isParentSpec.IsSatisfiedBy(eb)}");
        Console.WriteLine($"Is {dc} a parent of {eb}? {isParentSpec.IsSatisfiedBy(eb)}");

        IsParentOfSpecification isFatherSpec = new(fc);
        IsParentOfSpecification isMotherSpec = new(eb);
        Console.WriteLine($"Are {fc} and {eb} parents of {dc}?" +
            $" {isMotherSpec.And(isFatherSpec).IsSatisfiedBy(dc)}");

        Person mfc = new(4, "Maria", "Calvo", new DateTime(1990, 01, 01), GenderEnum.Feminine);
        Person sc = new(5, "Silvia", "Calvo", new DateTime(1990, 01, 01), GenderEnum.Feminine);

        mfc.setParents(eb, fc);
        sc.setParents(eb, fc);

        IsSiblingOfSpecification isSiblingSpec = new(dc);
        Console.WriteLine($"Is {dc} a sibling of {mfc}? " +
            $"{isSiblingSpec.IsSatisfiedBy(mfc) && isSiblingSpec.IsSatisfiedBy(sc)}");

        Console.WriteLine($"Is {dc} a sibling of {mfc}? " +
            $"{isSiblingSpec.IsSatisfiedBy(mfc) && isSiblingSpec.IsSatisfiedBy(fc)}");

        // Sample with invalid case
        Console.WriteLine("\r\nValidating with list of invalid... ");
        List<string> notSatisfied = new();

        Console.WriteLine($"Is {dc} a sibling of {mfc}? " +
            $"{isSiblingSpec.IsSatisfiedBy(mfc) && isSiblingSpec.IsSatisfiedBy(fc, notSatisfied)}");
        Console.WriteLine($"Is {dc} a sibling of {mfc}? " +
            $"{isSiblingSpec.IsSatisfiedBy(mfc) && isSiblingSpec.IsSatisfiedBy(eb, notSatisfied)}");
        foreach (var item in notSatisfied)
        {
            Console.WriteLine(item);
        }



    }
}



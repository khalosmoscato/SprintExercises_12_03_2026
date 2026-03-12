using SprintExercise_12_03_2026;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SprintExercise_12_03_2026
{
    // testing virtual
    class Pokemon // this is the `Base` (Parent)
    {
        public string Name { get; set; }
        public virtual bool IsShiny()
        {
            return false;
        }
    }

    class Pikachu : Pokemon // this is a `Derived` (Child) (same could be applied to Eevee)
    {
        public Pikachu() { Name = "Pikachu"; }
        // Pikachu has 2 fields, `Cry` is defaulted and the `Genre` is requested in the contructor
        public static string Cry = "Pika-pi";
        public string Genre {  get; set; }
        public override bool IsShiny()
        {
            // return base.IsShiny();
            return true;
        }
        public Pikachu(string genre) : this() // because I separated the Name constructor with this Genre construct, and I can link them by using `this()`, technique called `Contructor Chaining`
        {
            Genre = genre;
        }
    
    }
    
    class Eevee
    {
        // if I set a field to static, all the new eevees created using this class will inherit this field by default.
        // If I were to change the new eevees cry, that would also affect this class because of `static` making all the eevees Cry refencing the same point in memory.
        public static string Cry = "Eevee-ev";
        public string PotentialEvolution { get; set; }
        public Eevee(string potentialEvolution)
        {
            PotentialEvolution = potentialEvolution;
        }
        public override string ToString()
        {
            return $"This Eevee will potentially evolve into -> {PotentialEvolution}!";
        }
    }
    public class Task00
    {
        public static void Run()
        {
            Console.WriteLine("This works!");
            Pikachu ashPikachu = new Pikachu("male");
            ashPikachu.GetType();
            Console.WriteLine(Pikachu.Cry); // this would return the cry assigned by dafault
            Console.WriteLine(ashPikachu); // this would return something like `SprintExercise_12_03_2026.Pikachu` or something similar
                                           // because `Console.WriteLine` inherits `ToString()` by default from the System.Object
                                           // so it would only work by calling the class which is `Pikachu.Cry` or we could override `Console.WriteLine` behaviour.
                                           // check how to in the example below using the Eevee class:
            Eevee garyEevee = new Eevee("Umbreon");
            Console.WriteLine(garyEevee.PotentialEvolution);

            // underatanding `Equals()`: this checks for Reference Equality, are they pointing at the same spot in memory?
            Pikachu pika1 = new Pikachu("Male");
            Pikachu pika2 = new Pikachu("Male");
            Pikachu pika3 = pika1; // pika3 points to the SAME memory spot as pika1

            Console.WriteLine(pika1.Equals(pika2)); // False (Different spots in memory)
            Console.WriteLine(pika1.Equals(pika3)); // True (Exact same spot in memory)
            // like I did with the `ToString()`, I could override `Equals()` logic for my Pikachu class
            // example on how you would override is inside of Pokemon class:
            //```csharp
            // public override bool Equals(object obj)
            // ("Is this object even a Pikachu?")
            // (If yes, call it 'otherPikachu' so I can look at its properties.)
            // if (obj is Pikachu otherPikachu)
            // {
            //     (Now that I know it's a Pikachu, I check the details)
            //     return this.Genre == otherPikachu.Genre;
            // }
            // (If it's not even a Pikachu (e.g., it's an Eevee or a string), return false)
            // return false;
            // }
            //```
            // it is golden rule in c# that if I override `Equals()`, I should override `GetHashCode()` too
            // This ensures that if two objects are "Equal" (same Genre), the system gives them the same "Digital Fingerprint" (HashCode).
            // following the example above, I would then add to `Pikachu` class the following:
            //```csharp
            // public override GetHashCode()
            // {
            //     return Genre?.GetHasCode() ?? 0;
            // }
            //```
            // above, the `?.` is the `Null-Conditional Operator` -> it basically says if Genre exists, give me its hash code, if not, handles the null and prevent the program from crashing
            // although we cannot assing `null` to `GetHashCode()` which returns an `int`, so we concatenate this line at the end with:
            // `??` the `Null-Coalescing Operator` -> this says if the code before returnes null, assign a default value (int 0 in our case) to `GetHashCode()`
            // PS: for Strings/Objects: You use ?. and ?? because they can be null; for Integers/Booleans: You just return the value directly.
            // Instead of manually checking each property with `?.` and `??`, I can use "combine" machine, and it does the same: spits out a single, unique integer.
            // so you would replace `return Genre?.GetHasCode() ?? 0;` with `return HashCode.Combine(Genre);`
            // inside `Combine()` parantheses you mirror what you are returning in the `Equals()`, in our case is `Genre` only, could be more aruments, just mirror what the `Equals()` returns



            // trying `GetHashCode()`
            Console.WriteLine(pika1.GetHashCode());
            Console.WriteLine(pika3.GetHashCode()); // These will be identical!
            Console.WriteLine(pika2.GetHashCode()); // This will be different.

            // trying `Object.ReferenceEquales(objA, objB)`:
            bool check1 = Object.ReferenceEquals(pika1, pika2);
            Console.WriteLine($"Do pika1 and pika2 share a reference? {check1}"); // false

            // Scenario B: One points to the other
            bool check2 = Object.ReferenceEquals(pika1, pika3);
            Console.WriteLine($"Do pika1 and pikaCopy share a reference? {check2}"); // true
        }
    }
}
// Understanding the concept of `GetType()`:
// pre-concept to understant the example code below:
// `GetType()` = What is this specific object currently sitting in memory?"
// `typeof()` = "Give me the metadata for this specific class name."
// ```csharp
// Pikachu pika = new Pikachu("Male");
// Console.WriteLine(pika.GetType()); // Output: (Namespace + Class Name): `SprintExercise_12_03_2026.Pikachu`

// if (pika.GetType() == typeof(Pikachu)) // these 2 have the same output
// {
//     Console.WriteLine("This is definitely a Pikachu!");
// }
// ```
// pika.GetType() looks at the tag on the ear of the actual creature standing in front of you.
// typeof(Pikachu) looks at the heading of the page in the Pokédex.
// Why this is useful
// This is how C# handles Reflection—the ability for a program to inspect its own structure.
// You would use this comparison if you wanted to ensure an object is exactly a certain type, rather than just "something that looks like it."
// I could also write the above example code using the shorthand `is` keyword
//if (ashPikachu is Pikachu) 
// {
//     Console.WriteLine("It's a Pikachu!");
// }

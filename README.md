# SprintExercises_12_03_2026
# C# Engineering Lab: Inheritance & Object Identity

A technical exploration of Object-Oriented Programming (OOP) in C#, focusing on class hierarchies, constructor chaining, and overriding the default behavior of the `System.Object` class.

---

## Technical Implementations

### 1. Inheritance & Method Overriding
The project implements a `Pokemon` base class with derived classes to demonstrate the `virtual` and `override` relationship:
* **Base Class:** Defines the blueprint with a `virtual` method `IsShiny()`.
* **Derived Class:** Rewrites the logic using `override` to provide specific functionality.
* **Constructor Chaining:** Uses `: this()` to link constructors, ensuring the `Name` property is set consistently across different initialization paths.

### 2. System.Object Overrides
To master object identity, the following standard methods were redefined:
* **ToString():** Overridden to provide a human-readable summary of the object's state.
* **Equals(object obj):** Replaces **Reference Equality** with **Value Equality**, allowing two different objects in memory to be considered "equal" if their data (e.g., `Genre`) matches.
* **GetHashCode():** Implemented to maintain consistency with `Equals()`, ensuring that equal objects share the same digital fingerprint.

### 3. Logic & Validation
* Implemented robust user-input validation using `TryParse` patterns.
* Utilized `while(true)` loops with logical `break` points to ensure "Master Gatekeeper" control flow.
* Explored data transformation from `double` results into `char[]` arrays.

---

## Core Principles Applied
* **DRY (Don't Repeat Yourself):** Achieved through constructor chaining and inheritance.
* **Null Safety:** Used Null-conditional (`?.`) and Null-coalescing (`??`) operators to prevent runtime crashes.
* **Type Safety:** Used the `is` keyword for safe type checking and casting during object comparison.

---

## Environment
* **Platform:** Windows 11 Pro / PowerShell 7.5.4
* **Target Framework:** .NET 8.0+
* **Vault Folder:** Engineering

**Author:** Khalos CF Moscato  
**Date:** March 2026
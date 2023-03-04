# C# Crash Course

## Fundamentals
- See Week 6 canvas page
## Lamda & LINQ

- Lamda expressions are used to create anonymous functions (create function on the fly and doesn't really have a name)
- Lamda can either be an Expression or Statement
- We will concentrate on Type Interference
- Langugae-Integrated Query supports writing queries against Entity framework. But it has since expanded to work with lambda as well.
- We will be only concerned with LINQ to Entites functionality

## Abstract Classes

- A class that only can be inherited
- You can't instantiate and must be a base class
- Its method may or may not be abstract
- Inheriting classes must include an implementation of any abstract methods
- Engines are the most common use cases
- Not the same as an Interface
- Can't be used with Sealed keyword - Sealed means you cannot inherit from it 
## Interfaces

- Simply a contract
- Amy class implementing an interface must have all the methods and/or properties implemented
- Callers can perform transactions by knowing the interface only and not the class type!
- On of the most used patterns (interface patterns or facade pattern) is a corner stone of many enterprise applications.
- Use alongside abstract classes to provide contacts and allow for polymorphism

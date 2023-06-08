# Pluralsight-LINQ Fundamentals in C# 10

The **LINQ-Fundamentals-Starting.zip** contains the Start folders for each module. Use the files in this zip to follow along with the video course.

The **LINQHandsOn.zip** contains the unit tests to check your knowledge after each module.

# Using SequenceEquals() with Integer collections

* Compares two collections for equality => Simple data types (int, decimal, etc) - check values
* Object data types checks reference    => Use comparer class to check values in properties

# Using Except() with integer collections

Find all values in one list, but not the other one. Returns the list of exceptions.

# Using the ExceptBy() method

Find all values in one list, but not the other and returns the list of objects that are different.

**We don't need a comparer class to use it**.

By default, the key expression used for ExceptBy() is string, and if we want to change that, then we have to pass two parameters to this generic
method: 

* One is the type of things that are going to be in this collection.
* The second is the data type of the key expression.

```
List<Product> list = null;
List<Product> products = ProductRepository.GetAll();
List<SalesOrder> sales = SalesOrderRepository.GetAll();

// Write Method Syntax Here
list = products
    .ExceptBy<Product, int>(sales.Select(s => s.ProductID), p => p.ProductID)
    .ToList();
```

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

# Using Intersect()

This method allows to find all values in common between two lists (it's the opposite of Excep()).

# Concatenate  collections usinf Union and Concat

* **Union** will not give us any duplicates thar are bewtween the two list.
* **UnionBy** will not give us any duplicates thar are bewtween the two list.
* **Concat** will give us the duplicates thar are bewtween the two list.

# Using the Join cluase to combine two collections

## Perform an equijoin (inner join) between two or three collections

- At least one property in each collection must share equal values
- Using the **Join** method we need to specify the following parameters:
    * Outer sequence -> From the query starts
    * Inner sequence
    * outerKeySelector 
                        -> This two parameters are used to specify a filed whose value should be mach using lambda expression in order to include element in the result.
    * innerKeySelector
    * result selector -> Used to formulate the result

## Using a two-field for the inner join:

```
list = (from product in products
        join sale in sales on
        new { product.ProductID, Qty = (short)6 }
        equals
        new { sale.ProductID, Qty = sale.OrderQty }
        select new ProductOrder
        {
            ProductID = product.ProductID,
            Name = product.Name,
            Color = product.Color,
            StandardCost = product.StandardCost,
            ListPrice = product.ListPrice,
            Size = product.Size,
            SalesOrderID = sale.SalesOrderID,
            OrderQty = sale.OrderQty
        })
        .OrderBy(product => product.Name)
        .ToList();
```

Here, the **on**, instead of a single field, we need to create an anonymous class when we list what we're trying to join on. The example above can be traduced as:

"product.ProductId = sale.ProductID AND Qty = sale.OrderQty"

Using the LINQ methods instead:

```
list = products                            
    .Join(sales,                                       
            product => new { product.ProductID, Qty = (short)6 },              
            sale => new { sale.ProductID, Qty = sale.OrderQty }, 
            (product, sale) => new ProductOrder        
            {
    ProductID = product.ProductID,
    Name = product.Name,
    Color = product.Color,
    StandardCost = product.StandardCost,
    ListPrice = product.ListPrice,
    Size = product.Size,
    SalesOrderID = sale.SalesOrderID,
    OrderQty = sale.OrderQty
})
.OrderBy(product => product.Name)
.ToList();
```

## Create a one-to-many using group join

We'll try to create a new object with Sales collection for each Product. For this, the query syntax uses 'join' and 'into' keywords.
The method syntax uses **GroupJoin()**.

```
list = (from product in products
        orderby product.ProductID
        join sale in sales
        on product.ProductID equals sale.ProductID
        into newSales
        select new ProductSales 
        {
            Product = product,
            Sales = newSales.OrderBy(s => s.SalesOrderID).ToList()
        })
        .ToList();
```

Using the **into** keyword, the query takes the sales collection for each product and puts it into the **newSales** variable. With that, we're in order to create the ProductSales instance.

If we use, instead, the method syntax, we need to use the GroupJoin() method:

```
list = products
    .GroupJoin(
        sales,
        product => product.ProductID,
        sale => sale.ProductID,
        (product, salesGroup) => new ProductSales
        {
            Product = product,
            Sales = salesGroup.OrderBy(s => s.SalesOrderID).ToList()
        }
    )
    .ToList();
```

In the above example, the result selector includes grouped collection salesGroup.

## Simulate a left outer join using query syntax

We'll use an inner join using 'into' and a second 'from' statement.
Now, a null object may be returned fro the right collection that we get back from the from, so we'll use DefaultIfEmpty method to give us an empty object if there is nothing that matches in the right collection.

```
list = (from product in products
        join sale in sales
        on product.ProductID equals sale.ProductID
        into newSales
        from sale in newSales.DefaultIfEmpty()
        select new ProductOrder
        {
            ProductID = product.ProductID,
            Name = product.Name,
            Color = product.Color,
            StandardCost = product.StandardCost,
            ListPrice = product.ListPrice,
            Size = product.Size,
            SalesOrderID = sale?.SalesOrderID,  // use the null-conditional operator
            OrderQty = sale?.OrderQty,
            LineTotal = sale?.LineTotal,
        })
        .OrderBy(p => p.Name)
        .ToList();
```

We're putting the join result into newSales, so that means "give me all the sales for that ProductID".
Then, we add on an extra from (if the product has sales, that newSales has data). So, we can create a new ProductOrder instance.

## Simulate a left outer join using method syntax

For this, we gonna use the **SelectMany()** method to select the 'right' collection. 
We're going to use the **Where** method to filter what is selected in 'right' collection, and finally, we're goint to use **DefaultIfEmpty()** method for 'right' collection.

```
list = products
        .SelectMany(product => sales.Where(s => s.ProductID == product.ProductID).DefaultIfEmpty(),
        (product, sale) => new ProductOrder
        {
            ProductID = product.ProductID,
            Name = product.Name,
            Color = product.Color,
            StandardCost = product.StandardCost,
            ListPrice = product.ListPrice,
            Size = product.Size,
            SalesOrderID = sale?.SalesOrderID,  // use the null-conditional operator
            OrderQty = sale?.OrderQty,
            LineTotal = sale?.LineTotal,
        })
        .ToList();
```
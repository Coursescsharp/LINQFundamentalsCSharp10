To run this project in Visual Studio Code, open the LINQSamples.code-workspace
  When prompted to add "Required Assets", Click the 'Yes' button
  Run the project
  Check the DEBUG CONSOLE window for the output
To run this project in Visual Studio 2022, open the LINQSamples.sln
  Run the project
  A console window shows the output


SampleViewModel Samples
--------------------------------------------------
Where() - Filter products using where. If the data is not found, an empty list is returned
WhereTwoFields() - Filter products using where with two fields. If the data is not found, an empty list is returned
WhereExtensionMethod() - Filter products using a custom extension method

LINQ custom extension methods

For example, a method that returns an IEnumerable<T>, that way we can use this method on the query instead of like Aware:

(from product in products 
select prod).ByColor("Red")

What we od is create a static class that has a static method in it. In the method we use the "this" keyword to key to type of object:

public static class ProductHelper
{
	public static IEnumerable<Product> ByColor(this IEnumerable<Product> query, string color)
	{
		return query
			.Where(p => p.Color == color);
	}
}
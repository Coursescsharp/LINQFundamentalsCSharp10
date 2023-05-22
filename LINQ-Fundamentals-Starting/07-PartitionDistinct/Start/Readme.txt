To run this project in Visual Studio Code, open the LINQSamples.code-workspace
  When prompted to add "Required Assets", Click the 'Yes' button
  Run the project
  Check the DEBUG CONSOLE window for the output
To run this project in Visual Studio 2022, open the LINQSamples.sln
  Run the project
  A console window shows the output


SampleViewModel Samples
--------------------------------------------------

Take n elements / Skip n elements
----------------------------------
These methods are used to perform partitioning operations where we might take a certain amount of elements from the front, or we might skip a certain amount of elements from the front of a collection.

Take() - Use Take() to select a specified number of items from the beginning of a collection
TakeRange() - Use a range operator
TakeWhile() - Use TakeWhile() to select a specified number of items from the beginning of a collection based on a true condition
Skip() - Use Skip() to move past a specified number of items from the beginning of a collection
SkipWhile() - Use SkipWhile() to move past a specified number of items from the beginning of a collection based on a true condition


Get a distinct value from collection.

Distinct() - The Distinct() operator finds all unique values within a collection
DistinctBy() - The DistinctBy() operator finds all unique values within a collection and returns the objects

Chunk a collection into smaller sets

Chunk() - Chunk() splits the elements of a larger list into a collection of arrays of a specified size where each element of the collection is an array of those items.

To run this project in Visual Studio Code, open the LINQSamples.code-workspace
  When prompted to add "Required Assets", Click the 'Yes' button
  Run the project
  Check the DEBUG CONSOLE window for the output
To run this project in Visual Studio 2022, open the LINQSamples.sln
  Run the project
  A console window shows the output


SampleViewModel Samples
--------------------------------------------------
First() - Locate a specific product using First(). First() searches forward in the collection. NOTE: First() throws an exception if the result does not produce any values
FirstOrDefault() - Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list. NOTE: FirstOrDefault() returns a null if no value is found
FirstOrDefaultWithCustom() - Use a custom default value when not found
Last() - Locate a specific product using Last(). Last() searches from the end of the list backwards. NOTE: Last returns the last value from a collection, or throws an exception if no value is found
LastOrDefault() - Locate a specific product using LastOrDefault(). LastOrDefault() searches from the end of the list backwards. NOTE: LastOrDefault returns the last value in a collection or a null if no values are found
Single() - Locate a specific product using Single(). NOTE: Single() expects only a single element to be found in the collection, otherwise an exception is thrown
SingleOrDefault() - Locate a specific product using SingleOrDefault(). NOTE: SingleOrDefault() returns a single element found in the collection, or a null value if none found in the collection, if multiple values are found an exception is thrown.

First()/Last() vs. FirstOrDefault()/LastOrDefault()
---------------------------------------------------

First()/Last()
--------------
- If you expect the element to be present
- Want to handle/throw an exception if not found

FirstOrDefault()/LastOrDefault()
--------------------------------
- If you are not sure if element is present
- Don't want to handle an exception. Want to get back a null or other default value

First() vs. Single()
--------------------

First()
-------
- If you expect the element to be present
- Want to handle/throw an exception if not found
- Only searches until it finds the element. Then, it stops.
- Faster than Single()

Single()
--------
- If you expect the element to be present
- Want to handle/throw an exception if not found
- Search the entire list every time
- Slower than First()

FirstOrDefault() vs. SingleOrDefault()
--------------------------------------

FirstOrDefault()
----------------
- If you expect the element to be present
- Want to handle/throw an exception if not found
- Must search the entire list every time

SingleOrDefault()
-----------------
- If you are not sure if element is present
- Don't want to handle an exception. 
- Search only until it finds the element
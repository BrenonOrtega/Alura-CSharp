## Arrays And Collections - PluralSight (Generated Dinamically and trimmed for first commit.)

To access an object we can use it's index as follows: 
first object: index: 0 - BusRoute:celadon-city - Origin: celadon-city - Destination:navel-rock - Distance:0
Serves:cerulean-city

Index have a class System.Index, we can access the last index of an array as follow: var last = myArray[^1];
Last object: index: ^1 (this means "array.Length - 1") - BusRoute:navel-rock - Origin: navel-rock - Destination:celadon-city - Distance:92
Serves:birth-island

Using for loops we can iterate through the collection onwards or backwards and control what and how we'll handle the data.
Having the index while we are iterating the collection helps us control the flow of this data.

Index: 0, Route: celadon-city - Origin: celadon-city - Destination:navel-rock - Distance:0
Serves:cerulean-city
Index: 1, Route: cerulean-city - Origin: cerulean-city - Destination:birth-island - Distance:1
Serves:cinnabar-island, celadon-city
Index: 2, Route: cinnabar-island - Origin: cinnabar-island - Destination:seven-island - Distance:2
Serves:digletts-cave, cerulean-city
Index: 3, Route: digletts-cave - Origin: digletts-cave - Destination:six-island - Distance:3
Serves:fuchsia-city, cinnabar-island
Index: 4, Route: fuchsia-city - Origin: fuchsia-city - Destination:three-isle-path - Distance:4
Serves:mt-moon, digletts-cave

Here we will use the static class Array Method ForEach.
It takes the array you are iterating and the delegate that should be invoked
It is powerful since it is performatic and let's us do lots of things with every item in collection

Here we will use the List Class Method ForEach.
you invoke it directly from the list, passing the predicate that will be invoked.
It is powerful since it is performatic and let's us do lots of things with every item in collection
Pretty much like the Array Version of it does, it returns nothing.

*****************************************************
Let's find an item in the list using the List.Find() method.
We'll search for routes that goes with celadon 
We found this route celadon-city - Origin: celadon-city - Destination:navel-rock - Distance:0
Serves:cerulean-city
*****************************************************

Enumerating the dictionary keys and acessing then using [] notation
Key:0 - Value: celadon-city - Origin: celadon-city - Destination:navel-rock - Distance:0
Serves:cerulean-city

Key:1 - Value: cerulean-city - Origin: cerulean-city - Destination:birth-island - Distance:1
Serves:cinnabar-island, celadon-city
Key:2 - Value: cinnabar-island - Origin: cinnabar-island - Destination:seven-island - Distance:2
Serves:digletts-cave, cerulean-city
Key:3 - Value: digletts-cave - Origin: digletts-cave - Destination:six-island - Distance:3
Serves:fuchsia-city, cinnabar-island
Key:4 - Value: fuchsia-city - Origin: fuchsia-city - Destination:three-isle-path - Distance:4
Serves:mt-moon, digletts-cave

Now Lets try searching for a value that doesn't exist - key10000
System.Collections.Generic.KeyNotFoundException: The given key '10000' was not present in the dictionary.
   at System.Collections.Generic.Dictionary`2.get_Item(TKey key)
   at ArraysAndCollections.Application.CourseModules.Module4.Run(String[] args) in C:\Coding\estudo\CSharp\Pluralsight\Collections\ArraysAndCollections\ArraysAndCollections.Application\CourseModules\Module4.cs:line 30
As we can see, accessing keys that does not exist throws exceptions for us.

We have 2 ways to find if data is in dictionary. Using the method ContainsKey or
ContainsValue for searching for a data, and the lookup for it.
We can use the Method above and if return true we use it with the indexer operator (DON'T RECOMMEND IT SINCE IT'S 2 QUERIES)
And we can use have the 'TryGetValue' Method that returns a bool and puts the fought data
in an out variable with the result if found, not needing 2 access
As we see the TryGetValue returns False if it does not find anything.

if it finds anything, then it return True and puts the result in the object passed with out param 
cerulean-city - Origin: cerulean-city - Destination:birth-island - Distance:1
Serves:cinnabar-island, celadon-city


using ConsoleApplication;
using System.Collections;
using System.Collections.Concurrent;
using static System.Runtime.InteropServices.JavaScript.JSType;

//Test2.Main();

//SemaphoreTest.Printer();


//Demo.Main();


var lst = Enumerable.Range(1, 200);
var  bag= new ConcurrentBag<int>(lst);


//foreach (var number in lst)
//{
//    Console.WriteLine(number);
//    Thread.Sleep(100);
//}

//Parallel.ForEach(bag, number =>
//{
//    Console.WriteLine(number);
//    Thread.Sleep(100);
//});

await Parallel.ForEachAsync(bag, async (number, token) =>
{
    Console.WriteLine($"{number}");
    Thread.Sleep(100);
});
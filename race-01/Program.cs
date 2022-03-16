using System.Diagnostics;

var action = () =>
{
    var counter = 0;

    var watch = Stopwatch.StartNew();
    for (var i = 0; i < 4000000; i++)
    {
        ++counter;
    }
    watch.Stop();

    Console.WriteLine($"Counted to {counter} in {watch.Elapsed.TotalMilliseconds} milliseconds", counter, watch.ElapsedMilliseconds);
};
action.Invoke();
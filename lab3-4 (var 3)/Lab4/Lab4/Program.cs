using System.Globalization;
using Lab4;


while (true)
{
    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
    Console.Write("Enter PI 1: ");
    var pi1 = double.Parse(Console.ReadLine());

    Console.Write("Enter PI 2: ");
    var pi2 = double.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.WriteLine();

    var statistics = new Statistics();


    var firstChannel = new Channel(pi1, statistics, 0);
    var secondChannel = new Channel(pi2, statistics, 1);

    var actualTicks = 1000000;

    var ticks = actualTicks + 1;
    var queue = new CustomQueue(firstChannel, secondChannel, statistics);


    var system = new StaxanovSystem(queue, firstChannel, secondChannel, statistics);

    system.Work(ticks);

    foreach (var pair in statistics.States)
    {
        var prob = (decimal) pair.Value / actualTicks;
        Console.WriteLine($"P{pair.Key} = {prob}");
    }

    var declinedCount = (double) statistics.Requests
                                           .Count(r => r.IsDeclined);

    var requestsCount = (double)statistics.Requests
                                          .Count();

    Console.WriteLine();
    Console.WriteLine($"Sym(P) = {statistics.States.Sum(pair => (decimal) pair.Value / actualTicks)}");

    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine($"P declined: {(double)statistics.Requests.Count(r => r.IsDeclined) / statistics.Requests.Count}");
    Console.WriteLine("P block: 0");

    var inQueueRequests = (double) statistics.QueueStates
                                             .Select(pair => int.Parse(pair.Key) * pair.Value)
                                             .Sum();

    Console.WriteLine($"L queue: {inQueueRequests / actualTicks}");

    var lc = inQueueRequests + statistics.BusyTicks.Sum();

    Console.WriteLine($"L system: {(double) lc / actualTicks}");

    Console.WriteLine($"Q relative: {(double) statistics.Requests.Count(request => request.IsCompleted) / (double)statistics.Requests.Count}");

    Console.WriteLine($"A: {(double) statistics.Requests.Count(request => request.IsCompleted) / actualTicks}");

    var inSystemRequests = statistics.Requests
                                      .Where(request => !request.IsDeclined && request.IsCompleted)
                                      .ToList();

    Console.WriteLine($"W queue: {(double)inSystemRequests.Sum(r => r.InQueueTicks) / inSystemRequests.Count}");

    Console.WriteLine($"W system: {(double)inSystemRequests.Sum(request => request.InQueueTicks + request.InChannelTicks) / inSystemRequests.Count}");

    Console.WriteLine($"W channel1: {(double) statistics.BusyTicks[0] / actualTicks}");
    Console.WriteLine($"W channel2: {(double) statistics.BusyTicks[1] / actualTicks}");


    Console.WriteLine();
    Console.WriteLine();
}
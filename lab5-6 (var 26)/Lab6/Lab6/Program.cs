using System.Globalization;
using Lab6;


Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;


while (true)
{
    Console.Write("Enter lambda: ");
    var lambda = float.Parse(Console.ReadLine());
    //var lambda = 0.8f;

    Console.Write("Enter nu: ");
    var nu = float.Parse(Console.ReadLine());
    //var nu = 0.2f;

    var inputStream = new InputStream(new Generator(lambda));

    var firstChannel = new Channel(new Generator(2 * nu), 1);
    var secondChannel = new Channel(new Generator(nu), 2);
    var thirdChannel = new Channel(new Generator(nu), 3);

    var system = new Lab6.System(inputStream, new List<Channel> {firstChannel, secondChannel, thirdChannel});

    var ticks = 1000000;

    system.Work(ticks);

    foreach (var pair in system.States)
    {
        var prob = (decimal) pair.Value / system.TimePassed;
        Console.WriteLine($"P{pair.Key} = {prob}");
    }

    Console.WriteLine();
    Console.WriteLine();

    var completedRequests = system.Requests
                                  .Where(request => request.IsCompleted && !request.IsDeclined);

    Console.WriteLine($"W system: {completedRequests.Sum(request => request.ProcessingTime) / completedRequests.Count()}");
    Console.WriteLine($"A = {system.Requests.Count(request => request.IsCompleted) / system.TimePassed}");


    Console.WriteLine();
    Console.WriteLine();
}
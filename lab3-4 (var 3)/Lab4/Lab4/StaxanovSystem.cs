namespace Lab4
{
    public class StaxanovSystem
    {
        private const int tCount = 2;
        public CustomQueue Queue { get; }
        public Channel FirstChannel { get; }
        public Channel SecondChannel { get; }
        public Statistics Statistics { get; set; }

        public int T { get; set; }

        public StaxanovSystem(
            CustomQueue queue,
            Channel firstChannel,
            Channel secondChannel,
            Statistics statistics)
        {
            Queue = queue;
            FirstChannel = firstChannel;
            SecondChannel = secondChannel;
            Statistics = statistics;
        }

        public void Work(int ticks)
        {
            //var prev = string.Empty;

            for (var i = 1; i <= ticks; i++)
            {
                T = i % tCount + (tCount - 1);



                var code = $"{T}{Queue.Count}"
                           + (FirstChannel.IsBusy ? "1" : "0")
                           + (SecondChannel.IsBusy ? "1" : "0");

                Statistics.CollectState(code);

                // Console.WriteLine($"{i}) "+code);


                Statistics.CollectQueueState(Queue.Count.ToString());


                if (FirstChannel.IsBusy && FirstChannel.TryProcessRequest())
                {
                    // Console.WriteLine("First channel process request");
                }

                if (SecondChannel.IsBusy && SecondChannel.TryProcessRequest())
                {
                    //Console.WriteLine("Second channel process request");
                }

                Queue.SendHeldRequestsToChannels();

                if (T == 1)
                {
                    var request = new Request();
                    Queue.AddRequest(request);
                }

                /*if (i != 1)
                {
                    Statistics.NextStates[prev]
                              .Add(code);
                }

                prev = code;*/
            }
        }
    }
}
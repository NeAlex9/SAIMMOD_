namespace Lab4
{
    public class CustomQueue
    {
        private const int queueCount = 2;

        private readonly Queue<Request> _queue = new();
        private readonly Statistics _statistics;
        public Channel FirstChannel { get; }
        public Channel SecondChannel { get; }
        public int Count => _queue.Count;


        public event EventHandler RequestEvents;

        public CustomQueue(Channel firstChannel, Channel secondChannel, Statistics statistics)
        {
            FirstChannel = firstChannel;
            SecondChannel = secondChannel;
            _statistics = statistics;
        }

        public void AddRequest(Request request)
        {
            _statistics.Requests.Add(request);

            if (!FirstChannel.IsBusy)
            {
                FirstChannel.AddRequest(request);
                // Console.WriteLine("Request was added to first channel");
                return;
            }

            if (!SecondChannel.IsBusy)
            {
                SecondChannel.AddRequest(request);
                //Console.WriteLine("Request was added to second channel");
                return;
            }

            if (_queue.Count == queueCount)
            {
                request.IsDeclined = true;
                //Console.WriteLine("Request was declined");
                return;
            }

            RequestEvents += request.InQueueHandler;
            _queue.Enqueue(request);
            //Console.WriteLine("Request was  added to queue");
        }

        public void SendHeldRequestsToChannels()
        {
            RequestEvents?.Invoke(this, EventArgs.Empty);

            if (_queue.Count < 1)
            {
                return;
            }

            if (!FirstChannel.IsBusy)
            {
                var request = _queue.Dequeue();
                FirstChannel.AddRequest(request);
                RequestEvents -= request.InQueueHandler;
                //Console.WriteLine("Held request was added to first channel");
            }

            if (_queue.Count < 1)
            {
                return;
            }

            if (!SecondChannel.IsBusy)
            {
                var request = _queue.Dequeue();
                SecondChannel.AddRequest(request);
                RequestEvents -= request.InQueueHandler;
                //Console.WriteLine("Held request was added to second channel");
            }
        }
    }
}
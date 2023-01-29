namespace Lab4
{
    public class Channel
    {
        private static Random _random = new Random();
        private readonly int _number;
        private readonly double _probability;
        private Request _request;
        private readonly Statistics _statistics;

        public Channel(double probability, Statistics statistics, int number)
        {
            _probability = probability;
            _statistics = statistics;
            _number = number;
        }

        public bool IsBusy { get; set; } = false;

        public bool TryProcessRequest()
        {
            var currentProb = _random.NextDouble();
            _statistics.BusyTicks[_number]++;

            if (currentProb > _probability)
            {
                IsBusy = false;
                _request.IsCompleted = true;
                _statistics.ProcessedInChannelRequests[_number]++;

                return true;
            }

            _request.InChannelTicks++;

            return false;
        }

        public void AddRequest(Request request)
        {
            IsBusy = true;
            _request = request;
            request.InChannelTicks++;
        }
    }
}
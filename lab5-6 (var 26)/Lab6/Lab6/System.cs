namespace Lab6
{
    public class System
    {
        private readonly InputStream _inputStream;
        private List<Channel> _channels;

        public System(InputStream inputStream, List<Channel> channels)
        {
            _inputStream = inputStream;
            this._channels = channels;
            States = new Dictionary<string, decimal>()
            {
                ["000"] = 0,
                ["100"] = 0,
                ["110"] = 0,
                ["010"] = 0,
                ["001"] = 0,
                ["111"] = 0,
                ["011"] = 0,
                ["101"] = 0,
            };

            Ways = new Dictionary<string, HashSet<string>>()
            {
                ["000"] = new(),
                ["100"] = new(),
                ["110"] = new(),
                ["010"] = new(),
                ["001"] = new(),
                ["111"] = new(),
                ["011"] = new(),
                ["101"] = new(),
            };
        }

        public List<Request> Requests { get; set; } = new List<Request>();
        public Dictionary<string, decimal> States { get; set; }
        public Dictionary<string, HashSet<string>> Ways { get; set; }
        public decimal TimePassed { get; set; }

        public void Work(int ticks)
        {
            var prev = string.Empty;
            for (int i = 0; i < ticks; i++)
            {
                var passedTime = GetMinTime();

                var state = GetState();
               
                States[state] += passedTime;

                TimePassed += passedTime;

                foreach (var channel in _channels)
                {
                    channel.ProcessRequest(passedTime);
                }

                var request = _inputStream.Process(passedTime);
                if (request is not null)
                {
                    Requests.Add(request);

                    var result = SendToChannel(request);

                    if (!result) request.IsDeclined = true;
                }
            }
        }

        public bool SendToChannel(Request request)
        {
            foreach (var channel in _channels)
            {
                if (!channel.IsBusy())
                {
                    channel.AddRequest(request);
                    return true;
                }
            }

            return false;
        }

        public string GetState()
        {
            var states = new List<string>(3);
            var indexes = new List<int>() {1, 2, 3};
            indexes.ForEach(channel => states.Add(GetChannelState(channel)));
            var state = string.Join("", states);
            return state;

            //Console.WriteLine(state);

            string GetChannelState(int index) =>
                _channels.Find(channel => channel.Id == index)!.IsBusy()
                    ? "1"
                    : "0";
        }

        private decimal GetMinTime()
        {
            var minInChannel = _channels.Min(channel => channel.RemainedToProcessTime);

            return minInChannel > _inputStream.RemainedTime
                ? _inputStream.RemainedTime
                : minInChannel;
        }
    }
}
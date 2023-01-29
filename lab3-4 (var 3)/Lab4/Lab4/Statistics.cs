namespace Lab4
{
    public class Statistics
    {
        public Dictionary<string, int> States { get; set; }
        // public Dictionary<string, HashSet<string>> NextStates { get; set; }


        public Dictionary<string, int> QueueStates { get; set; }
        public List<Request> Requests { get; set; } = new List<Request>();


        public int[] ProcessedInChannelRequests = new int[2];
        public int[] BusyTicks = new int[2];



        public Statistics()
        {
            States = new Dictionary<string, int>()
            {
                ["2000"] = -1,
                ["1000"] = 0,
                ["2010"] = 0,
                ["1010"] = 0,
                ["1001"] = 0,
                ["2011"] = 0,
                ["1011"] = 0,
                ["2111"] = 0,
                ["1111"] = 0,
                ["2211"] = 0,
                ["1211"] = 0,
            };

            

            QueueStates = new Dictionary<string, int>()
            {
                ["0"] = -1,
                ["1"] = 0,
                ["2"] = 0,
            };
        }

        public void CollectState(string state)
        {
            States[state]++;
        }

        public void CollectQueueState(string state)
        {
            QueueStates[state]++;
        }
    }
}

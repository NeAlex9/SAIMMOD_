namespace Lab4
{
    public class Request
    {
        public int InQueueTicks { get; set; }
        public int InChannelTicks { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsDeclined { get; set; } = false;

        public void InQueueHandler(object sender, EventArgs args)
        {
            InQueueTicks++;
        }
    }
}

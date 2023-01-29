namespace Lab6
{
    public class Request
    {
        public decimal ProcessingTime { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsDeclined { get; set; } = false;
        public decimal RemainedTime { get; set; }
    }
}

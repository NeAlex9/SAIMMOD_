namespace Lab6
{
    public class Channel
    {
        public int Id { get; set; }
        private Request? _request;
        private Generator _generator;

        public Channel(Generator generator, int id)
        {
            _generator = generator;
            Id = id;
        }

        public bool IsBusy() => _request is not null;

        public void ProcessRequest(decimal passedTime)
        {
            if (_request is null) return;

            _request.RemainedTime -= passedTime;

            if (Math.Abs(_request.RemainedTime) <= decimal.Zero)
            {
                _request.IsCompleted = true;
                _request = null;
            }
        }

        public void AddRequest(Request request)
        {
            _request = request;
            var processingTime = _generator.GetNext();
            _request.RemainedTime = processingTime;
            _request.ProcessingTime = processingTime;
        }

        public decimal RemainedToProcessTime => _request?.RemainedTime ?? decimal.MaxValue;
    }
}
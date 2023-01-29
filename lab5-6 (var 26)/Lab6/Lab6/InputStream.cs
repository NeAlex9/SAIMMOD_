namespace Lab6
{
    public class InputStream
    {
        public Generator _generator;

        public decimal RemainedTime { get; set; }

        public InputStream(Generator generator)
        {
            _generator = generator;
            RemainedTime = generator.GetNext();
        }

        public Request? Process(decimal passedTime)
        {
            RemainedTime -= passedTime;

            if (Math.Abs(RemainedTime) <= decimal.Zero)
            {
                RemainedTime = _generator.GetNext();
                return new Request();
            }

            return null;
        }
    }
}

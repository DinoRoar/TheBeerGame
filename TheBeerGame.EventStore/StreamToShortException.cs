using System;

namespace TheBeerGame.EventStore
{
    public class StreamToShortException : InvalidOperationException
    {
        public StreamToShortException(string streamName)
            : base($"Invalid operation: {streamName} doesn't have enough events")
        {

        }
    }
}
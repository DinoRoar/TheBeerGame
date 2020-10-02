using System;

namespace TheBeerGame.EventStore
{
    public class StreamTooShortException : InvalidOperationException
    {
        public StreamTooShortException(string streamName)
            : base($"Invalid operation: {streamName} doesn't have enough events")
        {

        }
    }
}
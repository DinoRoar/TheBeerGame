using System;

namespace TheBeerGame.EventStore
{
    public class ProjectedEvent : StreamEvent
    {
        public ProjectedEvent(string projectedStreamName, StreamEvent streamEvent)
            : base(projectedStreamName, StreamPositions.Any, StreamPositions.Any, DateTime.Now, streamEvent)
        {

        }

        public ProjectedEvent SetPositions(in long streamPosition, in int globalPosition)
        {
            return new ProjectedEvent(StreamName,
                new StreamEvent(StreamName, streamPosition, globalPosition, DateTime.Now, Event));
        }
    }
}
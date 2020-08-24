﻿using TheBeerGame.GameEngine;

namespace TheBeerGame.EventStore
{
    public class CreateStreamEvent : IHaveStreamName
    {
        public CreateStreamEvent(string streamName, long streamPosition, Event @event)
        {
            StreamName = streamName;
            StreamPosition = streamPosition;
            Event = @event;
        }

        public string StreamName { get; }
        public long StreamPosition { get; }
        public Event Event { get; }
    }
}
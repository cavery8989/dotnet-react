using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using reactApp.Contracts;
using reactApp.Domain;
using reactApp.Events;

namespace reactApp.Repository
{
    public interface IEventStore
    {
        void SaveEvents(AggregateRoot root, int expectedVersion);
    }

    public class EventStore : IEventStore
    {

        private readonly IServiceBus bus;

        private readonly string connectionString;
        public EventStore(IConfiguration config, IServiceBus bus)
        {
            this.connectionString = config.GetConnectionString("DefaultConnection");
            this.bus = bus;
        }

        private struct EventDescriptor
        {
            public readonly Guid Id;
            public readonly string EventData;
            public readonly string EventType;
            public readonly int Version;
            public readonly DateTime CreatedAt;

            public EventDescriptor(Guid id, Event eventData, int version)
            {
                this.Id = id;
                this.EventType = eventData.GetType().Name;
                this.EventData = JsonConvert.SerializeObject(eventData);
                this.Version = version;
                this.CreatedAt = DateTime.UtcNow;
            }
        }

        public void SaveEvents(AggregateRoot root, int expectedVersion)
        {
            var events = root.GetChanges();
            int version = expectedVersion == -1 ? 0 : expectedVersion;

            if (events != null)
            {
                using (var conn = new NpgsqlConnection(this.connectionString))
                {
                    conn.Open();

                    foreach (var e in events)
                    {
                        version++;
                        root.Version = version;
                        EventDescriptor ed = new EventDescriptor(root.Id, e, version);

                        var persisted = persistEventToDb(conn, ed);

                        if (persisted) bus.Publish(e);
                    }
                }
            }

        }

        private bool persistEventToDb(NpgsqlConnection conn, EventDescriptor ed)
        {
            string insertCommand = @"INSERT INTO events (aggregate_id, event_type, event_data, version, created_at)
                                     VALUES(@aggregateId, @eventType, @eventData, @version, @createdAt)";
            try
            {
                using (var cmd = new NpgsqlCommand(insertCommand, conn))
                {
                    cmd.Parameters.AddWithValue("@aggregateId", ed.Id);
                    cmd.Parameters.AddWithValue("@eventType", ed.EventType);
                    cmd.Parameters.AddWithValue("@eventData", ed.EventData);
                    cmd.Parameters.AddWithValue("@version", ed.Version);
                    cmd.Parameters.AddWithValue("@createdAt", ed.CreatedAt);

                    var success = cmd.ExecuteNonQuery();
                    return success > 0;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
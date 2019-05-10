using System;
using Avro.Generic;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry.Serdes;
using Confluent.SchemaRegistry;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace badgeevent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var bootstrapServers = "40.76.55.228:31090";
            var schemaRegistryUrl = "13.90.136.100:8081";

            await ProduceSpecific(bootstrapServers, schemaRegistryUrl);
        }

        
        async static Task ProduceSpecific(string bootstrapServers, string schemaRegistryUrl)
        {
            using (var schemaRegistry = new CachedSchemaRegistryClient(new SchemaRegistryConfig { SchemaRegistryUrl = schemaRegistryUrl }))
            using (var producer =
                new ProducerBuilder<Null, BadgeEvent>(new ProducerConfig { BootstrapServers = bootstrapServers })
                    .SetValueSerializer(new AvroSerializer<BadgeEvent>(schemaRegistry))
                    .Build())
            {
                await producer.ProduceAsync("badgeevent",
                    new Message<Null, BadgeEvent>
                    {
                        Value = new BadgeEvent
                        {
                            
                            id =  "9",
                            name = "Teacher",
                            userId = "16",
                            displayName ="dragonmantank",
                            reputation = "7636",
                            upVotes = 56,
                            downVotes =  3
                        }
                        
                    });

                producer.Flush(TimeSpan.FromSeconds(30));
            }
        }

    }
}

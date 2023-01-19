using Microsoft.EntityFrameworkCore;
using Project4._0_C3_CrowdCtrl_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project4._0_C3_CrowdCtrl_Back.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {
                // Look for any EventTypes.
                if (context.EventTypes.Any())
                {
                    return;   // DB has been seeded
                }

                //Add EventTypes
                context.AddRange(
                    new EventType { Name = "Gala", Threshold = 1 },
                    new EventType { Name = "Football", Threshold = 3 },
                    new EventType { Name = "Party", Threshold = 2 },
                    new EventType { Name = "Proclamation", Threshold = 1 }
                    );

                context.SaveChanges();

                // Look for any Events.
                if (context.Events.Any())
                {
                    return;   // DB has been seeded
                }

                //Add Events
                context.AddRange(
                    new Event { Date = DateTime.Now, Name = "Thomas More Geel", Location = "Kleinhoefstraat 4, Geel", EventTypeId = 4 },
                    new Event { Date = DateTime.Now, Name = "KVV Noordstar - KFC Oever", Location = "Tarwestraat 7-31, Herentals", EventTypeId = 2 },
                    new Event { Date = DateTime.Now, Name = "EasterBunny Party", Location = "Konijnenber 13, Turnhout", EventTypeId = 3 },
                    new Event { Date = DateTime.Now, Name = "Thomas More Lier", Location = "Antwerpsestraat 99, Lier", EventTypeId = 4 },
                    new Event { Date = DateTime.Now, Name = "KRC Genk - KVC Westerlo", Location = "Stadionplein 4, Genk", EventTypeId = 2 },
                    new Event { Date = DateTime.Now, Name = "Carnival", Location = "Rio de Janeiro, Brasil", EventTypeId = 2 }
                    );

                context.SaveChanges();

                // Look for any Zones.
                if (context.Zones.Any())
                {
                    return;   // DB has been seeded
                }

                //Add Zones
                context.AddRange(
                    new Zone { Name = "Alfa" },
                    new Zone { Name = "Beta" },
                    new Zone { Name = "Gamma" }
                    );

                context.SaveChanges();

                // Look for any RecordingDevices.
                if (context.RecordingDevices.Any())
                {
                    return;   // DB has been seeded
                }

                //Add RecordingDevices
                context.AddRange(
                    new RecordingDevice { Name = "RB32F7", ZoneId = 1 },
                    new RecordingDevice { Name = "RB37G3", ZoneId = 2 },
                    new RecordingDevice { Name = "R1FB32", ZoneId = 3 },
                    new RecordingDevice { Name = "R9KCB4", ZoneId = 1 },
                    new RecordingDevice { Name = "JV1221", ZoneId = 2 },
                    new RecordingDevice { Name = "JD136G", ZoneId = 3 },
                    new RecordingDevice { Name = "TV3FD1", ZoneId = 1 },
                    new RecordingDevice { Name = "5RHRR3", ZoneId = 2 },
                    new RecordingDevice { Name = "LVG125", ZoneId = 3 },
                    new RecordingDevice { Name = "KO2N0W", ZoneId = 1 }
                    );

                context.SaveChanges();

                // Look for any Users.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                //Add Users
                context.AddRange(
                    new User { FirstName = "Jari", LastName = "Van de Vel", Email = "vandeveljari@outlook.com", Role = "Admin" },
                    new User { FirstName = "Renzo", LastName = "Beeckmans", Email = "rebe11@gmail.com", Role = "TeamLead" },
                    new User { FirstName = "Robin", LastName = "Ram", Email = "robin@ram.com", Role = "TeamLead" },
                    new User { FirstName = "Jesse", LastName = "Dierckx", Email = "jessedierckx@gmail.com", Role = "Guard" },
                    new User { FirstName = "Tim", LastName = "Verbecque", Email = "verbecquet@gmail.com", Role = "Guard" },
                    new User { FirstName = "Lenn", LastName = "Van Genechten", Email = "lennvangenechten@gmail.com", Role = "Guard" }
                    );

                context.SaveChanges();
            }
        }
    }
}

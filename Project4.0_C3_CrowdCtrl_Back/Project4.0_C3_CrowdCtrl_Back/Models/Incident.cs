﻿using System.Text.Json.Serialization;

namespace Project4._0_C3_CrowdCtrl_Back.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EventId { get; set; }
        public int RecordingDeviceId { get; set; }
        public string Mood { get; set; }
        [JsonIgnore]
        public List<Feedback> Feedbacks { get; set; } = new List<Feedback>();
        [JsonIgnore]
        public RecordingDevice RecordingDevice { get; set; }
        [JsonIgnore]
        public Event Event { get; set; }
    }
}

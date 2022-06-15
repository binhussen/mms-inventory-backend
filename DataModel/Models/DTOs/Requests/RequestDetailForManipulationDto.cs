﻿namespace DataModel.Models.DTOs.Requests
{
    public class RequestItemForManipulationDto
    {
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public string? status { get; set; }
        public int quantityRequest { get; set; }
    }
}

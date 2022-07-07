﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class HR
    {
        [Column("hrId")]
        public int id { get; set; }
        public string fpId { get; set; }
        public string name { get; set; }
        public string middleName { get; set; }
        public string LastName { get; set; }
        public string gender { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime higherDate { get; set; }
        public string occpation { get; set; }
        public string rank { get; set; }
        public string reponsibilty { get; set; }
    }
}

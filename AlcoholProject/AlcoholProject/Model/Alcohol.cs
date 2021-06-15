using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlcoholProject.Model
{
    public class Alcohol
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

    }
}

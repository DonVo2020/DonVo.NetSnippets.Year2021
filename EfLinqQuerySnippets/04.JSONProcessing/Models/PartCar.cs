﻿namespace EfLinqQuerySnippets._04.JSONProcessing.Models
{
    public class PartCar
    {
        public int PartId { get; set; }

        public Part Part { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}

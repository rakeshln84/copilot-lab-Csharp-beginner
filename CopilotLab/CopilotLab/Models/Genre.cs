﻿namespace CopilotLab
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Genre: {Name}";
        }
    }
}
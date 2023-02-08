using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DoubleGameEngine.GameObjects
{
    /// <summary>
    /// Сущность на уровне
    /// </summary>
    public class Entity
    {
        [JsonPropertyName("Id")]
        public string Type { get; set; }
        [JsonPropertyName("Iid")]
        public string Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Dictionary<string, object> CustomFields { get; set; }
    }
}

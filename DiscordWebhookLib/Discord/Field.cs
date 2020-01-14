using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebhookLib.Discord
{
    /// <summary>
    /// Discord message filed is one object inside emdeb show data like "table" in DiscordMessage
    /// It's like submessage
    /// <param name="Name">Max length - 1024 characters</param>
    /// <param name="Value">Max length - 2048 characters</param>
    /// <param name="Inline">Not required</param>
    /// </summary>
    public class Field
    {
        public Field(string Name, string Value, bool Inline = false)
        {
            this.name = Name;
            this.value = Value;
            this.inline = Inline;
        }
        public string name { get; set; }
        public string value { get; set; }
        public bool inline { get; set; } = false;
    };
}

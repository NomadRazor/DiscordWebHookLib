using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebhookLib.Discord
{
    /// <summary>
    /// Discord message embed is one object of embeds in DiscordMessage
    /// It's like submessage
    /// <param name="Title">Max length - 256 characters</param>
    /// <param name="Description">Max length - 2048 characters</param>
    /// <param name="Fields">Max length - 25 objects of field</param>
    /// </summary>
    public class Embed
    {
        public Embed(string Title,string Description) : this(Title)
        {
            this.description = Description;
        }
        public Embed(string Title)
        {
            this.title = Title;
        }
        public string title { get; set; }
        public string description { get; set; } = default(string);
        public Field[] fields { get; set; }
    };
}

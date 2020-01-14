using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebhookLib.Discord
{
    public class DiscordMessage
    {
        /// <summary>
        /// Discord message embed is one object of embeds in DiscordMessage
        /// It's like submessage
        /// <param name="Content">Max length - 2000 characters, this is the message</param>
        /// <param name="Username">Override default webhook name</param>
        /// <param name="Embeds">Max length - 10 objects of embed</param>
        /// <remarks>More info in https://discordapp.com/developers/docs </remarks>
        /// </summary>
        public DiscordMessage(string Content,string Username = default)
        {
            this.content = Content;
            this.username = Username;
        }
        public string content { get; set; }
        public string username { get; set; }
        public Embed[] embeds { get; set; }
    };
}

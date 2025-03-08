using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using Oxide.Core.Libraries.Covalence;
using System.Linq;
using ConVar;
namespace Oxide.Plugins
{
    [Info("Server Announcer", "chay", "1.0.0")]
    [Description("Announces your message to the Server.")]
    class ServerAnnouncer : RustPlugin
    {
        private void OnServerInitialized()
        {
            AddCovalenceCommand("sa", "Say");
            permission.RegisterPermission("sa.use", this);
        }
        private void Say(IPlayer player, string command, string[] args)
        {
            string userMessage = string.Join(" ", args);
            if (!permission.UserHasPermission(player.Id, "sa.use"))
            {
                player.Reply("You do not have permission to do this.");
                return;
            }
            if (args.Length == 0)
            {
                player.Reply("You did not specify a message.");
                return;
            }
            foreach (var onlinePlayer in BasePlayer.activePlayerList)
            {
                onlinePlayer.ChatMessage($"<size=13><color=#FFA500>STAFF</color></size> : <size=20>{userMessage}</size>");
                return;
            }
        }
    }
}

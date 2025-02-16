using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using Oxide.Core.Libraries.Covalence;
using System.Linq;
namespace Oxide.Plugins
{
    [Info("Pop", "chay", "1.0.0")]
    [Description("Simple pop command to show how many players are in the Server.")]
    class Pop : RustPlugin
    {
        #region registering
        private void OnServerInitialized()
        {
            permission.RegisterPermission("pop.use", this);
            AddCovalenceCommand("ping", "PingPong");
            AddCovalenceCommand("pop", "PopCommand");
        }
        #endregion
        #region popcommand
        private void PopCommand(IPlayer player, string command, string[] args)
        {
            if (!permission.UserHasPermission(player.Id, "pop.use"))
            {
                player.Reply("You do not have permission to do this!");
                return;
            }
            int connectedPlayers = BasePlayer.activePlayerList.Count;
            int queuedPlayers = ServerMgr.Instance.connectionQueue.Queued;
            int joiningPlayers = ServerMgr.Instance.connectionQueue.Joining;
            int sleepingPlayers = BasePlayer.sleepingPlayerList.Count;
            int totalPlayers = connectedPlayers + queuedPlayers + joiningPlayers;
            int maxPlayers = ConVar.Server.maxplayers;
            player.Reply($"Total of <color=#FFA500>{totalPlayers}</color> players \n <color=#0FFFFFFF>{connectedPlayers}/{maxPlayers}</color> Connected | <color=#0FFFFFFF>{queuedPlayers}</color> Queued | <color=#0FFFFFFF>{joiningPlayers}</color> Joining | <color=#0FFFFFFF>{sleepingPlayers}</color> Sleepers");
        }
        #endregion
    }
}
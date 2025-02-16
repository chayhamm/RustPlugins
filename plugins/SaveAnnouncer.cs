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
    [Info("SaveAnnouncer", "chay", "1.0.0")]
    [Description("Announces to the Server when it is saving.")]
    class SaveAnnouncer : RustPlugin
    {
        private void OnServerSave()
        {
            foreach (var onlinePlayer in BasePlayer.activePlayerList)
            {
                onlinePlayer.ChatMessage("Server saving, expect some lag...");
            }
        }
    }
}
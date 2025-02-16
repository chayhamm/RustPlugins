using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Threading;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using Oxide.Core.Libraries.Covalence;
namespace Oxide.Plugins
{
    [Info("Wipe-Time", "chay", "1.0.0")]
    [Description("/Wipe command that says when your Server wipes.")]
    class WipeTime : RustPlugin
    {
        private void OnServerInitialized()
        {
            AddCovalenceCommand("wipe", "WipeCommand");
        }
        private void WipeCommand(IPlayer player, string command, string[] args)
        {
            player.Reply("The current <color=#FFA500>wipe</color> times are: \n <size=11><color=#FFA500>Mondays</color> and <color=#FFA500>Fridays</color> at <color=#FFA500>17:00pm</color></size> \n <size=10>Please note all wipe-times are in <color=#ADD8E6>GMT</color>");
        }
    }
}
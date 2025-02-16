using Newtonsoft.Json;
using UnityEngine;
using System;
using System.Collections.Generic;
using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Rust.Cui;
using Oxide.Core.Libraries.Covalence;
using System.Linq;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
namespace Oxide.Plugins
{
    [Info("Kill-Feed", "chay", "1.0.0")]
    [Description("Simple Kill-Feed to show your kills in the chat.")]
    class KillFeed : RustPlugin
    {
        private object OnPlayerDeath(BasePlayer player, HitInfo info)
        {
            var attacker = info.Initiator as BasePlayer;
            string attackerName = attacker?.displayName ?? "player";
            string victimName = player.displayName;
            string gun = info?.Weapon?.GetItem()?.info?.displayName?.english ?? "unkown";
            float distance = Vector3.Distance(attacker.transform.position, player.transform.position);
            string hitBone = info.boneName;
            attacker.ChatMessage($"You killed <color=#FFA500>{victimName}</color> | <color=#FFA500>{distance:F2}m</color> | <color=#FFA500>{gun}</color> | <color=#FFA500>{hitBone}</color>");
            player.ChatMessage($"You died to <color=#FFA500>{attackerName}</color> | <color=#FFA500>{distance:F2}m</color> | <color=#FFA500>{gun}</color> | <color=#FFA500>{hitBone}</color>");
            return null;
        }
    }
}
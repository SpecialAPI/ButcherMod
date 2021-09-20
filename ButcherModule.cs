using Dungeonator;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ButcherMod
{
    public class ButcherModule : ETGModule
    {
        public enum ButcherOptions
        {
            erase,
            eraseWithRewards,
            damage
        }

        public override void Init()
        {
        }

        public override void Exit()
        {
        }

        public override void Start()
        {
            try
            {
                ETGModConsole.Commands.AddGroup("butcher", (string[] args) => { Butcher(ButcherOptions.damage, null); });
                ETGModConsole.Commands.GetGroup("butcher").AddGroup("erase", (string[] args) => { Butcher(ButcherOptions.erase, null); });
                ETGModConsole.Commands.GetGroup("butcher").GetGroup("erase").AddUnit("rewards", (string[] args) => { Butcher(ButcherOptions.eraseWithRewards, null); });
                ETGModConsole.Commands.GetGroup("butcher").AddUnit("damage", (string[] args) => { Butcher(ButcherOptions.damage, args); });

                ETGModConsole.Log($"ButcherMod v{this.Metadata.Version} initialized");
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    ETGModConsole.Log(ex.Message);
                }
            }
        }

        private void Butcher(ButcherOptions option, string[] args)
        {
            if (GameManager.Instance?.PrimaryPlayer?.CurrentRoom != null)
            {
                RoomHandler currentRoom = GameManager.Instance.PrimaryPlayer.CurrentRoom;

                if (currentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.All))
                {
                    // create new list because enemies would get removed during iteration leading to an enumeration exception
                    // the usual approach of iterating in reverse could also fail because the death of one enemy could potentially trigger the removal of another in OnDeath
                    List<AIActor> enemyList = new List<AIActor>(currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All));

                    if (enemyList != null)
                    {
                        ETGModConsole.Log("Starting butcher...");

                        int numberOfButcheredEnemies = 0;

                        if (args == null || args.Length == 0 || string.IsNullOrEmpty(args[0]) || !float.TryParse(args[0], out float damageAmount))
                        {
                            damageAmount = int.MaxValue;
                        }

                        foreach (var aiActor in enemyList)
                        {
                            if (aiActor && aiActor.healthHaver && aiActor.healthHaver.IsAlive)
                            {
                                switch (option)
                                {
                                    case ButcherOptions.damage:

                                        aiActor.healthHaver.ApplyDamage(damageAmount, Vector2.zero, "butcher", CoreDamageTypes.None, DamageCategory.Unstoppable, true, null, false);
                                        break;

                                    case ButcherOptions.erase:
                                        aiActor.EraseFromExistence();
                                        break;

                                    case ButcherOptions.eraseWithRewards:
                                        aiActor.EraseFromExistenceWithRewards();
                                        break;
                                }

                                numberOfButcheredEnemies++;
                            }
                        }

                        ETGModConsole.Log($"Butcher finished. Butchered {numberOfButcheredEnemies} enemies.");
                    }
                    else
                    {
                        ETGModConsole.Log("Enemy list is null! Can't use butcher!");
                    }
                }
                else
                {
                    ETGModConsole.Log("Current room has no active enemies! Can't use butcher!");
                }
            }
            else
            {
                ETGModConsole.Log("CurrentRoom is null! Can't use butcher!");
            }
        }
    }
}
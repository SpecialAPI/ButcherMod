using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using UnityEngine;
using System.Text;
using Dungeonator;

namespace ButcherMod
{
    public class ButcherModule : ETGModule
    {

        public override void Init()
        {

        }

        public override void Start()
        {
            try
            {
                ETGModConsole.Log("ButcherMod enabled.");
                ETGModConsole.Commands.AddGroup("butcher", this.Butcher);
                ETGModConsole.Commands.GetGroup("butcher").AddGroup("erase", this.ButcherErase);
                ETGModConsole.Commands.GetGroup("butcher").GetGroup("erase").AddUnit("rewards", this.ButcherEraseRewards);
                ETGModConsole.Commands.GetGroup("butcher").AddUnit("damage", this.ButcherDamage);
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    ETGModConsole.Log(ex.Message);
                }
            }
        }

        public void Butcher(string[] args)
        {
            if (GameManager.Instance != null)
            {
                if (GameManager.Instance.PrimaryPlayer != null)
                {
                    PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
                    if (primaryPlayer.CurrentRoom != null)
                    {
                        RoomHandler currentRoom = primaryPlayer.CurrentRoom;
                        List<AIActor> enemyList = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                        if (enemyList != null)
                        {
                            if (currentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.All))
                            {
                                ETGModConsole.Log("Starting butcher...");
                                int i = 0;
                                foreach (AIActor aiactor in enemyList)
                                {
                                    if (aiactor.healthHaver.IsAlive)
                                    {
                                        aiactor.healthHaver.ApplyDamage(int.MaxValue, Vector2.zero, "Butcher", CoreDamageTypes.None, DamageCategory.Unstoppable, true, null, false);
                                        i += 1;
                                    }
                                }
                                ETGModConsole.Log("Butcher finished. Butchered " + i + " enemies.");
                            }
                            else
                            {
                                ETGModConsole.Log("Current room has no active enemies! Can't use butcher.");
                            }
                        }
                        else
                        {
                            ETGModConsole.Log("Enemies are null! Can't use butcher!");
                        }
                    }
                    else
                    {
                        ETGModConsole.Log("CurrentRoom is null! Can't use butcher!");
                    }
                }
                else
                {
                    ETGModConsole.Log("PrimaryPlayer is null! Can't use butcher!");
                }
            }
            else
            {
                ETGModConsole.Log("GameManager is null! Can't use butcher!");
            }
        }

        public void ButcherErase(string[] args)
        {
            if (GameManager.Instance != null)
            {
                if (GameManager.Instance.PrimaryPlayer != null)
                {
                    PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
                    if (primaryPlayer.CurrentRoom != null)
                    {
                        RoomHandler currentRoom = primaryPlayer.CurrentRoom;
                        List<AIActor> enemyList = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                        if (enemyList != null)
                        {
                            if (currentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.All))
                            {
                                ETGModConsole.Log("Starting butcher...");
                                int i = 0;
                                foreach (AIActor aiactor in enemyList)
                                {
                                    if (aiactor.healthHaver.IsAlive)
                                    {
                                        aiactor.EraseFromExistence();
                                        i += 1;
                                    }
                                }
                                ETGModConsole.Log("Butcher finished. Butchered " + i + " enemies.");
                            }
                            else
                            {
                                ETGModConsole.Log("Current room has no active enemies! Can't use butcher.");
                            }
                        }
                        else
                        {
                            ETGModConsole.Log("Enemies are null! Can't use butcher!");
                        }
                    }
                    else
                    {
                        ETGModConsole.Log("CurrentRoom is null! Can't use butcher!");
                    }
                }
                else
                {
                    ETGModConsole.Log("PrimaryPlayer is null! Can't use butcher!");
                }
            }
            else
            {
                ETGModConsole.Log("GameManager is null! Can't use butcher!");
            }
        }

        public void ButcherEraseRewards(string[] args)
        {
            if (GameManager.Instance != null)
            {
                if (GameManager.Instance.PrimaryPlayer != null)
                {
                    PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
                    if (primaryPlayer.CurrentRoom != null)
                    {
                        RoomHandler currentRoom = primaryPlayer.CurrentRoom;
                        List<AIActor> enemyList = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                        if (enemyList != null)
                        {
                            if (currentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.All))
                            {
                                ETGModConsole.Log("Starting butcher...");
                                int i = 0;
                                foreach (AIActor aiactor in enemyList)
                                {
                                    if (aiactor.healthHaver.IsAlive)
                                    {
                                        aiactor.EraseFromExistenceWithRewards();
                                        i += 1;
                                    }
                                }
                                ETGModConsole.Log("Butcher finished. Butchered " + i + " enemies.");
                            }
                            else
                            {
                                ETGModConsole.Log("Current room has no active enemies! Can't use butcher.");
                            }
                        }
                        else
                        {
                            ETGModConsole.Log("Enemies are null! Can't use butcher!");
                        }
                    }
                    else
                    {
                        ETGModConsole.Log("CurrentRoom is null! Can't use butcher!");
                    }
                }
                else
                {
                    ETGModConsole.Log("PrimaryPlayer is null! Can't use butcher!");
                }
            }
            else
            {
                ETGModConsole.Log("GameManager is null! Can't use butcher!");
            }
        }

        public void ButcherDamage(string[] args)
        {
            if (GameManager.Instance != null)
            {
                if (GameManager.Instance.PrimaryPlayer != null)
                {
                    PlayerController primaryPlayer = GameManager.Instance.PrimaryPlayer;
                    if (primaryPlayer.CurrentRoom != null)
                    {
                        RoomHandler currentRoom = primaryPlayer.CurrentRoom;
                        List<AIActor> enemyList = currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
                        if (enemyList != null)
                        {
                            if (currentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.All))
                            {
                                if (!string.IsNullOrEmpty(args[0]))
                                {
                                    float damageAmount = float.Parse(args[0]);
                                    ETGModConsole.Log("Starting damage...");
                                    int i = 0;
                                    foreach (AIActor aiactor in enemyList)
                                    {
                                        if (aiactor.healthHaver.IsAlive)
                                        {
                                            aiactor.healthHaver.ApplyDamage(damageAmount, Vector2.zero, "butcher", CoreDamageTypes.None, DamageCategory.Unstoppable, true, null, false);
                                            i += 1;
                                        }
                                    }
                                    ETGModConsole.Log("Damage finished. Damaged " + i + " enemies.");
                                }
                                else
                                {
                                    ETGModConsole.Log("You haven't entered damage amount! Can't use butcher.");
                                }
                            }
                            else
                            {
                                ETGModConsole.Log("Current room has no active enemies! Can't use butcher.");
                            }
                        }
                        else
                        {
                            ETGModConsole.Log("Enemies are null! Can't use butcher!");
                        }
                    }
                    else
                    {
                        ETGModConsole.Log("CurrentRoom is null! Can't use butcher!");
                    }
                }
                else
                {
                    ETGModConsole.Log("PrimaryPlayer is null! Can't use butcher!");
                }
            }
            else
            {
                ETGModConsole.Log("GameManager is null! Can't use butcher!");
            }
        }

        public override void Exit()
        {

        }
    }
}

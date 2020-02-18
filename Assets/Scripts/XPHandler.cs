using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;

    }

    private void OnDisable()
    {
    }

    public void GainXP(BattleResultEventData data)
    {
        int initialxp = 0;
        if (data.outcome > 0)
        {
        print("xd");
            data.player.xp += 25;
            GameEvents.PlayerXPGain(25);
        }

        int xprequired = data.player.level * 250 + initialxp;

        if (data.player.xp >= xprequired)
        {
         data.player.xp = 0;
        data.player.level += 1;
        GameEvents.PlayerLevelUp(data.player.level);
                
        }
                
                //GameEvents.PlayerXPGAIN(100); << TO MAKE IT APPEAR ON THE SCREEN
                //GameEvents.PlayerLevelUp(1);
                
            
                

    }

}

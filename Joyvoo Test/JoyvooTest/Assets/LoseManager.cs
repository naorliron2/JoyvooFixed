using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseManager : MonoSingleton<LoseManager>
{
    /// <summary>
    /// Sets player as the winner
    /// </summary>
    /// <param name="playerThatLost"></param>
    public void Winner(Player playerThatLost)
    {
        //right now there is only one line here, but in the future we might want some logic that is disconnected from the UI
        IngameUiManager.instance.OpenLossScreen(playerThatLost.gameObject.name + " has emerged victorious!");
    }    
}

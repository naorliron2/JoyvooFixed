using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTile : TileBASE
{
    [SerializeField] uint rewardAmount;
    public override void LandedOn(Player playerThatLanded)
    {
        playerThatLanded.AddMoney(rewardAmount);
    }

    public override void PassedBy(Player playerThatLanded)
    {
        if (PlayerManager.instance.turnCount <= 2) { return; }

            playerThatLanded.AddMoney(rewardAmount);
        IngameUiManager.instance.PopUp("Passed by start, gained " + rewardAmount + "$");


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingTile : TileBASE
{
    [Header("Variable")]
    [SerializeField] uint rewardAmount;
    public override void LandedOn(Player playerThatLanded)
    {
        //add the start reward amount
        playerThatLanded.AddMoney(rewardAmount);
        IngameUiManager.instance.PopUp("Landed on start, gained " + rewardAmount + "$");

    }

    public override void PassedBy(Player playerThatLanded)
    {
        //if it isnt the first two turns
        if (PlayerManager.instance.turnCount <= 2) { return; }
        //add the start reward amount
        playerThatLanded.AddMoney(rewardAmount);
        IngameUiManager.instance.PopUp("Passed by start, gained " + rewardAmount + "$");


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraRollTile : TileBASE
{
    public override void LandedOn(Player playerThatLanded)
    {
        IngameUiManager.instance.PopUp(playerThatLanded.gameObject.name + " gets to roll the dice again");
        PlayerManager.instance.PlayTurn();
    }



}

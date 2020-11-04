using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyTile : TileBASE
{
    [Header("Variables")]
    [SerializeField] uint Cost;
    [Header("References")]
    [SerializeField] GameObject ownedByBlue;
    [SerializeField] GameObject ownedByRed;
    [Header("Debug Info")]
    [SerializeField] Player ownedBy;

    private const double FINE_PRECENTAGE = 0.5;

    public override void LandedOn(Player playerThatLanded)
    {
        //if the land has no ownership yet
        if (ownedBy == null)
        {
            SetupOwnershipLogic(playerThatLanded);
        }
        else
        {
            FinePlayer(playerThatLanded);
        }

    }
    //Buys the plot of land for the player
    private void SetupOwnershipLogic(Player playerThatLanded)
    {
        //if the player can afford the land
        if (Cost < playerThatLanded.getMoney())
        {
            //Applies the ownership and color
            ApplyOwnership(playerThatLanded);
            //subtract the cost from the player
            playerThatLanded.SubtractMoney(Cost);
            //pop up a message
            IngameUiManager.instance.PopUp("Sold! to " + PlayerManager.instance.currentPlayer.gameObject.name + " for " + Cost + "$");
        }
    }
    //checks which player the land is owned by and fines the player
    private void FinePlayer(Player playerThatLanded)
    {
        //if the player that landed on the tile owns it, do nothing;
        if (ownedBy == playerThatLanded) return;


        //Pop up a message
        IngameUiManager.instance.PopUp("Not your property, owner gains " + Cost * FINE_PRECENTAGE + "$");
        //check on all players, whoever owns the land gains money, everyone else loses money
        foreach (var player in PlayerManager.instance.players)
        {
            if (player == playerThatLanded)
            {
                player.SubtractMoney((uint)(Cost * FINE_PRECENTAGE));
            }
            else
            {
                player.AddMoney((uint)(Cost * FINE_PRECENTAGE));
            }
        }

    }


    //Applies the ownership and color
    void ApplyOwnership(Player PlayerToOwn)
    {

        ownedBy = PlayerToOwn;
        //check which color we need to change to
        switch (PlayerToOwn.playerColor)
        {
            case playerColor.blue:
                ownedByBlue.SetActive(true);
                break;
            case playerColor.red:
                ownedByRed.SetActive(true);
                break;
            default:
                break;
        }
    }

}

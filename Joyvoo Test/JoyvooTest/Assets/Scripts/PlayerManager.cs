using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public Player[] players;
    public Player currentPlayer;
    int playerIndex = 0;
    public int turnCount = 0;
    int lostPlayers;
    /// <summary>
    /// Rolls the dice for the next player
    /// </summary>
    public void PlayTurn()
    {
        //check if the current player has ended his movement
        if (currentPlayer.IsMoving()) { return; }
        //if he did, roll the dice
        DiceRoller.instance.Roll();

    }
    /// <summary>
    /// Changes the turn between players
    /// </summary>
    public void ChangeTurn()
    {
        if (currentPlayer.IsMoving()) return;
        //Add turn counter
        turnCount++;
        //Add one to the player index, we then modulo the player index, if we have reached array overload, the result will be 0, if not, the result will be the original index +1 
        playerIndex = (playerIndex + 1) % players.Length;
        //set current player to the new index
        currentPlayer = players[playerIndex];
        //check for all players whos playing now, and set playing now based on that
        foreach (var player in players)
        {
            if (player == currentPlayer)
            {
                player.setPlayingNow(true);
            }
            else
            {
                player.setPlayingNow(false);
            }
        }
    }

    private void Start()
    {
        currentPlayer = players[playerIndex];
    }
    /// <summary>
    /// Updates the manager that a certain player has lost
    /// </summary>
    public void UpdateLoss()
    {
        lostPlayers++;
    }
    private void Update()
    {
        CheckForAWinner();
    }

    private void CheckForAWinner()
    {
        //if there is only one player left that hasnt lost
        if (players.Length - lostPlayers == 1)
        {
            //reference a player
            Player winner = null;
            //check all player, and see which one is the winner
            foreach (var player in players)
            {
                if (!player.CheckForLoss())
                {
                    winner = player;
                    break;
                }
            }
            //Declare the winner
            LoseManager.instance.Winner(winner);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public Player[] players;
    public Player currentPlayer;
    int playerIndex = 0;
    public int turnCount = 0;
    public void PlayTurn()
    {
        if (currentPlayer.IsMoving()) { return; }
        DiceRoller.instance.Roll();

    }
   

    public void ChangeTurn()
    {
        turnCount++;
        playerIndex++;

        if (playerIndex == players.Length)
            playerIndex = 0;

        currentPlayer = players[playerIndex];
        foreach (var player in players)
        {
            if(player == currentPlayer)
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayTurn();
        }
    }
}

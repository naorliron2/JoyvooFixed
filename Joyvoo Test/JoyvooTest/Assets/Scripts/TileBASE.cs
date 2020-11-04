using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileBASE : MonoBehaviour
{
    [Tooltip("This is a reference to the next tile the player will move to")]
    public TileBASE nextTile;
    public Transform tileTransform;
    private void Awake()
    {
        tileTransform = GetComponent<Transform>();
    }
    /// <summary>
    /// Gets called when the player has landed on a the tile
    /// </summary>
    /// <param name="playerThatLanded"></param>
    public abstract void LandedOn(Player playerThatLanded);
    /// <summary>
    /// Gets called when the player has passed through the tile
    /// </summary>
    /// <param name="playerThatLanded"></param>
    public virtual void PassedBy(Player playerThatLanded) { }

}

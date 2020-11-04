using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileBASE : MonoBehaviour
{
    public abstract void LandedOn(Player playerThatLanded);
    public abstract void PassedBy(Player playerThatLanded);

    public TileBASE nextTile;
}
enum TileType{StartingPoint, Reward, Property}
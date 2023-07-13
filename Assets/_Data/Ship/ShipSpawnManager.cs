using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawnManager : ShipsManagerAbstract
{
    protected virtual void SpawnShips()
    {
        this.shipsManager.SpawnShips();
    }
}

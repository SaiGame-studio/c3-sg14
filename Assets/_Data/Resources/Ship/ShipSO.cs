using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "SO/Ship")]
public class ShipSO : ScriptableObject
{
    public string shipName = "Ship";
    public int hpMax = 2;
}

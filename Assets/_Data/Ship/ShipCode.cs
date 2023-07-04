using System;
using UnityEngine;

public enum ShipCode
{
    NoShip = 0,

    Fighter = 1,
    Healer = 2,
    Miner = 3,
    Tanker = 4,
}

public class ShipCodeParser
{
    public static ShipCode FromString(string name)
    {
        try
        {
            return (ShipCode)System.Enum.Parse(typeof(ShipCode), name);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ShipCode.NoShip;
        }
    }
}
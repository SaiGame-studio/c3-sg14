using UnityEngine;

public abstract class EnemyShipsAbstact : ShipManagerAbstact
{
    [Header("Enemy Ships Abstact")]
    public int dummy = 1;
    public EnemyShipsCtrl enemyShipsCtrl => this.shipManagerCtrl as EnemyShipsCtrl;
}

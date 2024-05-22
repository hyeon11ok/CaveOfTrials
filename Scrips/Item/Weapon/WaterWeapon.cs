using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWeapon : Weapon
{
    private float slowPer = 0.2f;
    private float slowTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        slowTime += (0.5f * (int)weaponRank);
        slowPer += (0.1f * (int)weaponRank);
    }

    public override void AttackDamage(Enemy enemy) {
        base.AttackDamage(enemy);
        StartCoroutine(SlowDown(enemy));
    }

    IEnumerator SlowDown(Enemy enemy) {
        enemy.SetSpeedDownPer(slowPer);
        yield return new WaitForSeconds(slowTime);
        enemy.SetSpeedDownPer(0);
    }
}

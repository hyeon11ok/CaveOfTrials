using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWeapon : Weapon {
    private float exDmgPer = 0.2f; // 추가 데미지 발동 확률

    // Start is called before the first frame update
    void Start()
    {
        exDmgPer += (0.2f * Mathf.Pow((float)weaponRank, 2));
    }

    public override void AttackDamage(Enemy enemy) {
        base.AttackDamage(enemy);
        float random = Random.Range(0.0f, 1.0f);
        if(random <= exDmgPer && enemy is Attackable) {
            Attackable attackable = (Attackable)enemy;
            attackable.GetDamaged(damage / 2);
        }
    }
}

using ItemEnum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : Weapon {
    private float fireDmg = 4; // 불속성 데미지
    private float damageTerm = 0.7f; // 데미지 간격 ex) 1.5초당 한 번 데미지
    private int damageCnt = 5; // 데미지 횟수

    // Start is called before the first frame update
    void Start() {
        damageCnt *= ((int)weaponRank + 1);
    }

    public override void AttackDamage(Enemy enemy) {
        base.AttackDamage(enemy);
        if (enemy is Attackable) {
            Attackable attackable = (Attackable)enemy;
            StartCoroutine(FireDamage(attackable));
        }
    }

    IEnumerator FireDamage(Attackable enemy) {
        int cnt = 0;
        while (cnt < damageCnt) {
            enemy.GetDamaged(fireDmg);
            cnt++;
            yield return new WaitForSeconds(damageTerm);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnemyEnum;

public abstract class Attackable : Enemy {
    [SerializeField] protected float hp;
    protected float curHp;

    public void GetDamaged(float damage) {
        if (curHp > damage) {
            curHp -= damage;
        } else {
            curHp = 0;
            // »ç¸Á Ã¼Å©
            eState = EnemyState.Death;
        }
    }
}


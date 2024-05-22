using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemEnum;

public class Weapon : Item
{
    [SerializeField] protected float damage;
    [SerializeField] protected WeaponRank weaponRank;

    public virtual void AttackDamage(Enemy enemy) {
        if (enemy is Attackable) {
            Attackable attackable = (Attackable)enemy;
            attackable.GetDamaged(damage);
        }
    }
}

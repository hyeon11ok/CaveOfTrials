using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyEnum {
    public abstract class Attackable : Enemy {
        protected float hp;

        public abstract void GetDamaged(float damage);
    }
}


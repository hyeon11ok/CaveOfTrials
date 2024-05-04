using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyEnum {
    public class Skelleton : Sentinel {

        private void Start() {
            InitStatus();
        }

        public override void InitStatus() {
            atkDmg = 10;
            moveSpeed = 2;
            atkRange = 3f;
            sightRange = 15;
            hp = 20;
            agent = gameObject.GetComponent<NavMeshAgent>();

            // 테스트용
            pivotPos = Vector3.zero;
            spawnPos = transform.position;
        }

        public override void Attack() {

        }

        public override void GetDamaged(float damage) {

        }

        public override void UpdateState() {
            
        }
    }

}

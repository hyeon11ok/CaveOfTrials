using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyEnum {
    public class Imoogi : Prowler {
        void Start() {
            InitStatus();
        }

        void Update() {
            TargetSearch();
            Move();
        }

        public override void InitStatus() {
            atkDmg = 10;
            moveSpeed = 2;
            chaseSpeed = 3.5f;
            atkRange = 3f;
            sightRange = 10;
            agent = gameObject.GetComponent<NavMeshAgent>();
        }

        public override void Attack() {
            agent.isStopped = true;
            Debug.Log("Attack");
        }

        public override void UpdateState() {
            throw new System.NotImplementedException();
        }
    }
}


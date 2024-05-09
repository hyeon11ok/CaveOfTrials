using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyEnum {
    public class FireGhost : Prowler {
        // Start is called before the first frame update
        void Start() {
            InitStatus();
        }

        // Update is called once per frame
        void Update() {
            TargetSearch();
            //Move();
        }

        public override void Attack() {
            throw new System.NotImplementedException();
        }

        public override void InitStatus() {
            atkDmg = 10;
            moveSpeed = 2;
            chaseSpeed = 3.5f;
            atkRange = 1f;
            sightRange = 5;
            agent = gameObject.GetComponent<NavMeshAgent>();
        }

        public override void UpdateState() {
            throw new System.NotImplementedException();
        }
    }
}


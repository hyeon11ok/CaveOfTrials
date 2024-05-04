using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

namespace EnemyEnum {
    public class BronzeRelics : Chaser {
        // Start is called before the first frame update
        void Start() {
            InitStatus();
            TargetSearch();
        }

        // Update is called once per frame
        void Update() {
            Move();
        }

        public override void InitStatus() {
            atkDmg = 10;
            moveSpeed = 4;
            atkRange = 6f;
            sightRange = 0;
            hp = 30;
            agent = gameObject.GetComponent<NavMeshAgent>();
        }

        public override void GetDamaged(float damage) {
            throw new System.NotImplementedException();
        }

        public override void Attack() {
            throw new System.NotImplementedException();
        }

        public override void UpdateState() {
            throw new System.NotImplementedException();
        }
    }

}

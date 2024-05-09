using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace EnemyEnum {
    public class Chaser : Attackable {
        protected Transform target_tr;

        void Start() {
            agent = gameObject.GetComponent<NavMeshAgent>();
            TargetSearch();
        }

        private void Update() {
            UpdateState();
        }

        public override void Attack() {
            throw new System.NotImplementedException();
        }

        public override void UpdateState() {
            switch (eState) {
                case EnemyState.Chase: {
                        Move(target_tr.position);
                        Rotate(target_tr.position);
                        if (GetDist(target_tr.position) <= atkRange) {
                            eState = EnemyState.Attack;
                            agent.isStopped = true;
                        }
                    }
                    break;
                case EnemyState.Attack: {
                        Rotate(target_tr.position);
                        // 현재 애니메이션이 공격이고 거의 끝나는 지점일 경우
                        if (eAnim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack") && eAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f) {
                            if (GetDist(targetPos) > atkRange) {
                                eState = EnemyState.Chase;
                                agent.isStopped = false;
                            }
                        }
                    }
                    break;
                case EnemyState.Death: {

                    }
                    break;
            }

            UpdateAnimState();
        }

        public override void OnDrawGizmos() {
            // 공격 범위 표시
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, atkRange);
        }

        public override void TargetSearch() {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            if (target_tr == null) {
                int idx = Random.Range(0, players.Length);
                target_tr = players[idx].transform;
            }
        }
    }
}


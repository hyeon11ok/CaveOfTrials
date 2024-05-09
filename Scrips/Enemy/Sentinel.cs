using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyEnum {
    public class Sentinel : Attackable {
        protected Vector3 pivotPos;
        protected Vector3 spawnPos;

        public Vector3 PivotPos { set { pivotPos = value; } }
        public Vector3 SpawnPos { set { spawnPos = value; } }

        private void Start() {
            agent = GetComponent<NavMeshAgent>();
            eAnim = GetComponent<Animator>();
            eState = EnemyState.Idle;

            // 테스트용
            pivotPos = Vector3.zero;
            spawnPos = transform.position;
        }

        private void Update() {
            TargetSearch();
            UpdateState();
        }

        public override void Attack() {

        }

        public override void UpdateState() {
            switch (eState) {
                case EnemyState.Idle: {
                        if (isChase)
                            eState = EnemyState.Chase;
                    }
                    break;
                case EnemyState.Move: {
                        Move(spawnPos);
                        Rotate(spawnPos);
                        if (isChase)
                            eState = EnemyState.Chase;
                        else if (GetDist(spawnPos) <= 0.2f)
                            eState = EnemyState.Idle;
                    }
                    break;
                case EnemyState.Chase: {
                        Move(targetPos);
                        Rotate(targetPos);
                        if (!isChase)
                            eState = EnemyState.Move;
                        if (GetDist(targetPos) <= atkRange) {
                            eState = EnemyState.Attack;
                            agent.isStopped = true;
                        }
                    }
                    break;
                case EnemyState.Attack: {
                        Rotate(targetPos);
                        // 현재 애니메이션이 공격이고 거의 끝나는 지점일 경우
                        if (eAnim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack") && eAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f) {
                            if (!isChase)
                                eState = EnemyState.Move;
                            else if (GetDist(targetPos) > atkRange) {
                                eState = EnemyState.Chase;
                            }
                            agent.isStopped = false;
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
            // 인식 범위 표시
            Gizmos.color = Color.gray;
            Gizmos.DrawWireSphere(pivotPos, sightRange);

            // 공격 범위 표시
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, atkRange);
        }

        public override void TargetSearch() {
            int playerLayermask = 1 << 6; // 6번 레이어마스크를 플레이어로 설정
            Collider[] colls = Physics.OverlapSphere(pivotPos, sightRange, playerLayermask); // 스포너 기준으로 일정 범위 안에 들어오는 플레이어 탐색

            if (colls.Length > 0) {
                targetPos = colls[0].transform.position;
                isChase = true;
            } else {
                isChase = false;
            }
        }
    }
}


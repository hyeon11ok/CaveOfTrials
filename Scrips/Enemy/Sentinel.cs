using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyEnum {
    public abstract class Sentinel : Attackable {
        protected Vector3 pivotPos;
        protected Vector3 spawnPos;

        public Vector3 PivotPos { set { pivotPos = value; } }
        public Vector3 SpawnPos { set { spawnPos = value; } }

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

        public override void Move() {
            if (isChase) {
                agent.speed = moveSpeed;
                agent.SetDestination(targetPos);
            } else {
                agent.SetDestination(spawnPos);
            }
        }
    }
}


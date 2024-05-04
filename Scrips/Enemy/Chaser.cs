using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace EnemyEnum {
    public abstract class Chaser : Attackable {
        Transform target_tr;

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

        public override void Move() {
            if (target_tr != null) {
                agent.speed = moveSpeed;
                agent.SetDestination(target_tr.position);
            } else {
                // 플레이어를 재탐색 후에도 없으면 정지
                TargetSearch();
                if (target_tr == null)
                    agent.isStopped = true;
            }
        }
    }
}


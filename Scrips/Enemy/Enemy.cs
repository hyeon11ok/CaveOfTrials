using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyEnum {
    public abstract class Enemy : MonoBehaviour {
        protected float atkDmg;
        protected float moveSpeed;
        protected float atkRange;
        protected float sightRange;
        protected Vector3 targetPos;
        protected bool isChase = false;
        protected NavMeshAgent agent;
        protected EnemyState eState = EnemyState.Idle;

        public abstract void InitStatus();
        public abstract void TargetSearch();
        public abstract void Move();
        public abstract void Attack();
        public abstract void OnDrawGizmos();
        public float GetDist(Vector3 target) {
            return Vector3.Distance(transform.position, target);
        }
        public abstract void UpdateState();
    }
}
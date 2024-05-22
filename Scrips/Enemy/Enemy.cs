using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using EnemyEnum;

public abstract class Enemy : MonoBehaviour {
    [SerializeField] protected float atkDmg;
    protected float speed; // 실제 대입될 속도
    protected float speedDownPer = 0; // 슬로우 퍼센트 (0.0 ~ 1.0)
    [SerializeField] protected float moveSpeed; // 기본 이동 속도
    [SerializeField] protected float atkRange;
    [SerializeField] protected float sightRange;
    protected Vector3 targetPos;
    protected bool isChase = false;
    protected NavMeshAgent agent;
    protected EnemyState eState = EnemyState.Idle;
    protected Animator eAnim;

    public abstract void TargetSearch();
    public void Move(Vector3 pos) {
        agent.speed = speed - (speed * speedDownPer);
        agent.SetDestination(pos);
    }

    public void Rotate(Vector3 pos) {
        Vector3 dir = pos - transform.position;
        dir.Normalize();
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }
    public abstract void Attack();
    public abstract void OnDrawGizmos();
    public float GetDist(Vector3 target) {
        return Vector3.Distance(transform.position, target);
    }
    public abstract void UpdateState();
    public void UpdateAnimState() {
        eAnim.SetInteger("EnemyState", (int)eState);
    }
    public void SetSpeedDownPer(float per) {
        speedDownPer = per;
    }
}
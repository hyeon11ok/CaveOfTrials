using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected string itemName;
    [SerializeField] private Sprite icon; // 아이템 이미지

    public Sprite Icon { get { return icon; } }

    // 아이템 획득 기능
    // 위치를 손으로 바꿔주고 아이템 꺼주기
    public void GetItem(Transform handPos) {
        transform.position = handPos.position;
        transform.rotation = handPos.rotation;
        enabled = false;
    }

    // 아이템 버리기 기능
    // 위치를 플레이어 위치 바닥으로 바꿔주고 아이템 켜주기
    public void DropItem(Transform dropPos) {
        transform.position = dropPos.position;
        transform.rotation = dropPos.rotation;
        enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Inventory inven;

    private void Start() {
        inven = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        // 일시 정지, 설정 팝업
        if (Input.GetKeyDown(KeyCode.Escape)) {

        }
        // 아이템 줍기
        if (Input.GetKeyDown(KeyCode.F)) {
            int itemLayer = 1 << 7;
            Collider[] items = Physics.OverlapSphere(transform.position, 1f, itemLayer); // 플레이어 오브젝트 중심부터 0.5거리 안에 있는 아이템 탐색
            if (items.Length > 0) {
                inven.GetItem(items[0].GetComponent<Item>());
            }
        }
        // 아이템 버리기
        if (Input.GetKeyDown(KeyCode.Q)) {
            inven.DropItem();
        }
        // 퍼즐 상호작용
        if (Input.GetKeyDown(KeyCode.E)) {

        }
        // 기본 공격
        if (Input.GetKeyDown(KeyCode.Mouse0)) {

        }
        // 특수 공격(레전드 등급 무기만 가능) / 물약 아이템 사용
        if (Input.GetKeyDown(KeyCode.Mouse1)) {

        }

        // 인벤토리 단축키 1~4
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            inven.ChangeSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            inven.ChangeSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            inven.ChangeSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            inven.ChangeSlot(3);
        }

        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        if (wheelInput > 0f) {
            inven.PrevSlot();
        } else if(wheelInput < 0f) {
            inven.NextSlot();
        }
    }
}

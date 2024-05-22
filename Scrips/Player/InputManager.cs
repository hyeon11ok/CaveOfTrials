using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void GetItemEvent(Item item);
    public static event GetItemEvent GetItem;
    public delegate void DropItemEvent();
    public static event DropItemEvent DropItem;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 일시 정지, 설정 팝업
        if (Input.GetKeyDown(KeyCode.Escape)) {

        }
        // 아이템 줍기
        if (Input.GetKeyDown(KeyCode.F)) {
            int itemLayer = 1 >> 7;
            Collider[] items = Physics.OverlapSphere(player.transform.position, 0.5f, itemLayer); // 플레이어 오브젝트 중심부터 0.5거리 안에 있는 아이템 탐색
            if(items.Length > 0) {
                GetItem(items[0].GetComponent<Item>());
            }
        }
        // 아이템 버리기
        if (Input.GetKeyDown(KeyCode.Q)) {
            DropItem();
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
    }
}

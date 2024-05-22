using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Player player;
    Slot[] slots = new Slot[4];
    int curSlotIdx = 0; // 현재 슬롯의 인덱스
    Slot curSlot;
    [SerializeField] RectTransform slotFocusTr; // 현재 슬롯을 표시하기 위한 UI
    Vector3 focusVel = Vector3.zero; // 포커스 이미지의 속도 변화량 기록 변수

    public Slot CurSlot { get { return curSlot; } }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InputManager.GetItem += GetItem;
        InputManager.DropItem += DropItem;
    }

    private void Update() {
        ChangeSlotFocus();
    }

    void CurSlotUpdate() {
        curSlot.ItemActiveChange(false);
        curSlot = slots[curSlotIdx];
        curSlot.ItemActiveChange(true);
    }

    public void SetSlotInfo() {
        for(int i = 0; i < transform.childCount; i++) {
            slots[i] = transform.GetChild(i).GetComponent<Slot>();
            slots[i].InitSlot();
        }
        CurSlotUpdate();
    }

    // 마우스 휠로 다음 슬롯으로 바꾸는 경우 현재 슬롯의 인덱스만 바꿔준다
    public void NextSlot() {
        if(curSlotIdx == slots.Length - 1) { // 현재 슬롯이 마지막 슬롯일 경우
            curSlotIdx = 0;
            return;
        }
        curSlotIdx++;
        CurSlotUpdate();
    }

    // 마우스 휠로 다음 슬롯으로 바꾸는 경우 현재 슬롯의 인덱스만 바꿔준다
    public void PrevSlot() {
        if (curSlotIdx == 0) { // 현재 슬롯이 첫번째 슬롯일 경우
            curSlotIdx = slots.Length - 1;
            return;
        }
        curSlotIdx--;
        CurSlotUpdate();
    }

    // 단축키로 슬롯으로 바꾸는 경우 현재 슬롯의 인덱스만 바꿔준다
    public void ChangeSlot(int idx) {
        if(idx >= 0 && idx < slots.Length) {
            curSlotIdx = idx;
        }
        CurSlotUpdate();
    }

    // 슬롯 포커스 이미지를 현재 슬롯의 위치로 이동
    void ChangeSlotFocus() {
        slotFocusTr.position = Vector3.SmoothDamp(slotFocusTr.position, slots[curSlotIdx].transform.position, ref focusVel, 1f);
    }

    public void GetItem(Item item) {
        if (!curSlot.HasItem()) { // 현재 슬롯이 빈 슬롯일 경우에만 줍기 가능
            curSlot.AddItem(item);
            item.transform.position = player.ItemPivot.position;
            item.transform.rotation = Quaternion.identity;
        }
    }

    public void DropItem() {
        if(curSlot.HasItem()) {
            Item drop = curSlot.DropItem();
            drop.transform.position = player.transform.position;
            Quaternion dropRot = drop.transform.rotation;
            dropRot.x = 90;
            drop.transform.rotation = dropRot;
        }
    }
}

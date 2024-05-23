using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    Item item; // 슬롯에 등록된 아이템 정보
    Image itemIconImg; // 등록될 아이템의 아이콘이 보여질 UI

    private void Start() {
        InitSlot();
    }

    // 슬롯 최초 초기화
    public void InitSlot() {
        item = null;
        itemIconImg = transform.GetChild(0).GetComponent<Image>();
        SetColor(0);
    }

    private void SetColor(float _alpha) {
        Color color = itemIconImg.color;
        color.a = _alpha;
        itemIconImg.color = color;
    }

    // 인벤토리에 새로운 아이템 슬롯 추가
    public void AddItem(Item _item) {
        if(item == null) {
            item = _item;
            itemIconImg.sprite = item.Icon;
            SetColor(1);
        }
    }

    public Item DropItem() {
        Item dropItem = item;
        item = null;
        itemIconImg.sprite = null;
        SetColor(0);

        return dropItem;
    }

    public void ItemActiveChange(bool active) {
        if(item != null) {
            item.gameObject.SetActive(active);
        }
    }

    public bool HasItem() {
        return item != null;
    }
}

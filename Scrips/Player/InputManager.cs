using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
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

        }
        // 아이템 버리기
        if (Input.GetKeyDown(KeyCode.Q)) {

        }
        // 퍼즐 상호작용
        if (Input.GetKeyDown(KeyCode.E)) {

        }
        // 기본 공격
        if (Input.GetKeyDown(KeyCode.Mouse0)) {

        }
        // 특수 공격(레전드 등급 무기만 가능)
        if (Input.GetKeyDown(KeyCode.Mouse1)) {

        }
    }
}

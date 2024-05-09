using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float walkSpeed = 3;
    private float runSpeed = 5;
    private float rotDamp = 6;
    private CharacterController cc;
    private PlayerManager pm;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        pm = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;
            pm.isUsingStamina = true;
            pm.UseStamina(10);
        } else {
            speed = walkSpeed;
            pm.isUsingStamina = false;
        }

        Vector3 dir = new Vector3(h, 0, v) * speed;
        cc.Move(dir * Time.deltaTime);
        PlayerRotate(dir);
    }

    private void PlayerRotate(Vector3 dir) {
        if(dir !=  Vector3.zero) {
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * rotDamp);
        }
    }
}

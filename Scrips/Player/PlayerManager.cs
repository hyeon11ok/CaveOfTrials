using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float hp;
    private float curHp;
    private float stamina;
    private float curStamina;
    private float staminaCharge;
    public bool isUsingStamina = false;

    public float CurHp { get { return hp; } }
    public float CurStamina { get {  return stamina; } }

    private void Update() {
        ChargeStamina();
    }

    public void GetDamaged(float dmg) {
        if(curHp >= dmg) {
            curHp -= dmg;
        } else {
            curHp = 0;
        }
    }

    public bool UseStamina(float u_stamina) {
        if (curStamina >= stamina) { 
            curStamina -= u_stamina;
            return true;
        } else {
            curStamina = 0;
            return false;
        }
    }

    private void ChargeStamina() {
        if (!isUsingStamina && curStamina < stamina) {
            curStamina += staminaCharge * Time.deltaTime;
            if (curStamina > stamina)
                curStamina = stamina;
        }
    }
}

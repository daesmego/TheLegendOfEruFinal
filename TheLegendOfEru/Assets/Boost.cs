using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
  private float speed;
  private float _normalSpeed = 3f;
  private float _speedBoost = 40f;
  private float _speedBoostDuration = 5;


 public void ActivateSpeedBoost()
     {
       {
         StartCoroutine(SpeedBoostCooldown());
       }

       IEnumerator SpeedBoostCooldown()
       {
         speed = _speedBoost;
         yield return new WaitForSeconds(_speedBoost);
         speed = _normalSpeed;
       }
     }

     void OnTriggerEnter2D(Collider2D collision)
     {
       if(collision.tag == "pocion")
       {
         // GetComponent(Player0).ActivateSpeedBoost();
         ActivateSpeedBoost();
       }
     }
}

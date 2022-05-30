using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour

{
  public int maxHealth = 5;
  public double currentHealth;

  void TakeDamage(double amount)
  {
    currentHealth -= amount;

    if(currentHealth <= 0)
    {
      Destroy(gameObject);
    }

  }

    public void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Player0")
    {
      var currentHealth = collision.GetComponent<Health>();
        if(currentHealth != null)
        {
          currentHealth.TakeDamage(0.5);
        }
    }
  }
}

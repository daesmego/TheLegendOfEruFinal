using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  public int maxHealth = 5;
  public double currentHealth;


  void Start()
  {
    currentHealth = maxHealth;
  }

  public void TakeDamage(double amount)
  {
    currentHealth -= amount;

    if(currentHealth <= 0)
    {
      Destroy(gameObject);
    }

  }




    // Start is called before the first frame update


}

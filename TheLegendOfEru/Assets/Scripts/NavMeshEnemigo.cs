using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemigo : MonoBehaviour
{
  public Transform objetivo;
  private NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter2D (Collider2D other)
    {
      if (other.gameObject.tag == "Player0");
      {
        agente.destination = objetivo.position;
      }

    }
}

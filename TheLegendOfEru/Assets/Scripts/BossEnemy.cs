using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BossEnemy : MonoBehaviour
{
    public AIPath pathfindingEnemy;
    public Transform boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pathfindingEnemy.desiredVelocity.x >= (0.01f))
        {
            boss.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (pathfindingEnemy.desiredVelocity.x <= (-0.01f))
        {
            boss.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}

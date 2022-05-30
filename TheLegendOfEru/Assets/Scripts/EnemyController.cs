using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyController : MonoBehaviour
{
    
    public Transform boss;
    public Transform targetPlayer;
    public float speed = 1;
    public float nextWayPointDistance = 3f;
    Path pathfollowing;
    public int currentWayPoint = 0;
    public bool reachEndOfPath = false;
    Seeker seeker;
    public Rigidbody2D rigitEnemy;
    public Vector2 directionEnemy;
    public Vector2 force;
    public float dintanceEnemy;
    // Start is called before the first frame update
    void Start()
    {
        seeker= GetComponent<Seeker>();
       
        InvokeRepeating("UpdatePat", 0f, 2f);
    }

    public void UpdatePath() {
        if (seeker.IsDone())
        {
            seeker.StartPath(rigitEnemy.position, targetPlayer.position, OnPathComplete);

        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(force.x >= (0.01f))
        {
            boss.localScale = new Vector3(-1f, 1f, 1f);
        }else if(force.x <= (-0.01f)){
            boss.localScale = new Vector3(1f, 1f, 1f);
        }

        if (pathfollowing == null) {
            return;
        }

        if (currentWayPoint >= pathfollowing.vectorPath.Count)
        {
            reachEndOfPath = true;
            return;
        }
        else {
            reachEndOfPath = false;
        }
        directionEnemy = ((Vector2)pathfollowing.vectorPath[currentWayPoint] - rigitEnemy.position).normalized;
        force = directionEnemy * speed * Time.deltaTime;
        rigitEnemy.AddForce(force);
        
        dintanceEnemy = Vector2.Distance(rigitEnemy.position, pathfollowing.vectorPath[currentWayPoint]);
        if (dintanceEnemy < nextWayPointDistance) {
            currentWayPoint++;
        }

    }

    public void OnPathComplete(Path mypath) {
        if (!mypath.error) {
            pathfollowing = mypath;
            currentWayPoint = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
        }
    }
}

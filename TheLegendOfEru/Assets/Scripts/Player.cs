using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   private BoxCollider2D boxCollider;
   private RaycastHit2D hit;
   public float horizontal;
    public float vertical;
    public Vector3 movement;
    public Animator animationsPlayer;
    public float velocity;
    public float timerEffectPosion;
    public float timerCount;
    
    private void Start()
   {
       boxCollider = GetComponent<BoxCollider2D>();

        velocity = 0.5f;
    }
    private void Update()
    {
        
        timerCount -= Time.deltaTime;

        if (timerCount > 0)
        {
            transform.position = transform.position + movement * (Time.deltaTime * velocity);
        }
        else {
            velocity = 0.5f;
        }
      
      
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movement = new Vector3(horizontal, vertical, 0.0f);
        transform.position = transform.position + movement * (Time.deltaTime*velocity);

        if ((horizontal > 0.01f) || (vertical > 0.01f))
        {
            animationsPlayer.SetBool("Walk", true);
            animationsPlayer.SetBool("Idle", false);
            animationsPlayer.SetBool("Jump", false);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if ( (horizontal < -0.01f)|| (vertical < -0.01f)) {
           
                transform.localScale = new Vector3(-1f, 1f, 1f);
                animationsPlayer.SetBool("Walk", true);
                animationsPlayer.SetBool("Idle", false);
                animationsPlayer.SetBool("Jump", false);
            
           
        }
        else
        {
            animationsPlayer.SetBool("Walk", false);
            animationsPlayer.SetBool("Idle", true);
            animationsPlayer.SetBool("Jump", false);
        }

        if (Input.GetKey(KeyCode.Space)) {
            animationsPlayer.SetBool("Walk", false);
            animationsPlayer.SetBool("Idle", false);
            animationsPlayer.SetBool("Jump", true);     
        }

        if (Input.GetMouseButton(0))
        {
            animationsPlayer.SetBool("Walk", false);
            animationsPlayer.SetBool("Idle", false);
            animationsPlayer.SetBool("Jump", false);
            //golpear al enemigo
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Enemy")
        {
           
        }
        else if (collision.gameObject.tag == "Posion")
        {
            
            timerEffectPosion = 7f;
            timerCount = timerEffectPosion;
            velocity = 1f;
            Destroy(collision.gameObject);
        }
       
    }
}

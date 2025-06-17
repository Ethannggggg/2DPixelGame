using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
   public int Health;
   public int blinks;
   public float time;
   public float dieTime;
   
   private PlayerController respawn;

   private Renderer myRender;
   private Animator anim;
   private ScreenFlash sf;
   private Rigidbody2D rb2d;
   private int i;
   private int health;

   


    // Start is called before the first frame update
    void Start()
    {   
        health = Health;
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        myRender = GetComponent<Renderer>(); 
        anim = GetComponent<Animator>();
        sf = GetComponent<ScreenFlash>();
        rb2d = GetComponent<Rigidbody2D>();;
        respawn= FindObjectOfType<PlayerController>();
        i = health;
       
   
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void DamagePlayer(int damage)
    {
        sf.FlashScreen();
        health -= damage;
        if(health < 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if(health <= 0)
        {
            rb2d.velocity = new Vector2(0, 0);
            GameController.isGameAlive = false;
            anim.SetTrigger("Die");
            Invoke("Respawn", dieTime);

        }
        BlinkPlayer(blinks, time);
    }

    void Respawn()
    {
        
        StartCoroutine("RespawnCo");
            
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }

    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i=0 ; i < numBlinks * 2; i++)
        {
             myRender.enabled = !myRender.enabled;
             yield  return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(3);
        respawn.transform.position = respawn.RespawnPosition;
        GameController.isGameAlive = true;
        HealthBar.HealthMax = i;
        HealthBar.HealthCurrent = i;
    }
}

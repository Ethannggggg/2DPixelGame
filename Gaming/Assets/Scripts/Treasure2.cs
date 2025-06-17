using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure2 : MonoBehaviour
{
    public GameObject dialogBox;
    public Image dialogBoxImage;
    public string QText;
    public GameObject star;
    public int damage;
    public float delaytime;

    private bool canOpen;
    private bool isOpened;
    private Animator anim;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        isOpened = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.U))
          {
              if(canOpen && !isOpened)
              {
                anim.SetTrigger("Opening");
                isOpened = true;
                Invoke("GetStar", delaytime);

              }
             
          }
          
          if(Input.GetKeyDown(KeyCode.O))
          {
              if(canOpen && !isOpened)
              {
                    if(playerHealth != null)
                    {
                        playerHealth.DamagePlayer(damage);
                    }
               }
           }

           if(Input.GetKeyDown(KeyCode.I))
          {
              if(canOpen && !isOpened)
              {
                    if(playerHealth != null)
                    {
                        playerHealth.DamagePlayer(damage);
                    }
               }
           }

           if(Input.GetKeyDown(KeyCode.P))
          {
              if(canOpen && !isOpened)
              {
                    if(playerHealth != null)
                    {
                        playerHealth.DamagePlayer(damage);
                    }
               }
           }

        
       
        
    }

    void GetStar()
    {
        Instantiate(star, transform.position, Quaternion.identity);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player") && other .GetType() .ToString() == "UnityEngine.CapsuleCollider2D")
       {
               canOpen =true;
       }
    }
    

    void OnTriggerExit2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player") && other .GetType() .ToString() == "UnityEngine.CapsuleCollider2D")
       {
               canOpen =false;
               dialogBox.SetActive(false);
       }
    }

    public void open()
    {
         if(canOpen && !isOpened)
         {
          //dialogBoxText.text = QText;
          dialogBox.SetActive(true);
         }  
    }
}

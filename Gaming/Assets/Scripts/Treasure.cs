using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{
    public GameObject dialogBox;
    public Image dialogBoxImage;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public string QText;
    public GameObject star;
    public int damage;
    public float delaytime;
    //public static Touch GetTouch()

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
               button1.gameObject.SetActive(false);
               button2.gameObject.SetActive(false);
               button3.gameObject.SetActive(false);
       }
    }

    public void Open()
    {
         if(canOpen && !isOpened)
         {
          //dialogBoxText.text = QText;
          dialogBox.SetActive(true);
          button1.gameObject.SetActive(true);
          button2.gameObject.SetActive(true);
          button3.gameObject.SetActive(true);
         }       
       
    }

    public void Correct()
          {
              if(canOpen && !isOpened)
              {
                anim.SetTrigger("Opening");
                isOpened = true;
                Invoke("GetStar", delaytime);

              }
             
          }
          
    public void Wrong1()
          {
              if(canOpen && !isOpened)
              {
                    if(playerHealth != null)
                    {
                        playerHealth.DamagePlayer(damage);
                    }
               }
           }

    public void Wrong2()
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

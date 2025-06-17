using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBox : MonoBehaviour
{
    public int health;
    public float time;

    private float coldTime;
    
    // Start is called before the first frame update
    void Start()
    {
       coldTime=time;
    }

    // Update is called once per frame
    void Update()
    {
       

         if(health == 0)
        {
            Broke();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
           health = 0;
        }
    }

    void Broke()
    {
        if(coldTime > 0)
        {
            coldTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}


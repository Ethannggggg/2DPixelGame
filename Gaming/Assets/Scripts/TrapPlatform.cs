using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{

    public float time;

    private int a;
    private int i;
    private float coldTime;
    // Start is called before the first frame update
    void Start()
    {
        i=1;
        a=0;
        coldTime=time;

    }

    // Update is called once per frame
    void Update()
    {
        if(a==1)
        {
            if(coldTime > 0)
            {
                coldTime -= Time.deltaTime;

            }
            else
            {
                Destroy();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            a = 1;
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}

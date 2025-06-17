using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public static int num;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            StarUI.CurrentStarQuantity += 1;
            count();
            Destroy(gameObject);
        }
    }

    void count()
    {
        num += 1;
    }
}

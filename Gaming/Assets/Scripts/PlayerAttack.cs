using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float startTime;
    public float time;
    //public Button button;

    private Animator anim;
    private PolygonCollider2D coll2D;

    // Start is called before the first frame update
    void Start()
    {
    anim= GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    coll2D = GetComponent<PolygonCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Attack()
    {
   
          GetComponent<Collider2D>().enabled = true;
          anim.SetTrigger("Attack");
          StartCoroutine(disableHitBox());

     
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(time);
        GetComponent<Collider2D>().enabled = true;
        StartCoroutine(disableHitBox());

    }

   
    
    
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        GetComponent<Collider2D>().enabled = false;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy1>().TakeDamage(damage);
        }
   

    }

  
}

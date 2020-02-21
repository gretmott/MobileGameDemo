using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFly : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(-moveSpeed, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //collect the gold and add to gold score
            MF_AutoPool.Despawn(this.gameObject); //this would despawn the gold
        }
    }
}

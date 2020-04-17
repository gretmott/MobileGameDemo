using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFly : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;
    public Animator myanim;
    public bool gold;
    public AudioSource hitsound;

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

        if(collision.tag == "Player" && gold == false)
        {
            StartCoroutine("Hit");
        }

        if (collision.tag == "Player" && gold == true)
        {
            //collect the gold and add to gold score
            collision.GetComponent<PlayerController>().gold += 1;

            MF_AutoPool.Despawn(this.gameObject); //this would despawn the gold

        }

        if (collision.tag == "ball" && gold == false)

        {
            StartCoroutine("Hit");
        }

         

    }

    IEnumerator Hit ()
    {
        myanim.SetBool("Hit", true);
        hitsound.Play();
        yield return new WaitForSeconds(1f);
        myanim.SetBool("Hit", false);
        MF_AutoPool.Despawn(this.gameObject);
    }


}

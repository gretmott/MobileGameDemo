using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addScore : MonoBehaviour
{
    public LevelEnd1 LE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void nTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Player")
        {
            LE.score += 1;
            this.gameObject.SetActive(false);
        }
    }
}

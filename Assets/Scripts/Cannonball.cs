using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float power;
    public float powerup;
    public float fallspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(power, (powerup -= (Time.deltaTime * fallspeed))); 
    }
}

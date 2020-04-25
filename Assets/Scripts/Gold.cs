using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

    public MenuManager mm;
    public LevelEnd2 le2;
    public AudioSource coinSound;

// Start is called before the first frame update
    void Start()
    {
        mm = GameObject.FindObjectOfType<MenuManager>();
        le2 = GameObject.FindObjectOfType<LevelEnd2>();
        coinSound = GameObject.FindGameObjectWithTag("CoinSound").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mm.goldCount += 1;
            le2.score += 1;
            coinSound.Play();
            this.gameObject.SetActive(false);
        }
    }


}

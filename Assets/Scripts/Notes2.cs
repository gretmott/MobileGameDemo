using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // this lets you call Images which are used in the UI buttons, toggles
using UnityEngine.SceneManagement; //this lets you use the scene manger which loads levels
using UnityEngine.Audio; //this calls the audio mixer

public class Notes2 : MonoBehaviour
{
    //Greta Motter
    public Notes2 n2;
    public GameObject GO;
    public Image myimage;
    public Button mybutton;
    public float timer;
    // Start is called before the first frame update
    //AI
    //MOVE TOWARDS (moves object towards another) flying follower enemy uses this
    public Vector3 start; //the start location
    public Vector3 finish; //the finish location
    public float speed; //how fast the mover goes from start to finish
    //LOOT
    public GameObject money;

    //ARRAY an array is a collection of gameObjects. Arrays allow us to affect large groups of objects

    public GameObject[] alltheenemies; //the staright brackets signify a collection of gameObjects

    //PLAYERPREFS
    //these are values that will save even after the player leaves the game. this is good for unlockable content or overall progress. this works for character skins

    public int GreenBird; //this is not a playerpref just a normal int

    void Start()
    {
        PlayerPrefs.SetInt("GreenBird", 2); //this will unlcok the green bird
        //I'd only do this when I'm ready to unlock it, before this it would be set to 0 or 1

        if(PlayerPrefs.HasKey("GreenBird"))
        {
            GreenBird = PlayerPrefs.GetInt("GreenBird"); //if I beat the game it will be 2, if I didn't beat the game yet it will be 1
        }

        if(GreenBird == 2)
        {
            //I can select the green bird
        }

        alltheenemies = GameObject.FindGameObjectsWithTag("enemy"); //this grabs all enemies
        //ENABLED vs SET ACTIVE
        //we enabled and disable components attached to gomeObjects
        //we set active true or false entire gameObjects

        n2.enabled = true; //enabled the Notes2 script
        GO.SetActive(true); //enabled the entire gameObject
        StartCoroutine(StarPower()); //this line calls the IEnumerator (don't do this in update)
    }

    // Update is called once per frame
    void Update()
    {
        //TIMERS
        //we can create timers using the command Time.deltaTime. Thi smeans time that has passed since the last frame. (a constant timer). We can take a floatand add or subtract
        //Time.deltaTime to create a timer that counts up or down
        timer -= Time.deltaTime; // -= subtracts time from the timer constantly
        timer += Time.deltaTime; // += adds time to the timer

        if(timer >= 0)
        {
            mybutton.interactable = true; //this allows the button to be pressed
        }

        if (timer < 0)
        {
            mybutton.interactable = false; //this grays the button out and cannot be pressed
        }


        Vector3.MoveTowards(start, finish, speed); //this line will move the object
        //start position is set to the movers position
        //the target position gets set to another gameObject (usually the player)
        //the speed is constant


        //INSTANTIATE is a way to make things appear in our scene. this could be enemies, loot, powerups,

        GameObject loot = Instantiate(money, transform.position, transform.rotation);
        //the above line makes a new gameObject by creating money at our current location
        //we say GameObject loot because we are creating a new gameobject in ther hierarchy call loot
        //money is usually a prefab that we can call over and over again this means money won't be in the hierarchy but inisde the game's asset folder
        Destroy(money, 5f); //this destroys the money if we don't get it fast enough

        //AUTOPOOLING we are using a plug-in called Mob Farm Auto pooler
        GameObject loot2 = MF_AutoPool.Spawn(money, transform.position, transform.rotation);
        //this is the mobile friendly version
        MF_AutoPool.Despawn(this.gameObject, 5f); //this line would be on the money gameObject itself and would put it back into the pool without any left over issues

        //ARRAY (how to go through your list and affect each object one at a time)
        //FOR LOOP
        for(int i = 0; i < alltheenemies.Length; i++)
        {
            alltheenemies[i].SetActive(true); //we set each enemy active
        }
        //int i = 0 means we start at the top of the list
        //i < alltheemnemies, means as long as the number we are on isn't larger than the list
        //lets say the list is 10 long if we are at 0, 0<10 so we add 1, 1 is less than 10 so we add another so on until we get to 10
        //i++ we move down the list by one

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this statemnet is used when we want the player to walk into a specific area and trigger somethings, this could be
        //an animation, enemy, anything we want
        //an event is triggered when the player passes thru a collider that is marked as a trigger, either the player or the collider must have a rigid body in order for the hit to register


        if(collision.tag == "Player")
        {
            //then we trigger the event. this will only trigger if we want the collider has the tag "Player" so enemies can't trigger this event
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //unliked a trigger, a collision happens when two colliders bump into each other but do not pass thru
    }

    //CO-ROUTINE which unity calls IEnumerator
    // normal functions in unity are read top to bottom all at once. sometimes we want to pause before finishing a function which is when we use IEnumerator
    //think of this as the start power is super mario. the player is invincible for a short time, the sprite changes, the music changes, then eventually wears off

    public IEnumerator StarPower()
    {
        //give mario star power
        //change the music
        //change sprite graphics
        //then we want to wait
        yield return new WaitForSeconds(5f); //this lines makes unity wait five seconds
        //star power wears off
        //change music back
        //change sprite back
    }


    //to call an IEnumerator we use the word Co-Routine (see Start loop)

}



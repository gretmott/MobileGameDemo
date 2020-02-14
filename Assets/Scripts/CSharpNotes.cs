using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSharpNotes : MonoBehaviour
{

    //Greta Motter
    //Two forward slashes allows for comments, these are not read by the engine
    //The top part of the script is where we stor evaraibles, things like numbers, referneces to objects, or referneces to other scripts
    //Variables have three parts. the first is public or provate, second is type, third part whatever we decide to name the variable

    //NUMBER VARAIABLES
    //Two types, floats and ints
    public float number; //floating point number, which means the number has a decimal point
    //examples: 1.25 is a float
    public int wholenumber; //1, 2, 3. are ints
    private float myhiddennumber; //a private variable is not visible inside the inspector

    //BOOLS (true/false statements)
    public bool yesorno; // a bool is a yes or no statement, a binary, think of it like a light switch, it's either on or off

    //Other things
    public GameObject mygameObject; //we can referenece any game object. all items in the hierarchy are game objects
    public CSharpNotes CSN; //we can also reference any script we have written as long as it's public
    //public
    public Rigidbody2D myRB2D; // we use rigid bodies on players and enemies and anything we want to be affected by Unity's gravity
    public BoxCollider2D myboxcollider; //WebCamDevice can also rfreferenceeerence colliders of all types
    public CircleCollider2D mycirclecollider;
    //we usually put these references at the top of the script. we need to call them here first if we want to maniupulate them later in the script

    // Start is called before the first frame update
    void Start()
    {
        //anything you want to happene when the games starts goes here.
        //sometimes we don't want to maunally drag and drop items into the inspector
        //sometimes we want to spawn new items during the gameplay. In this case we can use a few simple commands to hav ethe script automatically find objects

        myRB2D = GetComponent<Rigidbody2D>();
        //this will get the rigid body but only if its on the smae object as our script.
        myRB2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        //this will find any object in our scene that has the tag Player and get its rigid body
        myRB2D = GameObject.FindObjectOfType<Rigidbody2D>();
        //this only works when there are is no more than one RigidBody

        //whe the game starts we also might want to look at a few different properties of our game objects: transform, position, rotation, scale
        transform.position = new Vector2(0, 0);
        // the transform posiition is our location on x,y. Transforms are read by unity as called a Vector (Vector 2 or Vector 3)
        //Think of a vector like a bar graph with x and y axises
        //the vector above is set at the origin position. another example:
        transform.position = new Vector2(24, 128); //this is 24 units right and 128 units up
        //we can also ,maniuplate scale this way
        transform.localScale = new Vector2(0, 0);//2D
        transform.localScale = new Vector3(0, 0, 0);//3D both these scales would be invisible
        //rotation is more complicated. we use quaternion and EULER ("oiler")
        transform.rotation = Quaternion.Euler(0, 0, 0);



    }

    // Update is called once per frame
    void Update()
    {
       //inside the update function we call things that we want to update in real time as we play the game

        //IF STATEMENTS
        if (yesorno == true)
        {
            //we say yes, the player lives
        }

        if (yesorno == false)
        {
            //we say yes, the player dies
        }

        //this is an example oif how bools works. if a bool is true, one thing happens, if it's false anotehr thing happens
        //for the if statement to work we need a double equal sign. a single equal sign means that the bool is true or is false whereas a double checks to see IF it's true or false

        if(number >= 10)
        {
            //we do something
        }


        //we can also use if statements to control the player
        if (Input.GetAxis("Horiontal") > 0)
        {
            //we move the player
            myRB2D.velocity = new Vector2(25, 0);
        }

        if (Input.GetAxis("Horiontal") > 0)
        {
            //we stop the player
            myRB2D.velocity = new Vector2(0, 0); //this is zero velocity
            //to see all the different rigid body options we have, start typing myRB2d.
            myRB2D.gravityScale = .5f //give me half gravity
            myRB2D.simulated = false; // this mean sthe rigid body is no longer affected by the physics engine
            myRB2D.isKinematic = true; //kinematic rigidbody only moves if the code tells it to
            myRB2D.isKinematic = false; //non kinematic is the same as dynamic which means it isnt affected by the physics engine. This is how we make falling platform
        }

        //IF ELSE STATEMENTS
        //if statements get read one after the other which can make things get weird
        //if else statements can avaoid this

        if (yesorno == true)
        {
            //we say yes, the player lives
            //this turns out to be true, we won't read the below else statement
        }

        else if (yesorno == false)
        {
            //we say yes, the player dies
            //if the above if statement is not true we will read this else statement
        }

        //because thus code is in the update lop, changes can happen qucikly and we can cycle through multiple if statements faster than we wnat to. this is why we use else

    }

    public void FixedUpdate()
    {
        //regular update is based on frame rate, meaning a newer computer will run better and fatser
        //an oldr compuetr will run slower which is not ideal
        //for the most part graphical elements can live inside the update loop without any issue, the fiexed update loop is for physics calculations
        //because it's on a set interval which means that all computers run teh code at the same speed
    }



}

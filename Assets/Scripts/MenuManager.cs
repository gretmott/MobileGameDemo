using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    //The below two are animators for 2 UI components taht contain images, texts, and buttons
    public Animator simplenav;
    public Animator inventoryholder;
    public bool MenuOpen;

    //the below variables are needed to enable the ''party hat'' and have it vhange the player's appearnce
    public PlayerController pc;
    public int PartyHat;
    public GameObject inventoryHat; //button in our inventory
    public bool wearHat; //bool that tells us if we are wearing the hat
    public GameObject BirthdayHat; //the actual hat on the birds head

    //this keeps tracks of the player's gold
    public int goldCount;
    public Text goldtext;

    //All items in Rob;s shop are buttons so that when you click them you do something
    public Button ShopHat;
    public Button ShopItem2;
    public Button ShopItem3;

    //if we own something we might not want to purchase it again
    public bool ownHat;
    public bool ownItem2;
    public bool ownItem3;



    // Start is called before the first frame update
    void Start()
    {
        goldCount = PlayerPrefs.GetInt ("Gold"); //if you want to save gold across sessions
    }

    // Update is called once per frame
    void Update()
    {

        PlayerPrefs.SetInt("Gold", goldCount); //if you want to save gold across sessions
        goldtext.text = "Gold:" + goldCount;


        PartyHat = PlayerPrefs.GetInt("PartyHat");

        if (PartyHat == 1)
        {
            inventoryHat.SetActive(true); //turns on the hat button in our inventory
        }

        if (wearHat == true)
        {
            //pc.moveSpeed = 8;  //+3 move speed
            // pc.jumpSpeed = 18; //+8 jump speed
            BirthdayHat.SetActive(true); //lets us see the hat on our character
        }

        if (wearHat == false) //this will set up back to standard speed if we turn off the hat
        {
            //pc.moveSpeed = 5;
            //pc.jumpSpeed = 10;
            BirthdayHat.SetActive(false);

        }


        if (goldCount >= 1 && ownHat == false) //if we have enough gold and didn't but the hat yet
        {
            ShopHat.interactable = true; // the hat button is now clickable in the shop
        }
    }


    public void OpenNav()
    {
        if (MenuOpen == false)
        {
            simplenav.SetBool("Open", true);
            Time.timeScale = 0;
            MenuOpen = true;
        }

        else if (MenuOpen == true)
        {
            simplenav.SetBool("Open", false);
            Time.timeScale = 1;
            MenuOpen = false;
        }

    }


    public void CloseNav()
    {

        simplenav.SetBool("Open", false);
        Time.timeScale = 1;
        MenuOpen = false;
    }

    public void OpenInv()
    {
        inventoryholder.SetBool("Open", true);
    }

    public void CloseInv()
    {
        inventoryholder.SetBool("Open", false);
    }

    public void BuyHat()
    {
        goldCount -= 1;
        PlayerPrefs.SetInt("PartyHat", 1);
        ShopHat.interactable = false;
        ownHat = true;
    }

    public void PutOnHat()
    {
        wearHat = true;
    }

    public void Reset()
    {
        //PlayerPrefs.SetInt("PartyHat", 0);
        //inventoryHat.SetActive(false);
        //wearHat = false;
        PlayerPrefs.SetInt("LvlStart", 0);
        PlayerPrefs.SetInt("Gold", 0);
        goldCount = PlayerPrefs.GetInt("Gold");
        goldtext.text = "Gold:" + goldCount;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Get access to unitys ui system
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ShowPrompt : MonoBehaviour
{
    public Canvas EPromptCanvas;
    public Canvas HealthPotionCanvas;
    public Canvas GoldRingCanvas;
    public Canvas WhiteBottleCanvas;
    public Canvas RagnarokRuneCanvas;
    public GameObject script;
    private Player playerScript;
    public ItemObject HealthPotion;
    public ItemObject WhiteBottle;
    public ItemObject GoldRing;
    public ItemObject RagnarokRune;
    // public Canvas[] shopItems = { HealthPotionCanvas, GoldRingCanvas, WhiteBottleCanvas };

    int cycleNumber = 0;
    bool isPlayerInTheShopArea = false;
    Collider2D theThingstayinginthecollider;

    void DisableCanvas()
    {
        EPromptCanvas.enabled = false;
        HealthPotionCanvas.enabled = false;
        GoldRingCanvas.enabled = false;
        WhiteBottleCanvas.enabled = false;
        RagnarokRuneCanvas.enabled = false;
    }
    void Start()
    {
        DisableCanvas();
        playerScript = script.GetComponent<Player>();
    }
    
    void OnTriggerEnter2D(Collider2D TheThingEnteringTheCollider)
    {
        if(TheThingEnteringTheCollider.gameObject.tag == "Player")
        {
           //Debug.Log("The Player is in the shop vicinity");
            EPromptCanvas.enabled = true;

        }
    }

    void OnTriggerExit2D(Collider2D TheThingExitingTheCollider)
    {
        if(TheThingExitingTheCollider.gameObject.tag == "Player")
        {
            //Debug.Log("The Player is no longer in the shop vicinity");
            EPromptCanvas.enabled = false;
            isPlayerInTheShopArea = false;
        }
    }

    void OnTriggerStay2D(Collider2D TheThingStayingInTheCollider)
    {
        isPlayerInTheShopArea = true;
        theThingstayinginthecollider = TheThingStayingInTheCollider;
    }

    void Update()
    {
        if (isPlayerInTheShopArea)
        {
            if(theThingstayinginthecollider.gameObject.tag == "Player")
            {
                // if(Input.GetKeyDown(KeyCode.DownArrow) && cycleNumber > 1)
                // {
                //     --cycleNumber;
                // }
                // else if (Input.GetKeyDown(KeyCode.UpArrow) && cycleNumber < 3)
                // {
                //     ++cycleNumber;
                // }
                int change = 0;
                if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    change = -1;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    change = 1;
                }

                cycleNumber += 4 + change;
                cycleNumber %= 4;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    int costOfItem = 0;
                    ItemObject storeItemThing = GoldRing;

                    if (GoldRingCanvas.enabled)
                    {
                        costOfItem = 8;
                        storeItemThing = GoldRing;
                    }
                    else if (WhiteBottleCanvas.enabled)
                    {
                        costOfItem = 6;
                        storeItemThing = WhiteBottle;
                    }
                    else if (HealthPotionCanvas.enabled)
                    {
                        costOfItem = 4;
                        storeItemThing = HealthPotion;
                    }
                    else if (RagnarokRuneCanvas.enabled)
                    {
                        costOfItem = 6;
                        storeItemThing = RagnarokRune;
                    }

                    if (costOfItem <= playerScript.coins)
                    {
                        playerScript.coins -= costOfItem;
                        Inventory.instance.AddItem(storeItemThing);
                    }
                }
            }
        }

        if(cycleNumber == 3)
        {
            RagnarokRuneCanvas.enabled = true;
            HealthPotionCanvas.enabled = false;
            WhiteBottleCanvas.enabled = false;
            GoldRingCanvas.enabled = false;
        }
        if (cycleNumber == 2)
        {
            GoldRingCanvas.enabled = true;
            HealthPotionCanvas.enabled = false;
            WhiteBottleCanvas.enabled = false;
            RagnarokRuneCanvas.enabled = false;
        }
        if (cycleNumber == 1)
        {
            HealthPotionCanvas.enabled = true;
            GoldRingCanvas.enabled = false;
            WhiteBottleCanvas.enabled = false;
            RagnarokRuneCanvas.enabled = false;
        }
        if (cycleNumber == 0)
        {
            WhiteBottleCanvas.enabled = true;
            HealthPotionCanvas.enabled = false;
            GoldRingCanvas.enabled = false;
            RagnarokRuneCanvas.enabled = false;
        }

    }
}

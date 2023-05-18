using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPickUp : MonoBehaviour
{
    public ItemObject bow;
    public GameObject BowPickup;
    public GameObject TextPrompt;
    public bool playerInBowPickUpArea;
    // Start is called before the first frame update
    void Start()
    {
        BowPickup.GetComponent<BoxCollider2D>();
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            playerInBowPickUpArea = true;
        }

    }

    void Update()
    {
        if (playerInBowPickUpArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Inventory.instance.AddItem(bow);
                GameObject.Destroy(gameObject);
                GameObject.Destroy(TextPrompt);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GameObject endArea;

    void Start()
    {
        endArea.GetComponent<BoxCollider2D>();
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            SceneManager.LoadScene("Credits");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinCount : MonoBehaviour
{
    public GameObject script;
    private Player playerScript;
    public TMP_Text coinAMT;

    void Start()
    {
        playerScript = script.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        coinAMT.text = (playerScript.coins.ToString());
    }
}

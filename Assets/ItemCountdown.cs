using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ItemCountdown : MonoBehaviour
{
    public Canvas DaPercsCountdown;
    public Canvas GoldRingCountdown;
    public Canvas RagnarokRuneCountdown;
    public Player player;
    public TMP_Text DaPercsTimer;
    public TMP_Text GoldRingTimer;
    public TMP_Text RagnarokRuneTimer;
    public float percstimePassed;
    public float runetimepassed;
    public float ringtimepassed;
    public float DaPercsTimeLeft = 10;
    public float GoldRingTimeLeft;
    public float RagnarokRuneTimeLeft = 10;
    void Start()
    {
        player = player.GetComponent<Player>();
        DaPercsCountdown.enabled = false;
        RagnarokRuneCountdown.enabled = false;
        GoldRingCountdown.enabled = false;
    }

    public void DaPercsTimeCountDown()
    {
        if (!DaPercsCountdown.enabled) {DaPercsTimeLeft = 10f;}
        DaPercsCountdown.enabled = true;
        percstimePassed = Time.deltaTime;
        DaPercsTimeLeft -= percstimePassed;
        DaPercsTimer.text = (DaPercsTimeLeft).ToString("0");

        if (DaPercsTimeLeft <= 0)
        {
            DaPercsCountdown.enabled = false;
        }
    }

    public void RuneTimeCountDown()
    {
        if (!RagnarokRuneCountdown.enabled) {RagnarokRuneTimeLeft = 10f;}
        RagnarokRuneCountdown.enabled = true;
        runetimepassed = Time.deltaTime;
        RagnarokRuneTimeLeft -= runetimepassed;
        RagnarokRuneTimer.text = (RagnarokRuneTimeLeft).ToString("0");

        if (RagnarokRuneTimeLeft <= 0)
        {
            RagnarokRuneCountdown.enabled = false;
        }
    }

    public void RingTimeCountDown()
    {
        if (!GoldRingCountdown.enabled) {GoldRingTimeLeft = 10f;}
        GoldRingCountdown.enabled = true;
        ringtimepassed = Time.deltaTime;
        GoldRingTimeLeft -= ringtimepassed;
        GoldRingTimer.text = (GoldRingTimeLeft).ToString("0");

        if (GoldRingTimeLeft <= 0)
        {
            GoldRingCountdown.enabled = false;
        }
    }

    void Update()
    {
        if (player.meleeRate == 3.5)
        {
            DaPercsTimeCountDown();
        }

        if(player.meleeTimerReset)
        {
            DaPercsTimeLeft = 10;
        }

        if (player.damage == 10f)
        {
            RuneTimeCountDown();
        }

        if (player.attackTimerReset)
        {
            RagnarokRuneTimeLeft = 10;
        }

        if (player.isInvincible)
        {
            RingTimeCountDown();
        }

        if (player.ringTimerReset)
        {
            GoldRingTimeLeft = 10;
        }

        if (GoldRingTimeLeft <= 0)
        {
            GoldRingCountdown.enabled = false;
        }

        if (RagnarokRuneTimeLeft <= 0)
        {
            RagnarokRuneCountdown.enabled = false;
        }

        if (DaPercsTimeLeft <= 0)
        {
            DaPercsCountdown.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    CharacterHealth player;
    Text countdownText;

    public int timeCounter;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<CharacterHealth>();
        countdownText = this.GetComponent<Text>();
        countdownText.text = "Timer: " + timeCounter.ToString();

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while(timeCounter > 0 && player.victory == false && player.gameEnded == false)
        {
            //countdownText.text = "Timer: " + timeCounter.ToString();

            yield return new WaitForSeconds(1f);

            timeCounter--;
            countdownText.text = "Timer: " + timeCounter.ToString();
        }

        if (player.victory == false)
        {
            player.GameOver();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    GameObject tempButton;
    GameObject tempText;
    GameObject player;
    bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        tempText = this.transform.GetChild(2).gameObject;
        tempButton = this.transform.GetChild(3).gameObject;
        tempButton.SetActive(false);
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!(player.GetComponent<CharacterHealth>().victory))
        {
            if (!(player.GetComponent<CharacterHealth>().dead))
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame(gamePaused);
                }
            }
        }
    }

    private void PauseGame(bool gp)
    {
        string temp = tempText.GetComponent<Text>().text;

        gamePaused ^= true;

        if (gamePaused)
        {
            tempText.GetComponent<Text>().enabled = gamePaused;
            tempText.GetComponent<Text>().text = "Game Paused";
            tempButton.SetActive(gamePaused);
            Time.timeScale = 0;
        }
        else
        {
            tempText.GetComponent<Text>().enabled = gamePaused;
            tempText.GetComponent<Text>().text = temp;
            tempButton.SetActive(gamePaused);
            Time.timeScale = 1;
        }
    }

    public void ExitGame()
    {
        Debug.Log("this game has exited");
        Application.Quit();
    }
}

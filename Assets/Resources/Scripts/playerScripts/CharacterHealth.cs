using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Text conditionText;
    public Vector3 respawn;
    public int playerLife;
    bool victory;

    // Start is called before the first frame update
    void Start()
    {
        victory = false;
        conditionText.enabled = false;
        playerLife = 100;
        respawn = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hurt(int damage)
    {
        playerLife -= damage;

        if (playerLife <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (!victory)
        {
            //disable player controls
            player.GetComponent<CharacterMovement2D>().enabled = false;
            //instantiate a death animation and set player to inactive.
            player.SetActive(false);
            //indicates player died
            conditionText.text = "You died...\nRespawning...";
            conditionText.enabled = true;
            //pause and respawn
            Invoke("Respawn", 1.5f);
        }
    }
    private void Respawn()
    {
        //instantiate at new location
        player.transform.position = respawn;
        player.SetActive(true);
        player.GetComponent<CharacterMovement2D>().enabled = true;
        conditionText.enabled = false;
    }

    public void Win()
    {
        //disable player controls
        player.GetComponent<CharacterMovement2D>().enabled = false;
        //indicate player won
        victory = true;
        conditionText.text = "VICTORY!!!";
        conditionText.enabled = true;
        //pause and start next level
        Invoke("NextLevel", 3.0f);
    }

    private void NextLevel()
    {
        //loads next level
        conditionText.text = "Still working on next level.";

    }
}

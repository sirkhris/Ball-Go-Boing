using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Text livesText;
    [SerializeField] Text conditionText;

    public Vector3 respawn;

    int playerLife;
    int life;

    public bool victory;
    public bool dead;
    public bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        victory = false;
        dead = false;
        gameEnded = false;
        conditionText.enabled = false;
        playerLife = 100;
        life = 3;
        livesText.text = "Lives: " + life;
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
        if (!victory && !gameEnded)
        {
            //decrease player's life
            dead = true;
            life--;
            livesText.text = "Lives: " + life;

            //disable player controls
            player.GetComponent<CharacterMovement2D>().enabled = false;

            //instantiate a death animation and set player to inactive.
            player.SetActive(false);

            //indicates player died
            conditionText.text = "You died...\nRespawning...";
            conditionText.enabled = true;

            //checks if game over else respawn
            if (life <= 0)
            {
                GameOver();
            }
            else
            {
                //pause and respawn
                Invoke("Respawn", 1.5f);
            }
            
        }
    }
    private void Respawn()
    {
        dead = false;

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
        //conditionText.text = "Still working on next level.";
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(next);
    }

    public void GameOver()
    {
        //indicates player lost
        conditionText.text = "Game Over";
        conditionText.enabled = true;
        gameEnded = true;

        //pause and respawn
        Invoke("ReloadLevel", 3.0f);
    }

    private void ReloadLevel()
    {
        //loads next level
        //conditionText.text = "This is where you reload level";
        int reload = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(reload);
    }
}

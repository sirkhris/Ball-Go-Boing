using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    //[SerializeField] Transform respawnPoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //collision.transform.position = respawnPoint.position;
            collision.GetComponent<CharacterHealth>().Die();
        }
    }
}

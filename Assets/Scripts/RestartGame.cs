using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerPosition = player.transform.position;
        }
    }

    public void Restart()
    {
       if(player != null)
        {
            player.transform.position = playerPosition;
            Score.score = 0;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Restart();
        }
    }
}

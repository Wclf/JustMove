using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.ComponentModel.Design;
using Unity.VisualScripting;

public class RestartGame : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPosition;
    [SerializeField] private float startTime = 60f;
    [SerializeField] private TextMeshProUGUI timeCountDown;
    private float currentTime;
    
    private void Start()
    {
        currentTime = startTime;
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
        {
            playerPosition = player.transform.position;
        }
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        timeCountDown.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(currentTime / 60), Mathf.FloorToInt(currentTime % 60));

        if (currentTime <= 0) {
            currentTime = 0;
            ResetG.Restart();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ResetG.Restart();
        }
    }

 
}

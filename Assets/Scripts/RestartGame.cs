
using UnityEngine;
using TMPro;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private float startTime = 60f;
    [SerializeField] private TextMeshProUGUI timeCountDown;

    private GameObject player;
    private Vector3 playerPosition;
    private float currentTime;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
            audioManager.PlaySFX(audioManager.die);
            Death.isDeath = true;
            Movement.canMove = false;
            Invoke("DelayRestart", 0.5f);
        }
    }

    void DelayRestart()
    {
        ResetG.Restart();
        Movement.canMove = true;
    }


}

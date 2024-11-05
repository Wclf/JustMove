using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    public float minSpeed = 5f; // Min Speed of the weapon movement
    public float maxSpeed = 10f; // Max Speed of the weapon movement
    private float speed;

    public GameObject ways; // GameObject containing waypoints
    private Transform[] wayPoints; // Array to hold waypoints
    private int pointIndex; // Index of the current waypoint
    private int pointCount; // Total number of waypoints
    private Vector3 targetPos; // Current target position

    public static bool isTouchWeapon = false;

    private void Awake()
    {
        // Retrieve waypoints from the GameObject ways into the wayPoints array
        pointCount = ways.transform.childCount;
        wayPoints = new Transform[pointCount];
        for (int i = 0; i < pointCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i);
        }
    }

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        pointIndex = 0; // Start from the first waypoint
        targetPos = wayPoints[pointIndex].position; // Set target position
    }

    private void Update()
    {
        // Move towards the targetPos
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        // Check distance to targetPos
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            NextPoint(); // Move to the next point
        }
    }

    private void NextPoint()
    {
        // Update the index of the waypoint
        pointIndex++;

        // If reached the end of the array, loop back to the beginning
        if (pointIndex >= wayPoints.Length)
        {
            pointIndex = 0; // Return to the first point
        }

        // Update the target position
        targetPos = wayPoints[pointIndex].position;

        // Rotate the weapon
        Vector3 direction = (targetPos - transform.position).normalized; // Calculate direction of movement
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate rotation angle
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Rotate the weapon
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Death.isDeath = true;
            Movement.canMove = false;
            isTouchWeapon = true;
            Invoke("DelayRestart", 0.5f);
        }
    }

    void DelayRestart()
    {
        ResetG.Restart();
        Movement.canMove = true;
    }


}

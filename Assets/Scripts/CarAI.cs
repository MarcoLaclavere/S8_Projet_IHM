using UnityEngine;
using System.Collections;


public class CarAI : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float steerSpeed;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private bool isFrozen = false;



    private float stuckTimer = 0f;
    private float timeToConsiderStuck = 2f; // Temps pour considérer la voiture comme coincée
    private bool isStuck = false;
    private float unlockDelay = 2f; // Temps avant de pouvoir débloquer à nouveau
    private float lastUnstuckTime = 0f;

    private int stuckCount = 0;


    

    void FixedUpdate()
    {
        if (!isFrozen)
        {
            MoveTowardsWaypoint();
            SteerTowardsWaypoint();
            CheckIfStuck();
        }

    }

    public void Freeze()
    {
        isFrozen = true;
        rg.velocity = Vector3.zero; // Arrêter tout mouvement en cours
    }


    public void UnfreezePlayer()
    {
        isFrozen = false;
    }

    void MoveTowardsWaypoint()
    {

        if (currentWaypointIndex >= waypoints.Length) // Protection against index out of range
            currentWaypointIndex = 0;
        // Calculate direction vector to the next waypoint
        Vector3 directionToWaypoint = waypoints[currentWaypointIndex].position - transform.position;
        directionToWaypoint.y = 0; // Ensure the direction is only on the x-z plane

        // Move forward
        rg.AddForce(transform.forward * forwardMoveSpeed, ForceMode.Acceleration);

        // Check if we reached the waypoint
        if (directionToWaypoint.magnitude < 6) // 1 is the waypoint radius
        {
            currentWaypointIndex++;
            Debug.Log("Reached waypoint " + currentWaypointIndex);
           // Debug.Log("Waypoint Target: " + waypoints[currentWaypointIndex].position);
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }

        void CheckIfStuck()
    {
        if (rg.velocity.magnitude < 0.1f && Time.time - lastUnstuckTime > unlockDelay)
        {
            stuckTimer += Time.fixedDeltaTime;
        }
        else
        {
            stuckTimer = 0;
        }

        if (stuckTimer > timeToConsiderStuck && !isStuck)
        {
            isStuck = true;
            stuckCount++;
            StartCoroutine(UnstuckRoutine());
            lastUnstuckTime = Time.time;
        }
    }


    IEnumerator UnstuckRoutine()
    {
        // Tourner dans un sens
        float turnTime = 0.1f;
        

        if(stuckCount % 2 == 0)
        {
            float startTime = Time.time;
            while (Time.time - startTime < turnTime)
            {
                transform.Rotate(0, -steerSpeed/4 * Time.fixedDeltaTime, 0);
                MoveTowardsWaypoint();
                yield return null;

            }
           
        }
        else
        {
            float startTime = Time.time;
            while (Time.time - startTime < turnTime)
            {
                transform.Rotate(0, steerSpeed/4 * Time.fixedDeltaTime, 0);
                MoveTowardsWaypoint();
                yield return null;
            }

          
        }


        // Tourner dans l'autre sens

        isStuck = false;
    }

    void SteerTowardsWaypoint()
    {
        if(isStuck)
        {
            return;
        }
        Vector3 directionToWaypoint = waypoints[currentWaypointIndex].position - transform.position;
        directionToWaypoint.y = 0; // Ensure the direction is only on the x-z plane

        // Calculate the angle to the waypoint
        float targetAngle = Vector3.SignedAngle(directionToWaypoint, transform.forward, Vector3.up);

        // Steer towards the waypoint
        float steerAmount = Mathf.Clamp(targetAngle / 45.0f, -1, 1); // 45 is the max steer angle
        transform.Rotate(0, -steerAmount * steerSpeed * Time.fixedDeltaTime, 0, Space.World);
    }
}
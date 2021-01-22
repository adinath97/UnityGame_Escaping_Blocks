using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclePath : MonoBehaviour
{
    waveConfig particularWaveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    [SerializeField] float rotationSpeed1 = 4f;
    [SerializeField] float rotationSpeed2 = 8f;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = particularWaveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void SetWaveConfig(waveConfig waveConfigToSet)
    {
        this.particularWaveConfig = waveConfigToSet;
    }

    private void Move()
    {
        if(this.tag == "Diamond1")
        {
            if (waypointIndex <= waypoints.Count - 1)
            {
                var targetPosition = waypoints[waypointIndex].transform.position;
                var movementThisFrame = particularWaveConfig.GetMoveSpeed() * Time.fixedDeltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
                if (transform.position == targetPosition)
                {
                    waypointIndex++;
                }
            }
            else
            {
                Destroy(gameObject);
            }
            this.transform.Rotate(0, 0, rotationSpeed1);
        }
        else if (this.tag == "Diamond2")
        {
            if (waypointIndex <= waypoints.Count - 1)
            {
                var targetPosition = waypoints[waypointIndex].transform.position;
                var movementThisFrame = particularWaveConfig.GetMoveSpeed() * Time.fixedDeltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
                if (transform.position == targetPosition)
                {
                    waypointIndex++;
                }
            }
            else
            {
                Destroy(gameObject);
            }
            this.transform.Rotate(0, 0, rotationSpeed2);
        }
        else
        {
            if (waypointIndex <= waypoints.Count - 1)
            {
                var targetPosition = waypoints[waypointIndex].transform.position;
                var movementThisFrame = particularWaveConfig.GetMoveSpeed() * Time.fixedDeltaTime;
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
                if (transform.position == targetPosition)
                {
                    waypointIndex++;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ball")
        {
            Destroy(this.gameObject);
        }
    }
}

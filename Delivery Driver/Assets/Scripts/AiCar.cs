using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCar : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnRate = 10f;
    private Waypoints waypoints;
    private int currentIndex = 0;
    private Transform currentTarget;
    public void SetWaypoints(Waypoints wp) => waypoints = wp;

    private void MoveToWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, moveSpeed * Time.deltaTime);
        transform.up = Vector3.Lerp(transform.up, (currentTarget.position - transform.position), turnRate * Time.deltaTime);
        if (transform.position == currentTarget.position)
        {
            currentIndex = currentIndex + 1 < waypoints.GetWaypointLength() ? currentIndex + 1 : 0;
            currentTarget = waypoints.GetCurrentWaypoint(currentIndex);
        }
    }

    private void Update()
    {
        if (waypoints == null)
            return;
        if (currentTarget == null)
            currentTarget = waypoints.GetCurrentWaypoint(currentIndex);
        MoveToWaypoint();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public AiCar car;
    private List<Transform> waypoints;

    public int GetWaypointLength() => waypoints.Count;
    public Transform GetCurrentWaypoint(int index) => index < waypoints.Count ? waypoints[index] : null;

    private void Start()
    {
        if (car == null)
            return;
        waypoints = gameObject.GetComponentsInChildren<Transform>().ToList();
        waypoints.RemoveAt(0);
        car.SetWaypoints(this);
    }
}

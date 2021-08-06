using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    [SerializeField] bool isTraversable;
    public bool IsTraversable { get { return isTraversable; } }

    Bank bank;

    
    private void OnMouseDown() 
    {
        if(isPlaceable)
        {
            if(towerPrefab.CreateTower(towerPrefab, transform.position)) { isPlaceable = false; }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Transform NorthPoint;
    public Transform SouthPoint;
    public Transform EastPoint;
    public Transform WestPoint;
    public List<Transform> WayPointList = new List<Transform>();

    void AddWayPoint(Transform WayPoint)
    {
        if(WayPoint == null)
        {
            return;
        }
        WayPointList.Add(WayPoint);
    }

    // Start is called before the first frame update
    void Start()
    {
        AddWayPoint(NorthPoint);
        AddWayPoint(SouthPoint);
        AddWayPoint(EastPoint);
        AddWayPoint(WestPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

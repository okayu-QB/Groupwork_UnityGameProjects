using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private GameObject child;
    public List<GameObject> AllWayPointList = new List<GameObject>();
    [SerializeField]
    private bool chacknull;
    public int childrencount;

    void GetChildren(GameObject WayPoint)
    {
        if(WayPoint == null)
        {
            Debug.Log("WayPoint is null");
            return;
        }
        AllWayPointList.Add(WayPoint);
    }

    Transform GetWayPoint(GameObject WayPoint)
    {
        return WayPoint.transform;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        childrencount = parent.transform.childCount;
        for(int i = 0;i < childrencount; i++)
        {
            child = parent.transform.GetChild(i).gameObject;
            GetChildren(child);
            child = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

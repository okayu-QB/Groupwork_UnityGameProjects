using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWayPoint : MonoBehaviour
{
    public WayPoint waypoint;
    public Enemy Police;

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Through Point A");
        if (collision.gameObject.tag == "Enemy")
        {
            Police = collision.gameObject.GetComponent<Enemy>();
            if(Police == null)
            {
                Debug.Log("NullPolice");
                return;
            }
        }

        Police.setPos.RandomSetWayPoint(waypoint.WayPointList);
        Police = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        waypoint = GetComponentInParent<WayPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

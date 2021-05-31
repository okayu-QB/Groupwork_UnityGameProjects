using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihecleHit : MonoBehaviour
{
    public bool FrontHit;
    
    void OnTriggerEnter(Collider collection)
    {
        if (collection.gameObject.tag != "BoostItem")
        {
            Debug.Log("FrontHit");
            FrontHit = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

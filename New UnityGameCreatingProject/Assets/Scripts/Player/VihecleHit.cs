using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VihecleHit : MonoBehaviour
{
    public bool Hit;
    
    void OnCollisionEnter(Collision collection)
    {
        Hit = true;
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

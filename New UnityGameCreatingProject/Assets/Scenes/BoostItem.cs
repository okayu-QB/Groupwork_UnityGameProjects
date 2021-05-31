using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostItem : MonoBehaviour
{
    public float BoostTime;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Vihecle>())
        {
            collision.gameObject.GetComponent<Vihecle>().BoostSupply(BoostTime);
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

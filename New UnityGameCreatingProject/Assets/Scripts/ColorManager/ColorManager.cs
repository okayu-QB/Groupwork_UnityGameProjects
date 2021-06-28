using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{

    public Collider playerCollider;
    //public Collider collorR;
    //public Collider collorG;
    //public Collider collorB;

    public int redCount;
    public int greenCount;
    public int blueCount;


    // Start is called before the first frame update
    void Start()
    {
       //redCount = 0;
       //greenCount = 0;
       //blueCount = 0;
}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("R : " + redCount);
        Debug.Log("G : " +  greenCount);
        Debug.Log("B : " + blueCount);

    }
    
}

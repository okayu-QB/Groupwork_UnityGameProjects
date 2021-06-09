using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstructRGBManager : MonoBehaviour
{

    public Text rgbScoreText;
    [SerializeField]
    private GameObject colorObject;
    ColorManager colorManager;


    private void Start() {
        colorManager = colorObject.GetComponent<ColorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RgbScores();
    }
    
    void RgbScores() {
        rgbScoreText.text = "R : " + colorManager.redCount;
    }
}

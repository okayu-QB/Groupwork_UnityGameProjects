using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;//Post Processingのインポート

public class RGBScore : MonoBehaviour
{
    //RGBごとのスコアテキスト変数
    public Text redScoreText;
    public Text greenScoreText;
    public Text blueScoreText;

    //スコア上限
    public int redMax = 5;
    public int greenMax = 5;
    public int blueMax = 5;

    [SerializeField]
    private GameObject colorObject;
    ColorManager colorManager;

    PostProcessVolume _postProcess;
    ColorGrading _colorGrading;

    public GameObject cameraObject;

    //Color Grading の value用変数
    FloatParameter minimumParameter = new FloatParameter { value = 0 };
    FloatParameter defaultParameter = new FloatParameter { value = 100 };


    private void Start() {
        colorManager = colorObject.GetComponent<ColorManager>();//カラーマネージャークラスのインスタンス化

        // PostProcessVolume にスタックされた Effect が格納された配列 PostProcessVolume.profile.settings から ColorGrading を探して参照
        _postProcess = GameObject.Find("PlayerCam").gameObject.GetComponent<PostProcessVolume>();
        foreach (PostProcessEffectSettings item in _postProcess.profile.settings) {
            if (item as ColorGrading) {
                _colorGrading = item as ColorGrading;
            };
        }

        _colorGrading.saturation.value = -100f;
        _colorGrading.tint.value = 0f;
        _colorGrading.brightness.value = 0f;
        _colorGrading.mixerRedOutRedIn.value = defaultParameter;
        _colorGrading.mixerGreenOutGreenIn.value = defaultParameter;
        _colorGrading.mixerBlueOutBlueIn.value = defaultParameter;
    }

    private void Update() {
        RgbScores();

        if(colorManager.redCount == redMax && colorManager.greenCount == greenMax && colorManager.blueCount == blueMax) {
            SceneManager.LoadScene("ClearSean");
        }
        CameraColorGrade();
    }

    /// <summary>
    /// RGBごとにスコア表示
    /// </summary>
    void RgbScores() {
        redScoreText.text = "R : " + colorManager.redCount;
        greenScoreText.text = "G : " + colorManager.greenCount;
        blueScoreText.text = "B : " + colorManager.blueCount;

    }

    /// <summary>
    /// PostProcessによる変更
    /// </summary>
    void CameraColorGrade() {

        if (colorManager.redCount == redMax && colorManager.greenCount != greenMax && colorManager.blueCount != blueMax) {

            _colorGrading.saturation.value = -50f;
            _colorGrading.tint.value = 100f;
            _colorGrading.brightness.value = 100f;
            _colorGrading.mixerRedOutRedIn.value = defaultParameter;
            _colorGrading.mixerGreenOutGreenIn.value = minimumParameter;
            _colorGrading.mixerBlueOutBlueIn.value = minimumParameter;

        }

        if (colorManager.redCount == redMax && colorManager.greenCount == greenMax) {

            _colorGrading.saturation.value = -50f;
            _colorGrading.tint.value = 100f;
            _colorGrading.brightness.value = 0f;
            _colorGrading.mixerRedOutRedIn.value = defaultParameter;
            _colorGrading.mixerGreenOutGreenIn.value = defaultParameter;
            _colorGrading.mixerBlueOutBlueIn.value = minimumParameter;

        }

        if (colorManager.redCount == redMax && colorManager.blueCount == blueMax) {

            _colorGrading.saturation.value = -50f;
            _colorGrading.tint.value = 100f;
            _colorGrading.brightness.value = 0f;
            _colorGrading.mixerRedOutRedIn.value = defaultParameter;
            _colorGrading.mixerGreenOutGreenIn.value = minimumParameter;
            _colorGrading.mixerBlueOutBlueIn.value = defaultParameter;

        }

        if (colorManager.greenCount == greenMax && colorManager.redCount != redMax && colorManager.blueCount != blueMax) {

            _colorGrading.saturation.value = -50f;
            _colorGrading.tint.value = 100f;
            _colorGrading.brightness.value = 100f;
            _colorGrading.mixerRedOutRedIn.value = minimumParameter;
            _colorGrading.mixerGreenOutGreenIn.value = defaultParameter;
            _colorGrading.mixerBlueOutBlueIn.value = minimumParameter;

        }

        if (colorManager.greenCount == greenMax && colorManager.blueCount == blueMax) {

            _colorGrading.saturation.value = -50f;
            _colorGrading.tint.value = 100f;
            _colorGrading.brightness.value = 0f;
            _colorGrading.mixerRedOutRedIn.value = minimumParameter;
            _colorGrading.mixerGreenOutGreenIn.value = defaultParameter;
            _colorGrading.mixerBlueOutBlueIn.value = defaultParameter;

        }

        if (colorManager.blueCount == blueMax && colorManager.greenCount != greenMax && colorManager.redCount != redMax) {

            _colorGrading.saturation.value = -50f;
            _colorGrading.tint.value = 0f;
            _colorGrading.brightness.value = 100f;
            _colorGrading.mixerRedOutRedIn.value = minimumParameter;
            _colorGrading.mixerGreenOutGreenIn.value = minimumParameter;
            _colorGrading.mixerBlueOutBlueIn.value = defaultParameter;

        }


        if (colorManager.redCount == redMax && colorManager.greenCount == greenMax && colorManager.blueCount == blueMax) {

            _colorGrading.saturation.value = 0f;
            _colorGrading.tint.value = 0f;
            _colorGrading.brightness.value = 0f;
            _colorGrading.mixerRedOutRedIn.value = defaultParameter;
            _colorGrading.mixerGreenOutGreenIn.value = defaultParameter;
            _colorGrading.mixerBlueOutBlueIn.value = defaultParameter;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;//Post Processing�̃C���|�[�g

public class RGBScore : MonoBehaviour
{
    //RGB���Ƃ̃X�R�A�e�L�X�g�ϐ�
    public Text redScoreText;
    public Text greenScoreText;
    public Text blueScoreText;

    //�X�R�A���
    public int redMax = 5;
    public int greenMax = 5;
    public int blueMax = 5;

    [SerializeField]
    private GameObject colorObject;
    ColorManager colorManager;

    PostProcessVolume _postProcess;
    ColorGrading _colorGrading;

    public GameObject cameraObject;

    //Color Grading �� value�p�ϐ�
    FloatParameter minimumParameter = new FloatParameter { value = 0 };
    FloatParameter defaultParameter = new FloatParameter { value = 100 };


    private void Start() {
        colorManager = colorObject.GetComponent<ColorManager>();//�J���[�}�l�[�W���[�N���X�̃C���X�^���X��

        // PostProcessVolume �ɃX�^�b�N���ꂽ Effect ���i�[���ꂽ�z�� PostProcessVolume.profile.settings ���� ColorGrading ��T���ĎQ��
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
    /// RGB���ƂɃX�R�A�\��
    /// </summary>
    void RgbScores() {
        redScoreText.text = "R : " + colorManager.redCount;
        greenScoreText.text = "G : " + colorManager.greenCount;
        blueScoreText.text = "B : " + colorManager.blueCount;

    }

    /// <summary>
    /// PostProcess�ɂ��ύX
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

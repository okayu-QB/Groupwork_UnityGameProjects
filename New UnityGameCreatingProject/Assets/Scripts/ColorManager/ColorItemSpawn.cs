using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorItemSpawn : MonoBehaviour
{
    //public int clorItemSpawnValue = 15;

    [SerializeField]
    GameObject[] spawner;

    [SerializeField]
    GameObject[] colorObjects;

    List<int> numbers = new List<int>();

    public int maxSpawn = 15;

    public GameObject colorManagerComponent;
    ColorManager colorManager;

    public GameObject rgbManagerComporment;
    RGBScore rgbScore;


    //int rgbJud;//�ǂ�RGB�I�u�W�F�N�g���X�|�[�������邩���f����ϐ�


    // Start is called before the first frame update
    void Start()
    {
        colorManager = colorManagerComponent.GetComponent<ColorManager>();//�J���[�}�l�[�W���[�N���X�̃C���X�^���X��
        rgbScore = rgbManagerComporment.GetComponent<RGBScore>();//RGBScore�N���X�̃C���X�^���X��

        MakeRandomNumber();

        //rgbJud = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeRandomNumber() {

        Debug.Log(spawner.Length);
        for(int i = 1; i <= maxSpawn; i++) {
            numbers.Add(i);
        }

        int rgbJud = 0;//�ǂ�RGB�I�u�W�F�N�g���X�|�[�������邩���f����ϐ�

        for (int j = 0; j < maxSpawn; j++) {
            int index = Random.Range(0, numbers.Count);

            int randomNumber = numbers[index];

            Debug.Log(randomNumber);

            Spawn(rgbJud, randomNumber);

            rgbJud++;
            if(rgbJud > 2) {
                rgbJud = 0;
            }

            numbers.RemoveAt(index);
        }
        
    }

    
    void Spawn(int rgbJud ,int randomNunber) {
        GameObject.Instantiate(colorObjects[rgbJud], spawner[randomNunber - 1].transform.position, Quaternion.Euler(-90f, 0f, 0f));
    }
    
}

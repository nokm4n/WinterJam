using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SoundLevel : MonoBehaviour
{

    private string path = "./"; // путь к файлу
    public string nameFile = "test.txt"; // название файла 
    public float slide;
    public AudioSource ad;

    private void Start()
    {

        // Start is called before the first frame update
        StreamReader sr = new StreamReader(path + "/" + nameFile); // ��������� ����
        if (sr != null)
        {
            slide = float.Parse(sr.ReadLine()); // ������ ������
        }
        else
            slide = 0;
        sr.Close(); // ��������� ����

        ad.volume = slide;
        //Debug.Log(slide);
        InvokeRepeating("UpgradeSpeed", 10, 10);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

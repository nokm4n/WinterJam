using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Settings : MonoBehaviour
{
    private string path = "./"; // ���� � �����
    public string nameFile = "test.txt"; // �������� ����� 

    public Slider slide;
    public AudioSource ad;
    private float volume;

	private void Start()
	{
        StreamReader sr = new StreamReader(path + "/" + nameFile); // ��������� ����
        if (sr != null)
        {
            slide.value = float.Parse(sr.ReadLine()); // ������ ������
        }
        else
            slide.value = 0;
            sr.Close(); // ��������� ����

    }

	public void FullScreenToggle()
    {
        //isFullScreen = !isFullScreen;
        //Screen.fullScreen = isFullScreen;
    }
    public void Update()
    {
        ad.volume = slide.value;
        volume = slide.value;
        Debug.Log(volume);
        StreamWriter sw = new StreamWriter(path + "/" + nameFile); // ������ ����
        sw.WriteLine(volume); // ���������� � ���� ������
        sw.Close(); // ��������� ����
    }
    
    
}

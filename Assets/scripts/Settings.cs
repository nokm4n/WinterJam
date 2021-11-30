using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Settings : MonoBehaviour
{
    private string path = "./"; // путь к файлу
    public string nameFile = "test.txt"; // название файла 

    public Slider slide;
    public AudioSource ad;
    private float volume;

	private void Start()
	{
        StreamReader sr = new StreamReader(path + "/" + nameFile); // открываем файл
        if (sr != null)
        {
            slide.value = float.Parse(sr.ReadLine()); // читаем строку
        }
        else
            slide.value = 0;
            sr.Close(); // закрываем файл

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
        StreamWriter sw = new StreamWriter(path + "/" + nameFile); // создаём файл
        sw.WriteLine(volume); // записываем в файл строку
        sw.Close(); // закрываем файл
    }
    
    
}

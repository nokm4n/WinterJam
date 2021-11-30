using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DeleteObj : MonoBehaviour
{
    [Range(0, 1)]
    private float ChanseDelete = 0.5f;
    private string path = "./"; // путь к файлу
    public string nameFile = "count.txt"; // название файла 
    int count;

    void Start()
    {
        if(gameObject.tag != "Item")
		{
            ChanseDelete = 0.73f;

        }
        if (Random.value > ChanseDelete)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if(gameObject.tag=="Item")
		{
            StreamReader sr = new StreamReader(path + "/" + nameFile); // открываем файл
            count = int.Parse(sr.ReadLine()); // читаем строку
            sr.Close(); // закрываем файл


            StreamWriter sw = new StreamWriter(path + "/" + nameFile); // создаём файл
            sw.WriteLine(++count); // записываем в файл строку
            sw.Close(); // закрываем фай
           //
        }
    }


}

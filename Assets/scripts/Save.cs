using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    private string save;
    private string path = "C:\\Users\\Никита\\Desktop\\прога\\vs\\WinterJam"; // путь к файлу
    public string nameFile = "test.txt"; // название файла 

    public void WriteSave()
    { // функция сохранения
      /*  StreamWriter sw = new StreamWriter(path + "/" + nameFile); // создаём файл
       // sw.WriteLine("fffffffffffgffff"); // записываем в файл строку
        sw.Close(); // закрываем файл*/
    }

    public void Start()
	{
      /*  StreamReader sr = new StreamReader(path + "/" + nameFile); // открываем файл
        save = sr.ReadLine(); // читаем строку
        Debug.Log(save); 
        sr.Close(); // закрываем файл*/

    }

}

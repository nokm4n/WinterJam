using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Collectables : MonoBehaviour
{
	public GameObject scoreText;
	public int score=0;
	public AudioSource collectSound;


	private string path = "./"; // путь к файлу
	public string nameFiles = "test.txt";
	public string nameFile = "count.txt"; // название файла 
	private int count = 0;
	int couunt;

	private void Start()
	{

		StreamReader sr = new StreamReader(path + "/" + nameFile); // открываем файл
		count = int.Parse(sr.ReadLine()); // читаем строку
		sr.Close(); // закрываем файл
		couunt = count - 1;

		float slide = 0;
		StreamReader srr = new StreamReader(path + "/" + nameFiles); // ��������� ����
		if (srr != null)
		{
			slide = float.Parse(srr.ReadLine()); // ������ ������
		}
		else
			slide = 0;
		srr.Close(); // ��������� ����

		collectSound.volume = slide;
		//Debug.Log(slide);
		InvokeRepeating("UpgradeSpeed", 10, 10);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item")
		{
			collectSound.Play();
			score++;
			scoreText.GetComponent<Text>().text = "SCORE: " + score + "\tGOAL: " + couunt
				+  "\nSPEED: " + gameObject.GetComponent<PlayerMovement>().speed;


		//	Debug.Log("1");
			Destroy(other.gameObject);


		}


	}
	private void Update()
	{
		scoreText.GetComponent<Text>().text = "SCORE: " + score +"\tGOAL: " + couunt
				+ "\nSPEED: " + gameObject.GetComponent<PlayerMovement>().speed;
		if(score == count-1 || Input.GetKey(KeyCode.Q))
		{
			SceneManager.LoadScene("D");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.SceneManagement;

public class heroscript : MonoBehaviour
{
    private string path = "./"; // ���� � �����
    public string nameFile = "test.txt"; // �������� ����� 
    public float speed;
    public CharacterController cc;
    public AudioSource ad;
    public int Giftboxex = 0;
    public float slide;
    public AudioClip moneyclip;
    AudioSource audio;
    public float rotationspeed = 90;
    public float mouseposition,localy, newangle, rotating;
    public int MaxGifts;
    public float normaltime;
    public Pause_menu ps;
    void Start()
    {
        MaxGifts = 15;
        speed = 10;
        InvokeRepeating("UpgradeSpeed", 15, 15);
        cc = this.gameObject.GetComponent<CharacterController>();
        StreamReader sr = new StreamReader(path + "/" + nameFile); // ��������� ����
        if (sr != null)
        {
            slide = float.Parse(sr.ReadLine()); // ������ ������
        }
        else
        {
            slide = 0;
            sr.Close(); // ��������� ����
        }
        //ad.volume = slide;
        //Debug.Log(slide);
        audio = GetComponent<AudioSource>();
        normaltime = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseposition = Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f;
        localy = this.gameObject.transform.localEulerAngles.y > 180 ? this.gameObject.transform.localEulerAngles.y - 360 : this.gameObject.transform.localEulerAngles.y;
        newangle = Mathf.Clamp(localy + (mouseposition * rotationspeed * Time.deltaTime), -45, 45);
        rotating = localy - newangle;
        transform.Rotate(Vector3.down * rotating);
        checkforend();
        if (Input.GetKey(KeyCode.LeftShift)) //&& ps.GameIsPause==false)
        {
            speed = normaltime * 0.5f;
           
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) //&& ps.GameIsPause == false)
        {
            speed = normaltime;
        }
    }
    private void FixedUpdate()
    {
        cc.Move(transform.rotation * Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A) && this.gameObject.transform.position.x>-7.5f)
        {
            cc.Move(Vector3.left * speed * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && this.gameObject.transform.position.x < 7.5f)
        {
            cc.Move(Vector3.right * speed * Time.fixedDeltaTime);
        }
    }
    public void UpgradeSpeed()
    {
        speed += 2;
        normaltime = speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gift" && other.gameObject.activeSelf)
        {
            Giftboxex += 1;
            audio.PlayOneShot(moneyclip);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Enemy" && other.gameObject.activeSelf)
        {
            Application.LoadLevel("D");
        }
    }
    public void checkforend()
    {
        if(Giftboxex>=MaxGifts || this.gameObject.transform.position.z >= 2500)
        {
            Debug.Log("Выиграл");
            SceneManager.LoadScene("Menu");
            //  EditorApplication.isPlaying = false;
        }
    }
}

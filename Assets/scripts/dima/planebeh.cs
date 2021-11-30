using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planebeh : MonoBehaviour
{
    public GameObject leftplane;
    public GameObject rightplane;
    public GameObject middleplane;
    public int chance;
    public GameObject surp;
    public GameObject enemy;
    public GameObject neededPlat;
    public GameObject hero;
    public GameObject copy;
    public GameObject Zabor;
    void Start()
    {
        leftplane = this.gameObject.transform.Find("LEFT").gameObject;
        rightplane = this.gameObject.transform.Find("RIGHT").gameObject;
        middleplane = this.gameObject.transform.Find("MIDDLE").gameObject;
        chance = Random.Range(0, 101);
        ThatPlatformTag(chance);
        enemy = this.gameObject.transform.Find("Enemy").gameObject;
        surp = this.gameObject.transform.Find("Surp").gameObject;
        enemy.SetActive(false);
        surp.SetActive(false);
        SurpOrEnemy();
        hero = GameObject.FindGameObjectWithTag("MainHero");
       // copy = this.gameObject;
        Zabor = this.gameObject.transform.Find("LEFTogr").gameObject.transform.Find("Zabor").gameObject;
        Zabor.transform.localScale = new Vector3(0.2f, Random.Range(0.4f,0.7f),0.2f);
        Zabor = this.gameObject.transform.Find("RIGHTogr").gameObject.transform.Find("Zabor").gameObject;
        Zabor.transform.localScale = new Vector3(0.2f, Random.Range(0.4f, 0.7f), 0.2f);
        if (this.gameObject.transform.position.z % 60 == 0)
        {
            this.gameObject.transform.Find("FORESTL").transform.gameObject.SetActive(true);
            this.gameObject.transform.Find("FORESTR").transform.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.Find("FORESTL").transform.gameObject.SetActive(false);
            this.gameObject.transform.Find("FORESTR").transform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
         if ((hero.transform.position.z- this.gameObject.transform.position.z)>5)
         {
            GameObject copyone = Instantiate(copy);
            copyone.transform.position = this.gameObject.transform.position + (Vector3.forward * 250);
            copyone.SetActive(true);
            Destroy(this.gameObject);
         }
        if (surp.activeSelf)
        {
            surp.transform.RotateAround(surp.transform.position,new Vector3(0,1,0),50 * Time.deltaTime);
        }
        

    }
    public void ThatPlatformTag(int OurChance)
    {
        if (this.gameObject.transform.position.z < 1000)
        {
            if (OurChance < 9)
            {
                this.gameObject.transform.tag = "FriendlyPlat";
            }
            else if (OurChance >= 9 && OurChance <= 44)
            {
                this.gameObject.transform.tag = "EnemyPlat";
            }
            else
            {
                this.gameObject.transform.tag = "CasualPlat";
            }
        }
        else
        {
            if (OurChance < 14)
            {
                this.gameObject.transform.tag = "FriendlyPlat";
            }
            else if (OurChance >= 14 && OurChance <= 74)
            {
                this.gameObject.transform.tag = "EnemyPlat";
            }
            else
            {
                this.gameObject.transform.tag = "CasualPlat";
            }
        }
    }
    public void SurpOrEnemy()
    {
        int whatPlat = Random.Range(0, 3);
        switch (whatPlat)
        {
            case 0:
                neededPlat = leftplane;
                break;
            case 1:
                neededPlat = middleplane;
                break;
            case 2:
                neededPlat = rightplane;
                break;
        }
        if (this.gameObject.tag == "EnemyPlat")
        {
            enemy.SetActive(true);
            int size = Random.Range(70, 120);
            enemy.transform.localScale = new Vector3(size, size, size);
            enemy.transform.localPosition = (neededPlat.transform.localPosition + (Vector3.up * 1));
        }
        else if (this.gameObject.tag == "FriendlyPlat")
        {
            surp.SetActive(true);
            surp.transform.localPosition = (neededPlat.transform.localPosition + (Vector3.up * 3));
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject Plate;
    private int i;
    public GameObject panel;
    public heroscript hs;
    public Text text;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        text = panel.transform.Find("Text").GetComponent<Text>();
        for (i = -5; i < 45; i += 1)
        {
            GameObject copy = Instantiate(Plate);
            copy.transform.position = new Vector3(0, 0, i * 5);
        }
        hs = GameObject.FindGameObjectWithTag("MainHero").GetComponent<heroscript>();
        Calibrate(panel, Screen.width / 4, Screen.height / 8, -Screen.width / 8, -Screen.height / 16);
        Calibrate(panel.transform.Find("Image").gameObject, panel.GetComponent<RectTransform>().rect.width / 3, Screen.height / 8, panel.GetComponent<RectTransform>().rect.width / 6, 0);
        Calibrate(panel.transform.Find("Text").gameObject, panel.GetComponent<RectTransform>().rect.width * 2 / 3, Screen.height / 8, -panel.GetComponent<RectTransform>().rect.width / 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
     //   Cursor.visible = false;
        text.text = hs.Giftboxex + "/"+hs.MaxGifts;
    }
    public void Calibrate(GameObject gj, float x, float y, float fromx, float fromy)
    {
        RectTransform rt = gj.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(x, y); //ШиринаВысота
        rt.anchoredPosition = new Vector2(fromx, fromy);
    }
}

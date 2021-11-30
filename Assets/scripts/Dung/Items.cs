using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private float rotationSpeed = 15f;
    private float moveSpeed = 0.6f;
    private float change = 1.3f;

    private float flag = 0;
    

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
        gameObject.transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        flag += Time.deltaTime;
        if (flag>change)
        {
            flag =0;
            moveSpeed = -moveSpeed;
        }
    }
}

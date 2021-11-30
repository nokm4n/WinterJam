using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 18f;
    private float gravity = -27f;
    private float jumpHeight = 1.5f;

    public Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;
    public GameObject player;
	private void Start()
	{
        controller = GetComponent<CharacterController>();
	}
	// Update is called once per frame
	void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(groundCheck.position.y< -10)
		{
            Debug.Log("q");
        }
        if(isGrounded && velocity.y<0)
		{
            velocity.y = -2f;
		}

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift) && speed < 70)
        {
            speed = 36f;
           // speed++;
        }
        else if(speed >18f)
        {
            // speed--;
            speed = 18f;
        }
        controller.Move(move * speed * Time.deltaTime);
      
         if (Input.GetButtonDown("Jump") && isGrounded)
		{

            velocity.y = Mathf.Sqrt(jumpHeight * -2f *gravity);
		}

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

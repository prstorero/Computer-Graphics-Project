using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	float normalSpeed = 5.0f;
	float fastSpeed = 15.0f;
	public GameObject player;

	public float mouseSensitivityX = 3.0f;
	public float mouseSensitivityY = 3.0f;

	public float smooth = 2.0F;
	public float tiltAngle = 0.0F; // How much to tilt

	public bool PlayerMoving = true;

	float rotY = 0.0f;

	void Start()
	{
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}

	// Use this for initialization
	void Awake()
	{
		Vector3 startPos = new Vector3(0.0f, -27f, 0.0f);
	}

	// Update is called once per frame
	void Update()
	{
		// variables used for rotation via a mouse
		float tiltAroundZ = Input.mousePosition.z;
		float tiltAroundX = Input.mousePosition.x;
		float tiltAroundY = Input.mousePosition.y;

		Quaternion target = Quaternion.Euler(-tiltAroundY, tiltAroundX, 0); // rotate about the x and y axes by moving the mouse along the y
																			// and x axes, respectively

		transform.rotation = target; // spherically inteerpolates from the
																									// original position to our target position depending on where the mouse moves

		float forward = Input.GetAxis("Vertical"); // Used for forward/backward movement
		float strafe = Input.GetAxis("Horizontal"); // Used for left/right movement

		if (forward != 0.0f) // If we are currently moving, keep moving
		{
			PlayerMoving = true;
			float speed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : normalSpeed; // 
			Vector3 trans = new Vector3(0.0f, 0.0f, forward * Time.deltaTime * speed); // How much we move and along which axes

			/* Multiplying by Time.deltaTime says you want to move the object X distance per second rather than per frame, since the function is run
             *  per frame.
             * 
             */
			gameObject.transform.localPosition += gameObject.transform.localRotation * trans; // Update players position
		}

		if (Input.GetKey(KeyCode.U))
		{
			gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
		}

		gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 0.5f, gameObject.transform.localPosition.z);

		if (strafe != 0.0f) // If we are currently moving, keep moving
		{
			PlayerMoving = true;
			float speed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : normalSpeed;
			Vector3 trans = new Vector3(strafe * Time.deltaTime * speed, 0.0f, 0.0f); // How much we move and along which axes
			gameObject.transform.localPosition += gameObject.transform.localRotation * trans; // Update players position
		}
	}
}

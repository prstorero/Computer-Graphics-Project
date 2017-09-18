using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPortal : MonoBehaviour {

	public GameObject leftPortal;
	public GameObject rightPortal;

	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) // Left mouse click
		{
			Debug.Log("Left click");
			throwPortal(leftPortal);
		}
		if (Input.GetMouseButtonDown(1)) // Right mouse click
		{
			throwPortal(rightPortal);
		}
	}

	void throwPortal(GameObject portal) // Function for making a portal
	{
		// We want to throw the portal from the middle of the screen, so first determine the middle
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y)); // Enable us to shoot the ray
		RaycastHit hit; // Remember what our raycast hit

		if (Physics.Raycast(ray, out hit)) // If our ray hits something, move the portal to that position
		{
			Debug.Log("Ray hit");
			portal.transform.position = hit.point; // Places the portal where the raycast hit
		}
	}
}

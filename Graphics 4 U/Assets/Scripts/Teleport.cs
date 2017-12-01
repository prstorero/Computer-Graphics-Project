using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	private GameObject player;
	private GameObject playerCamera;

	// Portal variables
	private GameObject homePortalTopic1;
	private GameObject homePortalTopic2;
	private GameObject topic1Portal;
	private GameObject topic2Portal;

	// Topic 2 variables
	private GameObject topic2Canvas;
	private GameObject pickups;
	private bool isTopic2 = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		homePortalTopic1 = GameObject.FindWithTag("homePortalTopic1");
		homePortalTopic2 = GameObject.FindWithTag("homePortalTopic2");
		topic1Portal = GameObject.FindWithTag("topic1Portal");
		topic2Portal = GameObject.FindWithTag("topic2Portal");
		topic2Canvas = GameObject.FindWithTag("topic2Canvas");
		pickups = GameObject.FindWithTag("pickups");

		topic2Canvas.SetActive(false);
		pickups.SetActive(false);

		playerCamera = GameObject.FindWithTag("PlayerCamera");

	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.tag.Equals("Terrain"))
			Debug.Log("Collision detected with " + collision.gameObject.tag);

//		player.transform.position = new Vector3(0, 0, 0);

		switch (collision.gameObject.tag)
		{
			case "homePortalTopic1":
				player.transform.position = topic1Portal.transform.position + Vector3.back;
				break;
			case "homePortalTopic2":
				player.transform.position = topic2Portal.transform.position + Vector3.back;
				//topic2Canvas.SetActive(true);
				//pickups.SetActive(true);
				isTopic2 = true;
				GetComponent<PlayerMovement>().enabled = false;
				playerCamera.SetActive(false);
				break;
			case "topic1Portal":
				player.transform.position = homePortalTopic1.transform.position + Vector3.forward;
				break;
			case "topic2Portal":
				player.transform.position = homePortalTopic2.transform.position + Vector3.forward;
				topic2Canvas.SetActive(false);
				pickups.SetActive(false);
				break;
		}
	}

	// Update is called once per frame
	void Update () {

		if (isTopic2 && Input.GetKeyDown(KeyCode.Escape))
		{
			isTopic2 = false;
			GetComponent<PlayerMovement>().enabled = true;
			playerCamera.SetActive(true);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	private GameObject player;
	private GameObject playerCamera;

	// Portal variables
	private GameObject homePortalTopic1;
	private GameObject homePortalTopic2;
	private GameObject homePortalTopic3;
	private GameObject homePortalTopic2Shooter;
	private GameObject topic1Portal;
	private GameObject topic2Portal;
	private GameObject topic3Portal;

	// Topic 2 variables
	private GameObject topic2Canvas;
	private GameObject pickups;
	private GameObject topic2Camera;
	private bool isTopic2 = false;

	// Topic 2 Shooter game variables
	private GameObject shooterCanvas;
	private GameObject shooterPlayer;
	private GameObject shooterStarField;
	private GameObject shooterGameController;
	private GameObject shooterCamera;

	// Portal camera objects
	private GameObject camera1;
	private GameObject camera2;
	private GameObject camera3;
	private GameObject camera4;
	private GameObject camera5;
	private GameObject camera6;
	private GameObject camera7;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		homePortalTopic1 = GameObject.FindWithTag("homePortalTopic1");
		homePortalTopic2 = GameObject.FindWithTag("homePortalTopic2");
		homePortalTopic3 = GameObject.FindWithTag("homePortalTopic3");
		homePortalTopic2Shooter = GameObject.FindWithTag("HomePortalTopic2 Shooter");
		topic1Portal = GameObject.FindWithTag("topic1Portal");
		topic2Portal = GameObject.FindWithTag("topic2Portal");
		topic3Portal = GameObject.FindWithTag("topic3Portal");
		topic2Canvas = GameObject.FindWithTag("topic2Canvas");
		pickups = GameObject.FindWithTag("pickups");

		// Get shooter game objects
		shooterCanvas = GameObject.FindWithTag("shooterCanvas");
		shooterPlayer = GameObject.FindWithTag("shooterPlayer");
		shooterStarField = GameObject.FindWithTag("shooterStarField");
		shooterGameController = GameObject.FindWithTag("shooterGameController");
		shooterCamera = GameObject.FindWithTag("shooterCamera");

		// Initially disable shooter game objects
		shooterCanvas.SetActive(false);
		shooterPlayer.SetActive(false);
		shooterStarField.SetActive(false);
		shooterGameController.SetActive(false);
		shooterCamera.SetActive(false);

		// Get references to portal cameras
		camera1 = GameObject.FindWithTag("camera1");
		camera2 = GameObject.FindWithTag("camera2");
		camera3 = GameObject.FindWithTag("camera3");
		camera4 = GameObject.FindWithTag("camera4");
		camera5 = GameObject.FindWithTag("camera5");
		camera6 = GameObject.FindWithTag("camera6");
		camera7 = GameObject.FindWithTag("camera7");

		topic2Canvas.SetActive(false);
		pickups.SetActive(false);

		playerCamera = GameObject.FindWithTag("PlayerCamera");

		topic2Camera = GameObject.FindWithTag("topic2Camera");

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
				// Disable all portal cameras so we don't switch to them
				camera1.SetActive(false);
				camera2.SetActive(false);
				camera3.SetActive(false);
				camera4.SetActive(false);
				camera5.SetActive(false);
				camera6.SetActive(false);
				camera7.SetActive(false);

				player.transform.position = topic2Portal.transform.position + Vector3.back;
				topic2Canvas.SetActive(true);
				pickups.SetActive(true);
				isTopic2 = true;
				GetComponent<PlayerController>().enabled = false;
				playerCamera.SetActive(false);
				topic2Camera.SetActive(true);
				break;
			case "HomePortalTopic2 Shooter":
				playerCamera.SetActive(false);
				topic2Camera.SetActive(false);

				// Disable all portal cameras so we don't switch to them
				camera1.SetActive(false);
				camera2.SetActive(false);
				camera3.SetActive(false);
				camera4.SetActive(false);
				camera5.SetActive(false);
				camera6.SetActive(false);
				camera7.SetActive(false);

				isTopic2 = true;

				// Turn on shooter game objects
				shooterCamera.SetActive(true);
				shooterCanvas.SetActive(true);
				shooterPlayer.SetActive(true);
				shooterStarField.SetActive(true);
				shooterGameController.SetActive(true);
		break;
			case "homePortalTopic3":
				player.transform.position = topic3Portal.transform.position + Vector3.forward;
				break;
			case "topic1Portal":
				player.transform.position = homePortalTopic1.transform.position + Vector3.forward;
				break;
			case "topic2Portal":
				player.transform.position = homePortalTopic2.transform.position + Vector3.forward;
				topic2Canvas.SetActive(false);
				pickups.SetActive(false);
				break;
			case "topic3Portal":
				player.transform.position = homePortalTopic3.transform.position + Vector3.back;
				break;
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (isTopic2 && Input.GetKeyDown(KeyCode.Escape))
		{
			isTopic2 = false;
			GetComponent<PlayerController>().enabled = true;
			playerCamera.SetActive(true);
			topic2Canvas.SetActive(false);
			pickups.SetActive(false);

			// Turn off shooter game objects
			shooterCanvas.SetActive(false);
			shooterPlayer.SetActive(false);
			shooterStarField.SetActive(false);
			shooterGameController.SetActive(false);
			shooterCamera.SetActive(false);
		}

		// If we're in topic 2, allow switching to the shooter game
/*		if (isTopic2 && Input.GetKeyDown(KeyCode.Alpha2))
		{
			// Turn off roller ball objects
			topic2Canvas.SetActive(false);
			pickups.SetActive(false);

			// Turn on shooter game objects
			shooterCanvas.SetActive(true);
			shooterPlayer.SetActive(true);
			shooterStarField.SetActive(true);
			shooterGameController.SetActive(true);
			shooterCamera.SetActive(true);
		}
		*/
	}
}

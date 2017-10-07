using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	private GameObject player;
	private GameObject homePortalTopic1;
	private GameObject topic1Portal;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		homePortalTopic1 = GameObject.FindWithTag("homePortalTopic1");
		topic1Portal = GameObject.FindWithTag("topic1Portal");
		
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
			case "topic1Portal":
				player.transform.position = homePortalTopic1.transform.position + Vector3.forward;
				break;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}

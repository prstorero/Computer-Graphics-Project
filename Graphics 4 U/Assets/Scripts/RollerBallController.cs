using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollerBallController : MonoBehaviour {
    public float speed = 5;
    public Text questionText;
    public Text winText;
    public Text countText;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        questionText.text = "What are two ways to convert between logical and device coordinates?";
        winText.text = "";
        //countText.text = "";
    }

    void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("correct1")) //find gameobject that has the same tag as the string "Pickup"
        {
            other.gameObject.SetActive(false); //deactivate game pickup objects
            questionText.text = "What data type does a device coordinate system use?";
        }
        if (other.gameObject.CompareTag("correct2")) //find gameobject that has the same tag as the string "Pickup"
        {
            other.gameObject.SetActive(false); //deactivate game pickup objects
            questionText.text = "Which coordinate system goes upward on the positive y-axis?";
        }
        if (other.gameObject.CompareTag("correct3")) //find gameobject that has the same tag as the string "Pickup"
        {
            other.gameObject.SetActive(false); //deactivate game pickup objects
            SetCountText();
        }
        }
     

    void SetCountText()
    {
        winText.text = "You got everything correct!";
    }
}

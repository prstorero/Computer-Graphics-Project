using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollerBallController : MonoBehaviour
{
    public float speed = 5;
    public Text questionText;
    public Text winText;
    public Text countText;

    private Rigidbody rb;
  

    // Arrays to ensure question/answer order
    private static string[] answerArray = new string[] { "correct1", "correct2", "correct3", "correct4", "correct5"};
    private string[] questionArray = new string[] { "What are two ways to convert between logical and device coordinates?",
                                                    "What data type does a device coordinate system use?",
                                                    "Which coordinate system goes upward on the positive y-axis?", "What feature does a logical coordinate system contain?", "Which coordinate system travels downward on the positive y-axis?" };

    // Keep track of where to index into the answer and question arrays
    private int answerIndex = 0;
    private int questionIndex = 0;

    private int numQA = 5; // Number of questions/answers

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        questionText.text = questionArray[questionIndex++];
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);


    }

    void OnTriggerEnter(Collider other)
    {
        if (answerIndex < numQA && other.gameObject.CompareTag(answerArray[answerIndex]))
        {
            other.gameObject.SetActive(false);
            answerIndex++;

            if (questionIndex < numQA) // Assign next question text if we haven't reached the end
                questionText.text = questionArray[questionIndex++];

            if (answerIndex > 4)
                SetCountText();
        }
    }


    void SetCountText()
    {
        winText.text = "You got everything correct!";
    }
}
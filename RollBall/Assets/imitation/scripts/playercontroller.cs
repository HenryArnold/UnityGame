using UnityEngine;

//Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class Playercontroller : MonoBehaviour
{
	//create public variables for player speed, and for the Text UI game object
	public float speed;
	public Text countText;
	public Text winText;

	//creat private references to the rigidbody component on the player, and the count of pick up object picked up so far
	private Rigidbody rb;
	private int count;

	void Start ()
	{
		//assign the rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		//set the count to zero
		count = 0;

		//run the setcounttext function to update the ui
		SetCountText ();
		//set the text property of our win text ui to an empty string, making the 'you win'
		winText.text = "";
	}

	//each physics step..
	void FixedUpdate ()
	{
		//set some local float variables equal to the value of our horizontal and vertical inputs
		float moveHorizontal = Input.GetAxis("horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("pick up"))
		{
			other.gameObject.SetActive (false);

			count = count + 1;

			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count:" + count.ToString ();

		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	}

}


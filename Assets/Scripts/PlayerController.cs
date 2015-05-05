using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody sphereRB;
	public float speed;
	private int count;
	public Text countText;
	public Text winText;
	private bool win;

	void Start(){
		sphereRB = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		winText.text = "";
		win = false;
	}
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		sphereRB.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			count++;
			setCountText();
		}
		if (other.gameObject.CompareTag ("Pick Up Win")) {
			other.gameObject.SetActive(false);
			win = true;
			setCountText();
		}
	}
	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 8 && win) {
			winText.text = "You've Won!!!";
		}
		if (win && count < 8) {
			winText.text= "You've Lost :(";
		}
	}
}
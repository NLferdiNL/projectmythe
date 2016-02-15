

using UnityEngine;
using System.Collections;

public class BackupMovement : MonoBehaviour {

	[SerializeField]private float Speed = 4;
	[SerializeField]private float rotateSpeed;
	[SerializeField]private bool Player;
	[SerializeField]private float jumpHeight;
	[SerializeField]private int jumpTime;
	[SerializeField]private int maxJumpTime;
	// Use this for initialization
	void Start () {
		jumpTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		P1Moving ();
		P1Rotate ();
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			jumpTime = 0;
		}
	}

	public void P1Rotate()
	{if (Player == true) {
			//Rotates the player on the Y Axis
			if (Input.GetKey (KeyCode.Q)) {        //Rotates Left
				transform.Rotate (-Vector3.up * Time.deltaTime * rotateSpeed);
			}
			if (Input.GetKey (KeyCode.E)) {       //Rotates Right
				transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);
			}
		}
	}
	void P1Moving()
	{if (Player == true) {
			if (Input.GetKey (KeyCode.W)) {                 //Walk Forward
				transform.Translate (Vector3.forward * Time.deltaTime * Speed);
			}
			if (Input.GetKey (KeyCode.A)) {                //Walk Left
				transform.Translate (Vector3.left * Time.deltaTime * Speed);
			}
			if (Input.GetKey (KeyCode.S)) {                //Walk Backwards
				transform.Translate (-Vector3.forward * Time.deltaTime * Speed);
			}
			if (Input.GetKey (KeyCode.D)) {                //Walk Right
				transform.Translate (Vector3.right * Time.deltaTime * Speed);
			}
			if(jumpTime < maxJumpTime){
			  if (Input.GetKey (KeyCode.Space)) {
					jumpTime = jumpTime +1;
					this.GetComponent<Rigidbody>().velocity = new Vector3(0,jumpHeight,0);
			  }
			}
		}
	}
}
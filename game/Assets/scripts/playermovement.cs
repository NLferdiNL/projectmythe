using UnityEngine;
using System.Collections;

public class playermovement : MonoBehaviour 
{
    // This script is only for testing the powerups.
    // Will be removed once a proper movement comes up.
    [SerializeField]
    bool touchingGround = false;

    Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == Tags.GROUND) 
		{
            touchingGround = true;
        }
    }

    void OnCollisionStay(Collision other) 
	{
        if (other.gameObject.tag == Tags.GROUND) 
		{
            touchingGround = true;
        }
    }

    void OnCollisionExit(Collision other) 
	{
        if (other.gameObject.tag == Tags.GROUND) 
		{
            touchingGround = false;
        }
    }

    public void Move(bool forward, bool backward, bool left, bool right, bool jump) 
	{
        if (forward) {
            transform.position += transform.forward / 10;
        } else if (backward) {
            transform.position -= transform.forward / 10 ;
        }

        if (left) {
            transform.Rotate(new Vector3(0, -1));
        } else if (right) {
            transform.Rotate(new Vector3(0, 1));
        }

        if (jump && touchingGround) {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
    }
}

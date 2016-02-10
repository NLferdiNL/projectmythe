using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]
public class Planet : MonoBehaviour {
	[Range(0,200)]
	[SerializeField, TooltipAttribute("the amount of pull this object has on other objects")]
	public float standardAcceleration = 10f;

	private float basePullDistance = 10f;

	Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		if (rb.useGravity == true) {
			rb.useGravity = false;
		}
	}
	void OnEnable(){
		PlanetManager.Register (this);
	}
	void OnDisable(){
		PlanetManager.UnRegister (this);
	}

	public float GetAvgRadius(){
		return ((transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3) / 2;
	}

	public float GetPullRadius(){
		// get radius of when to start pulling in other objects based on object mass and base distance
		return basePullDistance * rb.mass;
	}                      
}

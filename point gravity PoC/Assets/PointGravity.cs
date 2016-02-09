using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PointGravity : MonoBehaviour
{
	[TooltipAttribute("The minimum amount of pull needed to affect the object")]
	public float
		minPull = 0f;
	Rigidbody rb;

	GameObject groundCheck;
	public bool grounded;
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		if (rb.useGravity == true) {
			rb.useGravity = false;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Planet[] items = PlanetManager.GetPlanets ();
		foreach (Planet planet in items) {
			float pullRadius = planet.GetPullRadius();
			//calculate distance between object and planets
			float distance = Vector3.Distance (planet.transform.position, transform.position);
			//get the radius of the planet
			float radius = planet.GetAvgRadius ();

			if (distance <= pullRadius) {
				// Calculate the force needed based on the object's distance, gravity and radius
				// Formula: https://en.wikipedia.org/wiki/Gravity_of_Earth#Altitude
				float acceleration = planet.standardAcceleration * Mathf.Pow ((radius / (radius + distance)), 2f);
				if (acceleration > minPull) {
					//apply force to the object
					rb.AddForce ((planet.transform.position - transform.position).normalized * acceleration);
				}
			}
		}
	}
}

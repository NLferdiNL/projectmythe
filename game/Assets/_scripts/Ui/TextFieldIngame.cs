using UnityEngine;
using System.Collections;


public class TextFieldIngame: MonoBehaviour {

	public string text;
	bool display = false;

	void OnTriggerEnter(Collider col)
	{
		if (col.transform.name == "Player1 || col.transform.name == "Player2") {
			display = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.transform.name == "Player1" || col.transform.name == "Player2") 
		{
			display = false;
		}
	}

	void OnGUI()
	{
		if (display == true) 
		{
			GUI.Box (new Rect(360,300,Screen.width-700, Screen.height-650), text);
		}
	}
}

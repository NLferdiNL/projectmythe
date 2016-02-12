using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {

    [SerializeField]
    bool forward, right, backward, left, jump = false;

    [SerializeField]
    playermovement playermove;

	void Update () {
        CheckKeys();
        CheckKeysDown();
	}

    void CheckKeys() {
        forward = Input.GetKey(KeyCode.W);
        backward = Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);

        jump = Input.GetKey(KeyCode.Space);

        if (left && right) {
            left = right = false;
        }

        if (forward && backward) {
            forward = backward = false;
        }

        playermove.Move(forward, backward, left, right, jump);
    }

    void CheckKeysDown() {
        if (Input.GetKeyDown(KeyCode.E)) {

        }
    }
}

using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {

    bool left, right, up, down = false;

    Vector2 mousePos = new Vector2(0,0);

	void Update () {
        CheckKeys();
        CheckKeysDown();
        CheckMousePos();

        if (left) {
            print("333");
        }
	}

    void CheckKeys() {
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        up = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);
    }

    void CheckKeysDown() {
        if (Input.GetKeyDown(KeyCode.E)) {
            print("222");
        }
    }

    void CheckMousePos() {

    }
}

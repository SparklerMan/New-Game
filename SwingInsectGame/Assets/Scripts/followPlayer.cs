using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    public Rigidbody2D playerRb;

	void Update () {
        Vector3 oof = new Vector3(playerRb.position.x, playerRb.position.y, -10);
        transform.position = oof;
	}

    
}

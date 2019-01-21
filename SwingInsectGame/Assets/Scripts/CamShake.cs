using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour {

    public Animator CamShaker;


    public void ShakeCam() {
        CamShaker.SetTrigger("Shake");
    }

}

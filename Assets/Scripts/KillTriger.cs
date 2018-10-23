using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTriger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D theObject)
    {
        if (theObject.tag == "Player")
        {
            PlayerController.sharedInstance.KillerPlayer();
        }
    }
}

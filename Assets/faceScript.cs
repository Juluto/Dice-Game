using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceScript : MonoBehaviour {

	cubeScript script;

	//Fonction utilisé avant le chargement du jeu
	void Awake () {
		script = GameObject.Find("dice").GetComponent<cubeScript>();
	}
	

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plateau")
        {
            //donner le numéro de la face du dé
            script.face = int.Parse(gameObject.name);
        }
    }
}

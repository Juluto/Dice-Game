using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertScore : MonoBehaviour {

	public string inputName;
	public string inputScore;

	// URL d'accès au PHP AddScore
	string AddScoreURL = "http://localhost/DiceGame/AddScore.php";
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	// Ajout du score dans la bdd
	public void AddScore(){
		WWWForm form = new WWWForm();
		form.AddField("namePost", inputName);
		form.AddField("scorePost", inputScore);

		WWW www = new WWW(AddScoreURL, form);
	}
}

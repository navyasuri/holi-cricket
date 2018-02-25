using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuntyAngerMeter : MonoBehaviour {

	public ParticleSystem explosion;
	public float maxAnger{ get; set; }
	public float currentAnger{ get; set; }
		
	public Slider angerMeter;


	// Use this for initialization
	void Start () {

		maxAnger = 200f;
		currentAnger = 0f;
		angerMeter.value = calculateAnger();
		GameObject.Instantiate (explosion, this.transform.position, Quaternion.identity);
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.X))
			getAngry (10);
		
	}

	void getAngry(float angerAmt){

		currentAnger += angerAmt;
		angerMeter.value = calculateAnger ();
		if (currentAnger > maxAnger)
			Explode ();

	}

	float calculateAnger(){
		return currentAnger / maxAnger;
	}

	void Explode(){
		currentAnger = maxAnger;
		this.GetComponentInParent<MeshRenderer> ().enabled = false;
		//generate particle system
		GameObject.Instantiate (explosion, this.transform.position, Quaternion.identity);
		explosion.Play();

		Debug.Log("Aunty polic bulalegi");
	}
}

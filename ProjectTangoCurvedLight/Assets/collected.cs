using UnityEngine;
using System.Collections;

public class collected : MonoBehaviour {

	private GameObject spawner;

	// Use this for initialization
	void Start () {
		spawner = GameObject.FindGameObjectWithTag ("Spawner");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		spawner.SendMessage ("spawnEgg");
	}

}

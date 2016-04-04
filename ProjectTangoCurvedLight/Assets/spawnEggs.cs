using UnityEngine;
using System.Collections;

public class spawnEggs : MonoBehaviour {

	public GameObject egg;
	public GameObject[] spawnPoints;

	private int pointIndex = -1;
	private int lastPoint = -1;

	private int eggsCollected = -1;

	void Start() {
			spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

		spawnEgg ();
		InvokeRepeating("collected", 0, 5.0F);
	}

	void collected(){
		AndroidHelper.ShowAndroidToastMessage(""+eggsCollected);
	}

	void spawnEgg()
	{
		++eggsCollected;
		if (spawnPoints.Length > 1) {
			while (pointIndex == lastPoint) {
				pointIndex = Random.Range (0, spawnPoints.Length);
			}
			lastPoint = pointIndex;
			Instantiate (egg, spawnPoints [pointIndex].transform.position, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}

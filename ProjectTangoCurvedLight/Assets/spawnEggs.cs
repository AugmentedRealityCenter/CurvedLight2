using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class spawnEggs : MonoBehaviour {

	public GameObject egg;
	public Text score;
	public GameObject[] spawnPoints;

	private int pointIndex = -1;
	private int lastPoint = -1;

	private string minutes;
	private string seconds;

	private int eggsCollected = -1;

	void Start() {
			spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

		spawnEgg ();
		InvokeRepeating("timer", 0, 1.0F);
	}

	void timer(){
		float timer = Time.time;
		minutes = Mathf.Floor (timer / 60).ToString("00");
		seconds = (Time.time % 60).ToString("00");
		score.text = "collected: "+eggsCollected + "\n"+minutes+":"+seconds;
	}

	void spawnEgg()
	{
		++eggsCollected;
		score.text = "collected: "+eggsCollected + "\n"+minutes+":"+seconds;
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

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
		GameObject[] allEggs = GameObject.FindGameObjectsWithTag("egg");
		int[] CurrentSpawns = new int[]{-1,-1,-1};
		int[] PrevSpawns = new int[]{-1,-1,-1};
		foreach( GameObject eg in allEggs )
		{
			Destroy(eg);
		}

		for (int x = 0; x <=1; x++) {
			if (spawnPoints.Length > 2) {
				while (pointIndex == CurrentSpawns[0] || pointIndex == CurrentSpawns[1] || pointIndex == CurrentSpawns[2]
				       || pointIndex == PrevSpawns[0] || pointIndex == PrevSpawns[1] || pointIndex == PrevSpawns[2]) {
					pointIndex = Random.Range (0, spawnPoints.Length);
				}
				lastPoint = pointIndex;
				CurrentSpawns[x] = pointIndex;
				GameObject e = (GameObject)Instantiate (egg, spawnPoints [pointIndex].transform.position, Quaternion.identity);
				e.GetComponent<MeshFilter>().mesh.bounds = new Bounds(new Vector3(0,0,0), new Vector3(2000,2000,2000));
			}
		}
		PrevSpawns = CurrentSpawns;
		CurrentSpawns[0] = -1;
		CurrentSpawns[1] = -1;
		CurrentSpawns [2] = -1;
	}

	public int getEggsCollected()
	{
		return eggsCollected;
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}

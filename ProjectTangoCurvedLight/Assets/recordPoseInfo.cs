using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class recordPoseInfo : MonoBehaviour {

	public GameObject CBHead;
	public Text textField;
	private spawnEggs script;

	private string fileName;
	// Use this for initialization
	void Start () {
		script = GetComponent<spawnEggs>();
		fileName = "PoseInfo_";
		fileName += System.DateTime.Now.ToString ("yyyy_MM_ddThh_mm_ss");
	}

	void startRecordingPoseInfo()
	{
		InvokeRepeating("recordPose", 0, 0.05F);
	}

	void recordPose() {
		string info = "";
		string tab = ",";
		info += CBHead.transform.position.x;
		info += tab;
		info += CBHead.transform.position.y;
		info += tab;
		info += CBHead.transform.position.z;
		info += tab;
		info += CBHead.transform.eulerAngles.x;
		info += tab;
		info += CBHead.transform.eulerAngles.y;
		info += tab;
		info += CBHead.transform.eulerAngles.z;
		info += tab;
		info += Time.time;
		info += tab;
		info += script.getEggsCollected();
		info += "\n";
		System.IO.File.AppendAllText(Application.persistentDataPath+"/"+fileName+".csv", info);
	}
}

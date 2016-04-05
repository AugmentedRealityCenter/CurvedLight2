using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class recordPoseInfo : MonoBehaviour {

	public GameObject CBHead;
	public Text textField;

	private string fileName;
	// Use this for initialization
	void Start () {
		fileName = "PoseInfo_";
		fileName += System.DateTime.Now.ToString ("yyyy_MM_ddThh_mm_ss");
	}

	void startRecordingPoseInfo()
	{
		InvokeRepeating("recordPose", 0, 0.1F);
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
		info += "\n";
		System.IO.File.AppendAllText(Application.persistentDataPath+"/"+fileName+".txt", info);
	}
}

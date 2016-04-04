using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class recordPoseInfo : MonoBehaviour {

	public GameObject CBHead;
	public Text textField;

	private string fileName;
	// Use this for initialization
	void Start () {
		InvokeRepeating("recordPose", 0, 0.1F);
		System.IO.File.AppendAllText(Application.persistentDataPath+"/PoseInfo.txt", "New run\n\n");
		//InvokeRepeating("show", 0, 05F);
	}

	//void Update(){
		//if (textField.text.Length > 0) {
			//fileName = textField.text;
		//}
	//}

	void show()
	{
		AndroidHelper.ShowAndroidToastMessage(fileName);
	}

	void startRecording(){
		fileName = textField.text;
		InvokeRepeating("recordPose", 0, 0.1F);
	}

	void recordPose() {
		string info = "";
		string tab = "\t";
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
		System.IO.File.AppendAllText(Application.persistentDataPath+"/PoseInfo.txt", info);
	}
}

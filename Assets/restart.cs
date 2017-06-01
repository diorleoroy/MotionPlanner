using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine.Events;  
using UnityEngine.UI;  
public class restart : MonoBehaviour {

	// Use this for initialization


	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
	//	plane_name = "potential_1";
	//	goal_control_point = "goal_control_point_1";
	//	gameObject.GetComponent<readrobot>().();
	/*	string delete_obj;
		GameObject SearchObject;
		for (int i = 0; i < readrobot.robot_num; i++) {
			delete_obj = "robot";
		    SearchObject = GameObject.Find (delete_obj);
			Destroy(SearchObject);
			Debug.Log (readrobot.robot_num);
		}

		for (int i = 0; i < readobstacle.obstacle_num; i++) {
			delete_obj = "obstacle";
			SearchObject = GameObject.Find (delete_obj);
			Destroy (SearchObject);
		}*/
		Application.LoadLevel("motion_planning");
	}

	// Update is called once per frame
	void Update () {
	
	}
}

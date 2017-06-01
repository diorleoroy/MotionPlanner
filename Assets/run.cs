using UnityEngine;
using System.Collections;
using UnityEngine.Events;  
using UnityEngine.UI;  
using System.Collections.Generic; 

public class run : MonoBehaviour {


	void TaskOnClick(){
		string ObjectName = "robot";
		GameObject SearchObject = GameObject.Find( ObjectName );
		SearchObject.AddComponent<action>();
	

	
	}
	// Use this for initialization
	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

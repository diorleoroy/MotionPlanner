using UnityEngine;
using System.Collections;
using UnityEngine.Events;  
using UnityEngine.UI;  
using System.Collections.Generic; 

public class show_path : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Button btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	void TaskOnClick(){



		string ObjectName = "robot";
		GameObject SearchObject = GameObject.Find( ObjectName );
		if (SearchObject.GetComponent<bfs_new3> () != null) {
			Destroy (SearchObject.GetComponent<bfs_new3> ());
		}
		SearchObject.AddComponent<bfs_new3>();

		string line_script = "line";
		GameObject SearchObject_line = GameObject.Find (line_script);

		//	SearchObject_line.gameObject.GetComponent<LineRenderer> ().SetPosition(0,Vector3.zero);
		//	SearchObject_line.gameObject.GetComponent<LineRenderer> ().SetPosition(1,Vector3.zero);
		SearchObject_line.gameObject.GetComponent<LineRenderer> ().SetVertexCount(0);
		//	Destroy (SearchObject_line.gameObject.GetComponent<LineRenderer> ());
		//	Destroy (SearchObject_line.gameObject.GetComponent<draw_plan> ());

		//	SearchObject_line.gameObject.GetComponent<draw_plan> ().DestroyLine();


	}
	// Update is called once per frame
	void Update () {
	
	}
}

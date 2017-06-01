using UnityEngine;
using System.Collections;

public class action : MonoBehaviour {
	int time = 0;
	// Use this for initialization
	void Start () {
		string ObjectName = "robot";
		GameObject robot = GameObject.Find (ObjectName);

		time = robot.GetComponent<bfs_new3>().times;

	}
	
	// Update is called once per frame
	void Update () {
		string ObjectNamer = "robot_goal";
		GameObject robot_goal = GameObject.Find (ObjectNamer);

		string ObjectName = "robot";
		GameObject robot = GameObject.Find (ObjectName);

			//		StartCoroutine (delay ());
		gameObject.transform.position = new Vector3 (robot.GetComponent<bfs_new3>().all_path [time].x, robot.GetComponent<bfs_new3>().all_path [time].y, 0);
			//		ru[gg] = gameObject.transform.position;
		gameObject.transform.rotation = Quaternion.Euler (0, 0, robot.GetComponent<bfs_new3>().all_path [time].z);
			time--;




			if (time == -1) {
			gameObject.transform.position = robot_goal.transform.position;
			gameObject.transform.rotation = robot_goal.transform.rotation;
				Destroy (GetComponent<action> ());
				//	Destroy (gameObject.transform.GetComponentInChildren<collision_detection> ());
				Destroy (gameObject.transform.GetChild(0).GetComponent<collision_detection> ());
				Destroy (gameObject.transform.GetChild(1).GetComponent<collision_detection> ());

			}

		}
	}

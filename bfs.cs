using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bfs : MonoBehaviour
{
	Vector4[] visited_plan = new Vector4[16384];
	Vector3 start_position = new Vector3 ();
	now_robot_state robot_state = new now_robot_state ();
	now_robot_state[] visited_point = new now_robot_state[16384];
	List<now_robot_state> open_list = new List<now_robot_state> ();
	int counter = 0;
	int visted_num = 0;
	now_robot_state last_point = new now_robot_state ();
	//	int potential_value = 200;
	// Use this for initialization
	bool stop = false;

	void Start ()
	{
		start_position.x = gameObject.transform.position.x;
		start_position.y = gameObject.transform.position.y;
		start_position.z = gameObject.transform.rotation.eulerAngles.z;
		int stop_count = 0;
		int rob_potential;
		int last_rob_potential = 0;
		while (stop == false && stop_count < 999) {
			stop = start_run ();
			rob_potential = count_potential ();
			if (rob_potential == last_rob_potential) {
				stop_count++;
			}
			last_rob_potential = rob_potential;
		}
		Debug.Log ("Hi");
		gameObject.transform.position = new Vector3 (start_position.x, start_position.y, 0);
		gameObject.transform.rotation = Quaternion.Euler (0, 0, start_position.z);


	}

	class now_robot_state
	{

		public Vector2 initial_point;
		public float arc;
		public int potential;

	}

	class root_data
	{

		public Vector2 root_point;
		public float arc;
		public Vector2 last_point;
		
	}


	void route ()
	{


		root_data[,] potential_tree = new root_data[508, 128];
		ArrayList temp = new ArrayList ();

		root_data gg = new root_data ();
		gg.root_point = new Vector2 (1, 1);
		gg.arc = 90;
		gg.last_point = new Vector2 (2, 1);
		temp.Add (gg);
		potential_tree [0, 0] = (root_data)temp [0];

	

//		Debug.Log (potential_tree[0,0].arc);

	}


	public bool collis = false;

	bool walk ()
	{
		
		int now_potential = 999;
		int tmp_potential;
		bool already_visited;
		Vector2 tmp_init_point = new Vector2 ();
		now_robot_state walk_point = new now_robot_state ();
		//	robot_state.initial_point = gameObject.transform.position;
		//	Debug.Log (robot_state.initial_point.x);
		now_robot_state robot_position = new now_robot_state ();
		robot_position.initial_point.x = gameObject.transform.position.x;
		robot_position.initial_point.y = gameObject.transform.position.y;
		robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
		last_point = robot_position;

/*		gameObject.transform.position.x = robot_tranform.initial_point.x;
		gameObject.transform.position.y = robot_tranform.initial_point.y;
		gameObject.transform.rotation.eulerAngles.z = robot_tranform.arc;*/

		gameObject.transform.position += new Vector3 (1, 0, 0);

		already_visited = false;
		robot_position.initial_point.x = gameObject.transform.position.x;
		robot_position.initial_point.y = gameObject.transform.position.y;
		robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i].initial_point == robot_position.initial_point && visited_point [i].arc == robot_position.arc) {
				already_visited = true;
			}
		}
	//	collis = checkcol ();
	//	Debug.Log (collis);
		if (already_visited == false && collis == false) {
			tmp_potential = count_potential ();
			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (-1, 0, 0);





		gameObject.transform.position += new Vector3 (-1, 0, 0);
		already_visited = false;
		robot_position.initial_point.x = gameObject.transform.position.x;
		robot_position.initial_point.y = gameObject.transform.position.y;
		robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i].initial_point == robot_position.initial_point && visited_point [i].arc == robot_position.arc) {
				already_visited = true;
			}
		}

		if (already_visited == false && collis == false) {
			tmp_potential = count_potential ();
			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (1, 0, 0);




		gameObject.transform.position += new Vector3 (0, 1, 0);
		already_visited = false;
		robot_position.initial_point.x = gameObject.transform.position.x;
		robot_position.initial_point.y = gameObject.transform.position.y;
		robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i].initial_point == robot_position.initial_point && visited_point [i].arc == robot_position.arc) {
				already_visited = true;
			}
		}

		if (already_visited == false && collis == false) {
			tmp_potential = count_potential ();
			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (0, -1, 0);



		gameObject.transform.position += new Vector3 (0, -1, 0);
		already_visited = false;
		robot_position.initial_point.x = gameObject.transform.position.x;
		robot_position.initial_point.y = gameObject.transform.position.y;
		robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i].initial_point == robot_position.initial_point && visited_point [i].arc == robot_position.arc) {
				already_visited = true;
			}
		}

		if (already_visited == false && collis == false) {
			tmp_potential = count_potential ();
			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (0, 1, 0);




		gameObject.transform.position += new Vector3 (0, 1, 0);
		already_visited = false;
		robot_position.initial_point.x = gameObject.transform.position.x;
		robot_position.initial_point.y = gameObject.transform.position.y;
		robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i].initial_point == robot_position.initial_point && visited_point [i].arc == robot_position.arc) {
				already_visited = true;
			}
		}

		if (already_visited == false && collis == false) {
			tmp_potential = count_potential ();
			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (0, -1, 0);


		for (int k = 0; k <= 45; k++) {
			gameObject.transform.Rotate (new Vector3 (0, 0, 4 * k));
			already_visited = false;
			robot_position.initial_point.x = gameObject.transform.position.x;
			robot_position.initial_point.y = gameObject.transform.position.y;
			robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
			for (int i = 0; i < visited_point.Length; i++) {

				if (visited_point [i] == null) {
					break;
				}
				if (visited_point [i].initial_point == robot_position.initial_point && visited_point [i].arc == robot_position.arc) {
					already_visited = true;
				}
			}

			if (already_visited == false && collis == false) {
				tmp_potential = count_potential ();
				if (now_potential > tmp_potential) {
					now_potential = tmp_potential;
					walk_point.initial_point.x = gameObject.transform.position.x;
					walk_point.initial_point.y = gameObject.transform.position.y;
					walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
					walk_point.potential = now_potential;
				}


			}
			gameObject.transform.Rotate (new Vector3 (0, 0, 4 * -k));
		}



		for (int k = 0; k <= 45; k++) {
			gameObject.transform.Rotate (new Vector3 (0, 0, 4 * k));
			already_visited = false;
			robot_position.initial_point.x = gameObject.transform.position.x;
			robot_position.initial_point.y = gameObject.transform.position.y;
			robot_position.arc = gameObject.transform.rotation.eulerAngles.z;
			for (int i = 0; i < visited_point.Length; i++) {

				if (visited_point [i] == null) {
					break;
				}
				if (visited_point [i].initial_point == robot_position.initial_point && visited_point [i].arc == robot_position.arc) {
					already_visited = true;
				}
			}

			if (already_visited == false && collis == false) {
				tmp_potential = count_potential ();
				if (now_potential > tmp_potential) {
					now_potential = tmp_potential;
					walk_point.initial_point.x = gameObject.transform.position.x;
					walk_point.initial_point.y = gameObject.transform.position.y;
					walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
					walk_point.potential = now_potential;
				}


			}
			gameObject.transform.Rotate (new Vector3 (0, 0, 4 * k));

		}


		if (now_potential == 999) {
			return false;
		} else {
			visited_point [visted_num] = walk_point;
			visited_plan [visted_num].x = visited_point [visted_num].initial_point.x;
			visited_plan [visted_num].y = visited_point [visted_num].initial_point.y;
			visited_plan [visted_num].z = visited_point [visted_num].arc;
			//	visited_point [visted_num].initial_point.y = 0f;
			//	visited_point [visted_num].arc = 0f;
			//	visited_point [visted_num].potential = 0;
			/*	visited_point [visted_num].initial_point.y = walk_point.initial_point.y;
			visited_point [visted_num].arc = walk_point.arc;
			visited_point [visted_num].potential = now_potential;
			Debug.Log (visited_point[visted_num]);*/
			//	Debug.Log (visited_point[visted_num].initial_point);

			visted_num++;


			open_list.Add (walk_point);
			gameObject.transform.position = walk_point.initial_point;
			gameObject.transform.rotation = Quaternion.Euler (0, 0, walk_point.arc);

			return true;

		}




//		return now_potential;
	}



	int count_potential ()
	{
		GameObject control_point_0 = gameObject.transform.GetChild (readrobot.gobal_polygon_num [0]).gameObject;
		GameObject control_point_1 = gameObject.transform.GetChild (readrobot.gobal_polygon_num [0] + 1).gameObject;

		if (control_point_0.transform.position.x >= 0 && control_point_0.transform.position.y >= 0 && control_point_0.transform.position.x < 128 && control_point_0.transform.position.y < 128
		    && control_point_1.transform.position.x >= 0 && control_point_1.transform.position.y >= 0 && control_point_1.transform.position.x < 128 && control_point_1.transform.position.y < 128) {
			int potential_value_0 = show_potential.potential_control_point_0 [(int)control_point_0.transform.position.x, (int)control_point_0.transform.position.y];
			int potential_value_1 = show_potential.potential_control_point_1 [(int)control_point_1.transform.position.x, (int)control_point_1.transform.position.y];
			int potential_value = potential_value_0 + potential_value_1;
			return potential_value;
		} else {
			return 999;
		}

	}


	/*	void route()
	{
		//	Vector2 potential = gameObject.transform.position;


		//		List<List<root_data>> list = new List<List<root_data>>();
		//		list.Add (new List <root_data> ());


		//	list.Add (new List <root_data> ());
		/*	ArrayList temp = new ArrayList();
		root_data gg = new root_data();
		gg.root_point = new Vector2 (1, 1);
		gg.arc = 90;
		gg.last_point = new Vector2 (2, 1);
		temp.Add (gg);
		root_data hi = (root_data)temp [0];
		Debug.Log (hi.arc);*/

	/*	root_data[,] potential_tree = new root_data[508,128];
		//	List <root_data> temp = new List<root_data>();
		ArrayList temp = new ArrayList();

		root_data gg = new root_data();
		gg.root_point = new Vector2 (1, 1);
		gg.arc = 90;
		gg.last_point = new Vector2 (2, 1);
		temp.Add (gg);
		//	root_data hi = (root_data)temp [0];
		potential_tree[0,0] = (root_data)temp[0];
		Debug.Log (potential_tree[0,0].arc);



		/*	root_data[,] test = new root_data[508,128];
		root_data gg = new root_data();
		gg.root_point = new Vector2 (1, 1);
		gg.arc = 90;
		gg.last_point = new Vector2 (2, 1);
		test [0,0] = gg;

		Debug.Log (test.GetLength(0));*/

	//	GameObject SearchObject = gameObject.Find ("init_control_point_0");


	/*


	}*/
	// Update is called once per frame
	int test_ipotential = 999;
	bool back = true;

	bool start_run ()
	{
		//	GameObject control_point_0 = gameObject.transform.GetChild(readrobot.gobal_polygon_num[0]).gameObject;
		//	GameObject control_point_1 = gameObject.transform.GetChild(readrobot.gobal_polygon_num[0]+1).gameObject;
		//	Debug.Log (control_point_0.transform.position);
		//	Debug.Log (control_point_1.transform.position);
		//	int now_potential =  count_potential(control_point_0.transform.position,show_potential.potential_control_point_0);
		//		bool collision_detection = false;
		//		collision_detection = gameObject.transform.GetChild(0).gameObject.transform.GetComponent<collision_detection>().detection();
		//		collision_detection = gameObject.transform.GetChild(1).gameObject.transform.GetComponent<collision_detection>().detection();
		//		Debug.Log (collision_detection);
		//		gameObject.transform.GetChild(0).gameObject.transform.GetComponent<collision_detection>().OnTriggerStay2D();
		int current_potential = count_potential ();
		/*	if (current_potential > 10) {
			walk (current_potential);
		}*/
		//Debug.Log (current_potential);

		if (current_potential > 0 && counter < 20) {

			if (back == true) {
				back = walk ();
			} else {
				//	gameObject.transform.position = last_point.initial_point;
				//	gameObject.transform.rotation = Quaternion.Euler (0, 0, last_point.arc);
				gameObject.transform.position = open_list [open_list.Count - 1].initial_point;
				gameObject.transform.rotation = Quaternion.Euler (0, 0, open_list [open_list.Count - 1].arc);
				open_list.RemoveAt (open_list.Count - 1);
				back = walk ();
			}
			Debug.Log (open_list.Count - 1);


			if (current_potential == 1) {
				counter++;
			}
			return false;
		} else if (counter == 20) {
			//	Destroy (GetComponent<bfs> ());
			//	gameObject.GetComponent<bfs> ().enabled = false;
			return true;
		} else {
			//	Destroy (GetComponent<bfs> ());
			return true;
		}
		//	Debug.Log (current_potential);

		//	Debug.Log (collis);

		//	test_ipotential = walk (999);
		//	count_potential(control_point_0.transform.position,show_potential.potential_control_point_0);
		//	Debug.Log (now_potential);
		//	bool test = false;
		//	gameObject.transform.GetChild (0).gameObject.transform.GetComponent<moveobj> ().abc (test);
		//	test = gameObject.transform.GetChild(0).gameObject.transform.GetComponent<moveobj>().OnTriggerStay2D();
		//	gameObject.transform.GetChild(1).gameObject.transform.GetComponent<moveobj>().OnTriggerStay2D(test);
		//	Debug.Log (gameObject.transform.GetChild(0).gameObject.GetComponent<PolygonCollider2D>().points[0].x );
		//	Debug.Log(gameObject.transform.GetChild (1).gameObject.transform.position.x);
		//	Debug.Log(gameObject.transform.position.x);
	}


	int times = 0;

	IEnumerator delay ()
	{
		yield return new WaitForSeconds (10);
	}



	void Update ()
	{
		

		string ObjectName = "robot_goal";
		GameObject SearchObject = GameObject.Find (ObjectName);
		int rob_potential = count_potential ();

		if (rob_potential < 10) {
			gameObject.transform.position = SearchObject.transform.position;
			gameObject.transform.rotation = SearchObject.transform.rotation;
			Destroy (GetComponent<bfs> ());

		} else {
			StartCoroutine (delay ());
			gameObject.transform.position = new Vector3 (visited_plan [times].x, visited_plan [times].y, 0);
			gameObject.transform.rotation = Quaternion.Euler (0, 0, visited_plan [times].z);
			times = times + 1;
		}


	}




}


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bfs_new : MonoBehaviour
{
	Vector3 start_position = new Vector3 ();
	now_robot_state robot_state = new now_robot_state ();
	Vector4[] visited_point = new Vector4[16384];
	int[] test = new int[100];
	List<Vector4> open_list = new List<Vector4> ();
	int counter = 0;
	int visted_num = 0;
	int count_tmp_root_data = 0;
	now_robot_state last_point = new now_robot_state ();
	Vector4[] tmp_root_data = new Vector4[16384];
	//	int potential_value = 200;
	// Use this for initialization
	bool run_stop = false;

	void Start ()
	{
	/*	start_position.x = gameObject.transform.position.x;
		start_position.y = gameObject.transform.position.y;
		start_position.z = gameObject.transform.rotation.eulerAngles.z;

		while (run_stop == false) {
			run_stop = start_run ();
		}
		Debug.Log ("Hi");
		gameObject.transform.position = new Vector3 (start_position.x, start_position.y, 0);
		gameObject.transform.rotation = Quaternion.Euler (0, 0, start_position.z);*/

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
		public int potential;
		public Vector2 parent_point;
		public float parent_arc;

	}


	void route ()
	{


		/*	root_data[,] potential_tree = new root_data[508, 128];
		ArrayList temp = new ArrayList ();

		root_data gg = new root_data ();
		gg.root_point = new Vector2 (1, 1);
		gg.arc = 90;
		gg.last_point = new Vector2 (2, 1);
		temp.Add (gg);
		potential_tree [0, 0] = (root_data)temp [0];
*/
	

//		Debug.Log (potential_tree[0,0].arc);

	}


	public bool collis = false;

	void walk (float input_range)
	{
		
		int now_potential = 999;
		int tmp_potential;
		bool already_visited;
		Vector2 tmp_init_point = new Vector2 ();
		now_robot_state walk_point = new now_robot_state ();
		float range = input_range;

		//	robot_state.initial_point = gameObject.transform.position;
		Vector4 robot_position = new Vector4 ();
		robot_position.x = gameObject.transform.position.x;
		robot_position.y = gameObject.transform.position.y;
		robot_position.z = gameObject.transform.rotation.eulerAngles.z;
		//	last_point = robot_position;

		//	tmp_root_data.parent_point = robot_position.initial_point;
		//	tmp_root_data.parent_arc = robot_position.arc;

		tmp_potential = count_potential ();
		/*	tmp_root_data.root_point.x = gameObject.transform.position.x;
		tmp_root_data.root_point.y = gameObject.transform.position.y;
		tmp_root_data.arc = gameObject.transform.rotation.eulerAngles.z;
		tmp_root_data.potential = tmp_potential;
		open_list.Add (tmp_root_data);*/



/*		gameObject.transform.position.x = robot_tranform.initial_point.x;
		gameObject.transform.position.y = robot_tranform.initial_point.y;
		gameObject.transform.rotation.eulerAngles.z = robot_tranform.arc;*/

		gameObject.transform.position += new Vector3 (range, 0, 0);

	// collis = checkcol ();
		Debug.Log(collis);
		already_visited = false;
		robot_position.x = gameObject.transform.position.x;
		robot_position.y = gameObject.transform.position.y;
		robot_position.z = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {
			
			if (visited_point [i] == null) {
				break;
			}

			if (visited_point [i] == robot_position) {
				already_visited = true;

			}
		}
		tmp_potential = count_potential ();
		if (already_visited == false && collis == false && tmp_potential != 999) {
			
			//	Debug.Log (tmp_root_data[count_tmp_root_data].root_point);
			//	tmp_root_data[count_tmp_root_data].root_point.x = 1;
			//	tmp_root_data[count_tmp_root_data].root_point.y = gameObject.transform.position.y;
			tmp_root_data [count_tmp_root_data].x = gameObject.transform.position.x;
			tmp_root_data [count_tmp_root_data].y = gameObject.transform.position.y;
			tmp_root_data [count_tmp_root_data].z = gameObject.transform.rotation.eulerAngles.z;
			tmp_root_data [count_tmp_root_data].w = tmp_potential;
				
			//	Debug.Log (gameObject.transform.position);
			open_list.Add (tmp_root_data [count_tmp_root_data]);


			count_tmp_root_data++;

			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (-range, 0, 0);





		gameObject.transform.position += new Vector3 (-range, 0, 0);

		//collis = checkcol ();

		already_visited = false;
		robot_position.x = gameObject.transform.position.x;
		robot_position.y = gameObject.transform.position.y;
		robot_position.z = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i] == robot_position) {
				already_visited = true;
			}
		}

		tmp_potential = count_potential ();
		if (already_visited == false && collis == false && tmp_potential != 999) {
			tmp_root_data [count_tmp_root_data].x = gameObject.transform.position.x;
			tmp_root_data [count_tmp_root_data].y = gameObject.transform.position.y;
			tmp_root_data [count_tmp_root_data].z = gameObject.transform.rotation.eulerAngles.z;
			tmp_root_data [count_tmp_root_data].w = tmp_potential;


			open_list.Add (tmp_root_data [count_tmp_root_data]);
			count_tmp_root_data++;

			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (range, 0, 0);




		gameObject.transform.position += new Vector3 (0, range, 0);

		// collis = checkcol ();

		already_visited = false;
		robot_position.x = gameObject.transform.position.x;
		robot_position.y = gameObject.transform.position.y;
		robot_position.z = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i] == robot_position) {
				already_visited = true;
			}
		}

		tmp_potential = count_potential ();
		if (already_visited == false && collis == false && tmp_potential != 999) {
			tmp_root_data [count_tmp_root_data].x = gameObject.transform.position.x;
			tmp_root_data [count_tmp_root_data].y = gameObject.transform.position.y;
			tmp_root_data [count_tmp_root_data].z = gameObject.transform.rotation.eulerAngles.z;
			tmp_root_data [count_tmp_root_data].w = tmp_potential;


			open_list.Add (tmp_root_data [count_tmp_root_data]);
			count_tmp_root_data++;

			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (0, -range, 0);



		gameObject.transform.position += new Vector3 (0, -range, 0);

		// collis = checkcol ();

		already_visited = false;
		robot_position.x = gameObject.transform.position.x;
		robot_position.y = gameObject.transform.position.y;
		robot_position.z = gameObject.transform.rotation.eulerAngles.z;
		for (int i = 0; i < visited_point.Length; i++) {

			if (visited_point [i] == null) {
				break;
			}
			if (visited_point [i] == robot_position) {
				already_visited = true;
			}
		}

		tmp_potential = count_potential ();
		if (already_visited == false && collis == false && tmp_potential != 999) {
			tmp_root_data [count_tmp_root_data].x = gameObject.transform.position.x;
			tmp_root_data [count_tmp_root_data].y = gameObject.transform.position.y;
			tmp_root_data [count_tmp_root_data].z = gameObject.transform.rotation.eulerAngles.z;
			tmp_root_data [count_tmp_root_data].w = tmp_potential;

			open_list.Add (tmp_root_data [count_tmp_root_data]);
			count_tmp_root_data++;
			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (0, range, 0);




		/*	gameObject.transform.position += new Vector3 (0, 1, 0);
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
			tmp_root_data.root_point.x = gameObject.transform.position.x;
			tmp_root_data.root_point.y = gameObject.transform.position.y;
			tmp_root_data.arc = gameObject.transform.rotation.eulerAngles.z;
			tmp_root_data.potential = tmp_potential;
			open_list.Add (tmp_root_data);

			if (now_potential > tmp_potential) {
				now_potential = tmp_potential;
				walk_point.initial_point.x = gameObject.transform.position.x;
				walk_point.initial_point.y = gameObject.transform.position.y;
				walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
				walk_point.potential = now_potential;
			}


		}
		gameObject.transform.position += new Vector3 (0, -1, 0);*/


		for (int k = 1; k <= 15; k++) {
			gameObject.transform.Rotate (new Vector3 (0, 0, 4 * k));

		//	 collis = checkcol ();

			already_visited = false;
			robot_position.x = gameObject.transform.position.x;
			robot_position.y = gameObject.transform.position.y;
			robot_position.z = gameObject.transform.rotation.eulerAngles.z;
			for (int i = 0; i < visited_point.Length; i++) {

				if (visited_point [i] == null) {
					break;
				}
				if (visited_point [i] == robot_position) {
					already_visited = true;
				}
			}
			tmp_potential = count_potential ();
			if (already_visited == false && collis == false && tmp_potential != 999) {
				tmp_root_data [count_tmp_root_data].x = gameObject.transform.position.x;
				tmp_root_data [count_tmp_root_data].y = gameObject.transform.position.y;
				tmp_root_data [count_tmp_root_data].z = gameObject.transform.rotation.eulerAngles.z;
				tmp_root_data [count_tmp_root_data].w = tmp_potential;

				open_list.Add (tmp_root_data [count_tmp_root_data]);
				count_tmp_root_data++;


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



		for (int k = 1; k <= 15; k++) {
			gameObject.transform.Rotate (new Vector3 (0, 0, 4 * -k));

		//	 collis = checkcol ();

			already_visited = false;
			robot_position.x = gameObject.transform.position.x;
			robot_position.y = gameObject.transform.position.y;
			robot_position.z = gameObject.transform.rotation.eulerAngles.z;
			for (int i = 0; i < visited_point.Length; i++) {

				if (visited_point [i] == null) {
					break;
				}
				if (visited_point [i] == robot_position) {
					already_visited = true;
				}
			}

			tmp_potential = count_potential ();
			if (already_visited == false && collis == false && tmp_potential != 999) {
				tmp_root_data [count_tmp_root_data].x = gameObject.transform.position.x;
				tmp_root_data [count_tmp_root_data].y = gameObject.transform.position.y;
				tmp_root_data [count_tmp_root_data].z = gameObject.transform.rotation.eulerAngles.z;
				tmp_root_data [count_tmp_root_data].w = tmp_potential;

				open_list.Add (tmp_root_data [count_tmp_root_data]);
				count_tmp_root_data++;

				if (now_potential > tmp_potential) {
					now_potential = tmp_potential;
					walk_point.initial_point.x = gameObject.transform.position.x;
					walk_point.initial_point.y = gameObject.transform.position.y;
					walk_point.arc = gameObject.transform.rotation.eulerAngles.z;
					walk_point.potential = now_potential;
				}


			}
			gameObject.transform.Rotate (new Vector3 (0, 0, 3 * k));

		}


		//	if (now_potential == 999) {
		//		return false;
		//	} else {

		//	Debug.Log (visited_point[visted_num].initial_point);




		int min = 999, min_index = 0;
		for (int i = 0; i < open_list.Count; i++) {
			
			if (open_list [i].w < min) {
				min = (int)open_list [i].w;
				min_index = i;
			}


		}
		//	Debug.Log (min_index);
		visited_point [visted_num].x = open_list [min_index].x;
		visited_point [visted_num].y = open_list [min_index].y;
		visited_point [visted_num].z = open_list [min_index].z;
		//	visited_point [visted_num].arc = 123;
		visted_num++;
		//	Debug.Log ( open_list[min_index].root_point);

		gameObject.transform.position = new Vector3 (open_list [min_index].x, open_list [min_index].y, 0);
		gameObject.transform.rotation = Quaternion.Euler (0, 0, open_list [min_index].z);
		open_list.RemoveAt (min_index);
		//	open_list_Removeat
		//		return true;

		//	}




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
			int potential_value = (potential_value_0 + potential_value_1) ;
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
	int last_potential = 0;
	float range = 1;
	int times = 0;

	IEnumerator delay ()
	{
		yield return new WaitForSeconds (10);
	}

	void Update ()
	{
		//	Debug.Log ("Hi");

		//while (run_stop == false) {
			run_stop = start_run ();
		//}

		string ObjectName = "robot_goal";
		GameObject SearchObject = GameObject.Find (ObjectName);
		int rob_potential = count_potential ();



		if (rob_potential < 10) {
			gameObject.transform.position = SearchObject.transform.position;
			gameObject.transform.rotation = SearchObject.transform.rotation;
			Destroy (GetComponent<bfs_new> ());

		} else {
			StartCoroutine (delay ());
			gameObject.transform.position = new Vector3 (visited_point [times].x, visited_point [times].y, 0);
			gameObject.transform.rotation = Quaternion.Euler (0, 0, visited_point [times].z);
			times = times + 1;
		}


	}


	bool start_run ()
	{
		string ObjectName = "robot_goal";
		GameObject SearchObject = GameObject.Find (ObjectName);
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
		//	Debug.Log (current_potential);

		if (current_potential > 0 && counter < 20) {

			//if (back == true) {
			//	back = walk ();
			//	} else {
			//	gameObject.transform.position = last_point.initial_point;
			//	gameObject.transform.rotation = Quaternion.Euler (0, 0, last_point.arc);
			//	gameObject.transform.position = open_list[open_list.Count-1].initial_point;
			//	gameObject.transform.rotation = Quaternion.Euler (0, 0, open_list[open_list.Count-1].arc);
			//	open_list.RemoveAt (open_list.Count - 1);
			//		back = walk ();
			//	}
			walk (range);

			//Debug.Log (open_list.Count);
			//	gameObject.transform.position =  open_list[min_index].root_point;
			//	gameObject.transform.rotation = Quaternion.Euler (0, 0, open_list[min_index].arc);
			//		Debug.Log (open_list[min_index].root_point);
			/*	if ((last_potential - current_potential) < 3 && range < 5) {
				range = range + 0.1f;
			} else {
				range = range - 0.1f;
			}

			last_potential = current_potential;*/

			//	Debug.Log (current_potential);



			if (current_potential < 10) {
				counter++;
			}

			return false;
		} else if (counter == 100) {
			//	Destroy (GetComponent<bfs> ());

			gameObject.transform.position = SearchObject.transform.position;
			gameObject.transform.rotation = SearchObject.transform.rotation;

			//	Debug.Log ("hi");
			//	gameObject.GetComponent<bfs> ().enabled = false;
			return true;
		} else {
			//	Destroy (GetComponent<bfs> ());
			gameObject.transform.position = SearchObject.transform.position;
			gameObject.transform.rotation = SearchObject.transform.rotation;
			//	Debug.Log ("hi");

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

	/*bool checkcol ()
	{
		Vector2 scan_point = new Vector2 ();
		int scan_point_num = 0;
		bool coll = false;
		int pot = 0;
		int r = (int)gameObject.transform.position.x;
		int p = (int)gameObject.transform.position.y;
		for (int i = r-15; i < r+15; i++) {

			for (int j = p-15; j < p+15; j++) {
				if (i <= 127 && j <= 127 && i >=0 && j>=0) {
					Ray ray = new Ray (new Vector2 (i, j), transform.forward);
					RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);

					if (hit.collider.gameObject.name == "sub_robot") {
						pot = show_potential.potential_control_point_0 [i, j];
						if(pot >= 250)
						{
							coll =  true;
							break;
						}
					}
				}
				if(pot >= 254)
				{
					coll =  true;
					break;
				}
			}

		}

		if (coll == true) {
			return true;
		} else {
			return false;
		}
	}*/
}


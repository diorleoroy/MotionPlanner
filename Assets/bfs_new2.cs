using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class bfs_new2 : MonoBehaviour
{
	LinkedList<root_data>[] linkList_test = new LinkedList<root_data>[511];
	LinkedList<root_data>[] potential_linklist = new LinkedList<root_data>[511];
	LinkedList<root_data>[] record_linklist = new LinkedList<root_data>[511];
	List<Vector3> all_path = new List<Vector3>();

	Vector3 init_position = new Vector3 ();
	Vector3 start_position = new Vector3 ();
	//Vector4[] visited_point = new Vector4[16384];
	Vector3[] visited_point = new Vector3[20000];
	int[] test = new int[100];
	List<Vector4> open_list = new List<Vector4> ();
	int counter = 0;
	int visted_num = 0;
	int count_tmp_root_data = 0;
	bool find_route = false;
	root_data path = new root_data ();
	//	int potential_value = 200;
	// Use this for initialization
	bool run_stop = false;
	int times = 0;


	class root_data
	{

		public Vector2 root_point;
		public float arc;
		public root_data partent_node;

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

	void walk ()
	{
		

		int tmp_potential;
		bool already_visited;
		Vector2 tmp_init_point = new Vector2 ();

		Vector3 robot_position = new Vector3 ();
		/*	robot_position.x = gameObject.transform.position.x;
		robot_position.y = gameObject.transform.position.y;
		robot_position.z = gameObject.transform.rotation.eulerAngles.z;*/
		//		gameObject.transform.position = new Vector3 (open_list [min_index].x, open_list [min_index].y, 0);
		//		gameObject.transform.rotation = Quaternion.Euler (0, 0, open_list [min_index].z);

		for (int k = 0; k < 508; k++) {
			if (potential_linklist [k].Count != 0 && visted_num < 20000 && find_route == false) {
				root_data old_pn = potential_linklist [k].First.Value;


				gameObject.transform.position = new Vector3 (old_pn.root_point.x, old_pn.root_point.y, 0);
				gameObject.transform.rotation = Quaternion.Euler (0, 0, old_pn.arc);

				int[] next_move = new int[4]{ 1, -1, 1, -1 };


				for (int i = 0; i < 4; i++) {
					Vector3 next_add_vector = new Vector3 ();
					root_data tmp_root_data = new root_data ();

					if (i <= 1) {
						next_add_vector = new Vector3 (next_move [i], 0, 0);
					} else {
						next_add_vector = new Vector3 (0, next_move [i], 0);
					}
		

					gameObject.transform.position += next_add_vector;

					//	Debug.Log(collis);
					already_visited = false;
					robot_position.x = gameObject.transform.position.x;
					robot_position.y = gameObject.transform.position.y;
					robot_position.z = gameObject.transform.rotation.eulerAngles.z;

					for (int j = 0; j < visited_point.Length; j++) {
						
						if (visited_point [j] == robot_position) {
							already_visited = true;


						}
						if (visited_point [j] == new Vector3 (0, 0, 0)) {
							break;
						}


					}

					//	
					//	collis = checkcol ();
				//	collis = bomb2();
					int now_potential = count_potential ();
					if (already_visited == false && collis == false && now_potential < 508) {
				

						tmp_root_data.root_point.x = gameObject.transform.position.x;
						tmp_root_data.root_point.y = gameObject.transform.position.y;
						tmp_root_data.arc = gameObject.transform.rotation.eulerAngles.z;
						tmp_root_data.partent_node = old_pn;

						potential_linklist [now_potential].AddFirst (tmp_root_data);

						visited_point [visted_num].x = tmp_root_data.root_point.x;
						visited_point [visted_num].y = tmp_root_data.root_point.y;
						visited_point [visted_num].z = tmp_root_data.arc;

						visted_num++;
						if (now_potential < 3) {
							find_route = true; 
						}
					}
					gameObject.transform.position -= next_add_vector;

				}
					



				for (int i = 1; i <= 8; i++) {
					root_data rotate_tmp_root_data = new root_data ();
					gameObject.transform.Rotate (new Vector3 (0, 0, 4 * i));

					//	Debug.Log(collis);
					already_visited = false;
					robot_position.x = gameObject.transform.position.x;
					robot_position.y = gameObject.transform.position.y;
					robot_position.z = gameObject.transform.rotation.eulerAngles.z;

					for (int j = 0; j < visited_point.Length; j++) {

						if (visited_point [j] == robot_position) {
							already_visited = true;


						}
						if (visited_point [j] == new Vector3 (0, 0, 0)) {
							break;
						}


					}
					//	
					//	collis = checkcol ();
				//	collis = bomb2();
					int rotate_now_potential = count_potential ();
					if (already_visited == false && collis == false && rotate_now_potential < 508) {


						rotate_tmp_root_data.root_point.x = gameObject.transform.position.x;
						rotate_tmp_root_data.root_point.y = gameObject.transform.position.y;
						rotate_tmp_root_data.arc = gameObject.transform.rotation.eulerAngles.z;
						rotate_tmp_root_data.partent_node = old_pn;
					//	rotate_tmp_root_data.partent_node = potential_linklist[k].First.Value;

						potential_linklist [rotate_now_potential].AddFirst (rotate_tmp_root_data);


						visited_point [visted_num].x = rotate_tmp_root_data.root_point.x;
						visited_point [visted_num].y = rotate_tmp_root_data.root_point.y;
						visited_point [visted_num].z = rotate_tmp_root_data.arc;

						visted_num++;
						if (rotate_now_potential < 3) {
							find_route = true; 
						}
					}
					gameObject.transform.Rotate (new Vector3 (0, 0, -4 * i));
				
				}


				for (int i = 1; i <= 8; i++) {
					root_data rotate_tmp_root_data = new root_data ();
					gameObject.transform.Rotate (new Vector3 (0, 0, -4 * i));


					already_visited = false;
					robot_position.x = gameObject.transform.position.x;
					robot_position.y = gameObject.transform.position.y;
					robot_position.z = gameObject.transform.rotation.eulerAngles.z;

					for (int j = 0; j < visited_point.Length; j++) {

						if (visited_point [j] == robot_position) {
							already_visited = true;


						}
						if (visited_point [j] == new Vector3 (0, 0, 0)) {
							break;
						}


					}
					//	
					//	collis = checkcol ();
				//	collis = bomb2();
					int rotate_now_potential = count_potential ();
					if (already_visited == false && collis == false && rotate_now_potential < 508) {


						rotate_tmp_root_data.root_point.x = gameObject.transform.position.x;
						rotate_tmp_root_data.root_point.y = gameObject.transform.position.y;
						rotate_tmp_root_data.arc = gameObject.transform.rotation.eulerAngles.z;
						rotate_tmp_root_data.partent_node = old_pn;

						potential_linklist [rotate_now_potential].AddFirst (rotate_tmp_root_data);
						record_linklist [rotate_now_potential].AddFirst (rotate_tmp_root_data);

						visited_point [visted_num].x = rotate_tmp_root_data.root_point.x;
						visited_point [visted_num].y = rotate_tmp_root_data.root_point.y;
						visited_point [visted_num].z = rotate_tmp_root_data.arc;

						visted_num++;

						if (rotate_now_potential < 10) {
							find_route = true; 
						}
					}
					gameObject.transform.Rotate (new Vector3 (0, 0, 4 * i));

				}
					
				potential_linklist [k].RemoveFirst ();
				break;
			}
		}


			




		//	Debug.Log ( open_list[min_index].root_point);


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
			int potential_value = (potential_value_0 + potential_value_1);
			return potential_value;

		} else {
			return 999;
		}

	}

	/*bool bomb2()
	{
		Vector2 gg1 = new Vector2 (gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x, gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y);
		Vector2 gg2 = new Vector2 (gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x, gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y);
		Vector2 gg3 = new Vector2 ((gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x)/2, gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y);
		Vector2 gg4 = new Vector2 ((gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x)/2, gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y);
		Vector2 gg5 = new Vector2 (gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x, (gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y)/2);
		Vector2 gg6 = new Vector2 (gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x, (gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y)/2);


		if(Physics2D.OverlapPoint(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max,1) != null ||
			Physics2D.OverlapPoint(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min,1) != null ||
			Physics2D.OverlapPoint(gg1,1) != null || Physics2D.OverlapPoint(gg2,1) != null ||
			Physics2D.OverlapPoint(gg3,1) != null || Physics2D.OverlapPoint(gg4,1) != null ||
			Physics2D.OverlapPoint(gg5,1) != null || Physics2D.OverlapPoint(gg6,1) != null )
			{
			Debug.Log ("gg");
				return true;
			}
			else
			{
				return false;
			}

	
	
	}*/
	/*bool bomb()
	{
		if ((int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x < 128 && (int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y < 128 &&
		   (int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x < 128 && (int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y < 128 &&
		   (int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x >= 0 && (int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y >= 0 &&
		   (int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x >= 0 && (int)gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y >= 0 &&

		   (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.x < 128 && (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.y < 128 &&
		   (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.x < 128 && (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.y < 128 &&
		   (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.x >= 0 && (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.y >= 0 &&
		   (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.x >= 0 && (int)gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.y >= 0) {
		
			int polygon_up_1 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x), (int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y)];
			int polygon_down_1 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x), (int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y)];

			int polygon_up_2 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.x), (int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.y)];
			int polygon_down_2 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.x), (int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.y)];

			int polygon_up_3 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x),(int) Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y)];
			int polygon_down_3 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x),(int) Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y)];

			int polygon_up_4 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.x),(int) Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.y)];
			int polygon_down_4 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.x),(int) Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.y)];

			int polygon_up_5 = show_potential.potential_control_point_0 [(int)Mathf.Ceil((gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.x + gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.x)/2),(int) Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.y)];
			int polygon_down_5 = show_potential.potential_control_point_0 [(int)Mathf.Ceil((gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.x + gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.x)/2),(int) Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.y)];
		
			int polygon_up_6 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.x),(int) Mathf.Ceil((gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.y + gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.y)/2)];
			int polygon_down_6 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.x),(int) Mathf.Ceil((gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.max.y + gameObject.transform.GetChild (1).GetComponent<Collider2D> ().bounds.min.y)/2)];

			int polygon_up_7 = show_potential.potential_control_point_0 [(int)Mathf.Ceil((gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x)/2),(int) Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y)];
			int polygon_down_7 = show_potential.potential_control_point_0 [(int)Mathf.Ceil((gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x)/2),(int) Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y)];

			int polygon_up_8 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.x),(int) Mathf.Ceil((gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y)/2)];
			int polygon_down_8 = show_potential.potential_control_point_0 [(int)Mathf.Ceil(gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.x),(int) Mathf.Ceil((gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.max.y + gameObject.transform.GetChild (0).GetComponent<Collider2D> ().bounds.min.y)/2)];

		


			if (polygon_up_1 == 255 || polygon_up_2 == 255 || polygon_down_1 == 255 || polygon_down_2 == 255 || polygon_up_3 == 255 || polygon_down_3 == 255 || polygon_up_4 == 255 || polygon_down_4 == 255 || polygon_up_5 == 255 || polygon_down_5 == 255 || polygon_up_6 == 255 || polygon_down_6 == 255 || polygon_up_7 == 255 || polygon_down_7 == 255 || polygon_up_8 == 255 || polygon_down_8 == 255) {
				return true;


			} else {
				return false;
			}
		
		
		}
		else {
			return false;
		}
			
	}*/

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






/*	bool start_run ()
	{
		string ObjectName = "robot_goal";
		GameObject SearchObject = GameObject.Find (ObjectName);

		int current_potential = count_potential ();

		if (current_potential > 0 && counter < 20) {

			walk ();


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

	}
*/
/*bool checkcol ()
	{
		Vector2 scan_point = new Vector2 ();
		int scan_point_num = 0;
		bool coll = false;
		int r = (int)gameObject.transform.position.x;
		int p = (int)gameObject.transform.position.y;
		for (int i = r-30; i < r+30; i++) {
			int pot = 0;
			for (int j = p-30; j < p+30; j++) {
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

			}
			if(pot >= 254)
			{
				coll =  true;
				break;
			}

		}

		if (coll == true) {
			return true;
		} else {
			return false;
		}
	} */

//	Collider2D tet = Physics2D.OverlapPointAll();



	void Start ()
	{

	/*		for (int i = 0; i < 508; i++) {
			linkList_test [i] = new LinkedList<root_data> ();
		}

		root_data test = new root_data ();
		root_data father = new root_data ();
		root_data gg = new root_data ();

		test.root_point = new Vector2 (10, 5);
		father.root_point = new Vector2 (9, 5);

		test.partent_node = father;

		linkList_test [0].AddFirst (test);
		linkList_test [0].AddFirst (father);
		linkList_test [0].RemoveFirst();
		//	gg = linkList_test [0].First.Value.partent_node;


		Debug.Log (linkList_test[0].First.Value.partent_node.root_point);
	/*	if (linkList_test [1].Count == 0) {
			Debug.Log ("Hi");
		}*/
			string ObjectName0 = "sub_robot";
			GameObject SearchObject0 = GameObject.Find( ObjectName0 );
			SearchObject0.AddComponent<collision_detection> ();



		for (int i = 0; i < 510; i++) {
			potential_linklist [i] = new LinkedList<root_data> ();
		}
		for (int i = 0; i < 510; i++) {
			record_linklist [i] = new LinkedList<root_data> ();
		}



		init_position.x = gameObject.transform.position.x;
		init_position.y = gameObject.transform.position.y;
		init_position.z = gameObject.transform.rotation.eulerAngles.z;


		root_data start_position = new root_data ();
		start_position.root_point.x = gameObject.transform.position.x;
		start_position.root_point.y = gameObject.transform.position.y;
		start_position.arc = gameObject.transform.rotation.eulerAngles.z;
		int start_potential = count_potential ();

		if (start_potential != 999  && start_potential != 508) {
			potential_linklist [start_potential].AddFirst (start_position);
			while (find_route == false) {
				walk ();
			}

		} else {
			Debug.Log ("沒有路徑");
			Destroy (GetComponent<bfs_new2> ());
		}
	


		if(find_route == true){
			for (int i = 0; i < 10; i++) { // 找終點的那個點!!
				if (potential_linklist [i].Count != 0) {
					path = potential_linklist [i].First.Value;
					break;
				}
			}

			string ObjectName = "robot_goal";
			GameObject SearchObject = GameObject.Find (ObjectName);
			Vector3 input_date0 = new Vector3 ();
			input_date0.x = SearchObject.transform.position.x;
			input_date0.y = SearchObject.transform.position.y;
			input_date0.z = SearchObject.transform.rotation.eulerAngles.z;
			all_path.Add (input_date0);

			for (int i = 0; i < 20000; i++) {
				if (path.partent_node != null) {
					path = path.partent_node;
					Vector3 input_date = new Vector3 ();
					input_date.x = path.root_point.x;
					input_date.y = path.root_point.y;
					input_date.z = path.arc;
					all_path.Add (input_date);

				} else {

					break;
				}

			}
			times = all_path.Count - 1;

			gameObject.transform.position = new Vector3 (init_position.x, init_position.y, 0);
			gameObject.transform.rotation = Quaternion.Euler (0, 0, init_position.z);


		}

	}

	IEnumerator delay ()
	{
	//yield return new WaitForSeconds (1000000000000);
		yield return new WaitForSeconds (1);
		

	}

	bool set_route = false;
	void FixedUpdate ()
	{





		//while (run_stop == false) {
		/*	run_stop = start_run ();
		//}

	/*	string ObjectName = "robot_goal";
		GameObject SearchObject = GameObject.Find (ObjectName);
		int rob_potential = count_potential ();



		if (rob_potential < 10) {
			gameObject.transform.position = SearchObject.transform.position;
			gameObject.transform.rotation = SearchObject.transform.rotation;
			Destroy (GetComponent<bfs_new> ());

		} else {

			gameObject.transform.position = new Vector3 (visited_point [times].x, visited_point [times].y, 0);
			gameObject.transform.rotation = Quaternion.Euler (0, 0, visited_point [times].z);
			times = times + 1;
		}
*/





	}





	void Update ()
	{







		//while (run_stop == false) {
		/*	run_stop = start_run ();
		//}

		string ObjectName = "robot_goal";
		GameObject SearchObject = GameObject.Find (ObjectName);
		int rob_potential = count_potential ();



		if (rob_potential < 10) {
			gameObject.transform.position = SearchObject.transform.position;
			gameObject.transform.rotation = SearchObject.transform.rotation;
			Destroy (GetComponent<bfs_new> ());

		} else {

			gameObject.transform.position = new Vector3 (visited_point [times].x, visited_point [times].y, 0);
			gameObject.transform.rotation = Quaternion.Euler (0, 0, visited_point [times].z);
			times = times + 1;
		}
*/

			string ObjectName = "robot_goal";
			GameObject SearchObject = GameObject.Find (ObjectName);
			int rob_potential = count_potential ();




		/*	if (rob_potential < 6) {
				gameObject.transform.position = SearchObject.transform.position;
				gameObject.transform.rotation = SearchObject.transform.rotation;
				Destroy (GetComponent<bfs_new2> ());

			} else {*/

				//		StartCoroutine (delay ());
				gameObject.transform.position = new Vector3 (all_path [times].x, all_path [times].y, 0);
				gameObject.transform.rotation = Quaternion.Euler (0, 0, all_path [times].z);
				times -- ;
				if (times == -1) {
					Debug.Log (rob_potential);
					Debug.Log (visted_num);
					Debug.Log (find_route);
				gameObject.transform.position = SearchObject.transform.position;
				gameObject.transform.rotation = SearchObject.transform.rotation;
				Destroy (GetComponent<bfs_new2> ());
				}



		}
}



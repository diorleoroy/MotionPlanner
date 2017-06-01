using UnityEngine;
using System.Collections;

public class drawrobot : MonoBehaviour
{

	// Use this for initialization

	void draw (Vector2[] input_ver, GameObject robot_obj, int input_ver_num, bool goal)
	{

		Mesh pm = new Mesh ();
		pm.Clear ();
		Vector3[] verts = new Vector3[input_ver_num];

		for (int i = 0; i < input_ver_num; i++) {
			input_ver [i] = input_ver [i] ;
			verts [i] = input_ver [i];

		}


		pm.vertices = verts;
		int[] tris = new int [3 + ((input_ver_num - 3) * 3)];
	

		for (int i = 0; i < (input_ver_num - 2); i++) {
			tris [i * 3] = 0;
			tris [(i * 3) + 1] = (input_ver_num - 1) - i;
			tris [(i * 3) + 2] = (input_ver_num - 1) - i - 1;
		
		}
			



		pm.triangles = tris;

		pm.RecalculateBounds ();
		pm.RecalculateNormals ();

		pm.Optimize ();


		//建立 GameObject, 並指定 MeshFilter 的 Mesh：
		GameObject sub_robot = new GameObject ();
		sub_robot.name = "sub_robot";
		MeshFilter mf = sub_robot.AddComponent<MeshFilter> ();
		mf.mesh = pm;

		sub_robot.AddComponent<MeshRenderer> (); 

		sub_robot.AddComponent<PolygonCollider2D> ();
		sub_robot.AddComponent<moveobj> (); 

		if (goal == false) {
			/*	Texture2D texture = new Texture2D (128, 128);

			for (int y = 127; y >= 0; y--) {
				for (int x = 0; x < 128; x++) {
					Color32 color = Color.blue;
					texture.SetPixel (x, y, color);
				}
			}

			sub_robot.GetComponent<Renderer> ().material.mainTexture = texture;*/
			sub_robot.AddComponent<collision_detection_2> ();
			sub_robot.GetComponent<Renderer> ().material.color = Color.blue;
			sub_robot.AddComponent<Rigidbody2D> ();
			sub_robot.GetComponent<Rigidbody2D> ().isKinematic = true;

			sub_robot.tag = "sub_robot";
		//	sub_robot.GetComponent<Rigidbody2D> ().detectCollisions = Continuous;
		//	sub_robot.AddComponent<collision_detection> (); 
			//	texture.Apply ();
		} else {
			sub_robot.GetComponent<Renderer> ().material.color = Color.green;
		}


		//	GetComponent<PolygonCollider2D>().points = new [] { new verts[0],new verts[1],new verts[2],new verts[3]};
		sub_robot.GetComponent<PolygonCollider2D> ().points = input_ver;
		//	GetComponent<PolygonCollider2D>().points = verts;

		//	go.AddComponent<ScriptableObject>(@"Assets\movetest.cs");
		sub_robot.transform.parent = robot_obj.transform;
		//go.AddComponent ScriptableObject.CreateInstance(@"Assets\movetest.cs");


	}


	void draw_robot (Vector2[,,] input_ver, int input_robot_num, int[] input_polygon_num, Vector3[] input_init_configuration, bool goal)
	{
		
		int count = 0;

		//	for (int k = 0; k < input_robot_num; k++) {
		for (int k = 0; k < 1; k++) {
			GameObject robot_obj = new GameObject ();
			robot_obj.tag = "robot";
			for (int i = 0; i < input_polygon_num [k]; i++) {
			
				Vector2[] ver_tmp = new Vector2[readrobot.gobal_vertice_num [k, i]];

				for (int j = 0; j < readrobot.gobal_vertice_num [k, i]; j++) {
					ver_tmp [j] = input_ver [k, i, j];

					count++;
				}


				draw (ver_tmp, robot_obj, readrobot.gobal_vertice_num [k, i], goal);

		
			}
				
			for (int i = 0; i < readrobot.gobal_control_point_num [k]; i++) {
				GameObject control_point = new GameObject ();
				control_point.transform.position = new Vector3 ((readrobot.gobal_control_point [k, i].x ), (readrobot.gobal_control_point [k, i].y ));
				control_point.transform.parent = robot_obj.transform;

				if (goal == false) {
					control_point.name = "init_control_point_" + i;

				} else {
					control_point.name = "goal_control_point_" + i;
				}
					
			}
			if (goal == false) {
			//	robot_obj.AddComponent<bfs> (); 
				robot_obj.name = "robot";
			} else {
				robot_obj.name = "robot_goal";
			}
			robot_obj.transform.position = new Vector3 (input_init_configuration [k].x, input_init_configuration [k].y);
			robot_obj.transform.rotation = Quaternion.Euler (0, 0, input_init_configuration [k].z);

		}

	}





	void Start ()
	{
	     
		draw_robot (readrobot.point, readrobot.robot_num, readrobot.gobal_polygon_num, readrobot.gobal_initialcon, false);
		draw_robot (readrobot.point, readrobot.robot_num, readrobot.gobal_polygon_num, readrobot.gobal_goalcon, true);
		//	Debug.Log (readrobot.robot_num);
		//	drawtest (readrobot.point);


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

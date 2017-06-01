using UnityEngine;
using System.Collections;

public class drawplane : MonoBehaviour
{

	// Use this for initialization

	void draw (Vector2[] input_ver, GameObject robot_obj,int input_ver_num)
	{

		Mesh pm = new Mesh ();
		pm.Clear ();
		Vector3[] verts = new Vector3[input_ver_num];

		for (int i = 0; i < input_ver_num; i++) {
			verts [i] = input_ver [i];
		}


		pm.vertices = verts;
		int[] tris = new int [3+ ((input_ver_num-3)*3)];
	

		for (int i = 0; i < (input_ver_num - 2); i++) {
			tris [i * 3] = 0;
			tris [(i * 3) + 1] = (input_ver_num-1) - i;
			tris [(i * 3) + 2] = (input_ver_num-1) - i -1;
		
		}



		pm.triangles = tris;

		pm.RecalculateBounds ();
		pm.RecalculateNormals ();

		pm.Optimize ();



		MeshFilter mf = robot_obj.AddComponent<MeshFilter> ();
		mf.mesh = pm;

		robot_obj.AddComponent<MeshRenderer> (); 

		//robot_obj.render.material.color = Color.green;
	//	renderer = robot_obj.GetComponent(Renderer);
		robot_obj.GetComponent<Renderer>().material.color= Color.black;
		robot_obj.name = "plane";
//		robot_obj.GetComponent<Transform>().position.z =new Vector3(64, 64, 0);
		robot_obj.transform.position =new Vector3(0, 0, 1);

	//	robot_obj.AddComponent<PolygonCollider2D> ();
	//	robot_obj.GetComponent<PolygonCollider2D> ().points = input_ver;
	//	robot_obj.GetComponent<PolygonCollider2D> ().isTrigger = true;

//		robot_obj.AddComponent<readrobot> (); 
//		robot_obj.AddComponent<readobstacle> (); 
	//	robot_obj.AddComponent<bitmap> (); 
	//	sub_robot.transform.parent = robot_obj.transform;


	}
		

	void Start ()
	{
		Vector2[] point = {new Vector2(127,127),new Vector2(0,127),new Vector2(0,0),new Vector2(127,0)};
		GameObject robot_obj = new GameObject ();
		draw (point,robot_obj, 4);


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

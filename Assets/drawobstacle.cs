using UnityEngine;
using System.Collections;

public class drawobstacle : MonoBehaviour
{

	// Use this for initialization

	void draw (Vector2[] input_ver, GameObject obstacle_obj,int input_ver_num, Vector2 input_init_configuration)
	{

		Mesh pm = new Mesh ();
		pm.Clear ();
		Vector3[] verts = new Vector3[input_ver_num];

		for (int i = 0; i < input_ver_num; i++) {
			input_ver [i] = input_ver [i] + input_init_configuration;
			verts [i] = input_ver [i];
		}


		pm.vertices = verts;
		int[] tris = new int [3+ ((input_ver_num-3)*3)];


		for (int i = 0; i < (input_ver_num - 2); i++) {
			tris [i * 3] = 0;
			tris [(i * 3) + 1] = (input_ver_num-1) - i;
			tris [(i * 3) + 2] = (input_ver_num-1) - i -1;

		}

	//	if (input_ver_num == 3) {
	//		tris = new int[] {  2, 1, 0 };
	//	} else if(input_ver_num==6)
	//	{
	//		tris = new int[] { 0, 5, 4, 0, 4, 3, 0, 3, 2, 0, 2, 1 };
	//	}
	//	else{
	//		tris = new int[] { 0, 2, 1, 0, 3, 2};
	//	}





		pm.triangles = tris;

		pm.RecalculateBounds ();
		pm.RecalculateNormals ();

		pm.Optimize ();


		//建立 GameObject, 並指定 MeshFilter 的 Mesh：
		GameObject sub_obstacle = new GameObject ();
		sub_obstacle.name = "sub_obstacle";
		MeshFilter mf = sub_obstacle.AddComponent<MeshFilter> ();
		mf.mesh = pm;

		sub_obstacle.AddComponent<MeshRenderer> (); 

		sub_obstacle.AddComponent<PolygonCollider2D> ();
		sub_obstacle.AddComponent<moveobj> (); 

		sub_obstacle.tag = "sub_obstacle";

		//	GetComponent<PolygonCollider2D>().points = new [] { new verts[0],new verts[1],new verts[2],new verts[3]};
		sub_obstacle.GetComponent<PolygonCollider2D> ().points = input_ver;
		//	GetComponent<PolygonCollider2D>().points = verts;
		/*sub_obstacle.AddComponent<Rigidbody2D> ();
		sub_obstacle.GetComponent<Rigidbody2D> ().gravityScale = 0;
		sub_obstacle.GetComponent<Rigidbody2D> ().drag = 9999;*/
		//	go.AddComponent<ScriptableObject>(@"Assets\movetest.cs");
	//	sub_obstacle.GetComponent<PolygonCollider2D> ().isTrigger = true;
		sub_obstacle.AddComponent<Rigidbody2D> (); 
		sub_obstacle.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
	//	sub_obstacle.GetComponent<Rigidbody2D> ().constraints.FreezeRotation  = true;
		sub_obstacle.transform.parent = obstacle_obj.transform;
		//go.AddComponent ScriptableObject.CreateInstance(@"Assets\movetest.cs");


	}


	void draw_obstacle (Vector2[,,] input_ver, int input_obstacle_num, int[] input_polygon_num, Vector3[] input_init_configuration)
	{
		
		int count = 0;

		for (int k = 0; k < input_obstacle_num; k++) {
			GameObject obstacle_obj = new GameObject ();
			obstacle_obj.tag = "obstacle";
			for (int i = 0; i < input_polygon_num[k]; i++) {
			
				Vector2[] ver_tmp = new Vector2[readobstacle.gobal_vertice_num[k, i]];

				for (int j = 0; j < readobstacle.gobal_vertice_num[k, i]; j++) {
					ver_tmp [j] = input_ver [k,i,j];

					count++;
				}
				obstacle_obj.transform.position = new Vector3 (input_init_configuration [k].x, input_init_configuration [k].y);

				draw (ver_tmp, obstacle_obj,readobstacle.gobal_vertice_num [k, i], readobstacle.gobal_initialcon [k]);
		
			}
			obstacle_obj.name = "obstacle";
			obstacle_obj.transform.rotation = Quaternion.Euler (0, 0,readobstacle.gobal_initialcon[k].z);

		}

	}






	void Start ()
	{
	     
		draw_obstacle (readobstacle.point, readobstacle.obstacle_num, readobstacle.gobal_polygon_num, readobstacle.gobal_initialcon);

		string ObjectName = "plane";
		GameObject SearchObject = GameObject.Find( ObjectName );
	//	SearchObject.AddComponent<bitmap> (); 
	//	SearchObject.AddComponent<potential> (); 
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

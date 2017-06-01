using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class readrobot : MonoBehaviour
{
	public static Vector2[,,] point = new Vector2[100,100,100];
	public static int robot_num = 0;
	public static int[] gobal_polygon_num = new int[10];
	public static int[,] gobal_vertice_num = new int[20,20];
	public static Vector3[] gobal_initialcon = new Vector3[3];
	public static Vector3[] gobal_goalcon = new Vector3[3];
//	public static Vector2[] gobal_control_point = new Vector2[2];

	public static Vector2[,] gobal_control_point = new Vector2[100,2];
	public static int[] gobal_control_point_num = new int[10];
	// Use this for initialization


	public void read (int index)
	{
	//	double[] controlpoi = new double[100];
		string line = "";

		int local_vertice_num = 0;
		int control_num = 0;
		int count_now_point = 0;
	    int local_polygon_num = 0;
	//	float[] loacal_initialcon = new float[100];
	//	double[] goalcon = new double[100];
		string[] lineArr = null;
		int a = 0;
		int a1 = 0;
	//	int g = 0;
	//	string robot_map = "robot0"+index;
		string path = "";

	//	Debug.Log (path);
		StreamReader sr = new StreamReader  ( Application.dataPath + @"/robot0"+index+".txt");

		for (int i = 0; i < 2; i++) {
			line = sr.ReadLine ();
		}
		robot_num = int.Parse (line);
		//機器人數量


		while (a1 < robot_num) {


			for (int i = 0; i < 3; i++) {
				line = sr.ReadLine ();
			}
			local_polygon_num = int.Parse (line);
			gobal_polygon_num [a1] = local_polygon_num;
			//polygon數量

			while (a < local_polygon_num) {
				for (int i = 0; i < 3; i++) {
					line = sr.ReadLine ();
				}
				local_vertice_num = int.Parse (line);
				gobal_vertice_num [a1,a] = local_vertice_num;



				line = sr.ReadLine ();


				float[] array_tmp = new float [(local_vertice_num * 2)];
				for (int i = 0; i < local_vertice_num; i++) {
					line = sr.ReadLine ();
					lineArr = line.Split (' ');
					int g = 0;
					foreach (string tmp in lineArr) {
						array_tmp [g] = float.Parse (tmp);
						g++;
					}
					point [a1, a ,i] = new Vector2 (array_tmp [0], array_tmp [1]);
				//	Debug.Log (point [a1, local_vertice_num] );

				}

			/*	g = 0;
				for (int j = 0; j < local_vertice_num; j++) {

					point [count_now_point] = new Vector2 (array_tmp [g], array_tmp [g + 1]);
					g = g + 2;
					count_now_point++;
				}
				g = 0;*/


				a++; 
			}
		//	Debug.Log (point [0, 0]);

			//	Debug.Log (point[2]);
			a = 0;


			line = sr.ReadLine ();
			line = sr.ReadLine ();
			lineArr = line.Split (' ');

			int initial_count = 0;
			float[] initial_tmp = new float [3];
			foreach (string tmp in lineArr) {
				initial_tmp [initial_count] = float.Parse (tmp);
				initial_count++;
			}
			gobal_initialcon[a1] = new Vector3 (initial_tmp [0], initial_tmp [1] ,initial_tmp[2]);

			//Array.Clear (lineArr,0,lineArr.Length);

			line = sr.ReadLine ();
			line = sr.ReadLine ();
			lineArr = line.Split (' ');

			int goal_count = 0;
			float[] goal_tmp = new float [3];
			foreach (string tmp in lineArr) {
				goal_tmp [goal_count] = float.Parse (tmp);
				goal_count++;
			}

			gobal_goalcon[a1] = new Vector3 (goal_tmp [0], goal_tmp [1] ,goal_tmp[2]);

			for (int i = 0; i < 2; i++) {
				line = sr.ReadLine ();
			}
			control_num = int.Parse (line);



			while (a < control_num) {
				line = sr.ReadLine ();
				line = sr.ReadLine ();
				lineArr = line.Split (' ');

				int control_count = 0;
				float[] control_tmp = new float [2];
				foreach (string tmp in lineArr) {
					control_tmp [control_count] = float.Parse (tmp);
					control_count++;
				}
				gobal_control_point[a1,a] = new Vector2 (control_tmp [0], control_tmp [1]);

				a++;
			}
			gobal_control_point_num [a1] = control_num;
			a = 0;
			a1++;

		} 


		sr.Close ();                     // 關閉串流
		gameObject.AddComponent<drawrobot> (); 
	}

	void Start ()
	{
	//	read ();
	//	
	}

	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

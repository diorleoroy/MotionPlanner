using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class readobstacle : MonoBehaviour
{
	public static Vector2[,,] point = new Vector2[200,200,200];
	public static int obstacle_num = 0;
	public static int[] gobal_polygon_num = new int[200];
	public static int[,] gobal_vertice_num = new int[200,200];
	public static Vector3[] gobal_initialcon = new Vector3[200];
	// Use this for initialization

	public void read (int index)
	{
		string line = "";
		int local_vertice_num = 0;
		int count_now_point = 0;
	    int local_polygon_num = 0;

		string[] lineArr = null;
		int a = 0;
		int a1 = 0;
		StreamReader sr = new StreamReader (Application.dataPath + @"/obstacle0"+index+".txt");
	//	StreamReader sr = new StreamReader ("http:/cherry.cs.nccu.edu.tw/~g10404/test/StreamingAssets/obstacle0"+index+".txt");

		for (int i = 0; i < 2; i++) {
			line = sr.ReadLine ();
		}
		obstacle_num = int.Parse (line);
		//障礙物數量
	//	Debug.Log (obstacle_num);

		while (a1 < obstacle_num) {


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
					

				a++; 
			}

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


			a1++;

		} 


		sr.Close ();                     // 關閉串流
		gameObject.AddComponent<drawobstacle> (); 
	}

	void Start ()
	{
	//	read ();
	//	Debug.Log (gobal_initialcon[1].ToString("f4"));
	//	gameObject.AddComponent<drawobstacle> (); 
	}

	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

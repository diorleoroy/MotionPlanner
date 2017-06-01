using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collision_detection_2 : MonoBehaviour {


	// Use this for initialization
	void Start () {
	//	detection_bomb ();
	}
	
	// Update is called once per frame
	void Update () {
	//	detection_bomb ();
	}
	public bool detection_bomb(){
		List<Vector3> edge_point = new List<Vector3> ();


		for (int i = 0; i < gameObject.transform.GetComponent<PolygonCollider2D> ().points.Length; i++) {
			edge_point.Add (gameObject.transform.TransformPoint (GetComponent<PolygonCollider2D> ().points[i]));
		}

		for (int i = 0; i < 5; i++) {
			List<Vector3> edge_point_tmp = new List<Vector3> ();
			for (int k = 0; k < edge_point.Count; k++) {
				edge_point_tmp.Add (edge_point [k]);
			}

			edge_point.Clear();
			int tmp_length = edge_point_tmp.Count;
			for (int j = 0; j < tmp_length-1; j++) {
				Vector3 mid_tmp = new Vector3 ();
				Vector3 old_data = new Vector3();
				old_data = edge_point_tmp [0];
			//	split_point (edge_point_tmp [0], edge_point_tmp [1],mid_tmp);
				mid_tmp.x = ((edge_point_tmp [0].x + edge_point_tmp [1].x) / 2);
				mid_tmp.y = ((edge_point_tmp [0].y + edge_point_tmp [1].y) / 2);
				mid_tmp.z = 0;

				edge_point.Add (old_data);
				edge_point.Add (mid_tmp);
				edge_point_tmp.RemoveAt (0);
			}
			Vector3 old_data2 = new Vector3();
			old_data2 = edge_point_tmp [0];
			edge_point.Add (old_data2);
		}


		for (int i = 0; i < edge_point.Count; i++) {

			if (edge_point [i].x > 127 || edge_point [i].x < 0 || edge_point [i].y < 0 || edge_point [i].y > 127) {
				return true;
			} else if (show_potential.potential_control_point_0 [(int)edge_point [i].x, (int)edge_point [i].y] > 235) {
				return true;
			}
	

		}
		return false;
	
	
	}

	void split_point(Vector3 point0,Vector3 point1,Vector3 final)
	{
	//	Vector3 mid = new Vector3 ();
		final.x = (float)(point0.x+point1.x) / 2;
		final.y = (float)(point0.y+point1.y) / 2;
		final.z = 0;

	//	mid_tmp = mid;
	}


/*	public void detection_bomb()
	{
		List<Vector3> edge_point = new List<Vector3> ();

		for (int i = 0; i < gameObject.transform.GetComponent<PolygonCollider2D> ().points.Length; i++) {
			edge_point.Add (gameObject.transform.TransformPoint (GetComponent<PolygonCollider2D> ().points[i]));
		}

		GameObject[] all_obstacle = GameObject.FindGameObjectsWithTag ("sub_obstacle");
		for (int k = 0; k < all_obstacle.Length; k++) {
			
		for ( int i = 0 ; i < gameObject.transform.GetComponent<PolygonCollider2D> ().points.Length ; i++ )
		{
			int front_i = i, back_i = i+1; // p1多邊形某條線的前後兩點
			if ( i == ( gameObject.transform.GetComponent<PolygonCollider2D> ().points.Length - 1 ) ) {
				back_i = 0;
			}
			//====向量v12'
			//int v_1_2_x_v = a_y[ back_i ] - a_y[ front_i ];
			float v_1_2_x_v =  gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_i ]).y - gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_i ]).y;
			//int v_1_2_y_v = 0 - (a_x[ back_i ] - a_x[ front_i ]);
			float v_1_2_y_v =   gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_i ]).x -  gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_i ]).x;
			//===========

				
				for ( int j = 0 ; j < all_obstacle [k].gameObject.transform.GetComponent<PolygonCollider2D> ().points.Length ; j++ )
				{
					int front_j = j, back_j = j+1; // p2多邊形某條線的前後兩點
					if ( j == ( all_obstacle [k].gameObject.transform.GetComponent<PolygonCollider2D> ().points.Length - 1 ) ) {
						back_j = 0;
					}
					Debug.Log (gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_i ]));
					//===向量v13
					//int v_1_3_x = b_x[ front_j ] - a_x[ front_i ];
					float v_1_3_x = all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_j ]).x - gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_i ]).x;
					//int v_1_3_y = b_y[ front_j ] - a_y[ front_i ];
					float v_1_3_y = all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_j ]).y- gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_i ]).y;
					//===向量v14
					//int v_1_4_x = b_x[ back_j ] - a_x[ front_i ];
					float v_1_4_x = all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_j ]).x - gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_i ]).x;
					//int v_1_4_y = b_y[ back_j ] - a_y[ front_i ];
					float v_1_4_y = all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_j ]).y - gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_i ]).y;
					//====向量v34'
					//int v_3_4_x_v = b_y[ back_j ] - b_y[ front_j ];
					float v_3_4_x_v = all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_j ]).y - all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_j ]).y;
					//int v_3_4_y_v = 0 - (b_x[ back_j ] - b_x[ front_j ]);
					float v_3_4_y_v = all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_j ]).x - all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_j ]).x;
					//===向量v31
					float v_3_1_x = 0 - v_1_3_x;
					float v_3_1_y = 0 - v_1_3_y;
					//===向量v32
					//int v_3_2_x = a_x[ back_i ] - b_x[ front_j ];
					float v_3_2_x = gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_i ]).x - all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_j ]).x;
					//int v_3_2_y = a_y[ back_i ] - b_y[ front_j ];
					float v_3_2_y = gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ back_i ]).y - all_obstacle [k].gameObject.transform.TransformPoint(GetComponent<PolygonCollider2D> ().points[ front_j ]).y;
					//===兩線段是否相交
					float v12_v_13 = (v_1_2_x_v * v_1_3_x) + (v_1_2_y_v * v_1_3_y); // 向量 v12' 和 v13 的內積
					float v12_v_14 = (v_1_2_x_v * v_1_4_x) + (v_1_2_y_v * v_1_4_y); // 向量 v12' 和 v14 的內積
					float v34_v_31 = (v_3_4_x_v * v_3_1_x) + (v_3_4_y_v * v_3_1_y); // 向量 v34' 和 v31 的內積
					float v34_v_32 = (v_3_4_x_v * v_3_2_x) + (v_3_4_y_v * v_3_2_y); // 向量 v34' 和 v32 的內積
					if ( (v12_v_13 * v12_v_14) < 0 ) {
						if ( (v34_v_31 * v34_v_32) < 0 ) {
							//System.out.println( "==========p1 =  " + i + ", p2 = " + j + " 相交" );
							Debug.Log("相交");
						}
					}
				} 
			
			
			
			}

		}





		for (int i = 0; i < edge_point.Count; i++) {
		
			if (edge_point [i].x <= 127 && edge_point [i].x >= 0 && edge_point [i].y >= 0 && edge_point [i].y <= 127) {
				if (show_potential.potential_control_point_0 [(int)edge_point [i].x, (int)edge_point [i].y] == 255 ) {
				//	Debug.Log ("Fuck");
				}
			}
		
		}

    //	Vector3[] vertex = gameObject.transform.TransformPoint (GetComponent<PolygonCollider2D> ().points);
	//	Debug.Log (gameObject.transform.TransformPoint (GetComponent<PolygonCollider2D> ().points[0]));


	}*/
}

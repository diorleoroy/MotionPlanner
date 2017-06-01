using UnityEngine;
using System.Collections;

public class draw_plan : MonoBehaviour
{
	private LineRenderer lineRenderer;  
	//定义一个Vector3,用来存储鼠标点击的位置  

	//用来索引端点  
	//端点数  

	void Start()  
	{  
		//添加LineRenderer组件  
	/*	lineRenderer = gameObject.GetComponent<LineRenderer>();  
		//设置材质  
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));  
		//设置颜色  
		lineRenderer.SetColors(Color.red, Color.red);  
		//设置宽度  
		lineRenderer.SetWidth(0.8f, 0.8f);  
		lineRenderer = GetComponent<LineRenderer>();  

		lineRenderer.SetVertexCount( bfs_new3.all_path.Count);
		Debug.Log (bfs_new3.all_path.Count);
		for (int i = 0; i < bfs_new3.all_path.Count; i++) {
			lineRenderer.SetPosition(i, new Vector3(bfs_new3.all_path[i].x,bfs_new3.all_path[i].y,1));  
		}
	*/

	}  

	void Update()  
	{    




	}  

	public void DestroyLine(){
		lineRenderer.SetVertexCount(0);
		/*int arrayLength = bfs_new3.all_path.Count;
		if(arrayLength > 0){
			GameObject.Destroy(pointPos[arrayLength-1]);
			bfs_new3.all_path.RemoveAt(arrayLength-1);        
			lineRenderer.SetVertexCount(--lineSeg);
		}*/
	}
}

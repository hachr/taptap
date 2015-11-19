using UnityEngine;
using System.Collections;

public class Util : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Physics2D.gravity
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static Vector3 RandomPosition(){
		float height = Camera.main.orthographicSize;
		float width = Camera.main.aspect * height;
		
		float x = Random.Range(-width, width);
		float y = Random.Range(-height, height);

		return new Vector3(x,y);
	}

//	public static void MoveObject (Transform thisTransform, startPos : Vector3, endPos : Vector3, time : float) : IEnumerator {
//		var i = 0.0;
//		var rate = 1.0/time;
//		while (i < 1.0) {
//			i += Time.deltaTime * rate;
//			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
//			yield; 
//		}
//	}
}

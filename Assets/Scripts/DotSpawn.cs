using UnityEngine;
using System.Collections;

public class DotSpawn : MonoBehaviour {

	GameObject go;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (go != null) {
			return;
		}

		go = Instantiate (Resources.Load ("circle-xl"), Util.RandomPosition(), new Quaternion ()) as GameObject;
	}
}

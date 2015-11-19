using UnityEngine;
using System.Collections;

public class DotController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float width = Camera.main.orthographicSize;
		float height = width * Camera.main.aspect;

		if(Input.touchCount > 0){
			for(int i = 0; i < Input.touchCount; i++){
				Touch currentTouch = Input.GetTouch(i);
				if(currentTouch.phase == TouchPhase.Began){
					Destroy(gameObject);
				}
			}
		}

		if (Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
			
			Debug.Log("mouse pos "+mousePosition.x+" y "+mousePosition.y+" "); 
			
			if(hitCollider){
				Debug.Log("Hit x"+hitCollider.transform.position.x+" y "+hitCollider.transform.position.y);    
				//Destroy(gameObject);
				Vector3 position = transform.position;

				Vector3 newPosition = getRandomPos(position);

				Vector3 size = GetComponent<Renderer>().bounds.size;
				//Debug.Log ("size: " + size.x + " and " + size.y);
				//size: 0.6400003 and 0.6399999

				newPosition.x = newPosition.x > 0 ? Mathf.Min(newPosition.x,(width - size.x)) : Mathf.Max(newPosition.x, -(width-size.x));
				newPosition.y = newPosition.y > 0 ? Mathf.Min(newPosition.y,(height - size.y)) : Mathf.Max(newPosition.y,-(height-size.y));

				Debug.Log (newPosition + " vs 5 & 8");

				StartCoroutine (DoMove(transform, newPosition, 0.1f));
			}
		}

	}

	Vector3 getRandomPos(Vector3 current){
		float width = Camera.main.orthographicSize;
		float height = width * Camera.main.aspect;

		float x = RandomNumber (current.x);
		float y = RandomNumber (current.y);


		x = x > 0 ? Mathf.Min(x,width) : Mathf.Max(x, -width);
		y = y > 0 ? Mathf.Min(y,height) : Mathf.Max(y,-height);

		Vector3 newPosition = new Vector3();
		newPosition.x = x;
		newPosition.y = y;
		return newPosition;
	}

	float RandomNumber(float baseValue){
		float x =  baseValue + Random.Range(-5,5);
		if (Mathf.Abs(x-baseValue) < 0.1f) {
			x += 0.1f;
		}
		return x;
	}


	IEnumerator DoMove(Transform transform, Vector3 newPosition, float rate){
		float i = 0.0f;
		while (i < rate) {
			i += Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, newPosition, i);
			yield return null;
		}
	}


//	void Move() {
//		for (var f = 1.0; f >= 0; f -= 0.1) {
//			var c = renderer.material.color;
//			c.a = f;
//			renderer.material.color = c;
//			yield;
//		}
//	}

}

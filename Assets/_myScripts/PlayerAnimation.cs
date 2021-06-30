using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator anim;

	public string [] staticDirections = {"Static_N", "Static_WN", "Static_W", "Static_SW", "Static_S", "Static_ES", "Static_E", "Static_NE"};
	public string [] runDirections = {"Run_N", "Run_WN", "Run_W", "Run_SW", "Run_S", "Run_ES", "Run_E", "Run_NE" };
	private int lastDirection;

	private void Awake ()
	{
		anim = GetComponent<Animator> ();

		//float result1 = Vector2.SignedAngle (Vector2.up, Vector2.right);
		//Debug.Log ("R1 = " + result1);
		//float result2 = Vector2.SignedAngle (Vector2.up, Vector2.down);
		//Debug.Log ("R2 = " + result2);
	}


	public void setDirection(Vector2 _direction) {

		string [] directionArray = null;

		if(_direction.magnitude < 0.01f) {
			directionArray = staticDirections;
		} else {

			directionArray = runDirections;
			lastDirection = DirectionToIndex (_direction);
		}

		anim.Play (directionArray [lastDirection]);


	}

	private int DirectionToIndex (Vector2 _direction)
	{
		Vector2 norDir = _direction.normalized;
		float step = 360 / 8;
		float offset = step / 2;
		float angle = Vector2.SignedAngle (Vector2.up, norDir);

		angle += offset;
		if (angle < 0) {

			angle += 360;
		}

		float stepCount = angle / step;
		return Mathf.FloorToInt (stepCount);

	}
}

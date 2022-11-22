using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstract
{

	[SerializeField] protected float speed = 9f;

	protected virtual void FixedUpdate()
	{
		this.Rotating();
	}

	protected virtual void Rotating()
	{
		Vector3 eulers = new Vector3(0, 0, 1);
		this.junkCtrl.Model.Rotate(eulers * this.speed * Time.fixedDeltaTime);
	}
}

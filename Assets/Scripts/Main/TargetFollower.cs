using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
	public Transform target;
	public float speed;

	public Vector3 offset;

	//public float oriOffset;
	private void Start()
	{
		//oriOffset = offset.z;
	}
	private void Update()
	{
		/*Vector3 currentPosition = transform.position;
		Vector3 newPosition = new Vector3(target.position.x,currentPosition.y,target.position.z-offset);
		transform.position = newPosition; */
		float interpolation = speed * Time.deltaTime;
		Vector3 movePosition = transform.position;
		//movePosition.y = target.position.y + offset.y; //Mathf.Lerp(transform.position.y, target.position.y+offset.y, interpolation); 
		movePosition.z = target.position.z - offset.z;
		movePosition.x = Mathf.Lerp(transform.position.x, target.position.x, interpolation);
		transform.position = movePosition;
	}

	//If Up arrow or down arrow is pressed
	public void ChangeOffset(float off)
	{
		//offset.z += off;
	}
}

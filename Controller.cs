using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Controller : MonoBehaviour
{
	Animator animator;
	Rigidbody2D rb2d;
	SpriteRenderer spriteRenderer;

	float holdDownStartTime;
	float touchStartTime = 0f;

	bool isMove;
	bool isSlow;
	bool isWater;
	private float OriSpeed;

	[SerializeField]
	private float runSpeed = 40f;

	[SerializeField]
	private float maxSpeed = 80f;

	[SerializeField]
	float upPower = 0.1f;

	[SerializeField]
	private float rotSpeed = 2f;

	[SerializeField]
	Transform waterCheck;



	// Start is called before the first frame update
	void Start()
	{
		
		animator = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		OriSpeed = runSpeed;
		
	}



	// Update is called once per frame
	private void Update()
	{
		if (Physics2D.Linecast(transform.position, waterCheck.position, 1 << LayerMask.NameToLayer("Water")))
		{
			isWater = true;
		}
		else
		{
			isWater = false;

		}

		if (Physics2D.Linecast(transform.position, waterCheck.position, 1 << LayerMask.NameToLayer("Slower")))
		{
			isSlow = true;
		}
		else
		{
			isSlow = false;

		}



		//core mekanik
		/////////////////////////////Control/////////////////////////

		//world pyshic logic
		upPower = rb2d.velocity.y;

		if (isWater && !isSlow)
		{

			rb2d.velocity = new Vector2(runSpeed, upPower);

		}


		if (isSlow)
		{

			if (runSpeed > -18)
			{
				runSpeed = runSpeed - 2.5f;
			}
			rb2d.velocity = new Vector2(runSpeed, upPower + 1.4f);

		}

		if (!isWater && !isSlow)
		{

			rb2d.velocity = new Vector2(runSpeed, upPower - 1.8f);

		}

		//pengatur kecepatan original
		if (runSpeed < OriSpeed)
		{
			runSpeed = runSpeed + 0.2f;
		}
		else if (runSpeed > OriSpeed)
		{
			runSpeed = runSpeed - 0.4f;
		}

		//mouse control
		//hold
		if (Input.GetMouseButtonDown(0))
		{
			float holdDownStartTime = Time.time;
			animator.Play("move");
		}

		if (Input.GetMouseButton(0))
		{
			float holdDownTime = Time.time - holdDownStartTime;
			if (runSpeed > 0)
			{
				runSpeed = runSpeed - 1.1f * CalculateHoldDownTime(holdDownTime);
			}

		}

		float CalculateHoldDownTime(float holdTime)
		{
			float maxforceHoldDownTime = 2f;
			float holdTimeNormalized = Mathf.Clamp01(holdTime / maxforceHoldDownTime);
			return holdTimeNormalized;


		}
		//rapid click
		if (Input.GetMouseButtonUp(0))
		{
			if (isSlow)
			{
				upPower = upPower + 3f;
			}

			if (runSpeed < maxSpeed)
			{
				runSpeed = runSpeed + 24f;
			}

		}

		/*/rotation limiter
		Vector3 euler = transform.eulerAngles;
		
		if (euler.z < 180)
		{ 
		//	euler.z = euler.z - 360;
			euler.z = Mathf.Clamp(euler.z, 0, 0);
			transform.eulerAngles = euler;
		}*/

	}

	////////////////incomplete omplementation///////////////////
	public void RotControl(Vector3 euler)
	{
		if (euler.z < 30)
		{
			//euler.z = euler.z - 360;
			euler.z -= 0;
			euler.z = Mathf.Clamp(euler.z, 0, 30);
			transform.eulerAngles = euler;
		}

		if (euler.z > 330)
		{
			//euler.z = euler.z - 360;
			euler.z = 330;
			euler.z = Mathf.Clamp(euler.z, -30, 0);
			transform.eulerAngles = euler;
		}
	}
	///////////////////////////////////////////////
    ///
	//locate position for creating stage
	public Vector3 GetPosition()
	{
		return transform.position;
	}

}
/////////////////////////unused control code//////////////////////
///
/*/touch control
		if(Input.touchCount > 0)
        {
			Touch t = Input.GetTouch(0);
			//dayung
			if (t.phase == TouchPhase.Began)
			{
				runSpeed = runSpeed + 8;


				//buat berenti
				while (t.phase == TouchPhase.Began)
				{
					if (runSpeed > 0)
					{
						runSpeed = runSpeed - 4;
					}
				}
			}
		
        }
		
*////////////////////////////////////////////////////////////////////////

//rotation control ((incomplete implementation))
/*
var rot = transform.rotation;

if(rot.z >= 12 || rot.z <= -12)
{
	//transform.rotation.z = 0;
	//transform.rotation = rot;
	transform.Rotate(Vector3.forward * -rot.z * rotSpeed);
} 
*/
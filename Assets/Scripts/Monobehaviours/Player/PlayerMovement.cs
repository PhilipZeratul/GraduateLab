using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour
{
	public float horizantalSpeed = 10.0f;
	public float verticalSpeed = 6.0f;

	private bool isWalking = false;
	private Animator walkAnimator;


	void Awake()
	{
		walkAnimator = GetComponent<Animator>();
	}

	void LateUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		if (h != 0 || v != 0)
			Move(h, v);
		else
			Stop();
	}

	void Move(float h, float v)
	{
        if (h > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            h = -h;
        }
        else if (h < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        transform.Translate(h*horizantalSpeed, v*verticalSpeed, 0.0f);
		walkAnimator.SetFloat("Speed", 2.0f);
	}

	void Stop()
	{
		walkAnimator.SetFloat("Speed", 0.0f);
	}
}
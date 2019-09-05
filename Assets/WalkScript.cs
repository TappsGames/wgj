using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
	private float walkSpeed = 0.1f;
	private float runSpeed = 0.3f;
	private float charSpeed;

	void Start()
	{
		charSpeed = walkSpeed;
	}

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
        	transform.localPosition -= new Vector3(charSpeed,0,0);
        	transform.localScale = new Vector3(-1,1,1);
        	GetComponent<Animator>().SetBool("walk", true);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
        	transform.localPosition += new Vector3(charSpeed,0,0);
        	transform.localScale = new Vector3(1,1,1);
        	GetComponent<Animator>().SetBool("walk", true);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
        	GetComponent<Animator>().SetBool("walk", false);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
        	charSpeed = runSpeed;
        	GetComponent<Animator>().SetBool("Run", true);
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
        	charSpeed = walkSpeed;
        	GetComponent<Animator>().SetBool("Run", false);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
        	GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,300f));
        }
    }
}

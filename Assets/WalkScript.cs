using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour
{
	private float walkSpeed = 0.1f;
	private float runSpeed = 0.3f;
	private float charSpeed;

	private bool isOnGround = false;

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
        	GetComponent<Animator>().SetBool("run", true);
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
        	charSpeed = walkSpeed;
        	GetComponent<Animator>().SetBool("run", false);
        }

        if(Input.GetKeyUp(KeyCode.Space) && isOnGround)
        {
        	GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,300f));
        	GetComponent<Animator>().SetBool("onground", false);
        	isOnGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "floor")
        {
        	isOnGround= true;
        	GetComponent<Animator>().SetBool("onground", true);
        }
    }
}

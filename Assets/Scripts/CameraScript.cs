using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour { 

    public LayerMask whatIsPlayer;

    public bool isTouchLeft = false;
    public bool isTouchRight = false;

    public GameObject leftCheck;
    public GameObject rightCheck;


    public bool await = false;

    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
       
    }


    IEnumerator CollideCheck()
    {

        yield return new WaitForSeconds(0.5f);
        await = false;
    }


    // Update is called once per frame
    void Update()
    {
        isTouchRight = Physics2D.OverlapBox(rightCheck.transform.position, new Vector2(0.001f, 5), 0, whatIsPlayer);
        isTouchLeft = Physics2D.OverlapBox(leftCheck.transform.position, new Vector2(0.001f, 5), 0, whatIsPlayer);

        if (isTouchRight && !isTouchLeft && !await)
        {
            await = true;
            cam.position = new Vector3(cam.position.x + 22, cam.position.y, cam.position.z);
            StartCoroutine(CollideCheck());
        }
        else if (isTouchLeft && !isTouchRight && !await)
        {
            await = true;
            cam.position = new Vector3(cam.position.x - 22, cam.position.y, cam.position.z);
            StartCoroutine(CollideCheck());


        }
    }


}

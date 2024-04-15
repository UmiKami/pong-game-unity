using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPaddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int PaddleVerticalSpeed = 7;

    [SerializeField]
    private bool isNPC = false;
  

    // Update is called once per frame
    void Update()
    {
        if (!isNPC)
        {
            if (Input.GetKey("w") && transform.position.y < 4.22f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + PaddleVerticalSpeed * Time.deltaTime);
            }

            if (Input.GetKey("s") && transform.position.y > -4.22f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - PaddleVerticalSpeed * Time.deltaTime);
            }
        }
    }



}



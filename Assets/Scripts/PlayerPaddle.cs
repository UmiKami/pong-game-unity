using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPaddle : MonoBehaviour
{
    // Start is called before the first frame update

    public int PaddleVerticalSpeed = 7;

    [SerializeField]
    private bool isNPC = false;

    public Ball ball;

    public bool getIsNPC(){
        return isNPC;
    }

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
        else
        {

            if (ball.getDx() > 0.9f)
            {
                Debug.Log($"AI Paddle Speed: {PaddleVerticalSpeed}");
                Debug.Log("Ball going towards the right");
                int m = ball.getDy() / ball.getDx();

                int targetY = m * (int)(transform.position.x - ball.transform.position.x) + (int)ball.transform.position.y;

                Debug.Log($"Target Y POS: {targetY}");

                if (ball.getDy() > 0 && transform.position.y < targetY && transform.position.y < 4.22f)
                {
                    Debug.Log($"Moving Up");
                    transform.position = new Vector3(transform.position.x, transform.position.y + PaddleVerticalSpeed  * Time.deltaTime);
                }else if (ball.getDy() < 0 && transform.position.y > targetY && transform.position.y > -4.22f)
                {
                    Debug.Log($"Moving down");
                    transform.position = new Vector3(transform.position.x, transform.position.y - PaddleVerticalSpeed  * Time.deltaTime);
                }else{
                    transform.position = new Vector3(transform.position.x, transform.position.y);
                }

            }

        }
    }



}



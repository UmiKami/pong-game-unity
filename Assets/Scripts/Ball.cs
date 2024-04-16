using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{

    public ScoreManager scoreManager;

    public TMP_Text countDownText;

    private int dx = 15;
    private int dy = 8;

    private float counter = 3f;

    public AudioSource wallHit;
    public AudioSource paddleHit;
    public AudioSource scoreSfx;

    void OnCollisionEnter2D(Collision2D collision) => ChangeTrajectory(collision) ;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0);

        dx = Random.Range(dx - 10, dx);
        dy = Random.Range(-dy, dy);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0.01){
            countDownText.alpha = 1;
            counter -= Time.deltaTime;
            countDownText.text = math.ceil(counter).ToString();
        }else 
        {
            countDownText.alpha = 0;
            transform.position = new Vector3(transform.position.x + dx * Time.deltaTime, transform.position.y + dy * Time.deltaTime);
        }
    }

    void ResetBall()
    {
        transform.position = new Vector3(0,0);
        if (paddle.getIsNPC())
        {
            paddle.PaddleVerticalSpeed = Random.Range(1, 4);
        }

        if (ScoreManager.player1Serving){

            dx = 15;

            dx = Random.Range(dx - 10, dx);
            dy = Random.Range(-dy, dy);

            counter = 3f;
        }

        if (ScoreManager.player2Serving){
            dx = -15;
            dy = 8;

            dx = Random.Range(dx, dx + 10);
            dy = Random.Range(-dy, dy);


            counter = 3f;
        }


        Debug.Log($"dx speed: {dx} ||| dy speed: {dy}");
    }

    void ChangeTrajectory(Collision2D collision)
   {    

        Debug.Log($"Ball collided with {collision.collider.tag}");
        if (collision.collider.tag == "Player")
        {
            paddleHit.Play();
            dx = (int)(-dx * 1.03f);
            dy = (int)(dy * 1.03f);
        }

        if (collision.collider.tag == "LevelLimitCollider")
        {
            wallHit.Play();
            dy = -dy;
        }
   }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log($"Goal on {(transform.position.x > 0 ? "player 2" : "player 1")}");

        scoreSfx.Play();

        if (transform.position.x > 0)
        {
            scoreManager.setPlayer1Score();
            ResetBall();
        }

        if (transform.position.x < 0)
        {
            scoreManager.setPlayer2Score();
            ResetBall();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text WinnerText;
    [SerializeField] private Text LivesText;
    [SerializeField] private Text GameOverText;
    [SerializeField] private Text YouDiedText;
    [SerializeField] private Transform Rewspawn;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private int score;
    private int remainingLives;


    // Start is called before the first frame update
    void Start()
    {   
        transform.position = Rewspawn.position;
        rigidbodyComponent = GetComponent<Rigidbody>();
        
        score = 0;
        SetScoreText();
        WinnerText.text = "";
        remainingLives = 3;
        SetLivesText();
        GameOverText.text = "";
        YouDiedText.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            jumpKeyWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput*2.3f, rigidbodyComponent.velocity.y, 0);
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
           
        }
        
        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 7.5f, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            score++;
            SetScoreText();

        }
        
            
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            transform.position = Rewspawn.position;


            if (remainingLives > 0)
                remainingLives--;           
            else
                remainingLives = 0;
            SetLivesText();
        }
    }
    void DisableText()
    {
        YouDiedText.enabled = false;
    }
    private void SetScoreText()
    {
        ScoreText.text = ("Score: " + score.ToString());
        if(score>=6 && remainingLives>0)
        {
            WinnerText.text = "Winner Winner Chicken Dinner";
            

            
        }
    }
    private void SetLivesText()
    {
        LivesText.text = ("Lives: " + remainingLives.ToString());
        if (score >= 5)
            return;
        else
        {
            if (remainingLives > 0)
            {
                YouDiedText.text = "You died!";
                Invoke("DisableText", 1f);
                YouDiedText.enabled = true;
            }
            else
            {

                GameOverText.text = "GameOver";

            }
        }
    }

}

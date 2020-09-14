using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController control;
    private Vector3 direction;
    public float speed;
    private int laneposition = 1;
    public int lanedistance = 4;
    public float JumpSpeed;
    public float GravityForce = -20;
    public Text ScoreText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        ScoreText.text = "Score: " + count.ToString();
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = speed;

        if(control.isGrounded)
        {
            direction.y = -1;
            if (Swipe.SwipeUp)
            {
                Sounds.PlaySound("smb_jump-small");
                direction.y = JumpSpeed;
            }
        }
        else
        {
            direction.y += GravityForce * Time.deltaTime;
        }
        if(Swipe.SwipeRight)
        {
            laneposition++;
            if(laneposition >= 3)
            {
                laneposition = 2;
            }
        }
        if (Swipe.SwipeLeft)
        {
            laneposition--;
            if (laneposition <= -1)
            {
                laneposition = 0;
            }
        }
        Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(laneposition == 0)
        {
            targetposition += Vector3.left * lanedistance;
        }
        else if (laneposition == 2)
        {
            targetposition += Vector3.right * lanedistance;
        }
        transform.position = targetposition;
    }
    private void FixedUpdate()
    {
        if (!GameOver.GameStart)
            return;
        PlayerMove();
    }
    private void PlayerMove()
    {
        control.Move(direction * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
            //other.gameObject.SetActive(false);
            Sounds.PlaySound("smb_coin");
            Destroy(other.gameObject);
            count = count + 1;
            ScoreText.text = "Score: " + count.ToString();
        }
        if(other.gameObject.CompareTag("cube"))
        {
            Sounds.PlaySound("smb_fireball");
            Destroy(other.gameObject);
            if(Health.health < 100)
                Health.health += 10f;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "obstacle")
        {
            //Destroy(gameObject);
            //GameOver.gameOver = true;
            Sounds.PlaySound("smb_kick");
            Health.health -= 10f;
        }
    }
}

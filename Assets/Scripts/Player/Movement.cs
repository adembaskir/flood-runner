using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float swipeSpeed;
    public float moveSpeed;
    #region OBJECTS
    private Camera cam;

    private Rigidbody rb;

    public GameObject deadPanel,effect;

    public GameObject pos;

    public GameObject woodEffect;

    public Text scoreText;
    public Transform target;

    #endregion
    [SerializeField] PlayerManager playerManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] public bool  isGrounded;

    float touchPosX;

    public int woodNumber;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        LevelBoundaries();
        if(playerManager.playerState == PlayerManager.PlayerState.Move)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (TouchController.Instance.canMove)
        {
            touchPosX = TouchController.Instance.touch.deltaPosition.x * Time.deltaTime * swipeSpeed;
            transform.position += Vector3.right * touchPosX;
   
        }
        scoreText.text = "" + woodNumber;


    }
    void resetRotate()
    {
        transform.rotation = Quaternion.identity;
    }
    void LevelBoundaries()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -4.2f, 4.5f);
        transform.position = pos;

    }
    public void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        //rb.constraints = RigidbodyConstraints.FreezeAll;


    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
        if (collision.collider.tag == "Obstacle")
        {
            if (woodNumber >= 1) { woodNumber--; }
           
            deadPanel.SetActive(false);
            Instantiate(effect, collision.GetContact(0).point, Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Wood")
        {
            woodNumber++;
            
            //Instantiate(woodEffect, collision.gameObject.transform.position,Quaternion.identity);
            //Destroy(collision.gameObject);
            //animator.SetTrigger("Give");
        }
       
    }
     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zebra")
        {
            ScoreManager.animalScore += 200;
            scoreManager.animalScoreText.text = "" + ScoreManager.animalScore;
            Debug.Log("Other Collider:" + other.name);
        }
        if (other.tag == "Giraffe")
        {
            ScoreManager.animalScore += 300;
            scoreManager.animalScoreText.text = "" + ScoreManager.animalScore;
            Debug.Log("Other Collider:" + other.name);
        }
        if (other.tag == "Pig")
        {
            ScoreManager.animalScore += 300;
            scoreManager.animalScoreText.text = "" + ScoreManager.animalScore;
            Debug.Log("Other Collider:" + other.name);
        }
        if (other.tag == "Ox")
        {
            ScoreManager.animalScore += 300;
            scoreManager.animalScoreText.text = "" + ScoreManager.animalScore;
            Debug.Log("Other Collider:" + other.name);
        }
    }

}

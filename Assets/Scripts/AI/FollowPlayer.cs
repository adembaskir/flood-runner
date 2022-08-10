using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
    public class FollowPlayer : MonoBehaviour
{
    #region Singleton class: FollowPlayer

    public static FollowPlayer Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion
    public GameObject target;
    public GameObject newTarget;
    NavMeshAgent _agent;
    public bool follow, endHit = false;
    public Animator anim;
    public float fly;
    public GameObject effect;
    Rigidbody rb;
    public Vector3 lastTargetPos;
    ScoreManager scoreManager;
        
        
        
        void Start()
        {
        _agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        
            
        }
        void FixedUpdate()
        {
            if (follow == true)
            {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3 * Time.deltaTime);
            transform.position += transform.forward * 6.2f * Time.deltaTime;
            
            }
            if(endHit == true)
            {
            follow = false;
            _agent.destination = newTarget.transform.position;
            _agent.GetComponent<Rigidbody>().isKinematic = false;
        }
            
        }
    void OnCollisionEnter(Collision other)
     {
         if (other.collider.tag == "Obstacle")
         {
             //FindObjectOfType<Movement>().monkeyNumber--;
            follow = false;
            anim.SetBool("IsRunning",false);
            _agent.GetComponent<NavMeshAgent>().enabled = false;
            _agent.GetComponent<Rigidbody>().AddForce(Vector3.zero);
            _agent.GetComponent<Rigidbody>().AddForce(Vector3.up * fly,ForceMode.Impulse);
            anim.GetComponent<Animator>().enabled = false;
            Instantiate(effect, other.GetContact(0).point,Quaternion.identity);
            ScoreManager.animalScore -= 200;
            if(this.gameObject != null) 
            { 
            Destroy(this.gameObject, 3f);
            }
            //rb.constraints = FreezeRotation;
        }
    }
        
        void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
            {
                follow = true;
                anim.SetBool("IsRunning", true);
                StartCoroutine(WaitFor());
            }
            if (collision.tag == "EndTrigger")
            {
                endHit = true;
                
            }

        }
    void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    IEnumerator WaitFor()
        {
            yield return new WaitForSeconds(0.3f);
            _agent.GetComponent<CapsuleCollider>().isTrigger = false;
        }
        

}



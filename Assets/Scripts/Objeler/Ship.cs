using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{

    [Header("Animatorleri tan�mla: ")]
    public Animator bigShipAnimator;
    public Animator midShipAnimator;
    [Header("Gereken bile�enler: ")]
    public Movement movement;
    public float woodNumber;
    [Header("Gemiler Ka� Odun Say�s�nda Spawn Olsun: ")]
    public float bigShipSpawnNumber;
    public float smallShipSpawnNumber;
    public float midShip;
    [Header("Gemilerin gidece�i Konum: ")]
    public Transform normalShip;
    public Transform bigShep;
    public Transform shipTarget;
    float speed = 10f;
    [Header("Kontrol Ama�l� Booleanler: ")]
    public bool normalShipSpawned;
    public bool midShipSpawned;
    public bool bigShipSpawned;

    [Header("Panel Atamalar�:")]
    public GameObject gameOverPanel;
    public GameObject animalScore;
    public GameObject woodPanel;



    void Update()
    {
        woodNumber = movement.woodNumber;
        if(normalShipSpawned == true)
        {
            normalShip.transform.position = Vector3.MoveTowards(normalShip.transform.position, shipTarget.transform.position,speed *Time.deltaTime);
           
        }
        if(bigShipSpawned == true)
        {
            bigShep.transform.position = Vector3.MoveTowards(bigShep.transform.position, shipTarget.transform.position, speed * Time.deltaTime);
        }
    }
   
    void OnTriggerEnter(Collider other)
    {

        if (woodNumber <= smallShipSpawnNumber && other.tag == "Player")
        {
            midShipAnimator.SetBool("MidShipRun", true);
            normalShipSpawned = true;
            StartCoroutine(WaitForspawn());
        }
        if (woodNumber >=bigShipSpawnNumber  && other.tag == "Player")
        {

            normalShipSpawned = false;
            bigShipAnimator.SetBool("BigShip", true);
            bigShipSpawned = true;
            StartCoroutine(WaitForspawn());
        }

        if (woodNumber < 1)
        {
            gameOverPanel.SetActive(true);
            woodPanel.SetActive(false);
            animalScore.SetActive(false);
            Time.timeScale = 0;

        }
    }

    IEnumerator WaitForspawn()
    {
        yield return new WaitForSeconds(3f);
        midShipAnimator.enabled = false;
        bigShipAnimator.enabled = false;

    }
    
    
}

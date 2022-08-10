using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    public GameObject effect;

    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Zebra"))
        {
            Instantiate(effect, other.GetContact(0).point,Quaternion.identity);
            other.gameObject.SetActive(false);
        }
        if (other.collider.CompareTag("Ox"))
        {
            Instantiate(effect, other.GetContact(0).point, Quaternion.identity);
            other.gameObject.SetActive(false);
        }
        if (other.collider.CompareTag("Giraffe"))
        {
            Instantiate(effect, other.GetContact(0).point, Quaternion.identity);
            other.gameObject.SetActive(false);
        }
        if (other.collider.CompareTag("Pig"))
        {
            Instantiate(effect, other.GetContact(0).point, Quaternion.identity);
            other.gameObject.SetActive(false);
        }
    }
}

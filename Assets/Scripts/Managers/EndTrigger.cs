using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EndTrigger : MonoBehaviour
{
    public GameObject nextLevelPanel,animScorePanel,woodPanel;
    public void EnHited()
    {
        StartCoroutine(WaitFor());
    }
    public void EndHittedForCamera()
    {
        StartCoroutine(WaitForCameraStop());
    }

    public void EndHitForPlayer()
    {
        StartCoroutine(WaitForAnim());
    }
     IEnumerator WaitFor()
     {
        yield return new WaitForSeconds(1.2f);
        FindObjectOfType<Movement>().GetComponentInChildren<Animator>().SetBool("Dance",true);
        FindObjectOfType<Movement>().enabled = false;
     }
    IEnumerator WaitForCameraStop()
    {
        yield return new WaitForSeconds(0.6f);
        FindObjectOfType<CameraFollow>().enabled = false;
        FindObjectOfType<CameraFollow>().GetComponent<Animator>().enabled = true;
        FindObjectOfType<CameraFollow>().anim.SetBool("Cam_big", true);
    }
    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(2.7f);
        nextLevelPanel.SetActive(true);
        animScorePanel.SetActive(false);
        woodPanel.SetActive(false);
       

    }

}

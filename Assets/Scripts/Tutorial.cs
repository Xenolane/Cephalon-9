using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject objectivesUI1;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            StartCoroutine(TutorialUI());
        }
    }

    IEnumerator TutorialUI()
    {
        objectivesUI1.SetActive(true);
        yield return new WaitForSeconds(10);
        objectivesUI1.SetActive(false);
        Destroy(this.gameObject);
    }
}

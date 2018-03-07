using UnityEngine;

public class TouchFloor : MonoBehaviour {

    private GameObject player;

	void Start ()
    {
        player = GameObject.Find("RobotGuy");
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            player.GetComponentInParent<PlayerController>().jumpAmmout = 0;
            player.GetComponent<Animator>().SetBool("grounded", true);
        }
    }
}

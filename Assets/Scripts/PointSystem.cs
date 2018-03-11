using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour {

	[SerializeField] private Text pointsText;
	public int points=0;

	void Update ()
    {
		pointsText.text = points + "";
	}
}

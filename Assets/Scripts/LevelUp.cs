using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour {

    public Slider levelUp;
    public int currentLevel;
    public int exp;
	public Text levelText;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateExp(5);
	}

    public void UpdateExp(int Exp)
    {
        
        int ourLvl = (int)(0.1f * Mathf.Sqrt(exp));
        if (ourLvl != currentLevel)
        {
			currentLevel = ourLvl;
        }

        int expnextLevel = 100 * (currentLevel + 1) * (currentLevel + 1);
        int differenceexp = expnextLevel - exp;

        int totaldifference = expnextLevel - (100 * currentLevel * currentLevel);

		levelUp.value = (1f - (float)differenceexp / (float)totaldifference);
		levelText.text = currentLevel + "";
    }
}

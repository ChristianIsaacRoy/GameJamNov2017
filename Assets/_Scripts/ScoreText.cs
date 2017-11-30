using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public int scoreOfPlayer;

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (scoreOfPlayer == 1)
            text.text = "<b>" + GameManager.instance.PlayerOneScore.ToString() + "</b>";
        else if (scoreOfPlayer == 2)
            text.text = "<b>" + GameManager.instance.PlayerTwoScore.ToString() + "</b>";
	}
}

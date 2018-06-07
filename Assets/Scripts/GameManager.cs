using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int score;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        score = 0;
	}
}

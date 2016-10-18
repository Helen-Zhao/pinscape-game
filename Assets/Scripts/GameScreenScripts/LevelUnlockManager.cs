using UnityEngine;
using System.Collections;
using Managers;
using UnityEngine.UI;

public class LevelUnlockManager : MonoBehaviour {

    private GameController _controller;
    public Button[] LevelButtons;

	// Use this for initialization
	void Start () {
        _controller = GameController.Instance;

        for (int i = 0; i < _controller.LevelsUnlocked; i++)
        {
            LevelButtons[i].interactable = true;
        }
	}
}

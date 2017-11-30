using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    

	public void NewGame()
    {
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("Map");
    }

    public void Quit()
    {
        
        SceneManager.LoadScene("Menu");
    }
}

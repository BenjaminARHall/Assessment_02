using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

    


        public void StartGame()
        {
            SceneManager.LoadScene("Start Game");
        }

        public void LevelSelect()
        {

        }

        public void QuitGame()
        {
            Application.Quit();
        }
 
}

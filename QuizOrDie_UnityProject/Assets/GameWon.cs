using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWon : MonoBehaviour
{
   public void RestartGame2() {
      SceneManager.LoadScene("main");
  }
   public void ExitButton2() {
      Application.Quit();
      Debug.Log("You quit the game!");
  }
    public void MainMenu2(){
        SceneManager.LoadScene("Menu");
    }
}

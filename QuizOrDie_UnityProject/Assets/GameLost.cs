using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLost : MonoBehaviour
{
  public void RestartGame() {
      SceneManager.LoadScene("main");
  }
   public void ExitButton() {
      Application.Quit();
      Debug.Log("You quit the game!");
  }
    public void MainMenu(){
        SceneManager.LoadScene("Menu");
    }
}

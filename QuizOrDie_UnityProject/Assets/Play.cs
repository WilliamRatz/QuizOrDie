using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
  public void QuitButton() {
      Application.Quit();
      Debug.Log("You quit the game!");
  }

  public void StartGame() {
      SceneManager.LoadScene("main");
  }
}
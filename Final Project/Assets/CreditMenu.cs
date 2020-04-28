using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditMenu : MonoBehaviour
{
   public void PlayGame(){
       SceneManager.LoadScene("Menu");
   }
   public void TutorialGame(){
       SceneManager.LoadScene("Menu");
   }
   public void QuitGame(){
       SceneManager.LoadScene("Menu");
   }
}

using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
   
   public void RestartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }
}

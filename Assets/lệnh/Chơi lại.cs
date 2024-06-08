using UnityEngine;
using UnityEngine.SceneManagement;

public class Chơi_lại : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}

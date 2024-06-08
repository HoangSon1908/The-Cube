using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.CompilerServices;

public class Tạm_dừng : MonoBehaviour
{
    public GameObject pause;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            tạm_dừng();
        }
    }

    public void tạm_dừng()
    {
        pause.SetActive(!pause.activeSelf);//đảo giữa bật và tắt tạm dừng.

        if (pause.activeSelf)
        {
            di_chuyển.instance.rb.isKinematic = true;//isKinematic để vật không bị tác dụng bởi lực và dừng lại luôn
            Time.timeScale = 0f;//tạm dừng thời gian
        }
        else
        {
            Time.timeScale = 1f;//chạy thời gian
            chờ.instance.đếm_ngược();
        }
    }
    public void thử_lại()
    {
        tạm_dừng();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        tạm_dừng();
        SceneManager.LoadScene("menu");
    }
    public void Thoát()
    {
        Application.Quit();
    }
}

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
        pause.SetActive(true);
        di_chuyển.instance.rb.isKinematic = true;//isKinematic để vật không bị tác dụng bởi lực và dừng lại luôn
        pause.GetComponent<Animator>().Play("OpenUI");
        Time.timeScale = 0f;//tạm dừng thời gian

    }

    public void tiếp_tục()
    {
        Time.timeScale = 1f;//chạy thời gian
        chờ.instance.đếm_ngược();
        pause.SetActive(false);
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
}

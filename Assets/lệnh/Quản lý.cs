using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quản_lý : MonoBehaviour
{
    public static Quản_lý instance;
    public static bool kết_thúc;
    public GameObject Chiến_thắng;
    void Awake()
    {
        Time.timeScale = 1;
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void chiến_thắng()
    {
       Chiến_thắng.SetActive(true);
       Nhạc_nền.instance.YATTA();
       kết_thúc=true;
       Time.timeScale = 0;
    }
    bool thua=false;
    public void đã_thua()
    {
        if(thua == false) 
        {
            thua = true;
            StartCoroutine(chơi_lại());
        } 
    }
    public IEnumerator chơi_lại()
    {
        chờ.instance.đếm_ngược();
        yield return new WaitForSeconds(3);
        thua = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

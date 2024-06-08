using System.Collections;
using TMPro;
using UnityEngine;

public class chờ : MonoBehaviour
{
    public static chờ instance;
    public GameObject Hồi_sinh;
    public TextMeshProUGUI hồi_sinh;
    private bool đang_chờ=false;

    private void Awake()
    {
        instance = this;
    }

    public void đếm_ngược()
    {
        if (đang_chờ)
        {
            return;
        }
        StartCoroutine(AnimateText());
    }

    public IEnumerator AnimateText()
    {
        đang_chờ = true;
        Hồi_sinh.SetActive(true);
        hồi_sinh.text = "3";
        int thời_gian = 3;

        yield return new WaitForSeconds(0.7f);

        while (thời_gian >0)
        {
            thời_gian--;
            hồi_sinh.text = thời_gian.ToString();

            yield return new WaitForSeconds(1f);
        }
        Hồi_sinh.SetActive(false);
        di_chuyển.instance.rb.isKinematic = false;
        đang_chờ = false;
    }
}

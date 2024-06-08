using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class điểm : MonoBehaviour
{
    public Transform người_chơi;
    public TextMeshProUGUI điểm_số;

    // Update is called once per frame
    void Update()
    {
        điểm_số.text=người_chơi.position.z.ToString("0");//khiến nó chỉ hiện giá trị int
    }
}

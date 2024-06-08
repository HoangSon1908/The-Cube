using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Điểm_cao : MonoBehaviour
{
    public TextMeshProUGUI điểm_cao_nhất;
    public TextMeshProUGUI điểm_hiện_tại;

    private int điểm_cao;

    void Start()
    {
        // Kiểm tra xem có giá trị điểm_cao đã được lưu trữ trước đó không
        if (PlayerPrefs.HasKey("Điểm cao"))
        {
            // Nếu có, tải giá trị lưu trữ vào biến điểm_cao
            điểm_cao = PlayerPrefs.GetInt("Điểm cao");
            điểm_cao_nhất.text = điểm_cao.ToString();
        }
        else
        {
            // Nếu không, giá trị high score ban đầu được đặt là 0
            điểm_cao = 0;
            điểm_cao_nhất.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        int điểm = int.Parse(điểm_hiện_tại.text);

        if (điểm > điểm_cao)
        {
            // Cập nhật highScoreValue và hiển thị giá trị mới trên hscore.text
            điểm_cao = điểm;
            điểm_cao_nhất.text = điểm_cao.ToString();

            // Lưu giá trị high score vào bộ nhớ cục bộ
            PlayerPrefs.SetInt("Điểm cao", điểm_cao);
        }
    }
}


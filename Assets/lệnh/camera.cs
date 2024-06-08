using UnityEngine;

public class camera : MonoBehaviour
{
    //cách tạo hiệu ứng mờ cuối cảnh:vào lighting-fog.
    public Transform người_chơi;
    public Vector3 khoảng_cách_camera;
    void Update()
    {
        transform.position = người_chơi.position + khoảng_cách_camera;
    }
}

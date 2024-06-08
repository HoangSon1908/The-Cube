using UnityEngine;

public class đích : MonoBehaviour
{
    public Quản_lý quản_lý;
    void OnTriggerEnter()
    {
        quản_lý.chiến_thắng();
    }
}

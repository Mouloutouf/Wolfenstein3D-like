using UnityEngine;

public class Billboard : MonoBehaviour
{
    void LateUpdate()
    {
        Camera m_Camera = Camera.main; 
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
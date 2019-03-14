using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour, IPlClass
{
    #region References
    GameObject player;
    public PlayerModules Modules { get; set; }
    public void SetClasses(PlayerModules _Modules) { Modules = _Modules; }

    #endregion

    #region Interface
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    #endregion

    #region Private Values
    Vector2 mouseLook;
    Vector2 smoothV;

    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = this.transform.parent.gameObject;

        GameManager.Instance.inputManager.MouseMoved += Rotation;
        GameManager.Instance.inputManager.Pause += Escape;
    }
    #endregion

    #region Public Methods
    public void WalkMovement(bool active)
    {
        if (active)
        {

        }
        else
        {

        }
    }

    #endregion

    #region Private Methods
    void Rotation(Vector2 mouseMovement)
    {
        mouseMovement = Vector2.Scale(mouseMovement, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseMovement.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseMovement.y, 1f / smoothing);

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -50, 90);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }

    void Escape()
    {
        Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
    }
    #endregion
}

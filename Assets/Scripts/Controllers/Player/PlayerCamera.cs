using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerCamera : MonoBehaviour, IPlClass
{
    #region References
    GameObject player;
    [HideInInspector]
    public PlayerModules Modules { get; set; }
    public void SetClasses(PlayerModules _Modules) { Modules = _Modules; }

    #endregion

    #region Interface
    [FoldoutGroup("Rotation Settings")]
    public float sensitivity = 5.0f;
    [FoldoutGroup("Rotation Settings")]
    public float smoothing = 2.0f;

    [FoldoutGroup("BobHead Settings")]
    public Vector2 multiplierWalk = new Vector2(0.5f, 0.3f);
    [FoldoutGroup("BobHead Settings")]
    public float walkLoopTime = 0.75f;
    [FoldoutGroup("BobHead Settings")]
    public float originTime = 0.2f;
    [FoldoutGroup("BobHead Settings")]
    public AnimationCurve walkCurve;

    #endregion

    #region Private Values
    Vector2 mouseLook;
    Vector2 smoothV;

    bool walkAnim;
    Vector2 offset;
    Vector2 positive = new Vector2(-1, -1);
    Vector2 percentage = Vector2.zero;
    Vector2 time = Vector2.zero;
    Vector2 loopTime = Vector2.zero;
    Vector3 origin;

    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = this.transform.parent.gameObject;
        origin = this.transform.localPosition;

        GameManager.Instance.inputManager.MouseMoved += Rotation;
        GameManager.Instance.inputManager.Pause += Escape;
    }

    private void Update()
    {
        if (walkAnim) BobHead();
        else if (!walkAnim && this.transform.localPosition != origin) ReturnToOrigin();
    }
    #endregion

    #region Public Methods
    public void WalkMovement(bool active)
    {
        if (active && !walkAnim)
        {
            positive = new Vector2(-1, -1);
            percentage = Vector2.zero;
            time = Vector2.zero;
            loopTime = new Vector2(walkLoopTime, walkLoopTime/2);
            walkAnim = true;
        }
        else if (!active && walkAnim)
        {
            time = Vector2.zero;
            percentage = Vector2.zero;
            walkAnim = false;
        }
    }

    #endregion

    #region Private Methods
    void Rotation(Vector2 mouseMovement)
    {
        mouseMovement = Vector2.Scale(mouseMovement, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, mouseMovement.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, mouseMovement.y, 1f / smoothing);
        // Replace previous line with : smoothV.y = 0; To remove movement in yAxis

        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -50, 90);
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }

    private void BobHead()
    {
        if (percentage.x == 1 || percentage.y == 1)
        {
            if (percentage.x == 1)
            {
                offset.x = walkCurve.Evaluate(1) * positive.x * multiplierWalk.x;
                time.x = 0;
                percentage.x = 0;
                positive.x = -positive.x;
            }
            if (percentage.y == 1)
            {
                offset.y = walkCurve.Evaluate(1) * positive.x * multiplierWalk.y;
                time.y = 0;
                percentage.y = 0;
                positive.y = -positive.y;
            }
        }
        else
        {
            offset.x = walkCurve.Evaluate(percentage.x) * positive.x * multiplierWalk.x;
            offset.y = walkCurve.Evaluate(percentage.y) * positive.y * multiplierWalk.y;

            time.x = Mathf.Clamp(time.x + Time.deltaTime, 0, loopTime.x);
            time.y = Mathf.Clamp(time.y + Time.deltaTime, 0, loopTime.y);

            percentage.x = time.x / loopTime.x;
            percentage.y = time.y / loopTime.y;
        }
        this.transform.localPosition = new Vector3(origin.x + offset.x, origin.y + offset.y, origin.z);
    }

    private void ReturnToOrigin()
    {
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, origin, percentage.x);
        time.x = Mathf.Clamp(time.x + Time.deltaTime, 0, originTime);
        percentage.x = time.x / originTime;
    }

    void Escape()
    {
        Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Behaviour, IPlClass
{
    #region Private Fields
    #region References
    public PlayerModules Modules { get; set; }
    public void SetClasses(PlayerModules _Modules) { Modules = _Modules; }

    #endregion

    float actualSpeed;
    float time;
    float percentage;
    bool moving;

    Vector3 lastMoveInput;
    #endregion

    #region MonoBehaviour Callbacks

    #endregion

    #region Public Methods
    public void Move(Vector3 movement)
    {
        if(movement != Vector3.zero)
        {
            if (!moving)
            {
                percentage = 0;
                time = 0;
                actualSpeed = 0;
                moving = true;
                Modules.Camera.WalkMovement(true);
            }
            if (actualSpeed != Modules.Player.stats.SpeedMax)
            {
                actualSpeed = Mathf.Lerp(actualSpeed, Modules.Player.stats.SpeedMax, percentage);
                time = Mathf.Clamp(time + Time.deltaTime, 0, Modules.Player.stats.SpeedAcc);
                percentage = time / Modules.Player.stats.SpeedAcc;
            }

            Vector3 direction = (movement.x * Modules.Player.transform.right + movement.z * Modules.Player.transform.forward).normalized;
            Modules.Player.rb.MovePosition(Modules.Player.rb.position + direction * actualSpeed * Time.deltaTime);

            lastMoveInput = movement;
        }
        else
        {
            if (moving)
            {
                percentage = 0;
                time = 0;
                moving = false;
                Modules.Camera.WalkMovement(false);
            }

            if (actualSpeed != 0)
            {
                actualSpeed = Mathf.Lerp(actualSpeed, 0, percentage);
                time = Mathf.Clamp(time + Time.deltaTime, 0, Modules.Player.stats.SpeedDecc);
                percentage = time / Modules.Player.stats.SpeedDecc;

                Vector3 direction = (lastMoveInput.x * Modules.Player.transform.right + lastMoveInput.z * Modules.Player.transform.forward).normalized;
                Modules.Player.rb.MovePosition(Modules.Player.rb.position + direction * actualSpeed * Time.deltaTime);
            }
        }
    }

    public void Action()
    {

    }

    #endregion

    #region Private Methods

    #endregion
}

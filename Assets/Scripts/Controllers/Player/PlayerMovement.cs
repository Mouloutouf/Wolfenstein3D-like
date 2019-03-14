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

    #endregion

    #region MonoBehaviour Callbacks

    #endregion

    #region Public Methods
    public void Move(Vector3 movement)
    {
        if(movement != Vector3.zero)
        {
            //movement = movement.normalized * Modules.Player.stats.Speed;
            Vector3 direction = (movement.x * Modules.Player.transform.right + movement.z * Modules.Player.transform.forward).normalized;
            Modules.Player.rb.MovePosition(Modules.Player.rb.position + direction * Modules.Player.stats.Speed * Time.deltaTime);

            Modules.Camera.WalkMovement(true);
        }
        else
        {

            Modules.Camera.WalkMovement(false);
        }
    }

    #endregion

    #region Private Methods

    #endregion
}

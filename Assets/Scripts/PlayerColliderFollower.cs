using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class PlayerColliderFollower : MonoBehaviour {

    #region Fields

    /// <summary>
    /// The transform of CameraRig.
    /// </summary>
    [SerializeField]
    private Transform CameraRigTrans;

    #endregion Fields

    #region MonoBehaviour

    /// <summary>
    /// Start
    /// </summary>
    void Start () {
        this.PlayerFollower();
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update () {
        this.PlayerFollower();
    }

    #endregion MonoBehaviour

    /// <summary>
    /// Keep the collider follows the player (VR Camera)
    /// </summary>
    private void PlayerFollower()
    {
        Vector3 headPos = InputTracking.GetLocalPosition(VRNode.CenterEye);
        headPos += CameraRigTrans.position;
        headPos.y = 0.0f;
        //Debug.Log(headPos.ToString());
        this.transform.position = headPos;
    }
}

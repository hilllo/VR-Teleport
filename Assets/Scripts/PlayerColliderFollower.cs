using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class PlayerColliderFollower : MonoBehaviour {

    #region Fields

    /// <summary>
    /// The position of CameraRig.
    /// </summary>
    private Vector3 _Offset = new Vector3(0.0f, 0.0f, 0.0f);

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
        headPos += this._Offset;
        headPos.y = 0.0f;
        //Debug.Log(headPos.ToString());
        this.transform.position = headPos;
    }

    /// <summary>
    /// Update Offset (CameraRig position)
    /// </summary>
    public void UpdateOffset(Vector3 newOffset)
    {
        this._Offset = newOffset;
    }
}

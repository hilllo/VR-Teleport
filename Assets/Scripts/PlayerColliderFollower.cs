using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class PlayerColliderFollower : MonoBehaviour {

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
    /// PlayerFollower
    /// </summary>
    private void PlayerFollower()
    {
        Vector3 headPos = InputTracking.GetLocalPosition(VRNode.Head);
        headPos.y = 0.0f;
        //Debug.Log(headPos.ToString());
        this.transform.position = headPos;
    }
}

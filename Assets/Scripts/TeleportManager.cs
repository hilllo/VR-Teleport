using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class TeleportManager : Singleton<TeleportManager> {

    #region Fields

    /// <summary>
    /// The GameObject of PortalEnterPointCube.
    /// </summary>
    [SerializeField]
    private GameObject PortalEnterPointCube;

    /// <summary>
    /// The GameObject of PortalExitPointCube.
    /// </summary>
    [SerializeField]
    private GameObject PortalExitPointCube;

    /// <summary>
    /// The CameraRig.
    /// </summary>
    [SerializeField]
    private Transform CameraRigTrans;

    /// <summary>
    /// The PortalExitPoint.
    /// </summary>
    [SerializeField]
    private Transform PortalExitPointTrans;

    /// <summary>
    /// The PlayerCollider.
    /// </summary>
    private bool HasTeleported = false;


    #endregion Fields

    #region MonoBehaviour

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
        // Change color of points
        this.PortalEnterPointCube.GetComponent<Renderer>().material.color = Color.green;
        this.PortalExitPointCube.GetComponent<Renderer>().material.color = Color.red;
    }

    #endregion MonoBehaviour

    #region Teleport

    /// <summary>
    /// Trigger whenever OnTriggerStay or OnTriggerEnter
    /// </summary>
    public void Teleport()
    {
        if (HasTeleported)
            return;
                
        Vector3 destination = PortalExitPointTrans.position;
        Vector3 offset = CameraRigTrans.position - InputTracking.GetLocalPosition(VRNode.Head);
        destination += offset;
        Debug.Log(offset.ToString());
        destination.y = CameraRigTrans.position.y;

        Debug.Log(string.Format("Portal Destination: {0}", destination.ToString()));
        CameraRigTrans.position = destination;

        HasTeleported = true;
    }

    #endregion Teleport
}

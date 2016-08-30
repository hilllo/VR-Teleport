using UnityEngine;
using UnityEngine.VR;
using System.Collections;
using UnityEngine.UI;

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
    /// The transform of CameraRig.
    /// </summary>
    [SerializeField]
    private Transform CameraRigTrans;

    /// <summary>
    /// The Image of BlockoutPanel.
    /// </summary>
    [SerializeField]
    private Image BlockoutPanelImage;

    /// <summary>
    /// Fading duration.
    /// </summary>
    [SerializeField]
    private float FlashingDuration = 0.5f;

    /// <summary>
    /// Is true when the player has teleported.
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
    public void Teleport(Vector3 destination)
    {
        if (this.HasTeleported)
            return;

        HasTeleported = true;
        SteamVR_Fade.Start(Color.black, 0.0f);
        this.StartCoroutine(this.TeleportCoroutine(destination));
    }


    /// <summary>
    /// Trigger whenever OnTriggerStay or OnTriggerEnter
    /// </summary>
    public IEnumerator TeleportCoroutine(Vector3 destination)
    {
        SteamVR_Fade.Start(Color.white, this.FlashingDuration / 2.0f);
        yield return new WaitForSeconds(this.FlashingDuration / 2.0f);

        Vector3 offset = CameraRigTrans.position - InputTracking.GetLocalPosition(VRNode.Head);
        destination += offset;
        destination.y = CameraRigTrans.position.y;

        //Debug.Log(string.Format("Portal Destination: {0}", destination.ToString()));
        this.CameraRigTrans.position = destination;

        SteamVR_Fade.Start(Color.clear, this.FlashingDuration / 2.0f);
        //this.HasTeleported = false;
    }
    #endregion Teleport
}

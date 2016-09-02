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
    private GameObject _PortalEnterPointCube;

    /// <summary>
    /// The GameObject of PortalExitPointCube.
    /// </summary>
    [SerializeField]
    private GameObject _PortalExitPointCube;

    /// <summary>
    /// The transform of CameraRig.
    /// </summary>
    [SerializeField]
    private Transform _CameraRigTrans;

    /// <summary>
    /// The transform of CameraRig.
    /// </summary>
    [SerializeField]
    private Transform _CameraEyeTrans;

    /// <summary>
    /// PlayerColliderFollower
    /// </summary>
    [SerializeField]
    private PlayerColliderFollower _PlayerColliderFollower;

    /// <summary>
    /// Fading duration.
    /// </summary>
    [SerializeField]
    private float _FlashingDuration = 0.5f;

    /// <summary>
    /// Backfield of IsTeleporting Property. Is true when the player has teleported.
    /// </summary>
    private bool _IsTeleporting = false;

    #endregion Fields

    /// <summary>
    /// Is true when the player has teleported.
    /// </summary>
    public bool IsTeleporting
    {
        get
        {
            return this._IsTeleporting;
        }
    }

    #region Properties



    #endregion Properties

    #region MonoBehaviour

    /// <summary>
    /// Start
    /// </summary>
    void Start()
    {
    }

    #endregion MonoBehaviour

    #region Teleport
    public void Teleport(Vector3 destination)
    {
        this._IsTeleporting = true;
        this.StartCoroutine(this.TeleportCoroutine(destination));
    }


    /// <summary>
    /// Trigger whenever OnTriggerStay or OnTriggerEnter
    /// </summary>
    public IEnumerator TeleportCoroutine(Vector3 destination)
    {
        SteamVR_Fade.Start(Color.white, this._FlashingDuration / 2.0f);
        yield return new WaitForSeconds(this._FlashingDuration / 2.0f);

        Vector3 offset = this._CameraRigTrans.position - this._CameraEyeTrans.position;
        destination += offset;
        destination.y = this._CameraRigTrans.position.y;

        //Debug.Log(string.Format("Portal Destination: {0}", destination.ToString()));
        this._CameraRigTrans.position = destination;
        this._PlayerColliderFollower.UpdateOffset(this._CameraRigTrans.position);

        SteamVR_Fade.Start(Color.clear, this._FlashingDuration / 2.0f);
        this._IsTeleporting = false;
    }
    #endregion Teleport
}

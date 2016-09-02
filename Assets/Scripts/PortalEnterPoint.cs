using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class PortalEnterPoint : MonoBehaviour {

    #region Fields

    /// <summary>
    /// The PlayerCollider.
    /// </summary>
    [SerializeField]
    private Collider _PlayerCollider;

    /// <summary>
    /// The PortalExitPoint.
    /// </summary>
    [SerializeField]
    private Transform _PortalExitPointTrans;

    #endregion Fields

    #region Collide

    /// <summary>
    /// OnTriggerStay
    /// </summary>
    public void OnTriggerStay(Collider other)
    {
        if (other == null && TeleportManager.Instance.IsTeleporting)
            return;

        //Debug.Log(string.Format("Collider: {0}{1}", other.gameObject.name.ToString(),other.gameObject.GetInstanceID().ToString()));
        if (other == this._PlayerCollider)
        {
            Debug.Log(string.Format("Start teleporting to {0}", this._PortalExitPointTrans.position.ToString()));
            TeleportManager.Instance.Teleport(this._PortalExitPointTrans.position);
        }
    }

    #endregion Collide
}

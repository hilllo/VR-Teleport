using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class PortalEnterPoint : MonoBehaviour {

    #region Fields

    /// <summary>
    /// The PlayerCollider.
    /// </summary>
    [SerializeField]
    private Collider PlayerCollider;

    /// <summary>
    /// The PortalExitPoint.
    /// </summary>
    [SerializeField]
    private Transform PortalExitPointTrans;

    #endregion Fields

    #region Collide

    /// <summary>
    /// OnTriggerEnter
    /// </summary>
    public void OnTriggerEnter(Collider other)
    {
        if (other == this.PlayerCollider)
            TeleportManager.Instance.Teleport(PortalExitPointTrans.position);

        Debug.Log(other.gameObject.name.ToString());
    }

    /// <summary>
    /// OnTriggerStay
    /// </summary>
    public void OnTriggerStay(Collider other)
    {
        if (other == this.PlayerCollider)
            TeleportManager.Instance.Teleport(PortalExitPointTrans.position);

        Debug.Log(other.gameObject.name.ToString());
    }

    #endregion Collide
}

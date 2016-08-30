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

    #endregion Fields

    #region Collide

    /// <summary>
    /// OnTriggerEnter
    /// </summary>
    public void OnTriggerEnter(Collider other)
    {
        if (other == PlayerCollider)
            TeleportManager.Instance.Teleport();
    }

    /// <summary>
    /// OnTriggerStay
    /// </summary>
    public void OnTriggerStay(Collider other)
    {
        if (other == PlayerCollider)
            TeleportManager.Instance.Teleport();
    }

    #endregion Collide
}

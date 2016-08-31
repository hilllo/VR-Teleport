using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;

public class WandController : MonoBehaviour {

    #region Fields

    /// <summary>
    /// The SteamVR_TrackedObject.
    /// </summary>
    [SerializeField]
    private SteamVR_TrackedObject _SteamVR_TrackedObject;

    /// <summary>
    /// The Ojbect that is being hovered.
    /// </summary>
    private HashSet<InteractableObject> _ObjectsHoveringOver = new HashSet<InteractableObject>();

    /// <summary>
    /// The Ojbect that is the closest can be interacting.
    /// </summary>
    private InteractableObject _ClosestObject;
    private InteractableObject _InteractingObject;

    #endregion Fields

    #region Properties

    /// <summary>
    /// The index of the current controller
    /// </summary>
    private SteamVR_Controller.Device _ControllerIndex
    {
        get
        {
            return SteamVR_Controller.Input((int)this._SteamVR_TrackedObject.index);
        }
    }

    #endregion Properties

    #region MonoBehaviour

    /// <summary>
    /// Start
    /// </summary>
    void Start () {
	
	}

    /// <summary>
    /// Update
    /// </summary>
    void Update () {
	    // Make sure there's controller
        if(this._ControllerIndex == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        if (this._ControllerIndex.GetPressDown(EVRButtonId.k_EButton_Grip))
        {
            this.GetInteractingObject();
            //Debug.Log(string.Format("IsInteracting with {0}", this._InteractingObject.name));
        }

        if (this._ControllerIndex.GetPressUp(EVRButtonId.k_EButton_Grip) && this._InteractingObject != null)
        {
            this._InteractingObject.EndInteration(this);
            this._InteractingObject = null;
        }

    }

    #endregion MonoBehaviour

    #region Trigger

    /// <summary>
    /// The index of the current controller
    /// </summary>
    public void OnTriggerEnter(Collider collider)
    {
        InteractableObject collidedObject = collider.GetComponent<InteractableObject>();
        if (collidedObject)
        {
            this._ObjectsHoveringOver.Add(collidedObject);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        InteractableObject collidedObject = collider.GetComponent<InteractableObject>();
        if (collidedObject)
        {
            this._ObjectsHoveringOver.Remove(collidedObject);
        }
    }

    #endregion Trigger

    #region Interaction

    /// <summary>
    /// Get closest object for interaction
    /// </summary>
    private void GetInteractingObject()
    {
        float minDistance = float.MaxValue;

        float distance;
        foreach(InteractableObject obj in this._ObjectsHoveringOver)
        {
            distance = (obj.transform.position - transform.position).sqrMagnitude;

            if(distance < minDistance)
            {
                this._ClosestObject = obj;
                minDistance = distance;
            }
        }

        this._InteractingObject = this._ClosestObject;

        if(this._InteractingObject != null)
        {
            if (this._InteractingObject.IsInteracting)
                this._InteractingObject.EndInteration(this);

            this._InteractingObject.StartInteraction(this);
        }
    }

    #endregion Interaction

}

using UnityEngine;
using System.Collections;

public class PickableObject : InteractableObject {

    #region Fields

    /// <summary>
    /// VelocityFactor, affects the feeling of picking
    /// </summary>
    [SerializeField]
    private float _VelocityFactor = 20000f;

    /// <summary>
    /// RotationFactor, affects the feeling of picking
    /// </summary>
    [SerializeField]
    private float _RotationFactor = 400f;

    private Rigidbody _Rigidbody;

    #endregion Fields

    #region MonoBehaviour

    /// <summary>
    /// OnStart
    /// </summary>
    protected override void OnStart()
    {
        base.OnStart();
        this._Rigidbody = this.GetComponent<Rigidbody>();

        if (this._Rigidbody.mass <= 0)
            throw new System.ArgumentException(string.Format("Expected {0}.Rigidbody.mass > 0 to get the correct picking effect.", this.gameObject.name));

        this._VelocityFactor /= this._Rigidbody.mass;
        this._RotationFactor /= this._Rigidbody.mass;
    }

    /// <summary>
    /// Update
    /// </summary>
    void Update () {
        if (this.AttachedWand && this.IsInteracting)
        {
            Vector3 posDelta = this.AttachedWand.transform.position - this.InteractionPoint.position;
            this._Rigidbody.velocity = posDelta * this._VelocityFactor * Time.fixedDeltaTime;

            Quaternion rotationDelta = this.AttachedWand.transform.rotation * Quaternion.Inverse(this.InteractionPoint.rotation);

            float angle;
            Vector3 axis;
            rotationDelta.ToAngleAxis(out angle, out axis);
            if (angle > 180)
                angle -= 360;

            this._Rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * this._RotationFactor;
        }
    }

    #endregion MonoBehaviour
}

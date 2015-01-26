using UnityEngine;
using BehaviorDesigner.Runtime;

[System.Serializable]
public class SharedPlant : SharedVariable
{
	public Plant Value { get { return mValue; } set { mValue = value; } }
	[SerializeField]
    private Plant mValue;

	public override object GetValue() { return mValue; }
    public override void SetValue(object value) { mValue = (Plant)value; }

	public override string ToString() { return mValue == null ? "null" : mValue.ToString(); }
    public static implicit operator SharedPlant(DikDik value) { var sharedVariable = new SharedPlant(); sharedVariable.SetValue(value); return sharedVariable; }
}

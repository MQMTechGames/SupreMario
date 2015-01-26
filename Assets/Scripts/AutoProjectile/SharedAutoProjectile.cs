using UnityEngine;
using BehaviorDesigner.Runtime;

[System.Serializable]
public class SharedAutoProjectile : SharedVariable
{
	public AutoProjectile Value { get { return mValue; } set { mValue = value; } }
	[SerializeField]
    private AutoProjectile mValue;

	public override object GetValue() { return mValue; }
    public override void SetValue(object value) { mValue = (AutoProjectile)value; }

	public override string ToString() { return mValue == null ? "null" : mValue.ToString(); }
    public static implicit operator SharedAutoProjectile(AutoProjectile value) { var sharedVariable = new SharedAutoProjectile(); sharedVariable.SetValue(value); return sharedVariable; }
}

using UnityEngine;
using BehaviorDesigner.Runtime;

[System.Serializable]
public class SharedDikDik : SharedVariable
{
	public DikDik Value { get { return mValue; } set { mValue = value; } }
	[SerializeField]
    private DikDik mValue;

	public override object GetValue() { return mValue; }
    public override void SetValue(object value) { mValue = (DikDik)value; }

	public override string ToString() { return mValue == null ? "null" : mValue.ToString(); }
    public static implicit operator SharedDikDik(DikDik value) { var sharedVariable = new SharedDikDik(); sharedVariable.SetValue(value); return sharedVariable; }
}

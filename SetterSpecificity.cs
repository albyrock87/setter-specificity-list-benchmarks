using System.Runtime.CompilerServices;

namespace SetterSpecificityListPerfBenchmarks;

internal readonly struct SetterSpecificity : IComparable<SetterSpecificity>, IEquatable<SetterSpecificity>
{
	readonly ulong _value;
	
	public static readonly SetterSpecificity Spec0 = new SetterSpecificity(0);
	public static readonly SetterSpecificity Spec1 = new SetterSpecificity(1);
	public static readonly SetterSpecificity Spec2 = new SetterSpecificity(2);
	public static readonly SetterSpecificity Spec3 = new SetterSpecificity(3);
	public static readonly SetterSpecificity Spec4 = new SetterSpecificity(4);
	public static readonly SetterSpecificity Spec5 = new SetterSpecificity(5);
	public static readonly SetterSpecificity Spec6 = new SetterSpecificity(6);
	
	public SetterSpecificity(ulong value)
	{
		_value = value;
	}

	public int CompareTo(SetterSpecificity other) => _value.CompareTo(other._value);
	public override bool Equals(object? obj) => obj is SetterSpecificity s && Equals(s);
	public override int GetHashCode() => _value.GetHashCode();

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(SetterSpecificity other) => _value == other._value;

	public static bool operator <(SetterSpecificity left, SetterSpecificity right) => left._value < right._value;
	public static bool operator >(SetterSpecificity left, SetterSpecificity right) => left._value > right._value;
	public static bool operator >=(SetterSpecificity left, SetterSpecificity right) => left._value >= right._value;
	public static bool operator <=(SetterSpecificity left, SetterSpecificity right) => left._value <= right._value;
	public static bool operator ==(SetterSpecificity left, SetterSpecificity right) => left.Equals(right);
	public static bool operator !=(SetterSpecificity left, SetterSpecificity right) => !left.Equals(right);
}
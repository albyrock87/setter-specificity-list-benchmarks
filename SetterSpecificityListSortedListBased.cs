using System.Runtime.CompilerServices;

namespace SetterSpecificityListPerfBenchmarks;

internal class SetterSpecificityListSortedListBased : SetterSpecificityListSortedListBased<object>
{
    public SetterSpecificityListSortedListBased()
    {
    }

    public SetterSpecificityListSortedListBased(int capacity) : base(capacity)
    {
    }
}

/// <summary>
/// Stores values for a property with different specificities.
/// </summary>
internal class SetterSpecificityListSortedListBased<T> : SortedList<SetterSpecificity, T>
{
    public SetterSpecificityListSortedListBased()
    {
    }

    public SetterSpecificityListSortedListBased(int capacity) : base(capacity)
    {
    }
    
    /// <summary>
    /// Returns what the value would be if the current value was removed
    /// </summary>
    public T GetClearedValue()
    {
        var clearedValueIndex = Count - 2;
        return clearedValueIndex >= 0 ? GetSpecificityValueAt(clearedValueIndex) : default!;
    }
		
    /// <summary>
    /// Returns what the SetterSpecificity would be if the current value was removed
    /// </summary>
    public SetterSpecificity GetClearedSpecificity()
    {
        var clearedValueIndex = Count - 2;
        return clearedValueIndex >= 0 ? GetSpecificityAt(clearedValueIndex) : default!;
    }
		
    /// <summary>
    /// Gets the highest specificity
    /// </summary>
    /// <returns></returns>
    public SetterSpecificity GetSpecificity()
    {
        var count = Count;
        return count == 0 ? default : GetSpecificityAt(count - 1);
    }
		
    /// <summary>
    /// Gets the value for the highest specificity
    /// </summary>
    /// <returns></returns>
    public T GetValue()
    {
        var count = Count;
        return count == 0 ? default! : GetSpecificityValueAt(count - 1);
    }

    /// <summary>
    /// Gets the highest specificity and value
    /// </summary>
    /// <returns></returns>
    public KeyValuePair<SetterSpecificity, T> GetSpecificityAndValue()
    {
        var count = Count;

        if (count == 0)
        {
            return default;
        }
			
        return new KeyValuePair<SetterSpecificity, T>(GetSpecificityAt(count - 1), GetSpecificityValueAt(count - 1));
    }
		
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    SetterSpecificity GetSpecificityAt(int index)
    {
#if NETSTANDARD
			return Keys[index];
#else
        return GetKeyAtIndex(index);
#endif
    }
		
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    T GetSpecificityValueAt(int index)
    {
#if NETSTANDARD
			return Values[index];
#else
        return GetValueAtIndex(index);
#endif
    }

}
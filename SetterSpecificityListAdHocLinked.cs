#nullable disable
using System.Runtime.CompilerServices;

namespace SetterSpecificityListPerfBenchmarks;

internal class SetterSpecificityListAdHocLinked : SetterSpecificityListAdHocLinked<object>
{
}

/// <summary>
/// Stores values for a property with different specificities.
/// </summary>
internal class SetterSpecificityListAdHocLinked<T> where T : class
{
    private class ValueNode
    {
        public ValueNode Next;
        public SetterSpecificity Specificity;
        public T Value;
    }

    ValueNode _first;
    ValueNode _current;
    ValueNode _cleared;
    int _count;

    public int Count => _count;

    public T this[SetterSpecificity key]
    {
        set => SetValue(key, value);
        get => GetValue(key);
    }

    /// <summary>
    /// Gets the highest specificity
    /// </summary>
    /// <returns></returns>
    public SetterSpecificity GetSpecificity()
    {
        return _current?.Specificity ?? default;
    }

    /// <summary>
    /// Gets the value for the highest specificity
    /// </summary>
    /// <returns></returns>
    public T GetValue()
    {
        return _current?.Value;
    }

    /// <summary>
    /// Returns what the value would be if the current value was removed
    /// </summary>
    public T GetClearedValue()
    {
        return _cleared?.Value;
    }

    /// <summary>
    /// Returns what the SetterSpecificity would be if the current value was removed
    /// </summary>
    public SetterSpecificity GetClearedSpecificity()
    {
        return _cleared?.Specificity ?? default;
    }

    /// <summary>
    /// Gets the highest specificity and value
    /// </summary>
    /// <returns></returns>
    public KeyValuePair<SetterSpecificity, T> GetSpecificityAndValue()
    {
        var current = _current;
        return current == null
            ? default
            : new KeyValuePair<SetterSpecificity, T>(current.Specificity, current.Value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    void SetValue(SetterSpecificity key, T value)
    {
        // nothing here, just set the value
        var node = _first;
        if (node == null)
        {
            node = new ValueNode { Specificity = key, Value = value };
            _first = node;
            _current = node;
            ++_count;
            return;
        }

        var lastNode = node;
        while (node != null)
        {
            var indexSpecificity = node.Specificity;
            if (indexSpecificity == key)
            {
                node.Value = value;
                return;
            }

            lastNode = node;
            node = node.Next;
        }

        node = new ValueNode { Specificity = key, Value = value };
        lastNode.Next = node;

        if (_current.Specificity < key)
        {
            _cleared = _current;
            _current = node;
        }
        else if (_cleared != null && _cleared.Specificity < key)
        {
            _cleared = node;
        }

        ++_count;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    T GetValue(SetterSpecificity key)
    {
        var node = _first;
        while (node != null)
        {
            if (node.Specificity == key) return node.Value;
            node = node.Next;
        }

        return default;
    }

    public void Remove(SetterSpecificity key)
    {
        var node = _first;
        ValueNode lastNode = null;
        ValueNode current = null;
        ValueNode cleared = null;
        while (node != null)
        {
            var indexSpecificity = node.Specificity;

            if (indexSpecificity == key)
            {
                if (lastNode == null)
                {
                    _first = node.Next;
                }
                else
                {
                    lastNode.Next = node.Next;
                }

                --_count;
            }
            else if (current == null || current.Specificity < indexSpecificity)
            {
                cleared = current;
                current = node;
            }

            lastNode = node;
            node = node.Next;
        }

        _current = current;
        _cleared = cleared;
    }
}
namespace SetterSpecificityListPerfBenchmarks;

internal class SetterSpecificityListListBased : SetterSpecificityListListBased<object>
{
    public SetterSpecificityListListBased(int capacity = 0) : base(capacity)
    {
    }
}

internal class SetterSpecificityListListBased<T> : List<KeyValuePair<SetterSpecificity, T>>
{
    private int _current = -1;

    public T this[SetterSpecificity specificity]
    {
        set => SetValue(specificity, value);
    }

    public SetterSpecificityListListBased(int capacity = 0) : base(capacity)
    {
    }

    public object? GetValue()
    {
        return _current >= 0 ? this[_current].Value : default!;
    }
    
    public KeyValuePair<SetterSpecificity, T> GetSpecificityAndValue()
    {
        return _current < 0 ? default : this[_current];
    }
    
    public void SetValue(SetterSpecificity specificity, T value)
    {
        var kv = new KeyValuePair<SetterSpecificity, T>(specificity, value);
        
        var hasGreaterSpecificity = true;
        var count = Count;
        for (var index = count - 1; index > 0; --index)
        {
            var indexSpecificity = this[index].Key;
            if (indexSpecificity == specificity)
            {
                this[index] = kv;
                return;
            }
            
            if (indexSpecificity > specificity)
            {
                hasGreaterSpecificity = false;
            }
        }
        
        Add(kv);
        if (hasGreaterSpecificity)
        {
            _current = count;
        }
    }

    public void Remove(SetterSpecificity specificity)
    {
        var count = Count;
        
        if (count == 0) return;

        var index = count - 1;
        var current = -1;
        var highestSpecificity = default(SetterSpecificity);
        for (; index > 0; --index)
        {
            var indexSpecificity = this[index].Key;
            if (indexSpecificity == specificity)
            {
                RemoveAt(index);
                continue;
            }
            if (indexSpecificity >= highestSpecificity)
            {
                highestSpecificity = indexSpecificity;
                current = index;
            }
        }

        _current = current;
    }
}
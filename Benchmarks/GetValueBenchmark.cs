using BenchmarkDotNet.Attributes;

namespace SetterSpecificityListPerfBenchmarks.Benchmarks;

public class GetValueBenchmark
{
    private const int Iterations = 10000;
    
    [Benchmark(Baseline = true)]
    public void FieldBased()
    {
        var list = new SetterSpecificityListFieldBased();
        list[SetterSpecificity.Spec0] = null!;
        
        for (int i = 0; i < Iterations; i++)
        {
            _ = list.GetSpecificityAndValue().Value;
        }
    }
    
    [Benchmark]
    public void SortedListBased()
    {
        var list = new SetterSpecificityListSortedListBased();
        list[SetterSpecificity.Spec0] = null!;
        
        for (int i = 0; i < Iterations; i++)
        {
            _ = list.GetValue();
        }
    }
    
    [Benchmark]
    public void SortedListBasedDefaultCapacity()
    {
        var list = new SetterSpecificityListSortedListBased(4);
        list[SetterSpecificity.Spec0] = null!;
        
        for (int i = 0; i < Iterations; i++)
        {
            _ = list.GetValue();
        }
    }
    
    [Benchmark]
    public void ListBasedDefaultCapacity()
    {
        var list = new SetterSpecificityListListBased(4);
        list[SetterSpecificity.Spec0] = null!;
        
        for (int i = 0; i < Iterations; i++)
        {
            _ = list.GetValue();
        }
    }
    
    [Benchmark]
    public void AdHoc()
    {
        var list = new SetterSpecificityListAdHoc();
        list[SetterSpecificity.Spec0] = null!;
        
        for (int i = 0; i < Iterations; i++)
        {
            _ = list.GetValue();
        }
    }
    
    [Benchmark]
    public void AdHocLinked()
    {
        var list = new SetterSpecificityListAdHocLinked();
        list[SetterSpecificity.Spec0] = null!;
        
        for (int i = 0; i < Iterations; i++)
        {
            _ = list.GetValue();
        }
    }
}
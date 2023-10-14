using BenchmarkDotNet.Attributes;

namespace SetterSpecificityListPerfBenchmarks.Benchmarks;

public class AddValuesBenchmark
{
    private const int Iterations = 10000;
    
    [Benchmark(Baseline = true)]
    public void FieldBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListFieldBased();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec2] = null!;
            list[SetterSpecificity.Spec3] = null!;
        }
    }
    
    [Benchmark]
    public void SortedListBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListSortedListBased();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec2] = null!;
            list[SetterSpecificity.Spec3] = null!;
        }
    }
    
    [Benchmark]
    public void SortedListBasedDefaultCapacity()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListSortedListBased(4);
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec2] = null!;
            list[SetterSpecificity.Spec3] = null!;
        }
    }
    
    [Benchmark]
    public void ListBasedDefaultCapacity()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListListBased(4);
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec2] = null!;
            list[SetterSpecificity.Spec3] = null!;
        }
    }
    
    [Benchmark]
    public void AdHoc()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListAdHoc();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec2] = null!;
            list[SetterSpecificity.Spec3] = null!;
        }
    }
    
    [Benchmark]
    public void AdHocLinked()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListAdHocLinked();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec2] = null!;
            list[SetterSpecificity.Spec3] = null!;
        }
    }
}
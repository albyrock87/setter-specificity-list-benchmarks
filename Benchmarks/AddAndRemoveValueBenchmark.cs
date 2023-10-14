using BenchmarkDotNet.Attributes;

namespace SetterSpecificityListPerfBenchmarks.Benchmarks;

public class AddAndRemoveValueBenchmark
{
    private const int Iterations = 10000;
    
    [Benchmark(Baseline = true)]
    public void FieldBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListFieldBased();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec1] = null!;
            list[SetterSpecificity.Spec5] = null!;
            list[SetterSpecificity.Spec3] = null!;
            list.Remove(SetterSpecificity.Spec1);
            list.Remove(SetterSpecificity.Spec3);
        }
    }
    
    [Benchmark]
    public void SortedListBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListSortedListBased();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec1] = null!;
            list[SetterSpecificity.Spec5] = null!;
            list[SetterSpecificity.Spec3] = null!;
            list.Remove(SetterSpecificity.Spec1);
            list.Remove(SetterSpecificity.Spec3);
        }
    }
    
    [Benchmark]
    public void SortedListBasedDefaultCapacity()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListSortedListBased(4);
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec1] = null!;
            list[SetterSpecificity.Spec5] = null!;
            list[SetterSpecificity.Spec3] = null!;
            list.Remove(SetterSpecificity.Spec1);
            list.Remove(SetterSpecificity.Spec3);
        }
    }
    
    [Benchmark]
    public void ListBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListListBased(4);
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec1] = null!;
            list[SetterSpecificity.Spec5] = null!;
            list[SetterSpecificity.Spec3] = null!;
            list.Remove(SetterSpecificity.Spec1);
            list.Remove(SetterSpecificity.Spec3);
        }
    }
    
    [Benchmark]
    public void AdHoc()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListAdHoc();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec1] = null!;
            list[SetterSpecificity.Spec5] = null!;
            list[SetterSpecificity.Spec3] = null!;
            list.Remove(SetterSpecificity.Spec1);
            list.Remove(SetterSpecificity.Spec3);
        }
    }
    
    [Benchmark]
    public void AdHocLinked()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListAdHocLinked();
            list[SetterSpecificity.Spec0] = null!;
            list[SetterSpecificity.Spec1] = null!;
            list[SetterSpecificity.Spec5] = null!;
            list[SetterSpecificity.Spec3] = null!;
            list.Remove(SetterSpecificity.Spec1);
            list.Remove(SetterSpecificity.Spec3);
        }
    }
}
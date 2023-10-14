using BenchmarkDotNet.Attributes;

namespace SetterSpecificityListPerfBenchmarks.Benchmarks;

public class AddAndRemoveManyValuesBenchmark
{
    private const int Iterations = 10000;
    
    [Benchmark(Baseline = true)]
    public void FieldBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListFieldBased();
            list[SetterSpecificity.Spec0] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec5] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec3);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec6] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec4] = null!;
        }
    }
    
    [Benchmark]
    public void SortedListBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListSortedListBased();
            list[SetterSpecificity.Spec0] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec5] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec3);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec6] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec4] = null!;
        }
    }
    
    [Benchmark]
    public void SortedListBasedDefaultCapacity()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListSortedListBased(4);
            list[SetterSpecificity.Spec0] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec5] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec3);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec6] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec4] = null!;
        }
    }
    
    [Benchmark]
    public void ListBased()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListListBased(4);
            list[SetterSpecificity.Spec0] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec5] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec3);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec6] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec4] = null!;
        }
    }
    
    [Benchmark]
    public void AdHoc()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListAdHoc();
            list[SetterSpecificity.Spec0] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec5] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec3);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec6] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec4] = null!;
        }
    }
    
    [Benchmark]
    public void AdHocLinked()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var list = new SetterSpecificityListAdHocLinked();
            list[SetterSpecificity.Spec0] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec5] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec3);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec6] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec3] = null!;
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec1] = null!;
            list.GetSpecificityAndValue();
            list.Remove(SetterSpecificity.Spec1);
            list.GetSpecificityAndValue();
            list[SetterSpecificity.Spec4] = null!;
        }
    }
}
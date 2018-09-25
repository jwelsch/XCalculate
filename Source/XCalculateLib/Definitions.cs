namespace XCalculateLib
{
    public delegate bool ValueValidator<T>(T value);

    public delegate void PhaseHandler(IPhase phase);
}
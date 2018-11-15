namespace XCalculateLib
{
    public interface IPhaseTransition
    {
        int Id
        {
            get;
        }

        IValue[] Inputs
        {
            get;
        }
    }
}

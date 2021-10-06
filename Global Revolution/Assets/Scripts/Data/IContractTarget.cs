using Assets.Scripts.World;

namespace Assets.Scripts.Data
{
    public interface IContractTarget
    {
        string TargetName { get; }
        Corporation TargetOwner { get; }
    }
}

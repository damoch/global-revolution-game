using Assets.Scripts.Data.Enum;
using System;

namespace Assets.Scripts.Data
{
    public class Contract
    {
        public IContractTarget Target { get; set; }
        public int Reward { get; set; }
        public int Peanalty { get; set; }
        public DateTime Deadline { get; set; }
        public ContractType ContractType { get; set; }
    }
}

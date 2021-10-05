using Assets.Scripts.World;
using System;
using UnityEngine;

namespace Assets.Scripts.Data.Factories
{
    public class ContractFactory : MonoBehaviour
    {
        private static Rules _rules;
        public static Contract CreateContractFor(Corporation corporation)
        {
            var contract = new Contract();

            //contract.Target

            return contract;
        }

        internal void SetRules(Rules rules)
        {
            _rules = rules;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class Corporation : MonoBehaviour
    {
        public string Name;

        public List<Corporation> HostileCorporations;
        public List<Corporation> AlliedCorporations;

        public IndustryType[] IndustryTypes;
    }
}

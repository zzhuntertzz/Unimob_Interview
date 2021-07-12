using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interview
{
    [CreateAssetMenu(fileName = "Data", order = 0, menuName = "Data/Data")]
    public partial class Data : ScriptableObject
    {
        private static Data i;
        public static Data I
        {
            get
            {
                if (i == null) i = Resources.Load<Data>(nameof(Data));
                return i;
            }
        }
    }
}
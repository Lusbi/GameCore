using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Dialogue
{
    [CreateAssetMenu(menuName = "DialogueSystem/PN Create")]
    public class PNRefer : ScriptableObject
    {
        [HideInInspector] public List<ReferInfo> referInfos = new List<ReferInfo>();
        private Dictionary<int, ReferInfo> m_referInfos = new Dictionary<int, ReferInfo>();

        public string GetValue(int id)
        {
            if (m_referInfos.Count == 0)
            {
                Initilization();
            }

            if (m_referInfos.ContainsKey(id))
            {
                return m_referInfos[id].value;
            }

            return id.ToString();
        }

        private void Initilization()
        {
            m_referInfos.Clear();
            for (int i = 0 , Count = referInfos.Count; i < Count; i ++)
            {
                m_referInfos.Add(referInfos[i].id, referInfos[i]);
            }
        }
    }
}
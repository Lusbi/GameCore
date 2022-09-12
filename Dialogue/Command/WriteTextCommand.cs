using UnityEngine;

namespace GameCore.Dialogue
{
    public class WriteTextCommand : ICommand
    {
        private const string BOLD_FORMAT = "<B>{0}</B>";
        private const string ITALIC_FORMAT = "<I>{0}</I>";
        private const string COLOR_FORMAT = "{0}</COLOR>";

        private string m_parameterValue;
        private int m_currentIndex = 0;
        private float m_lastTime = 0;

        private int m_paremterLength;
        public bool isDoen
        {
            get
            {
                return m_currentIndex == m_paremterLength;
            }
        }
        public void Do(ref GroupVariable groupVariable)
        {
            if (Time.time - m_lastTime > groupVariable.durationTime && isDoen == false)
            {
                m_currentIndex+= 1;
                string writeText = m_parameterValue.Substring(0, m_currentIndex);

                SetFormat(ref groupVariable , writeText);
                m_lastTime = Time.time;

            }
            groupVariable.currentCommandEnd = isDoen;
        }

        public void LoadParameter(string parameterValue)
        {
            Reset();
            m_parameterValue = parameterValue;
            m_paremterLength = m_parameterValue.Length;
        }

        private void Reset()
        {
            m_parameterValue = string.Empty;
            m_currentIndex = 0;
            m_lastTime = 0;
            m_paremterLength = 0;
        }

        private void SetFormat(ref GroupVariable groupVariable , string value)
        {
            if (groupVariable.isBlod)
            {
                value = string.Format(BOLD_FORMAT, value);
            }
            if (groupVariable.isItalic)
            {
                value = string.Format(ITALIC_FORMAT, value);
            }
            if (groupVariable.isColor)
            {
                value = string.Format(COLOR_FORMAT, value);
            }
            groupVariable.cacheDialogue = value;
        }
    }
}
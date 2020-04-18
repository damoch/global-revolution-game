using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameLogController : MonoBehaviour
    {
        private Text _logtext;

        [SerializeField]
        private int _noOfLogLines;

        private string[] _logLines;
        private int _currentLine;

        private void Start()
        {
            _logtext = GetComponent<Text>();
            _logLines = new string[_noOfLogLines];
            _currentLine = 0;
        }

        public void LogMessage(string message)
        {
            if (_currentLine >= _noOfLogLines)
            {
                for (var i = 1; i < _logLines.Length; i++)
                {
                    _logLines[i - 1] = _logLines[i];
                }
                _currentLine--;
            }
            _logLines[_currentLine] = message + System.Environment.NewLine;
            _currentLine++; 
            _logtext.text = "";

            for(var i = 0; i < _logLines.Length; i++)
            {
                _logtext.text += _logLines[i];
            }
        }
    }
}
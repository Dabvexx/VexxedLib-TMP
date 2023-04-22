using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VexxedLib.TMP
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TypeWriter : MonoBehaviour
    {
        #region Variables
        // Variables.
        private TextMeshProUGUI GUIText;
        private string text;

        [SerializeField] bool runOnEnable;
        [SerializeField] float waitTime;
        #endregion

        #region Unity Methods

        private void Awake()
        {
            GUIText = GetComponent<TextMeshProUGUI>();
            text = GUIText.text;
            ClearText();
        }

        private void OnEnable()
        {
            if (runOnEnable)
            {
                StartTypeWrite();
            }
        }

        #endregion

        #region Private Methods
        // Private Methods.
        private IEnumerator TypeWrite(string text, float waitTime)
        {
            foreach (char c in text)
            {
                // Use tmp textinfo wordinfo to modify vertex on letters
                GUIText.text = GUIText.text + c;
                yield return new WaitForSeconds(waitTime);
            }
        }
        #endregion

        #region Public Methods
        // Public Methods.
        // Maybe make a callback for a callback every time a character is typed.
        // TODO? ^
        public void StartTypeWrite()
        {
            var coroutine = TypeWrite(text, waitTime);
            StartCoroutine(coroutine);
        }
        public void StartTypeWrite(string text, float waitTime)
        {
            var coroutine = TypeWrite(text, waitTime);
            StartCoroutine(coroutine);
        }
        public void StartTypeWrite(string text)
        {
            var coroutine = TypeWrite(text, waitTime);
            StartCoroutine(coroutine);
        }
        public void StartTypeWrite(float waitTime)
        {
            var coroutine = TypeWrite(text, waitTime);
            StartCoroutine(coroutine);
        }

        public void ClearText()
        {
            GUIText.text = "";
        }
        #endregion
    }
}
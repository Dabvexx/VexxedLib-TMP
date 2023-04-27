using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace VexxedLib.TMP
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(AudioSource))]
    public class TypeWriterAudio : MonoBehaviour
    {
        #region Variables
        // Variables.
        private TextMeshProUGUI GUIText;
        private string text;

        [SerializeField] bool runOnEnable;
        [SerializeField] AudioClip[] clips;
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
        private IEnumerator TypeWrite(string text, AudioClip[] clips)
        {
            foreach (char c in text)
            {
                var clip = clips[Random.Range(0, clips.Length - 1)];

                GUIText.text = GUIText.text + c;

                yield return new WaitForSeconds(clip.length);
            }
        }
        #endregion

        #region Public Methods
        // Public Methods.
        // Maybe make a callback for a callback every time a character is typed.
        // TODO? ^
        public void StartTypeWrite()
        {
            var coroutine = TypeWrite(text, clips);
            StartCoroutine(coroutine);
        }
        public void StartTypeWrite(string text, AudioClip clip)
        {
            var coroutine = TypeWrite(text, new AudioClip[] { clip });
            StartCoroutine(coroutine);
        }
        public void StartTypeWrite(string text)
        {
            var coroutine = TypeWrite(text, clips);
            StartCoroutine(coroutine);
        }
        public void StartTypeWrite(AudioClip clip)
        {
            var coroutine = TypeWrite(text, new AudioClip[] { clip });
            StartCoroutine(coroutine);
        }
        public void StartTypeWrite(string text, AudioClip[] clips)
        {
            var coroutine = TypeWrite(text, clips);
            StartCoroutine(coroutine);
        }

        public void StartTypeWrite(AudioClip[] clips)
        {
            var coroutine = TypeWrite(text, clips);
            StartCoroutine(coroutine);
        }

        public void ClearText()
        {
            GUIText.text = "";
        }
        #endregion
    }
}
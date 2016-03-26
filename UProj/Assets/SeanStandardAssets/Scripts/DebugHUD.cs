using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace SeanStandardScript
{
    public class DebugHUD : SingletonMonoBehaviour<DebugHUD>
    {
        [SerializeField]
        private CanvasGroup ContainingDebugCanvasGroup;
        [SerializeField]
        private KeyCode ToggleOnOffKey = KeyCode.BackQuote;

        private List<Coroutine> LogLineCoroutines;

        protected override void Awake()
        {
            base.Awake();
            LogLineCoroutines = new List<Coroutine>(transform.childCount);
            for (int i = 0; i < transform.childCount; i++)
            {
                LogLineCoroutines.Add(null);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(ToggleOnOffKey))
            {
                ToggleOnOff();
            }
        }

        public void ToggleOnOff()
        {
            if (Math.Abs(ContainingDebugCanvasGroup.alpha - 1f) < 0.1f)
                ContainingDebugCanvasGroup.Hide();
            else if (Math.Abs(ContainingDebugCanvasGroup.alpha) < 0.1f)
                ContainingDebugCanvasGroup.Show();
        }

        public void ClearLog()
        {
            var logLines = GetComponentsInChildren<Text>();
            for (var i = 0; i < logLines.Length; i++)
            {
                logLines[i].text = string.Empty;
            }
            for (var i = 0; i < LogLineCoroutines.Count; i++)
            {
                if (LogLineCoroutines[i] != null)
                {
                    StopCoroutine(LogLineCoroutines[i]);
                    LogLineCoroutines[i] = null;
                }
            }
        }

        public void Log(string log, int lineNum = -1, float lifeTime = 0.0f)
        {
            if (lineNum >= transform.childCount)
            {
                Debug.LogError("Log line number is out of bounds, there are only lines 0 through " +
                               (transform.childCount - 1));
                return;
            }
            if (lineNum == -1)
            {
                lineNum = GetFreeLogLineNum();
            }
            var logLineTrans = transform.GetChild(lineNum);
            var logLineText = logLineTrans.GetComponent<Text>();
            logLineText.text = log;
            if (LogLineCoroutines[lineNum] != null)
            {
                StopCoroutine(LogLineCoroutines[lineNum]);
                LogLineCoroutines[lineNum] = null;
            }
            if (lifeTime > 0.0f)
            {
                var c = StartCoroutine("DestroyLogLine", new object[] {lifeTime, logLineText, lineNum});
                LogLineCoroutines[lineNum] = c;
            }
        }

        private int GetFreeLogLineNum()
        {
            var logLineTexts = GetComponentsInChildren<Text>();
            for (int i = 0; i < logLineTexts.Length; i++)
            {
                if (logLineTexts[i].text == string.Empty)
                {
                    return i;
                }
            }
            return 0;
        }

        private IEnumerator DestroyLogLine(object[] parameters)
        {
            float lt = (float) parameters[0];
            Text logLine = (Text) parameters[1];
            int lineNum = (int) parameters[2];
            yield return new WaitForSeconds(lt);
            logLine.text = string.Empty;
            LogLineCoroutines[lineNum] = null;
        }
    }
}
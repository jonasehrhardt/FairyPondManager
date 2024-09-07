using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace DialogSystem.UI
{
    public class NodeDisplayer : MonoBehaviour
    {
        [SerializeField] private float _delayBetweenCharacters;        
        [SerializeField] private float _timeForChange;
        [SerializeField] private Vector2 _randomizationDelay;

        [SerializeField] private TextMeshProUGUI _textField;
        [SerializeField] private Transform _layoutTransform;        

        private List<Choice> _choices = new List<Choice>();
        [SerializeField] private Choice _buttonPrefab;

        private DialogNode _lastNode;
        public void DisplayNode(DialogNode node)
        {
            DestroyAllChoices();
            StopAllCoroutines();
            DisplayText(node);
        }

        public void DisplayText(DialogNode node)
        {
            _lastNode = node;
            _textField.text = string.Empty;
            StartCoroutine(PrintTextAndContinueDialogInLinearCase(node));
        }

        public void DestroyAllChoices()
        {
            foreach(var btn in _choices)
                Destroy(btn.gameObject);
            _choices.Clear();
        }

        public void TryToSkipNode() 
        {
            if (!_lastNode.IsLinear)
                return;

            StopCoroutine(nameof(PrintTextAndContinueDialogInLinearCase));

            if(!_lastNode.IsEnd)
                DisplayNode(_lastNode.nextNode);
        }

        private void CreateChoices(DialogNode node)
        {
            foreach(var choice in node.choices)
            {
                var btnChoice = Instantiate(_buttonPrefab, _layoutTransform);
                btnChoice.ApplyChoice(choice, this);
                _choices.Add(btnChoice);
            }
        }

        private IEnumerator PrintTextAndContinueDialogInLinearCase(DialogNode node)
        {
            foreach(var symbol in node.text)
            {
                yield return new WaitForSeconds(_delayBetweenCharacters + Random.Range(_randomizationDelay.x, _randomizationDelay.y));
                _textField.text += symbol;
            }

            StartCoroutine(CreateChoicesOrContinueDialog(node));
        }

        private IEnumerator CreateChoicesOrContinueDialog(DialogNode node)
        {
            yield return new WaitForSeconds(_timeForChange);
            DialogEventHandler.PlayEvents(node.events);
            if (node.IsLinear)
                DisplayNode(node.nextNode);
            else
                CreateChoices(node);
        }
    }
}

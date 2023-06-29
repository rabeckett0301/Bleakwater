using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IDialogueManager
    {
        public void Draw(string Title, string Class, string Location);

        //writing should open, clear, and display the new text for the dialogue box.
        public void Write(string text);

        public void DisplayOption(string text, Action option);

        public void Close();

        public void SubscribeOnOpen();
        public void SubscribeOnClose();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IDialogueManager
    {
        //writing should open, clear, and display the new text for the dialogue box.
        public void Write(string text);

        public void DisplayOption(string text);

        public void Close();
    }
}
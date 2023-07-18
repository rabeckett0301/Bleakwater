using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Bleakwater
{
    public interface IDialogueManager
    {
        public void Draw_NPC(string Title, string Class, string Location, Sprite Portrait);

        public void Draw_Event(string Title, Sprite Portrait, string Description, string Effect);

        public void Draw_Item(string Title, Sprite Portrait, string Description, string Effect);

        public void Draw_Pickup();

        //writing should open, clear, and display the new text for the dialogue box.
        public void Write(string text);

        public void DisplayOption(string text, Action option);

        public void Close_NPC();

        public void Close_Event();

        public void SubscribeOnOpen();
        public void SubscribeOnClose();
    }
}
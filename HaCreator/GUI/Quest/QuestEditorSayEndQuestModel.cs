﻿/*Copyright(c) 2024, LastBattle https://github.com/lastbattle/Harepacker-resurrected

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaCreator.GUI.Quest
{
    public class QuestEditorSayEndQuestModel : INotifyPropertyChanged
    {
        public QuestEditorStopConversationType _questEditorConversationType;

        private ObservableCollection<QuestEditorSayResponseModel> _responses = new ObservableCollection<QuestEditorSayResponseModel>();

        /// <summary>
        /// Constructor
        /// </summary>
        public QuestEditorSayEndQuestModel()
        {

        }

        public QuestEditorStopConversationType ConversationType
        {
            get => _questEditorConversationType;
            set
            {
                if (_questEditorConversationType != value)
                {
                    _questEditorConversationType = value;
                    OnPropertyChanged(nameof(ConversationType));
                }
            }
        }

        /// <summary>
        /// If the user selects yes, this defines what the NPC would say next
        /// </summary>
        public ObservableCollection<QuestEditorSayResponseModel> Responses
        {
            get => _responses;
            set
            {
                _responses = value;
                OnPropertyChanged(nameof(Responses));
            }
        }


        #region Property Changed Event
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

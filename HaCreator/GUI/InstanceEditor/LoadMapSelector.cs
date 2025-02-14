﻿/* Copyright (C) 2020 lastbattle

* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using System;
using System.Windows.Forms;

namespace HaCreator.GUI.InstanceEditor
{
    public partial class LoadMapSelector : System.Windows.Forms.Form
    {
        /// <summary>
        /// The NumericUpDown text to set upon selection
        /// </summary>
        private NumericUpDown numericUpDown = null;

        /// <summary>
        /// Or the textbox
        /// </summary>
        private TextBox textBox = null;

        /// <summary>
        /// Constructor for no NumericUpDown or TextBox
        /// </summary>
        public LoadMapSelector()
        {
            InitializeComponent();

            this.FormClosing += LoadQuestSelector_FormClosing;
            this.KeyDown += Load_KeyDown;

            DialogResult = DialogResult.Cancel;

            this.searchBox.TextChanged += this.mapBrowser.Search.TextChanged;
        }

        /// <summary>
        /// Load map selector for NumericUpDown
        /// </summary>
        /// <param name="numericUpDown"></param>
        public LoadMapSelector(NumericUpDown numericUpDown)
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            
            this.numericUpDown = numericUpDown;

            this.searchBox.TextChanged += this.mapBrowser.Search.TextChanged;
        }

        /// <summary>
        /// Load map selector for TextBox
        /// </summary>
        /// <param name="textbox"></param>
        public LoadMapSelector(TextBox textbox) {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            this.textBox = textbox;
            this.searchBox.TextChanged += this.mapBrowser.Search.TextChanged;
        }

        /// <summary>
        /// On load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Load(object sender, EventArgs e)
        {
            this.mapBrowser.InitializeMapsListboxItem(false); // load list of maps without Cash Shop, Login, etc
        }

        /// <summary>
        /// On load button clicked, selects that map and closes this dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadButton_Click(object sender, EventArgs e)
        {
            if (mapBrowser.SelectedItem == null)
                return;

            string mapid = mapBrowser.SelectedItem.Substring(0, 9);
            string mapcat = "Map" + mapid.Substring(0, 1);

            if (numericUpDown != null) {
                this.numericUpDown.Value = long.Parse(mapid);
            } else if (textBox != null) {
                this.textBox.Text = mapid;
            }
            // set selected map
            SelectedMap = mapid;

            DialogResult = DialogResult.OK;
            _bNotUserClosing = true;
            Close();
        }

        private bool _bNotUserClosing = false;
        private string _selectedMap = string.Empty;
        public string SelectedMap
        {
            get { return _selectedMap; }
            set { this._selectedMap = value; }
        }

        private void mapBrowser_SelectionChanged()
        {
        }

        #region Window
        private void Load_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _selectedMap = string.Empty;
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                loadButton_Click(null, null);
            }
        }

        /// <summary>
        /// The form is being closed by the user (e.g., clicking the X button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadQuestSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_bNotUserClosing)
            {
                _selectedMap = string.Empty;
            }
        }
        #endregion
    }
}

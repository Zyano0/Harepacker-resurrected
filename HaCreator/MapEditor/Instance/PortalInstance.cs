﻿/* Copyright (C) 2015 haha01haha01

* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using HaCreator.MapEditor.Info;
using MapleLib.WzLib.WzStructure;
using MapleLib.WzLib.WzStructure.Data;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNA = Microsoft.Xna.Framework;

namespace HaCreator.MapEditor.Instance
{
    public class PortalInstance : BoardItem, ISerializable
    {
        private PortalInfo baseInfo;
        private string _pn;
        private PortalType _pt;
        private string _tn;
        private int _tm;
        private string _script;
        private int? _delay;
        private MapleBool _hideTooltip;
        private MapleBool _onlyOnce;
        private int? _horizontalImpact;
        private int? _verticalImpact;
        private string _image;
        private int? _hRange;
        private int? _vRange;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseInfo"></param>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="pn">Portal name</param>
        /// <param name="pt">Portal type</param>
        /// <param name="tn">Target name</param>
        /// <param name="tm">To map</param>
        /// <param name="script"></param>
        /// <param name="delay"></param>
        /// <param name="hideTooltip"></param>
        /// <param name="onlyOnce"></param>
        /// <param name="horizontalImpact"></param>
        /// <param name="verticalImpact"></param>
        /// <param name="image"></param>
        /// <param name="hRange"></param>
        /// <param name="vRange"></param>
        public PortalInstance(PortalInfo baseInfo, Board board, int x, int y, string pn, PortalType pt, string tn, int tm, string script, int? delay, MapleBool hideTooltip, MapleBool onlyOnce, int? horizontalImpact, int? verticalImpact, string image, int? hRange, int? vRange)
            : base(board, x, y, -1)
        {
            this.baseInfo = baseInfo;
            this._pn = pn;
            this._pt = pt;
            this._tn = tn;
            this._tm = tm;
            this._script = script;
            this._delay = delay;
            this._hideTooltip = hideTooltip;
            this._onlyOnce = onlyOnce;
            this._horizontalImpact = horizontalImpact;
            this._verticalImpact = verticalImpact;
            this._image = image;
            this._hRange = hRange;
            this._vRange = vRange;
        }

        public override void Draw(SpriteBatch sprite, XNA.Color color, int xShift, int yShift)
        {
            XNA.Rectangle destinationRectangle = new XNA.Rectangle((int)X + xShift - Origin.X, (int)Y + yShift - Origin.Y, Width, Height);
            sprite.Draw(baseInfo.GetTexture(sprite), destinationRectangle, 
                null, 
                color, 
                0f, 
                new XNA.Vector2(0f, 0f), 
                SpriteEffects.None, 
                1f);
            base.Draw(sprite, color, xShift, yShift);
        }

        public override MapleDrawableInfo BaseInfo
        {
            get { return baseInfo; }
        }

        public override ItemTypes Type
        {
            get { return ItemTypes.Portals; }
        }

        public override System.Drawing.Bitmap Image
        {
            get
            {
                return baseInfo.Image;
            }
        }

        public override int Width
        {
            get { return baseInfo.Width; }
        }

        public override int Height
        {
            get { return baseInfo.Height; }
        }

        public override System.Drawing.Point Origin
        {
            get
            {
                return baseInfo.Origin;
            }
        }

        /// <summary>
        /// The image number in Map.wz/MapHelper.img/portal/game/(portal type)/(image number)
        /// </summary>
        public string image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string pn
        {
            get
            {
                return _pn;
            }
            set
            {
                _pn = value;
            }
        }

        /// <summary>
        /// The portal type
        /// </summary>
        public PortalType pt
        {
            get
            {
                return _pt;
            }
            set
            {
                _pt = value;
                baseInfo = PortalInfo.GetPortalInfoByType(value);
            }
        }


        public string tn
        {
            get
            {
                return _tn;
            }
            set
            {
                _tn = value;
            }
        }

        /// <summary>
        /// To map
        /// </summary>
        public int tm
        {
            get
            {
                return _tm;
            }
            set
            {
                _tm = value;
            }
        }

        /// <summary>
        /// Portal script
        /// </summary>
        public string script
        {
            get
            {
                return _script;
            }
            set
            {
                _script = value;
            }
        }

        public int? delay
        {
            get
            {
                return _delay;
            }
            set
            {
                _delay = value;
            }
        }

        public MapleBool hideTooltip
        {
            get
            {
                return _hideTooltip;
            }
            set
            {
                _hideTooltip = value;
            }
        }

        public MapleBool onlyOnce
        {
            get
            {
                return _onlyOnce;
            }
            set
            {
                _onlyOnce = value;
            }
        }

        public int? horizontalImpact
        {
            get
            {
                return _horizontalImpact;
            }
            set
            {
                _horizontalImpact = value;
            }
        }

        public int? verticalImpact
        {
            get
            {
                return _verticalImpact;
            }
            set
            {
                _verticalImpact = value;
            }
        }

        public int? hRange
        {
            get { return _hRange; }
            set { _hRange = value; }
        }

        public int? vRange
        {
            get { return _vRange; }
            set { _vRange = value; }
        }

        public new class SerializationForm : BoardItem.SerializationForm
        {
            public string pn, pt, tn;
            public int tm;
            public string script;
            public int? delay;
            public MapleBool hidett, onlyonce;
            public int? himpact, vimpact;
            public string image;
            public int? hrange, vrange;
        }

        public override object Serialize()
        {
            SerializationForm result = new SerializationForm();
            UpdateSerializedForm(result);
            return result;
        }

        protected void UpdateSerializedForm(SerializationForm result)
        {
            base.UpdateSerializedForm(result);
            result.pn = _pn;
            result.pt = _pt.ToCode();
            result.tn = _tn;
            result.tm = _tm;
            result.script = _script;
            result.delay = _delay;
            result.hidett = _hideTooltip;
            result.onlyonce = _onlyOnce;
            result.himpact = _horizontalImpact;
            result.vimpact = _verticalImpact;
            result.image = _image;
            result.hrange = _hRange;
            result.vrange = _vRange;
        }

        public PortalInstance(Board board, SerializationForm json)
            : base(board, json)
        {
            _pn = json.pn;
            _pt = PortalTypeExtensions.FromCode(json.pt);
            _tn = json.tn;
            _tm = json.tm;
            _script = json.script;
            _delay = json.delay;
            _hideTooltip = json.hidett;
            _onlyOnce = json.onlyonce;
            _horizontalImpact = json.himpact;
            _verticalImpact = json.vimpact;
            _image = json.image;
            _hRange = json.hrange;
            _vRange = json.vrange;
            baseInfo = PortalInfo.GetPortalInfoByType(pt);
        }
    }
}

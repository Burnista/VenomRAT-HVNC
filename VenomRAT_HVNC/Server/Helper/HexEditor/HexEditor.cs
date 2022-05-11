using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VenomRAT_HVNC.Server.Helper.HexEditor
{
    public class HexEditor : Control
    {
        public override Font Font
        {
            set
            {
                base.Font = value;
                this.UpdateRectanglePositioning();
                base.Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte[] HexTable
        {
            get
            {
                object hexTableLock = this._hexTableLock;
                byte[] result;
                lock (hexTableLock)
                {
                    result = this._hexTable.ToArray();
                }
                return result;
            }
            set
            {
                object hexTableLock = this._hexTableLock;
                lock (hexTableLock)
                {
                    if (value == this._hexTable.ToArray())
                    {
                        return;
                    }
                    this._hexTable = new ByteCollection(value);
                }
                this.UpdateRectanglePositioning();
                base.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SizeF CharSize
        {
            get
            {
                return this._charSize;
            }
            private set
            {
                if (this._charSize == value)
                {
                    return;
                }
                this._charSize = value;
                if (this.CharSizeChanged != null)
                {
                    this.CharSizeChanged(this, EventArgs.Empty);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int MaxBytesV
        {
            get
            {
                return this._maxBytesV;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int FirstVisibleByte
        {
            get
            {
                return this._firstByte;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int LastVisibleByte
        {
            get
            {
                return this._lastByte;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool VScrollBarHidden
        {
            get
            {
                return this._isVScrollHidden;
            }
            set
            {
                if (this._isVScrollHidden == value)
                {
                    return;
                }
                this._isVScrollHidden = value;
                if (!this._isVScrollHidden)
                {
                    base.Controls.Add(this._vScrollBar);
                }
                else
                {
                    base.Controls.Remove(this._vScrollBar);
                }
                this.UpdateRectanglePositioning();
                base.Invalidate();
            }
        }

        [DefaultValue(8)]
        [Category("Hex")]
        [Description("Property that specifies the number of bytes to display per line.")]
        public int BytesPerLine
        {
            get
            {
                return this._bytesPerLine;
            }
            set
            {
                if (this._bytesPerLine == value)
                {
                    return;
                }
                this._bytesPerLine = value;
                this.UpdateRectanglePositioning();
                base.Invalidate();
            }
        }

        [DefaultValue(10)]
        [Category("Hex")]
        [Description("Property that specifies the margin between each of the entitys in the control.")]
        public int EntityMargin
        {
            get
            {
                return this._entityMargin;
            }
            set
            {
                if (this._entityMargin == value)
                {
                    return;
                }
                this._entityMargin = value;
                this.UpdateRectanglePositioning();
                base.Invalidate();
            }
        }

        [DefaultValue(BorderStyle.Fixed3D)]
        [Category("Appearance")]
        [Description("Indicates where the control should have a border.")]
        public BorderStyle BorderStyle
        {
            get
            {
                return this._borderStyle;
            }
            set
            {
                if (this._borderStyle == value)
                {
                    return;
                }
                if (value != BorderStyle.FixedSingle)
                {
                    this._borderColor = Color.Empty;
                }
                this._borderStyle = value;
                this.UpdateRectanglePositioning();
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Empty")]
        [Category("Appearance")]
        [Description("Indicates the color to be used when displaying a FixedSingle border.")]
        public Color BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                if (this.BorderStyle != BorderStyle.FixedSingle || this._borderColor == value)
                {
                    return;
                }
                this._borderColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "Blue")]
        [Category("Hex")]
        [Description("Property for the background color of the selected text areas.")]
        public Color SelectionBackColor
        {
            get
            {
                return this._selectionBackColor;
            }
            set
            {
                if (this._selectionBackColor == value)
                {
                    return;
                }
                this._selectionBackColor = value;
            }
        }

        [DefaultValue(typeof(Color), "White")]
        [Category("Hex")]
        [Description("Property for the foreground color of the selected text areas.")]
        public Color SelectionForeColor
        {
            get
            {
                return this._selectionForeColor;
            }
            set
            {
                if (this._selectionForeColor == value)
                {
                    return;
                }
                this._selectionForeColor = value;
            }
        }

        [DefaultValue(HexEditor.CaseStyle.UpperCase)]
        [Category("Hex")]
        [Description("Property for the case type to use on the line counter.")]
        public HexEditor.CaseStyle LineCountCaseStyle
        {
            get
            {
                return this._lineCountCaseStyle;
            }
            set
            {
                if (this._lineCountCaseStyle == value)
                {
                    return;
                }
                this._lineCountCaseStyle = value;
                if (this._lineCountCaseStyle == HexEditor.CaseStyle.LowerCase)
                {
                    this._lineCountCaps = "x";
                }
                else
                {
                    this._lineCountCaps = "X";
                }
                base.Invalidate();
            }
        }

        [DefaultValue(HexEditor.CaseStyle.UpperCase)]
        [Category("Hex")]
        [Description("Property for the case type to use for the hexadecimal values view.")]
        public HexEditor.CaseStyle HexViewCaseStyle
        {
            get
            {
                return this._hexViewCaseStyle;
            }
            set
            {
                if (this._hexViewCaseStyle == value)
                {
                    return;
                }
                this._hexViewCaseStyle = value;
                if (this._hexViewCaseStyle == HexEditor.CaseStyle.LowerCase)
                {
                    this._editView.SetLowerCase();
                }
                else
                {
                    this._editView.SetUpperCase();
                }
                base.Invalidate();
            }
        }

        [DefaultValue(false)]
        [Category("Hex")]
        [Description("Property for the visibility of the vertical scrollbar.")]
        public bool VScrollBarVisisble
        {
            get
            {
                return this._isVScrollVisible;
            }
            set
            {
                if (this._isVScrollVisible == value)
                {
                    return;
                }
                this._isVScrollVisible = value;
                this.UpdateRectanglePositioning();
                base.Invalidate();
            }
        }

        [Description("Event that is triggered whenever the hextable has been changed.")]
        public event EventHandler HexTableChanged;

        [Description("Event that is triggered whenever the SelectionStart value is changed.")]
        public event EventHandler SelectionStartChanged;

        [Description("Event that is triggered whenever the SelectionLength value is changed.")]
        public event EventHandler SelectionLengthChanged;

        [Description("Event that is triggered whenever the size of the char is changed.")]
        public event EventHandler CharSizeChanged;

        protected void OnVScrollBarScroll(object sender, ScrollEventArgs e)
        {
            switch (e.Type)
            {
                case ScrollEventType.SmallDecrement:
                    this.ScrollLineUp(1);
                    break;

                case ScrollEventType.SmallIncrement:
                    this.ScrollLineDown(1);
                    break;

                case ScrollEventType.LargeDecrement:
                    this.ScrollLineUp(this._vScrollLarge);
                    break;

                case ScrollEventType.LargeIncrement:
                    this.ScrollLineDown(this._vScrollLarge);
                    break;

                case ScrollEventType.ThumbTrack:
                    this.ScrollThumbTrack(e.NewValue - e.OldValue);
                    break;
            }
            base.Invalidate();
        }

        protected void CaretSelectionStartChanged(object sender, EventArgs e)
        {
            if (this.SelectionStartChanged != null)
            {
                this.SelectionStartChanged(this, e);
            }
        }

        protected void CaretSelectionLengthChanged(object sender, EventArgs e)
        {
            if (this.SelectionLengthChanged != null)
            {
                this.SelectionLengthChanged(this, e);
            }
        }

        protected override void OnMarginChanged(EventArgs e)
        {
            base.OnMarginChanged(e);
            this.UpdateRectanglePositioning();
            base.Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (this._handler != null)
            {
                this._handler.OnGotFocus(e);
            }
            this.UpdateRectanglePositioning();
            base.Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this._dragging = false;
            this.DestroyCaret();
            base.OnLostFocus(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            return keyData - Keys.Left <= 3 || keyData - (Keys.LButton | Keys.MButton | Keys.Space | Keys.Shift) <= 3 || base.IsInputKey(keyData);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (this._handler != null)
            {
                this._handler.OnKeyPress(e);
            }
            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Next)
            {
                if (!this._isVScrollHidden)
                {
                    this.ScrollLineDown(this._vScrollLarge);
                    base.Invalidate();
                }
            }
            else if (e.KeyCode == Keys.Prior)
            {
                if (!this._isVScrollHidden)
                {
                    this.ScrollLineUp(this._vScrollLarge);
                    base.Invalidate();
                }
            }
            else if (this._handler != null)
            {
                this._handler.OnKeyDown(e);
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (this._handler != null)
            {
                this._handler.OnKeyUp(e);
            }
            base.OnKeyUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Focused)
            {
                if (this._handler != null)
                {
                    this._handler.OnMouseDown(e);
                }
                if (e.Button == MouseButtons.Left)
                {
                    this._dragging = true;
                    base.Invalidate();
                }
            }
            else
            {
                base.Focus();
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.Focused && this._dragging)
            {
                if (this._handler != null)
                {
                    this._handler.OnMouseDragged(e);
                }
                base.Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this._dragging = false;
            if (this.Focused && this._handler != null)
            {
                this._handler.OnMouseUp(e);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (this.Focused && this._handler != null)
            {
                this._handler.OnMouseDoubleClick(e);
            }
            base.OnMouseDoubleClick(e);
        }

        public int CaretPosX
        {
            get
            {
                object caretLock = this._caretLock;
                int x;
                lock (caretLock)
                {
                    x = this._caret.Location.X;
                }
                return x;
            }
        }

        public int CaretPosY
        {
            get
            {
                object caretLock = this._caretLock;
                int y;
                lock (caretLock)
                {
                    y = this._caret.Location.Y;
                }
                return y;
            }
        }

        public int SelectionStart
        {
            get
            {
                object caretLock = this._caretLock;
                int selectionStart;
                lock (caretLock)
                {
                    selectionStart = this._caret.SelectionStart;
                }
                return selectionStart;
            }
        }

        public int SelectionLength
        {
            get
            {
                object caretLock = this._caretLock;
                int selectionLength;
                lock (caretLock)
                {
                    selectionLength = this._caret.SelectionLength;
                }
                return selectionLength;
            }
        }

        public int CaretIndex
        {
            get
            {
                object caretLock = this._caretLock;
                int currentIndex;
                lock (caretLock)
                {
                    currentIndex = this._caret.CurrentIndex;
                }
                return currentIndex;
            }
        }

        public bool CaretFocused
        {
            get
            {
                object caretLock = this._caretLock;
                bool focused;
                lock (caretLock)
                {
                    focused = this._caret.Focused;
                }
                return focused;
            }
        }

        public void SetCaretStart(int index, Point location)
        {
            location = this.ScrollToCaret(index, location);
            object caretLock = this._caretLock;
            lock (caretLock)
            {
                this._caret.SetStartIndex(index);
                this._caret.SetCaretLocation(location);
            }
            base.Invalidate();
        }

        public void SetCaretEnd(int index, Point location)
        {
            location = this.ScrollToCaret(index, location);
            object caretLock = this._caretLock;
            lock (caretLock)
            {
                this._caret.SetEndIndex(index);
                this._caret.SetCaretLocation(location);
            }
            base.Invalidate();
        }

        public bool IsSelected(int byteIndex)
        {
            object caretLock = this._caretLock;
            bool result;
            lock (caretLock)
            {
                result = this._caret.IsSelected(byteIndex);
            }
            return result;
        }

        public void DestroyCaret()
        {
            object caretLock = this._caretLock;
            lock (caretLock)
            {
                this._caret.Destroy();
            }
        }

        public int HexTableLength
        {
            get
            {
                object hexTableLock = this._hexTableLock;
                int length;
                lock (hexTableLock)
                {
                    length = this._hexTable.Length;
                }
                return length;
            }
        }

        public void RemoveSelectedBytes()
        {
            int selectionStart = this.SelectionStart;
            int selectionLength = this.SelectionLength;
            if (selectionLength > 0)
            {
                object hexTableLock = this._hexTableLock;
                lock (hexTableLock)
                {
                    this._hexTable.RemoveRange(selectionStart, selectionLength);
                }
                this.UpdateRectanglePositioning();
                base.Invalidate();
                if (this.HexTableChanged != null)
                {
                    this.HexTableChanged(this, EventArgs.Empty);
                }
            }
        }

        public void RemoveByteAt(int index)
        {
            object hexTableLock = this._hexTableLock;
            lock (hexTableLock)
            {
                this._hexTable.RemoveAt(index);
            }
            this.UpdateRectanglePositioning();
            base.Invalidate();
            if (this.HexTableChanged != null)
            {
                this.HexTableChanged(this, EventArgs.Empty);
            }
        }

        public void AppendByte(byte item)
        {
            object hexTableLock = this._hexTableLock;
            lock (hexTableLock)
            {
                this._hexTable.Add(item);
            }
            this.UpdateRectanglePositioning();
            base.Invalidate();
            if (this.HexTableChanged != null)
            {
                this.HexTableChanged(this, EventArgs.Empty);
            }
        }

        public void InsertByte(int index, byte item)
        {
            object hexTableLock = this._hexTableLock;
            lock (hexTableLock)
            {
                this._hexTable.Insert(index, item);
            }
            this.UpdateRectanglePositioning();
            base.Invalidate();
            if (this.HexTableChanged != null)
            {
                this.HexTableChanged(this, EventArgs.Empty);
            }
        }

        public char GetByteAsChar(int index)
        {
            object hexTableLock = this._hexTableLock;
            char charAt;
            lock (hexTableLock)
            {
                charAt = this._hexTable.GetCharAt(index);
            }
            return charAt;
        }

        public byte GetByte(int index)
        {
            object hexTableLock = this._hexTableLock;
            byte at;
            lock (hexTableLock)
            {
                at = this._hexTable.GetAt(index);
            }
            return at;
        }

        public void SetByte(int index, byte item)
        {
            object hexTableLock = this._hexTableLock;
            lock (hexTableLock)
            {
                this._hexTable.SetAt(index, item);
            }
            base.Invalidate();
            if (this.HexTableChanged != null)
            {
                this.HexTableChanged(this, EventArgs.Empty);
            }
        }

        public void ScrollLineUp(int lines)
        {
            if (this._firstByte > 0)
            {
                lines = ((lines > this._vScrollPos) ? this._vScrollPos : lines);
                this._vScrollPos -= this._vScrollSmall * lines;
                this.UpdateVisibleByteIndex();
                this.UpdateScrollValues();
                if (this.CaretFocused)
                {
                    Point caretLocation = new Point(this.CaretPosX, this.CaretPosY);
                    caretLocation.Y += this._recLineCount.Height * lines;
                    object caretLock = this._caretLock;
                    lock (caretLock)
                    {
                        this._caret.SetCaretLocation(caretLocation);
                    }
                }
            }
        }

        public void ScrollLineDown(int lines)
        {
            if (this._vScrollPos <= this._vScrollMax - this._vScrollLarge)
            {
                lines = ((lines + this._vScrollPos > this._vScrollMax - this._vScrollLarge) ? (this._vScrollMax - this._vScrollLarge - this._vScrollPos + 1) : lines);
                this._vScrollPos += this._vScrollSmall * lines;
                this.UpdateVisibleByteIndex();
                this.UpdateScrollValues();
                if (this.CaretFocused)
                {
                    Point caretLocation = new Point(this.CaretPosX, this.CaretPosY);
                    caretLocation.Y -= this._recLineCount.Height * lines;
                    object caretLock = this._caretLock;
                    lock (caretLock)
                    {
                        this._caret.SetCaretLocation(caretLocation);
                        if (caretLocation.Y < this._recContent.Y)
                        {
                            this._caret.Hide(base.Handle);
                        }
                    }
                }
            }
        }

        public void ScrollThumbTrack(int lines)
        {
            if (lines == 0)
            {
                return;
            }
            if (lines < 0)
            {
                this.ScrollLineUp(-1 * lines);
                return;
            }
            this.ScrollLineDown(lines);
        }

        public Point ScrollToCaret(int caretIndex, Point position)
        {
            if (position.Y < 0)
            {
                this._vScrollPos -= Math.Abs((position.Y - this._recContent.Y) / this._recLineCount.Height) * this._vScrollSmall;
                this.UpdateVisibleByteIndex();
                this.UpdateScrollValues();
                if (this.CaretFocused)
                {
                    position.Y = this._recContent.Y;
                }
            }
            else if (position.Y > this._maxVisibleBytesV * this._recLineCount.Height)
            {
                this._vScrollPos += (position.Y / this._recLineCount.Height - (this._maxVisibleBytesV - 1)) * this._vScrollSmall;
                if (this._vScrollPos > this._vScrollMax - (this._vScrollLarge - 1))
                {
                    this._vScrollPos = this._vScrollMax - (this._vScrollLarge - 1);
                }
                this.UpdateVisibleByteIndex();
                this.UpdateScrollValues();
                if (this.CaretFocused)
                {
                    position.Y = (this._maxVisibleBytesV - 1) * this._recLineCount.Height + this._recContent.Y;
                }
            }
            return position;
        }

        private void UpdateRectanglePositioning()
        {
            if (base.ClientRectangle.Width == 0)
            {
                return;
            }
            SizeF sizeF;
            using (Graphics graphics = base.CreateGraphics())
            {
                sizeF = graphics.MeasureString("D", this.Font, 100, this._stringFormat);
            }
            this.CharSize = new SizeF((float)Math.Ceiling((double)sizeF.Width), (float)Math.Ceiling((double)sizeF.Height));
            this._recContent = base.ClientRectangle;
            this._recContent.X = this._recContent.X + base.Margin.Left;
            this._recContent.Y = this._recContent.Y + base.Margin.Top;
            this._recContent.Width = this._recContent.Width - base.Margin.Right;
            this._recContent.Height = this._recContent.Height - base.Margin.Bottom;
            if (this.BorderStyle == BorderStyle.Fixed3D)
            {
                this._recContent.X = this._recContent.X + 2;
                this._recContent.Y = this._recContent.Y + 2;
                this._recContent.Width = this._recContent.Width - 1;
                this._recContent.Height = this._recContent.Height - 1;
            }
            else if (this.BorderStyle == BorderStyle.FixedSingle)
            {
                this._recContent.X = this._recContent.X + 1;
                this._recContent.Y = this._recContent.Y + 1;
                this._recContent.Width = this._recContent.Width - 1;
                this._recContent.Height = this._recContent.Height - 1;
            }
            if (!this.VScrollBarHidden)
            {
                this._recContent.Width = this._recContent.Width - this._vScrollBarWidth;
                this._vScrollBar.Left = this._recContent.X + this._recContent.Width - base.Margin.Left;
                this._vScrollBar.Top = this._recContent.Y - base.Margin.Top;
                this._vScrollBar.Width = this._vScrollBarWidth;
                this._vScrollBar.Height = this._recContent.Height;
            }
            this._recLineCount = new Rectangle(this._recContent.X, this._recContent.Y, (int)(this._charSize.Width * 4f), (int)this._charSize.Height - 2);
            this._editView.Update(this._recLineCount.X + this._recLineCount.Width + this._entityMargin / 2, this._recContent);
            this._maxBytesH = this._bytesPerLine;
            this._maxBytesV = (int)Math.Ceiling((double)((float)this._recContent.Height / (float)this._recLineCount.Height));
            this._maxBytes = this._maxBytesH * this._maxBytesV;
            this._maxVisibleBytesV = (int)Math.Floor((double)((float)this._recContent.Height / (float)this._recLineCount.Height));
            this.UpdateScrollBarSize();
        }

        private void UpdateVisibleByteIndex()
        {
            if (this._hexTable.Length == 0)
            {
                this._firstByte = 0;
                this._lastByte = 0;
                return;
            }
            this._firstByte = this._vScrollPos * this._maxBytesH;
            this._lastByte = Math.Min(this.HexTableLength, this._firstByte + this._maxBytes);
        }

        private void UpdateScrollValues()
        {
            if (!this._isVScrollHidden)
            {
                this._vScrollBar.Minimum = this._vScrollMin;
                this._vScrollBar.Maximum = this._vScrollMax;
                this._vScrollBar.Value = this._vScrollPos;
                this._vScrollBar.SmallChange = this._vScrollSmall;
                this._vScrollBar.LargeChange = this._vScrollLarge;
                this._vScrollBar.Visible = true;
                return;
            }
            this._vScrollBar.Visible = false;
        }

        private void UpdateScrollBarSize()
        {
            if (!this.VScrollBarVisisble || this._maxVisibleBytesV <= 0 || this._maxBytesH <= 0)
            {
                this.VScrollBarHidden = true;
                return;
            }
            int maxVisibleBytesV = this._maxVisibleBytesV;
            int num = 1;
            int vScrollMin = 0;
            int num2 = this.HexTableLength / this._maxBytesH;
            int num3 = this._firstByte / this._maxBytesH;
            if (maxVisibleBytesV != this._vScrollLarge || num != this._vScrollSmall)
            {
                this._vScrollLarge = maxVisibleBytesV;
                this._vScrollSmall = num;
            }
            if (num2 >= maxVisibleBytesV)
            {
                if (num2 != this._vScrollMax || num3 != this._vScrollPos)
                {
                    this._vScrollMin = vScrollMin;
                    this._vScrollMax = num2;
                    this._vScrollPos = num3;
                }
                this.VScrollBarHidden = false;
                this.UpdateScrollValues();
                return;
            }
            this.VScrollBarHidden = true;
        }

        public HexEditor()
            : this(new ByteCollection())
        {
        }

        public HexEditor(ByteCollection collection)
        {
            this._stringFormat = new StringFormat(StringFormat.GenericTypographic);
            this._stringFormat.Alignment = StringAlignment.Center;
            this._stringFormat.LineAlignment = StringAlignment.Center;
            this._hexTable = collection;
            this._vScrollBar = new VScrollBar();
            this._vScrollBar.Scroll += this.OnVScrollBarScroll;
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            base.SetStyle(ControlStyles.Selectable, true);
            this._caret = new Caret(this);
            this._caret.SelectionStartChanged += this.CaretSelectionStartChanged;
            this._caret.SelectionLengthChanged += this.CaretSelectionLengthChanged;
            this._editView = new EditView(this);
            this._handler = this._editView;
            this.Cursor = Cursors.IBeam;
        }

        private RectangleF GetLineCountBound(int index)
        {
            RectangleF result = new RectangleF((float)this._recLineCount.X, (float)(this._recLineCount.Y + this._recLineCount.Height * index), (float)this._recLineCount.Width, (float)this._recLineCount.Height);
            return result;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (this.BorderStyle == BorderStyle.Fixed3D)
            {
                SolidBrush brush = new SolidBrush(this.BackColor);
                Rectangle clientRectangle = base.ClientRectangle;
                pevent.Graphics.FillRectangle(brush, clientRectangle);
                ControlPaint.DrawBorder3D(pevent.Graphics, base.ClientRectangle, Border3DStyle.Sunken);
                return;
            }
            if (this.BorderStyle == BorderStyle.FixedSingle)
            {
                SolidBrush brush2 = new SolidBrush(this.BackColor);
                Rectangle clientRectangle2 = base.ClientRectangle;
                pevent.Graphics.FillRectangle(brush2, clientRectangle2);
                ControlPaint.DrawBorder(pevent.Graphics, base.ClientRectangle, this.BorderColor, ButtonBorderStyle.Solid);
                return;
            }
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Region region = new Region(base.ClientRectangle);
            region.Exclude(this._recContent);
            e.Graphics.ExcludeClip(region);
            this.UpdateVisibleByteIndex();
            this.PaintLineCount(e.Graphics, this._firstByte, this._lastByte);
            this._editView.Paint(e.Graphics, this._firstByte, this._lastByte);
        }

        private void PaintLineCount(Graphics g, int startIndex, int lastIndex)
        {
            SolidBrush brush = new SolidBrush(this.ForeColor);
            int num = 0;
            while (num * this._maxBytesH + startIndex <= lastIndex)
            {
                RectangleF lineCountBound = this.GetLineCountBound(num);
                string text = (startIndex + num * this._maxBytesH).ToString(this._lineCountCaps);
                int num2 = this._nrCharsLineCount - text.Length;
                string s;
                if (num2 > -1)
                {
                    s = new string('0', num2) + text;
                }
                else
                {
                    s = new string('~', this._nrCharsLineCount);
                }
                g.DrawString(s, this.Font, brush, lineCountBound, this._stringFormat);
                num++;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.UpdateRectanglePositioning();
            base.Invalidate();
        }

        private object _caretLock = new object();

        private object _hexTableLock = new object();

        private IKeyMouseEventHandler _handler;

        private EditView _editView;

        private ByteCollection _hexTable;

        private string _lineCountCaps = "X";

        private int _nrCharsLineCount = 4;

        private Caret _caret;

        private Rectangle _recContent;

        private Rectangle _recLineCount;

        private StringFormat _stringFormat;

        private int _firstByte;

        private int _lastByte;

        private int _maxBytesH;

        private int _maxBytesV;

        private int _maxBytes;

        private int _maxVisibleBytesV;

        private VScrollBar _vScrollBar;

        private int _vScrollBarWidth = 20;

        private int _vScrollPos;

        private int _vScrollMax;

        private int _vScrollMin;

        private int _vScrollSmall;

        private int _vScrollLarge;

        private SizeF _charSize;

        private bool _isVScrollHidden = true;

        private int _bytesPerLine = 8;

        private int _entityMargin = 10;

        private BorderStyle _borderStyle = BorderStyle.Fixed3D;

        private Color _borderColor = Color.Empty;

        private Color _selectionBackColor = Color.Blue;

        private Color _selectionForeColor = Color.White;

        private HexEditor.CaseStyle _lineCountCaseStyle = HexEditor.CaseStyle.UpperCase;

        private HexEditor.CaseStyle _hexViewCaseStyle = HexEditor.CaseStyle.UpperCase;

        private bool _isVScrollVisible;

        private bool _dragging;

        public enum CaseStyle
        {
            LowerCase,

            UpperCase
        }
    }
}

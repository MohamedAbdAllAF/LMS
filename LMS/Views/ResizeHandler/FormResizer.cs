using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Views.ResizeHandler
{
    public class FormResizer
    {
        Dictionary<Control, Size> result = new Dictionary<Control, Size>();
        public Dictionary<Control, Size> GetControlSizes(Control control)
        {
            foreach (Control childControl in control.Controls)
            {
                result[childControl] = childControl.Size;

                GetControlSizes(childControl);
            }

            return result;
        }

        public Control ResizeComponents(Control control, Dictionary<Control, Size> originalSizes)
        {
            foreach (Control childControl in control.Controls)
            {
                Control originalControl = originalSizes.Keys.FirstOrDefault(c => c.Name == childControl.Name);

                if (originalControl != null)
                {
                    Size originalSize = originalSizes[originalControl];

                    float widthRatio = (float)childControl.Width / originalSize.Width;
                    float heightRatio = (float)childControl.Height / originalSize.Height;

                    // Recursively resize nested controls
                    ResizeComponents(childControl, originalSizes);

                    // Calculate new size based on the original size and current control size
                    int newWidth = (int)(originalSize.Width * widthRatio);
                    int newHeight = (int)(originalSize.Height * heightRatio);

                    // Resize
                    childControl.Size = new Size(newWidth, newHeight);

                    // Reposition
                    childControl.Left = (int)(childControl.Left * widthRatio);
                    childControl.Top = (int)(childControl.Top * heightRatio);
                }
                else
                {
                    // Recursively resize nested controls
                    ResizeComponents(childControl, originalSizes);
                }
            }

            return control;
        }
    }
}

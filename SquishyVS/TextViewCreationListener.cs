using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Outlining;
using Microsoft.VisualStudio.Utilities;

namespace SquishyVS
{
    [ContentType("csharp")]
    [Export(typeof(IWpfTextViewCreationListener))]
    [TextViewRole(PredefinedTextViewRoles.Editable)]
    internal sealed class TextViewCreationListener : IWpfTextViewCreationListener
    {
        IOutliningManager outliningManager;

        public void TextViewCreated(IWpfTextView textView)
        {
            outliningManager = OutliningManager.GetOutliningManager(textView);
            outliningManager.RegionsChanged += outliningManager_RegionsChanged;
        }

        void outliningManager_RegionsChanged(object sender, RegionsChangedEventArgs e)
        {
            foreach (ICollapsible collapsible in outliningManager.GetAllRegions(e.AffectedSpan))
            {
                if (!Regex.IsMatch(collapsible.Tag.CollapsedForm.ToString(), @"\s*\/\/\/"))
                    continue;

                var field = GetBackingFieldForAutoImplProp(collapsible.Tag, "CollapsedForm");
                field.SetValue(collapsible.Tag, "/// <summary> ...");
            }
        }

        FieldInfo GetBackingFieldForAutoImplProp(object instance, string propertyName)
        {
            var fieldName = $"<{propertyName}>k__BackingField";
            return instance.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
        }

        [Import]
        internal IOutliningManagerService OutliningManager { get; set; }
    }
}

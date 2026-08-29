using System;
using System.Collections.Generic;
using SoulArena.Core;
using SoulArena.Characters;
using SoulArena.Combat;

namespace SoulArena.Tools
{
    /// <summary>
    /// Developer & Production Tooling: FrameDataInspectorTool
    /// Purpose: Real-time frame advantage, blockstun, and startup comparison table for character balance
    /// </summary>
    public class FrameDataInspectorTool
    {
        public bool IsEditorOpen { get; set; } = false;
        public string ActiveTargetAssetId { get; set; } = "kael_varyn";
        private readonly List<string> _undoStack = new List<string>();

        public event Action<string> OnAssetDataModified;

        public void OpenToolWindow(string targetFighterId)
        {
            ActiveTargetAssetId = targetFighterId;
            IsEditorOpen = true;
            _undoStack.Clear();
        }

        public void ModifyParameter(string paramName, float newValue)
        {
            if (!IsEditorOpen) return;
            _undoStack.Add("Modified " + paramName + " to " + newValue);
            OnAssetDataModified?.Invoke(ActiveTargetAssetId);
        }

        public void UndoLastModification()
        {
            if (_undoStack.Count > 0)
            {
                _undoStack.RemoveAt(_undoStack.Count - 1);
            }
        }
    }
}

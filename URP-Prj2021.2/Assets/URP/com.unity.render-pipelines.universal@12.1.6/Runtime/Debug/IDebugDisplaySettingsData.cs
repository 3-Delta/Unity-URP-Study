namespace UnityEngine.Rendering.SelfUniversal
{
    public interface IDebugDisplaySettingsData : IDebugDisplaySettingsQuery
    {
        /// <summary>
        /// Creates the debug UI panel needed for these debug settings.
        /// </summary>
        /// <returns>The debug UI panel created.</returns>
        IDebugDisplaySettingsPanelDisposable CreatePanel();
    }
}

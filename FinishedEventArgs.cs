public class FinishedEventArgs : EventArgs
{
    public int SurahNumber { get; internal set; }
    public long EllapsedTime {get; internal set; }
    public string? FileFullPath { get; internal set; }
}

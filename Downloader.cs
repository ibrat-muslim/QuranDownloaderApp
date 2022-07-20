using System.Net;
using System.Diagnostics;
public class Downloader
{   
    private const string _baseUrl = "https://server7.mp3quran.net/s_gmd";
    
    private string _curPath = Directory.GetCurrentDirectory();

    public event EventHandler<DownloadingEventArgs>? OnDownloading;

    public event EventHandler<FinishedEventArgs>? OnFinished;

    public void Start(int surahNumber)
    {
        OnDownloading?.Invoke(this, new DownloadingEventArgs()
        {
            SurahNumber = surahNumber
        });
        Task.Run(() =>
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var fileFullPath = Path.Combine(_curPath,$"{surahNumber:D3}.mp3");
 
            WebClient mywebClient = new WebClient();

            mywebClient.DownloadFile($"{_baseUrl}/{surahNumber:D3}.mp3", $"{_curPath}/{surahNumber:D3}.mp3");

            OnFinished?.Invoke(this, new FinishedEventArgs()
            {
                EllapsedTime = stopwatch.ElapsedMilliseconds,
                SurahNumber = surahNumber,
                FileFullPath = fileFullPath
            });
        });
    }
}

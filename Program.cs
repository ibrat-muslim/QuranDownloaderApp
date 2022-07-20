    while(true)
    {
        Downloader d1 = new Downloader();

        d1.OnDownloading += Downloading;
        d1.OnFinished += Finished;

        Console.WriteLine($"Sura raqamini kiriting");
        int surahNum = int.Parse(Console.ReadLine());
        if (File.Exists($"/home/ibrat_muslim/Downloads/quran/{surahNum:D3}.mp3"))
        {
            Console.WriteLine($"Bu Sura avvaldan mavjud.");
        }
        else if (surahNum > 0 && surahNum < 115)
        {
            d1.Start(surahNum);
        }
        else 
        {
            Console.WriteLine("Raqam noto'g'ri kiritildi. Qaytadan kiriting.");
        }

        void Downloading(object? sender, DownloadingEventArgs e)
        {
            Console.WriteLine($"{e.SurahNumber} - Sura yuklanmoqda...");
        }

        void Finished(object? sender, FinishedEventArgs e)
        {
            Console.WriteLine($"{e.SurahNumber} - Sura yuklandi!");
            Console.WriteLine($"Sura {(double)e.EllapsedTime/1000}s da yuklandi");
            Console.WriteLine($"File Location: {e.FileFullPath}");
        }
    }    

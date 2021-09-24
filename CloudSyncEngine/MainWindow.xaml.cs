using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using Vanara.PInvoke.Tests;

namespace CloudSyncEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CldApi.CF_CONNECTION_KEY? key = null;

        public MainWindow()
        {
            InitializeComponent();
            var path = @"E:\tmp\sync2";
            var provider = new CloudSyncProvider(path, "Test");
            provider.FetchPlaceholders += ProviderOnFetchPlaceholders;
            provider.FetchData += ProviderOnFetchData;

            var fileName = @"E:\tmp\sync2\test.txt";
            File.Delete(fileName);
            provider.CreatePlaceholderFromFile(@"test.txt", new FileInfo(@"E:\tmp\sync\test.txt"));
            // var result = provider.CreatePlaceholders(new List<PlaceholderInfo>()
            // {
            //     new PlaceHolderDirectoryInfo()
            //     {
            //         RelativePath = "Test.txt",
            //         CreationTime = DateTime.Now,
            //         LastWriteTime = DateTime.Now,
            //         LastAccessTime = DateTime.Now,
            //         FileAttributes = FileAttributes.Normal,
            //     }
            // });

            using var hFile = GetHFILE(fileName);
            var result = CldApi.CfHydratePlaceholder(hFile);
        }
        
        private Kernel32.SafeHFILE GetHFILE(string path) => Kernel32.CreateFile(path, Kernel32.FileAccess.FILE_READ_ATTRIBUTES, FileShare.Read, null, FileMode.Open, 0);

        private void ProviderOnFetchData(object? sender, CloudSyncCallbackArgs<CldApi.CF_CALLBACK_PARAMETERS.FETCHDATA> e)
        {
            
        }

        private void ProviderOnFetchPlaceholders(object? sender, CloudSyncCallbackArgs<CldApi.CF_CALLBACK_PARAMETERS.FETCHPLACEHOLDERS> e)
        {
            
        }
    }
    
}
